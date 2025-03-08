using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompts the user to enter their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();

        // Converts the input string to an integer
        int gradePercentage = int.Parse(input);
        string letterGrade = "";
        string sign = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Identify the sign (+ or -) except for A & F grades
        int lastDigit = gradePercentage % 10;

        if (letterGrade != "A" && letterGrade != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // alerts user of grade
        Console.WriteLine($"Your grade is: {letterGrade}{sign}");

        // pass / fail
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed.");
        }
        else
        {
            Console.WriteLine("Sorry, you failed.");
        }
    }
}