using System;

namespace Bit_Counting
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
    public static int CountBits(int n)
    {
        int count = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                count++;
            }

            n >>= 1;
        }

        return count;
    }
}