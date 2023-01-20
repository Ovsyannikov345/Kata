using System;

namespace _8kyu_Count_by_X
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static int[] CountBy(int x, int n)
    {
        if (n == 0)
        {
            return new int[0];
        }

        int[] multiples = new int[n];

        multiples[0] = x;

        for (var i = 1; i < multiples.Length; i++)
        {
            multiples[i] = multiples[i - 1] + x;
        }

        return multiples;
    }
}
