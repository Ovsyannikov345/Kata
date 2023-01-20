using System;
using System.Linq;

namespace Ocean
{
    public static class Voyage
    {
        private const string floodablePoints = "xFST ";

        public static string Flotsam(char[][] image)
        {
            // Calculating water level.
            int waterLevel = GetWaterLevel(image);

            // Searching for 'x' on image.
            for (var i = 0; i < image.Length; i++)
            {
                for (var j = 0; j < image[i].Length; j++)
                {
                    // Flooding the point if needed.
                    if (image[i][j] == 'x' && IsHole(image, i, j))
                    {
                        TryFlood(image, i, j, waterLevel);
                    }
                }
            }

            // Looking for survivors.
            string survivors = "";

            // Looking for Frank.
            if (image.Any(line => line.Contains('F')))
            {
                survivors += "Frank ";
            }

            // Looking for Sam.
            if (image.Any(line => line.Contains('S')))
            {
                survivors += "Sam ";
            }

            // Looking for Tom.
            if (image.Any(line => line.Contains('T')))
            {
                survivors += "Tom ";
            }

            return survivors.TrimEnd();
        }

        // Calculates water level.
        private static int GetWaterLevel(char[][] image)
        {
            int waterLevel = image.Length;

            while (waterLevel > 0 && image[waterLevel - 1][0] == '~')
            {
                waterLevel--;
            }

            return waterLevel;
        }

        // Checks if 'x' will start the flood.
        private static bool IsHole(char[][] image, int i, int j)
        {
            // Water is above 'x'.
            if (i != 0 && image[i - 1][j] == '~')
            {
                return true;
            }

            // Water is below 'x'.
            if (i != image.Length - 1 && image[i + 1][j] == '~')
            {
                return true;
            }

            // Water is leftwards 'x'.
            if (j != 0 && image[i][j - 1] == '~')
            {
                return true;
            }

            // Water is rightwards 'x'.
            if (j != image[0].Length - 1 && image[i][j + 1] == '~')
            {
                return true;
            }

            // No water near 'x'.
            return false;
        }

        // Floods the points recursively.
        private static void TryFlood(char[][] image, int i, int j, int waterLevel)
        {
            // Checking the bounds of image and water level.
            if (i < waterLevel || i > image.Length - 1 || j < 0 || j > image[0].Length - 1)
            {
                return;
            }

            // Flooding the point if possible and trying it's neighbors.
            if (floodablePoints.Contains(image[i][j]))
            {
                image[i][j] = '~';
                TryFlood(image, i + 1, j, waterLevel);
                TryFlood(image, i - 1, j, waterLevel);
                TryFlood(image, i, j + 1, waterLevel);
                TryFlood(image, i, j - 1, waterLevel);
            }
        }
    }
}