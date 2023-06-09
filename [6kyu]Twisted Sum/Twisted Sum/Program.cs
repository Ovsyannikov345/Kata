using System;

namespace Twisted_Sum
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class TwistedSum
{
    public static long Solution(long number)
    {
        int sum = 0;

        for (var i = 1; i <= number; i++)
        {
            sum += GetSumOfDigits(i);
        }

        return sum;
    }

    public static int GetSumOfDigits(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }
}