using System;
using System.Linq;

namespace _6kyu_Find_the_odd_int
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

namespace Solution
{
    class Kata
    {
        public static int find_it(int[] sequence)
        {
            return Array.Find(sequence, number => sequence.Count(x => x == number) % 2 == 1);
        }
    }
}