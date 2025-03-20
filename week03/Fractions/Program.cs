using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters (defaults to 1/1)
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter (sets denominator to 1)
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter for numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    // Setter for numerator
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter for denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    // Setter for denominator (ensures denominator is not zero)
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }

    // Method to return fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to return decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}

class Program
{
    static void Main()
    {
        // Test different constructors
        Fraction f1 = new Fraction(); // 1/1
        Fraction f2 = new Fraction(5); // 5/1
        Fraction f3 = new Fraction(3, 4); // 3/4
        Fraction f4 = new Fraction(1, 3); // 1/3

        // Display fraction representations
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Testing getters and setters
        Fraction testFraction = new Fraction(2, 5);
        Console.WriteLine(testFraction.GetFractionString());
        testFraction.SetNumerator(7);
        testFraction.SetDenominator(8);
        Console.WriteLine(testFraction.GetFractionString());
        Console.WriteLine(testFraction.GetDecimalValue());
    }
}