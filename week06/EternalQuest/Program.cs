using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager manager = new GoalManager();

        Console.WriteLine("=== Eternal Quest - Goal Tracker ===");
        Console.WriteLine("Level up in real life by completing goals!\n");

        manager.Start();
    }
}