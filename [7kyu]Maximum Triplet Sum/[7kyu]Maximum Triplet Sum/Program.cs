using System;
using System.Linq;

namespace _7kyu_Maximum_Triplet_Sum
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Kata
{
    public static int MaxTriSum(int[] a)
    {
        return a.Distinct() // Removing duplicates.
                .OrderByDescending(x => x) // Sorting.
                .Take(3) // Taking 3 biggest elements.
                .Sum(); // Adding them up.
    }
}