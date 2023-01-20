using System;
using System.Linq;

namespace _7kyu_Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Kata
{
    public static string PositiveOutput { get; } = "STRONG!!!!";

    public static string NegativeOutput { get; } = "Not Strong !!";

    public static string StrongNumber(int number)
    {
        // Memorising number.
        int initNumber = number;

        int sum = 0;

        while (number > 0)
        {
            // Adding the factorial of the last digit to the sum.
            sum += GetFactorial(number % 10);
            number /= 10;
        }

        return sum == initNumber ? PositiveOutput : NegativeOutput;
    }

    public static int GetFactorial(int number)
    {
        if (number == 0)
        {
            return 1;
        }

        return Enumerable.Range(1, number).Aggregate((x, y) => x * y);
    }
}