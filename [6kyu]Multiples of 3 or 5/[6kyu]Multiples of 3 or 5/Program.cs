using System;
using System.Linq;

namespace _6kyu_Multiples_of_3_or_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static int Solution(int value)
    {
        // Validation.
        if (value < 3)
        {
            return 0;
        }

        return Enumerable.Range(1, value - 1) // Generating sequence.
                         .Where(x => x % 3 == 0 || x % 5 == 0) // Taking only multiples of 3 or 5.
                         .Sum(); // Summarising them.
    }
}