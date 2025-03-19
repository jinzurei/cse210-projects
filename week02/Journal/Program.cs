// This Journal program includes several enhancements beyond the base requirements:
// 1. Mood Rating System: Users rate their mood (1-10) when making an entry.
// 2. Auto-Load: The program automatically loads previous journal entries on startup.
// 3. Auto-Save: Entries are automatically saved to cacheJournal.txt after creation.
// 4. Input Validation: Ensures mood ratings are between 1-10, preventing errors.
// These features improve usability and allow users to track their emotional well-being.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string cacheFile = "cacheJournal.txt";

        if (System.IO.File.Exists(cacheFile))
        {
            journal.LoadFromFile(cacheFile);
            Console.WriteLine("Previous journal entries loaded from cache.\n"); 
        }

        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to your Journal!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load entries from a file");
            Console.WriteLine("4. Save entries to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {entry._promptText}");

                    Console.Write("On a scale of 1 to 10, how are you feeling today? ");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int mood) && mood >= 1 && mood <= 10)
                        {
                            entry._moodRating = mood;
                            break;
                        }
                        Console.Write("Invalid input. Please enter a number between 1 and 10: ");
                    }

                    Console.Write("Your response: ");
                    entry._entryText = Console.ReadLine();

                    journal.AddEntry(entry);
                    journal.SaveToFile(cacheFile);
                    Console.WriteLine("Entry added and auto-saved to cache.\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully.\n");
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully.\n");
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program! Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please select again.\n");
                    break;
            }
        }
    }
}