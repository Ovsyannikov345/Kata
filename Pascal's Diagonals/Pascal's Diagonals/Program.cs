using System;
using System.Collections.Generic;
using System.Numerics;

namespace Pascal_s_Diagonals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] result = Kata.GenerateDiagonal(2, 5);

            foreach (var num in result)
            {
                Console.Write(num + " ");
            }
        }
    }
}

public class Kata
{
    public static BigInteger[] GenerateDiagonal(int n, int l)
    {
        BigInteger[][] triangle = GenerateTriangle(l + n - 1);

        BigInteger[] result = new BigInteger[l];

        for (var i = n; i < triangle.GetLength(0); i++)
        {
            result[i - n] = triangle[i][i - n];
        }

        return result;
    }

    /// <summary>
    /// Generates the Pascal's triangle with required height.
    /// </summary>
    /// <param name="height">The heigth of the triangle.</param>
    /// <returns>The Pascal's triangle.</returns>
    public static BigInteger[][] GenerateTriangle(int height)
    {
        // Initializing the triangle.
        BigInteger[][] triangle = new BigInteger[height + 1][];

        for (var i = 0; i <= height; i++)
        {
            triangle[i] = new BigInteger[i + 1];
            triangle[i][0] = 1;
            triangle[i][^1] = 1;
        }

        // Calculating all cells of triangle.
        for (var i = 2; i <= height; i++)
        {
            for (var j = 1; j < triangle[i].Length - 1; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        return triangle;
    }
}