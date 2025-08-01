using System;
using System.Collections.Generic;
using System.Threading;
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private int _count;

    public ListingActivity() : base()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in answer to a prompt in the amount of time you decide on.";
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"List as many things as you can about: {prompt}");
        ShowCountDown(5);

        Console.WriteLine("\nBegin listing:");
        List<string> items = GetListFromUser();

        _count = items.Count;    
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private Random random = new Random();
    public string GetRandomPrompt()
    {
        return _prompts[random.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        return items;
    }
}