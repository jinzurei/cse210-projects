using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through slow, deep breaths. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartMessage();
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            PauseWithCountdown(4);
            Console.Write("Breathe out...");
            PauseWithCountdown(6);
            Console.WriteLine(); // spacing
        }

        DisplayEndMessage();
    }
}