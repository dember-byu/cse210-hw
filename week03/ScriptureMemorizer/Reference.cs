using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse; 
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }


    public Reference(string fullReferenceText)
    {

        int lastSpaceIndex = fullReferenceText.LastIndexOf(' ');
        _book = fullReferenceText.Substring(0, lastSpaceIndex).Trim();
        
        string numbersPart = fullReferenceText.Substring(lastSpaceIndex + 1);
        string[] chapterAndVerses = numbersPart.Split(':');
        
        _chapter = int.Parse(chapterAndVerses[0]);

        if (chapterAndVerses[1].Contains("-"))
        {
            string[] verses = chapterAndVerses[1].Split('-');
            _verse = int.Parse(verses[0]);
            _endVerse = int.Parse(verses[1]);
        }
        else
        {
            _verse = int.Parse(chapterAndVerses[1]);
            _endVerse = _verse;
        }
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
