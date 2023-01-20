using System;
using System.Collections.Generic;

namespace Sums_of_Perfect_Squares
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(SumOfSquares.NSquaresFor(500_000_000));
        }
    }
}

public class SumOfSquares
{
    public static int NSquaresFor(int number)
    {
        Console.WriteLine($"Current number: {number}");

        if (number > 500000000)
        {
            return -1;
        }

        int initNumber = number;

        int minCount = int.MaxValue;

        int[] squares = GetPerfectSquares(number);

        for (var startIndex = 0; startIndex < squares.Length; startIndex++)
        {
            int count = 0;

            number = initNumber;

            for (var currentIndex = startIndex; currentIndex < squares.Length; currentIndex++)
            {
                count += number / squares[currentIndex];
                number %= squares[currentIndex];
            }

            if (count < minCount)
            {
                minCount = count;
            }
        }

        Console.WriteLine($"Result: {minCount}");

        return minCount;
    }

    public static int[] GetPerfectSquares(int number)
    {
        List<int> squares = new List<int>();

        int upperLimit = (int)Math.Sqrt(number);

        // Adding all squares of numbers up to sqrt(number).
        for (var i = upperLimit; i >= 1; i--)
        {
            squares.Add(i * i);
        }

        return squares.ToArray();
    }
}