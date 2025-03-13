using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string cacheFile = "cacheJournal.txt";

        // Automatically load entries from cache at program start (if exists)
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
                    Console.Write("Your response: ");
                    entry._entryText = Console.ReadLine();

                    journal.AddEntry(entry);

                    // Automatically save the new entry to cache
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