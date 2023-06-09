using System;

namespace Make_a_spiral
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[,] result = Spiralizor.Spiralize(54);

            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(0); j++)
                {
                    Console.Write(result[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

public class Spiralizor
{
    public static int[,] Spiralize(int size)
    {
        // Initializing matrix and it's borders.
        int[,] matrix = new int[size, size];

        for (var i = 0; i < size; i++)
        {
            // Top border.
            matrix[0, i] = 1;

            // Right border. 
            matrix[i, size - 1] = 1;

            // Lower border.
            matrix[size - 1, i] = 1;

            // Left border.
            matrix[i, 0] = 1;
        }

        // Removing one 1 from left border.
        matrix[1, 0] = 0;

        // Filling the matrix.
        // The main idea is filling until we get 1 in front of us.
        // The filling goes in 4 steps(as directions).
        int iterationLimit = size % 2 == 0 ? size / 2 : size / 2 + 1;

        for (var i = 2; i < iterationLimit; i += 2)
        {
            // From left to right.
            int index = i - 1;

            while (matrix[i, index + 1] == 0)
            {
                matrix[i, index] = 1;
                index++;
            }

            // From top to bottom.
            index = i + 1;

            while (matrix[index + 1, size - i - 1] == 0)
            {
                matrix[index, size - i - 1] = 1;
                index++;
            }

            // From right to left.
            index = size - i - 2;

            while (matrix[size - i - 1, index - 1] == 0)
            {
                matrix[size - i - 1, index] = 1;
                index--;
            }

            // From bottom to top.
            index = size - i - 2;

            while (matrix[index - 1, i] == 0)
            {
                matrix[index, i] = 1;
                index--;
            }
        }

        // Removing one redundant point that may occur in spirals with even size.
        if (size % 2 == 0)
        {
            matrix[size / 2, size / 2 - 1] = 0;
        }

        return matrix;
    }
}