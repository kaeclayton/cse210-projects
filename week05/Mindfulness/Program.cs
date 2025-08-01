using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        while (true)
        {
            Console.WriteLine("\nWelcome to mindfulness practice!");
            Console.WriteLine("Please choose from the following activities:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("\nInvalid input. Please enter 1-4.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            if (choice == 4) break;

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectionActivity(),
                3 => new ListingActivity(),
                _ => null
            };

            if (activity is BreathingActivity breathing)
                breathing.Run();
            else if (activity is ReflectionActivity reflection)
                reflection.Run();
            else if (activity is ListingActivity listing)
                listing.Run();
                
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey();
        }    
    }
}