using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _unusedQuestions;
    private List<string> _unusedPrompts;
    private Random random = new Random();
    private DateTime _activityEndTime;

    public ReflectionActivity() : base()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _unusedQuestions = new List<string>(_questions);
        _unusedPrompts = new List<string>(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();
        _activityEndTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("\nConsider the following prompt:");
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        ShowCountDown(5);

        Console.Clear();
        DisplayQuestions();

        DisplayEndingMessage();
    }

    private string GetUniquePrompt()
    {
        // Refresh if all prompts have been used
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);

        int index = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }

    private string GetUniqueQuestion()
    {
        // Refresh if all questions have been used
        if (_unusedQuestions.Count == 0)
            _unusedQuestions = new List<string>(_questions);

        int index = random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"{GetUniquePrompt()}");
    }

    public void DisplayQuestions()
    {
        while (DateTime.Now < _activityEndTime)
        {
            if (DateTime.Now >= _activityEndTime) break;
            Console.WriteLine($"> {GetUniqueQuestion()} ");
            ShowSpinner(10);
        }
    }
}