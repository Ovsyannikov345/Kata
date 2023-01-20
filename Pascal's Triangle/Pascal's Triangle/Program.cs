using System;
using System.Collections.Generic;

namespace Pascal_s_Triangle
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
    public static List<int> PascalsTriangle(int n)
    {
        // Initializing the triangle.
        int[][] triangle = new int[n][];

        for (var i = 0; i < n; i++)
        {
            triangle[i] = new int[i + 1];
            triangle[i][0] = 1;
            triangle[i][^1] = 1;
        }

        // Calculating all cells of triangle.
        for (var i = 2; i < n; i++)
        {
            for (var j = 1; j < triangle[i].Length - 1; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        // Converting triangle to one-dimensional array.
        List<int> result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < triangle[i].Length; j++)
            {
                result.Add(triangle[i][j]);
            }
        }

        return result;
    }
}
