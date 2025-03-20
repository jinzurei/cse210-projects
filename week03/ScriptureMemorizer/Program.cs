using System;

class Program
{
    static void Main()
    {
        // Initialize the scripture with a reference and text
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, 
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("💡 **Scripture Memorizer** 💡\n");
            Console.WriteLine(scripture.GetDisplayText());

            // Display options
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Hide more words");
            Console.WriteLine("2. Reset scripture");
            Console.WriteLine("3. Quit");
            Console.Write("\nEnter your choice: ");
            
            string input = Console.ReadLine()?.Trim();

            if (input == "1")
            {
                scripture.HideRandomWords(2); // Hides 2 words per step
                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine("🎉 Congratulations! You memorized the scripture! 🎉");
                    break;
                }
            }
            else if (input == "2")
            {
                // Reset the scripture
                scripture = new Scripture(reference, 
                    "For God so loved the world that he gave his one and only Son, " +
                    "that whoever believes in him shall not perish but have eternal life.");
                Console.WriteLine("\n✅ Scripture has been reset!");
            }
            else if (input == "3")
            {
                Console.WriteLine("\n👋 Exiting the program. Have a great day!");
                break;
            }
            else
            {
                Console.WriteLine("\n❌ Invalid input. Please choose a valid option.");
            }
        }
    }
}