using System;
using System.Linq;

public static class LandPerimeter
{
    public static readonly int sideLength = 1;

    public static readonly char landMark = 'X';

    public static string Calculate(string[] map)
    {
        char[][] field = map.Select(x => x.ToCharArray()).ToArray();

        int totalPerimeter = 0;

        for (var i = 0; i < field.Length; i++)
        {
            for (var j = 0; j < field[i].Length; j++)
            {
                if (field[i][j] == landMark)
                {
                    totalPerimeter += GetTilePerimeter(field, i, j);
                }
            }
        }

        return $"Total land perimeter: {totalPerimeter}";
    }

    private static int GetTilePerimeter(char[][] field, int i, int j)
    {
        int tilePerimeter = 0;

        if (j + 1 >= field[i].Length || field[i][j + 1] != landMark)
        {
            tilePerimeter++;
        }

        if (i + 1 >= field.Length || field[i + 1][j] != landMark)
        {
            tilePerimeter++;
        }

        if (j - 1 < 0 || field[i][j - 1] != landMark)
        {
            tilePerimeter++;
        }

        if (i - 1 < 0 || field[i - 1][j] != landMark)
        {
            tilePerimeter++;
        }

        return tilePerimeter;
    }
}
