using System;
using System.Linq;

public static class Matrix
{
    public static int Determinant(int[][] matrix)
    {
        // 0x0 matrix.
        if (matrix.Length == 0)
        {
            return 1;
        }

        // 1x1 matrix.
        if (matrix.Length == 1)
        {
            return matrix[0][0];
        }

        // 2x2 matrix.
        if (matrix.Length == 2)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        // Calculating determinant for 3x3 or bigger matrix.
        int determinant = 0;

        for (var i = 0; i < matrix[0].Length; i++)
        {
            determinant += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(GetMinor(matrix, i));
        }

        return determinant;
    }

    // Finds the minor for specified element in first row.
    private static int[][] GetMinor(int[][] matrix, int index)
    {
        return matrix.Skip(1) // Skipping first row.
                     .Select(row => row.Where((_, j) => j != index) // Taking elements except those who are below specified.
                                       .ToArray())
                     .ToArray();
    }
}