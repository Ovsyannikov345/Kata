using System;

namespace _7kyu_Minimize_Sum_Of_Array
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
    public static int MinSum(int[] numbers)
    {
        Array.Sort(numbers);

        int sum = 0;

        for (var i = 0; i < numbers.Length / 2; i++)
        {
            sum += numbers[i] * numbers[^(i + 1)];
        }

        return sum;
    }
}