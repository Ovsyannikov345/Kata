using System;

namespace _7kyu_Maximum_Product
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
    public static int AdjacentElementsProduct(int[] array)
    {
        int maxProduct = array[0] * array[1];

        for (var i = 1; i < array.Length - 1; i++)
        {
            var product = array[i] * array[i + 1];

            if (product > maxProduct)
            {
                maxProduct = product;
            }
        }

        return maxProduct;
    }
}