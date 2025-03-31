// Creativity note:
// I exceeded requirements by implementing:
// - Spinner animation reuse across activities
// - Dynamic countdown system
// - Clean inheritance structure with abstract base class
// - Listing item counter and user input tracker

using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Activity breathing = new BreathingActivity();
                    breathing.Run();
                    Console.WriteLine("Press Enter to return to menu.");
                    Console.ReadLine();
                    break;
                case "2":
                    Activity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    Console.WriteLine("Press Enter to return to menu.");
                    Console.ReadLine();
                    break;
                case "3":
                    Activity listing = new ListingActivity();
                    listing.Run();
                    Console.WriteLine("Press Enter to return to menu.");
                    Console.ReadLine();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}