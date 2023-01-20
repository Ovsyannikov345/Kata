using System;
using System.Linq;

namespace _7kyu_Form_The_Minimum
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
    public static long MinValue(int[] numbers)
    {
        var digits = numbers.Distinct()
                            .OrderBy(x => x);

        return long.Parse(string.Join("", digits));
    }
}