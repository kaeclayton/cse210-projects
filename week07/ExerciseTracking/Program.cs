using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        DateTime date = new DateTime(2025, 08, 09);

        Activity running = new Running(date, 45, 15);
        Activity cycling = new Cycling(date, 90, 30);
        Activity swimming = new Swimming(date, 60, 30);

        List<Activity> activities = new List<Activity>();

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}