using System;

namespace _7kyu_Special_Number
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
    public static string PositiveOutput { get; } = "Special!!";

    public static string NegativeOutput { get; } = "NOT!!";

    public static string SpecialNumber(int number)
    {
        while (number > 0)
        {
            if (number % 10 > 5)
            {
                return NegativeOutput;
            }

            number /= 10;
        }

        return PositiveOutput;
    }
}