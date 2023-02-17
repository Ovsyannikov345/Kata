using System;
using System.Collections.Generic;
using System.Linq;

public class DirReduction
{
    private static readonly (string, string)[] oppositeDirections =
    {
        ("NORTH", "SOUTH"),
        ("SOUTH", "NORTH"),
        ("EAST", "WEST"),
        ("WEST", "EAST"),
    };

    public static string[] dirReduc(string[] directions)
    {
        List<string> reducedDirections = new List<string>(directions);

        for (var i = 0; i < reducedDirections.Count - 1; i++)
        {
            if (reducedDirections.Count < 2)
            {
                break;
            }

            if (oppositeDirections.Contains((reducedDirections[i], reducedDirections[i + 1])))
            {
                reducedDirections.RemoveRange(i, 2);

                i -= i != 0 ? 2 : 1;
            }
        }

        return reducedDirections.ToArray();
    }
}