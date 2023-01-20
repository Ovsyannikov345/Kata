using System;
using System.Linq;

namespace _6kyu_Transform_To_Prime
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

namespace TransformToPrime
{
    public class Solution
    {
        public static int MinimumNumber(int[] numbers)
        {
            int sum = numbers.Sum();

            return GetNearestPrime(sum) - sum;
        }

        public static int GetNearestPrime(int number)
        {
            while (!IsPrime(number))
            {
                number++;
            }

            return number;
        }

        public static bool IsPrime(int number)
        {
            return !Enumerable.Range(2, (int)Math.Sqrt(number)).Any(x => number % x == 0);
        }
    }
}