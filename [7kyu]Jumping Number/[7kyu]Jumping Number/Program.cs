using System;

namespace _7kyu_Jumping_Number
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[] tests = {849292,600539,546979,351950,761075,806921,368932,315388,49366,369160,192244,176576,1143,13256};

            foreach (var test in tests)
            {
                Console.WriteLine($"{test}  {Kata.JumpingNumber(test)}");
            }
        }
    }
}

public class Kata
{
    public static string PositiveOutput { get; } = "Jumping!!";

    public static string NegativeOutput { get; } = "Not!!";

    public static string JumpingNumber(int number)
    {
        while (number > 9)
        {
            // The difference between last digit and next to it should be 1.
            if (Math.Abs(number % 10 - number % 100 / 10) != 1)
            {
                return NegativeOutput;
            }

            number /= 10;
        }

        return PositiveOutput;
    }
}