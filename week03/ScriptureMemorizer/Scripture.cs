using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            if (!string.IsNullOrEmpty(wordText)) 
            {
                _words.Add(new Word(wordText));
            }
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0) return;

        int actualToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < actualToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}    {scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> library = new List<Scripture>();

        if (!File.Exists(filename))
        {
            return library;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;


            int textStartIndex = FindTextStartIndex(line);
            
            if (textStartIndex != -1)
            {
                string referencePart = line.Substring(0, textStartIndex).Trim();
                string textPart = line.Substring(textStartIndex).Trim();

                Reference reference = new Reference(referencePart);
                library.Add(new Scripture(reference, textPart));
            }
        }

        return library;
    }

    private static int FindTextStartIndex(string line)
    {

        int colonIndex = line.IndexOf(':');
        if (colonIndex == -1) return -1;


        int index = colonIndex + 1;
        while (index < line.Length && (char.IsDigit(line[index]) || line[index] == '-'))
        {
            index++;
        }

        while (index < line.Length && char.IsWhiteSpace(line[index]))
        {
            index++;
        }

        return index < line.Length ? index : -1;
    }
}
