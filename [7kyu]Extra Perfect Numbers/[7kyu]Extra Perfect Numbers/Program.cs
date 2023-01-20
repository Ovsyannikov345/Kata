using System;
using System.Linq;

namespace _7kyu_Extra_Perfect_Numbers
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
    public static int[] ExtraPerfect(int n)
    {
        return Enumerable.Range(1, n)
                         .Where(x => x % 2 == 1)
                         .ToArray();
    }
}