using System;
using System.Linq;

namespace _7kyu_Highest_and_Lowest
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
    public static string HighAndLow(string source)
    {
        var numbers = source.Split(' ').Select(x => int.Parse(x));

        return $"{numbers.Max()} {numbers.Min()}";
    }
}