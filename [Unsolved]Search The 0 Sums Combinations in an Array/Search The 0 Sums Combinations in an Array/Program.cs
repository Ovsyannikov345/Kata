using System;

namespace Search_The_0_Sums_Combinations_in_an_Array
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static int[][] FindZeroSumGroups(int[] arr, int n)
    {
        //  - throw an InvalidOperationException "No combinations" if there are no combinations with sum equals to 0.
        //  - throw an ArgumentException "No elements to combine" if the function receives an empty array.
        //  - in all other cases, return a  int[][] , even if there is only 1 combination found.

        if (arr is null || arr.Length == 0 || arr.Length < n)
        {
            throw new ArgumentException("No elements to combine");
        }


    }
}
