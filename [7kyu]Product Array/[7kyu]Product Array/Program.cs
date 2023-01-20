using System;
using System.Linq;

namespace _7kyu_Product_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

class Kata
{
    public static int[] ProductArray(int[] array)
    {
        int[] result = new int[array.Length];

        int product = array.Aggregate((x, y) => x * y);

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = product / array[i];
        }

        return result;
    }
}