using System;

namespace _8kyu_Beginner_Series_4._Cockroach
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Cockroach
{
    public static int CockroachSpeed(double x)
    {
        return (int)Math.Floor(x * 100_000 / 3_600);
    }
}
