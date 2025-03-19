using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public int _moodRating;  // New field for mood rating

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Mood Rating: {_moodRating}/10");
        Console.WriteLine($"{_entryText}\n");
    }
}