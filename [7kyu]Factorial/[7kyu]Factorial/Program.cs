using System;
using System.Linq;

namespace _7kyu_Factorial
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
    public static class Program
    {
        public static int factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return Enumerable.Range(1, n).Aggregate((x, y) => x * y);
        }
    }
}