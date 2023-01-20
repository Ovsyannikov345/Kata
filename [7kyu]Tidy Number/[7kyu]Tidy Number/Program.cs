using System;

namespace _7kyu_Tidy_Number
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
    public static bool TidyNumber(int n)
    {
        while (n > 9)
        {
            if (n % 10 < n % 100 / 10)
            {
                return false;
            }

            n /= 10;
        }

        return true;
    }
}