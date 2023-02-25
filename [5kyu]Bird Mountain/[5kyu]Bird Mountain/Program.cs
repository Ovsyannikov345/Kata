using System;
using System.Linq;

public class Dinglemouse
{
    public static int PeakHeight(char[][] mountain)
    {
        // Replacing empty cells with '0'
        // Replacing the borders of the mountain on the edge of the field with '1'.
        for (var i = 0; i < mountain.Length; i++)
        {
            for (var j = 0; j < mountain[i].Length; j++)
            {
                if (mountain[i][j] == ' ')
                {
                    mountain[i][j] = '0';
                }
                else if (mountain[i][j] == '^' && (i == 0 || i == mountain.Length - 1 || j == 0 || j == mountain[i].Length - 1))
                {
                    mountain[i][j] = '1';
                }
            }
        }

        bool isFinished = false;

        char currentHeight = '0';

        while (!isFinished)
        {
            CalculateHeights(mountain, currentHeight, out isFinished);

            currentHeight++;
        }

        return GetMaxHeight(mountain);
    }

    /// <summary>
    /// Marks the cells of 'currentHeight + 1' height.
    /// </summary>
    /// <param name="currentHeight">The last marked height.</param>
    /// <param name="isFinished">Returns true if the whole mountain is calculated. False otherwise.</param>
    private static void CalculateHeights(char[][] mountain, char currentHeight, out bool isFinished)
    {
        isFinished = true;

        for (var i = 0; i < mountain.Length; i++)
        {
            for (var j = 0; j < mountain[i].Length; j++)
            {
                if (mountain[i][j] == currentHeight)
                {
                    CalculateNeighborHeights(mountain, i, j);
                }
                else if (mountain[i][j] == '^')
                {
                    isFinished = false;
                }
            }
        }
    }

    /// <summary>
    /// Marks the cells of 'currentHeight + 1' height, that are neighbors of current cell.
    /// </summary>
    /// <param name="mountain">The field.</param>
    /// <param name="i">Current cell row.</param>
    /// <param name="j">Current cell column.</param>
    private static void CalculateNeighborHeights(char[][] mountain, int i, int j)
    {
        char currentHeight = mountain[i][j];

        // Upper neighbor.
        if (i != 0 && mountain[i - 1][j] == '^')
        {
            mountain[i - 1][j] = (char)(currentHeight + 1);
        }

        // Lower neighbor.
        if (i != mountain.Length - 1 && mountain[i + 1][j] == '^')
        {
            mountain[i + 1][j] = (char)(currentHeight + 1);
        }

        // Left neigbor.
        if (j != 0 && mountain[i][j - 1] == '^')
        {
            mountain[i][j - 1] = (char)(currentHeight + 1);
        }

        // Right neigbor.
        if (j != mountain[i].Length - 1 && mountain[i][j + 1] == '^')
        {
            mountain[i][j + 1] = (char)(currentHeight + 1);
        }
    }

    /// <summary>
    /// Finds the max height of the mountain.
    /// </summary>
    /// <param name="mountain">The field.</param>
    private static int GetMaxHeight(char[][] mountain)
    {
        char maxHeight = mountain.Max(x => x.Max());

        return maxHeight - '0';
    }
}