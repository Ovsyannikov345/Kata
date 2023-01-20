using System.Collections.Generic;
using System.Linq;

public static class Finder
{
    public static int PathFinder(string maze)
    {
        // Converting the maze to the array if integers.
        // -1 is a wall.
        // int.MaxValue is an unreached point.
        // Other values are distances between current point and start.
        int[][] field = maze.Split('\n')
                            .Select(line => line.Select(x => x == '.' ? int.MaxValue : -1)
                                                .ToArray())
                            .ToArray();

        // Visiting points from the start.
        TryVisit(field, 0, 0, -1);

        int finishPointValue = field[field.Length - 1][field.Length - 1];

        // Return distance if the finish point is not a wall and it was reached.
        if (finishPointValue != -1 && finishPointValue != int.MaxValue)
        {
            return finishPointValue;
        }
        else
        {
            return -1;
        }
    }

    private static void TryVisit(int[][] field, int i, int j, int previousDistance)
    {
        // Checking the bounds of the field.
        if (i < 0 || j < 0 || i >= field.Length || j >= field.Length)
        {
            return;
        }

        // Checking if the point is a wall.
        if (field[i][j] == -1)
        {
            return;
        }

        // If the point is unreached or we have just found the shortest way,
        // we should recalculate the distance and visit the neighbors again.
        if (field[i][j] == int.MaxValue || field[i][j] > previousDistance + 1)
        {
            field[i][j] = previousDistance + 1;

            TryVisit(field, i, j + 1, field[i][j]);
            TryVisit(field, i, j - 1, field[i][j]);
            TryVisit(field, i + 1, j, field[i][j]);
            TryVisit(field, i - 1, j, field[i][j]);
        }
    }
}
