using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int cycle = 0;
        int baseDuration = 3;

        Console.WriteLine("\nFollow the breathing animation:");
        Console.WriteLine("(Longer breaths will promote deeper relaxation)");
        Console.Write("Ready? ");
        ShowCountDown(3);

        while (DateTime.Now < endTime)
        {
            //progressive relaxation
            int breathDuration = baseDuration + (cycle / 2);
            breathDuration = Math.Min(breathDuration, 7); //cap at 7 seconds

            //inhale phase
            ShowBreathingAnimation(breathDuration, true);

            //exhale phase (slightly longer)
            ShowBreathingAnimation(breathDuration + 1, false);

            cycle++;
            Console.Clear();
        }

        Console.WriteLine($"\nYou completed {cycle} breathing cycles!");
        Console.WriteLine($"\nMaximum breath duration: {Math.Min(baseDuration + (cycle / 2), 7)} seconds");

        DisplayEndingMessage();
    }

    private void ShowBreathingAnimation(int duration, bool isInhale)
    {
        int steps = 10;
        int delay = duration * 1000 / steps;

        for (int i = 1; i <= steps; i++)
        {
            Console.Clear();

            //growing/shrinking bar visualizationo
            int barSize = isInhale ? i : steps - i + 1;
            string bar = new string('#', barSize);

            Console.WriteLine(isInhale ? "Breathe IN..." : "Breathe OUT...");
            Console.WriteLine($"[{bar.PadRight(steps)}]");
            Console.WriteLine($"\n{barSize * 10}% complete");

            Thread.Sleep(delay);
        }
    }
}