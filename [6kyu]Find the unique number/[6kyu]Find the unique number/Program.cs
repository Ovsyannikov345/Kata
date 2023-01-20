using System;
using System.Collections.Generic;
using System.Linq;

namespace _6kyu_Find_the_unique_number
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
    public static int GetUnique(IEnumerable<int> source)
    {
        // Parsing.
        int[] numbers = source.ToArray();

        // Finding element that occurs once.
        return Array.Find(numbers, x => numbers.Count(y => y == x) == 1);
    }
}