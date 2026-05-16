using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("--- Digital Journal ---");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();

                    Console.Write("What emotion did you feel most today? ");
                    string emotion = Console.ReadLine();

                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToShortDateString(),
                        Prompt = prompt,
                        Response = response,
                        Emotion = emotion
                    };
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("File name: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("File name: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully.");
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Digital Journal. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
