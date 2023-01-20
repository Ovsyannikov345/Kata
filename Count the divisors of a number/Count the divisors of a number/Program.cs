using System;

namespace Count_the_divisors_of_a_number
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
    public static int Divisors(int number)
    {
        int divisorsCount = 0;

        // No need to check divisors bigger than sqrt(n).
        int upperLimit = (int)Math.Sqrt(number);

        for (var i = 1; i <= upperLimit; i++)
        {
            // Checking if i is the divisor.
            if (number % i == 0)
            {
                divisorsCount++;

                // Adding also the divisor that is in pair with i.
                // But we should avoid adding same divisor twice.
                if (number / i != i)
                {
                    divisorsCount++;
                }
            }
        }

        return divisorsCount;
    }
}