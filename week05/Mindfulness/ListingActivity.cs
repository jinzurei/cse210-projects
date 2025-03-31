using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "When have you felt peace this month?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
        : base("Listing", "This activity helps you reflect on the good things in your life by having you list as many items as you can.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public override void Run()
    {
        DisplayStartMessage();
        Console.Clear();

        // Show prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nYou may begin in: ");
        PauseWithCountdown(5);
        Console.WriteLine("Start listing! Press Enter after each item.");

        // Collect responses
        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    responses.Add(input.Trim());
                }
            }

            Thread.Sleep(100); // prevent high CPU usage
        }

        // Show count
        Console.WriteLine($"\nYou listed {responses.Count} items.");
        DisplayEndMessage();
    }
}