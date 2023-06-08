using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

public enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3,
}

public class PathFinder
{
    private static int currentX = 0;

    private static int currentY = 0;

    private static Direction currentDirection = Direction.Left;

    public static Point iAmHere(string path)
    {
        string[] commands = Regex.Matches(path, @"\d+|[rlRL]")
                                 .Select(x => x.Value)
                                 .ToArray();

        foreach (var command in commands)
        {
            if (int.TryParse(command, out int steps))
            {
                switch (currentDirection)
                {
                    case Direction.Up:
                        currentY += steps;
                        break;
                    case Direction.Down:
                        currentY -= steps;
                        break;
                    case Direction.Right:
                        currentX += steps;
                        break;
                    case Direction.Left:
                        currentX -= steps;
                        break;
                }
            }
            else
            {
                int newDirection = (int)currentDirection + command switch
                {
                    "r" => 1,
                    "l" => 3,
                    _ => 2,
                };

                newDirection %= 4;

                currentDirection = (Direction)newDirection;
            }
        }

        return new Point(currentX, currentY);
    }
}