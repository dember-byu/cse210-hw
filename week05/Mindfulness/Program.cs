using System;

/*
1. NO-REPETITION LOGIC (ReflectionActivity): 
   
2. SESSION STATISTICS TRACKING LOG (Program):

*/

namespace MindfulnessApp
{
    class Program
    {
        
        private static int _breathingCount = 0;
        private static int _reflectionCount = 0;
        private static int _listingCount = 0;

        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflection activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. View session stats (Creativity Extra)");
                Console.WriteLine("  5. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run();
                        _breathingCount++;
                        break;
                    case "2":
                        ReflectionActivity reflection = new ReflectionActivity();
                        reflection.Run();
                        _reflectionCount++;
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        _listingCount++;
                        break;
                    case "4":
                        DisplayStats();
                        break;
                    case "5":
                        keepRunning = false;
                        Console.WriteLine("\nThank you for taking time for mindfulness today. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("=== Session Activity Log ===");
            Console.WriteLine($"Breathing Activities Completed: {_breathingCount}");
            Console.WriteLine($"Reflection Activities Completed: {_reflectionCount}");
            Console.WriteLine($"Listing Activities Completed:    {_listingCount}");
            Console.WriteLine("============================");
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
