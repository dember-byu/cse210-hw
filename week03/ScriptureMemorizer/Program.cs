using System;
using System.Collections.Generic;

// CREATIVITY REPORT:
// 1. Added a Scripture Library loaded directly from an external text file ("scriptures.txt").

class Program
{
    static void Main(string[] args)
    {
        string filename = "scriptures.txt";
        
        List<Scripture> scriptureLibrary = Scripture.LoadScripturesFromFile(filename);

        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine($"Warning: '{filename}' not found or empty. Loading default scripture...");
            scriptureLibrary.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ));
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];


        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Great job! You have hidden the entire scripture.");
                break;
            }

            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }

        Console.WriteLine("\nProgram finished. Goodbye!");
    }
}
