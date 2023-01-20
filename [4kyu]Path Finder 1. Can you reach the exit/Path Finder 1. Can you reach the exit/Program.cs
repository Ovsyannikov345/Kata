public class Finder
{
    public static bool PathFinder(string maze)
    {
        // Parsing the field to the array of chars.
        string[] lines = maze.Split('\n');

        char[,] field = new char[lines.Length, lines.Length];

        for (var i = 0; i < lines.Length; i++)
        {
            char[] line = lines[i].ToCharArray();

            for (var j = 0; j < line.Length; j++)
            {
                field[i,j] = line[j];
            }
        }

        // Start to visit points.
        TryVisit(field, 0, 0);

        // Checking if the final point was marked as reached.
        return field[field.GetLength(0) - 1, field.GetLength(1) - 1] == '1';
    }

    // Marks the field point as 1 if it was reached.
    private static void TryVisit(char[,] field, int i, int j)
    {
        // Checking the field bounds.
        if (i < 0 || j < 0 || i >= field.GetLength(0) || j >= field.GetLength(1))
        {
            return;
        }

        // Mark the point as reached if it was '.'
        if (field[i,j] == '.')
        {
            field[i,j] = '1';
        }
        else
        {
            return;
        }

        // Try to visit the neighbors.
        TryVisit(field, i, j + 1);
        TryVisit(field, i, j - 1);
        TryVisit(field, i + 1, j);
        TryVisit(field, i - 1, j);
    }
}