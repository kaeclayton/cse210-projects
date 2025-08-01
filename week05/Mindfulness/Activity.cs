public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine(_description);
        Console.WriteLine();

        bool validInput = false;
        while (!validInput)
        {
            Console.Write("How many seconds would you like to practice? (10-600) ");
            string input = Console.ReadLine();

            validInput = int.TryParse(input, out _duration)
                        && _duration >= 10
                        && _duration <= 600;

            if (!validInput)
                Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        Console.WriteLine($"Great! Your session will last {_duration} seconds.");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(5);
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("\nNicely done!");
        Console.WriteLine($"You've completed the {_name} for {_duration} seconds.");
        Console.Write("Returning to menu...");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        bool showPlus = true;

        while (DateTime.Now < endTime)
        {
            Console.Write(showPlus ? "+" : "#");
            Thread.Sleep(200);
            Console.Write("\b \b");
            showPlus = !showPlus;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}