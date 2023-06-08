using System;

string d = "0707\n" +
           "7070\n" +
           "0707\n" +
           "7070";

Finder.PathFinder(d);

public class Finder
{
    public static int PathFinder(string maze)
    {
        string[] lines = maze.Split('\n');

        int[][] map = lines.Select(line => line.ToCharArray()
                                               .Select(cell => cell - '0')
                                               .ToArray())
                           .ToArray();

        int FindEffectiveWay(int[][] map, bool[][] visitedCells, int i, int j)
        {
            if (i > 0 && !visitedCells[i - 1][j])
            {

            }

            if (i < map.Length - 1 && !visitedCells[i + 1][j])
            {

            }
        }
    }
}