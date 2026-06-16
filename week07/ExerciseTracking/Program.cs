using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Activity> activities = new List<Activity>();

            
            Running runningActivity = new Running("03 Nov 2022", 30, 3.0);
            Cycling cyclingActivity = new Cycling("03 Nov 2022", 30, 12.0);
            Swimming swimmingActivity = new Swimming("03 Nov 2022", 30, 20);

            
            activities.Add(runningActivity);
            activities.Add(cyclingActivity);
            activities.Add(swimmingActivity);

            
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
