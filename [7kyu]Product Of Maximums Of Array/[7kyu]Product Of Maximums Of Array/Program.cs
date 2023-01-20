using System;
using System.Linq;

namespace _7kyu_Product_Of_Maximums_Of_Array
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
    public static int MaxProduct(int[] arr, int size)
    {
        return arr.OrderByDescending(x => x)
                  .Take(size)
                  .Aggregate((x, y) => x * y);
    }
}