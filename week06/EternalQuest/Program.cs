// CREATIVITY AND EXCEEDING REQUIREMENTS SHOWCASE:
// 1. Leveling Up System: The program tracks player milestones and increments levels.
// 2. Custom Title Ranks: Player receives a special rank dependent on their milestone stage.
//    At Level 13+, user reaches the legendary milestone of "Level 13 Ninja Unicorn"!
// 3. User Dashboard integration: Levels and Titles display seamlessly in Player Info.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
