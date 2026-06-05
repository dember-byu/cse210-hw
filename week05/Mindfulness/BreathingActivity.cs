using System;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);

            
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... [>>>>] ");
                ShowCountdown(4);
                Console.WriteLine();

                Console.Write("Breathe out.. [<<<<] ");
                ShowCountdown(4);
                Console.WriteLine("\n");
            }

            DisplayEndingMessage();
        }
    }
}
