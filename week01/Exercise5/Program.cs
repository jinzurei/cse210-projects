using System;

class Program
{
    static void Main(string[] args)
    {
        // Call functions in proper order
        DisplayWelcome(); // Step 1: Show welcome message

        string userName = PromptUserName(); // Step 2: Get user's name
        int favoriteNumber = PromptUserNumber(); // Step 3: Get user's favorite number
        int squaredNumber = SquareNumber(favoriteNumber); // Step 4: Square the number

        DisplayResult(userName, squaredNumber); // Step 5: Show the result
    }

    // Function 1: Display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function 2: Ask for the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function 3: Ask for the user's favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number;

        // Handle non-integer input
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Please enter your favorite number: ");
        }

        return number;
    }

    // Function 4: Square a given number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5: Display the user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}