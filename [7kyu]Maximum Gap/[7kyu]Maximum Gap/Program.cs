using System;
using System.Linq;

namespace _7kyu_Maximum_Gap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static int MaxGap(int[] numbers)
    {
        Array.Sort(numbers);

        var maxGap = int.MinValue;

        for (var i = 0; i < numbers.Length - 1; i++)
        {
            var gap = Math.Abs(numbers[i] - numbers[i + 1]);

            if (gap > maxGap)
            {
                maxGap = gap;
            }
        }

        return maxGap;
    }
}