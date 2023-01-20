using System;
using System.Linq;

namespace _7kyu_Nth_Smallest_Element
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
    public static int NthSmallest(int[] arr, int pos)
    {
        return arr.OrderBy(x => x).ElementAt(pos - 1);
    }
}