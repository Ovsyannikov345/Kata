using System;
using System.Linq;

public static class Dinglemouse
{
    public static int[] DryGround(char[][] terrain)
    {
        int[] landingSpots = new int[4];

        int?[][] heightMap = GetHeightMap(terrain);

        for (var i = 0; i < landingSpots.Length; i++)
        {
            landingSpots[i] = GetGroundCount(heightMap);

            Flood(heightMap, i);
        }

        return landingSpots;
    }

    // Parsing char map into integer height map.
    // Ground => non-negative numbers.
    // River => -1.
    private static int?[][] GetHeightMap(char[][] terrain)
    {
        // Preparing the map.
        // Empty space => 0.
        // Mountain => null.
        // River => -1.
        int?[][] heightMap = new int?[terrain.Length][];

        for (var i = 0; i < terrain.Length; i++)
        {
            int?[] row = new int?[terrain[i].Length];

            for (var j = 0; j < terrain[i].Length; j++)
            {
                if (terrain[i][j] == ' ')
                {
                    row[j] = 0;
                }
                else if (terrain[i][j] == '^')
                {
                    row[j] = null;
                }
                else
                {
                    row[j] = -1;
                }
            }

            heightMap[i] = row;
        }

        // Furter calculations for mountains (getting rid of null).
        CalculateMountainsEdges(heightMap);
        CalculateMountains(heightMap);

        return heightMap;
    }

    private static void CalculateMountainsEdges(int?[][] map)
    {
        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                // Not a mountain cell.
                if (map[i][j] != null)
                {
                    continue;
                }

                // Map egde.
                if (i == 0 || j == 0 || i == map.Length - 1 || j == map[i].Length - 1)
                {
                    map[i][j] = 1;
                }
                else if (CheckNeihgborWithHeight(map, i, j, 0)) // Borders flat ground.
                {
                    map[i][j] = 1;
                }
                else if (CheckNeihgborWithHeight(map, i, j, -1)) // Borders river.
                {
                    map[i][j] = 1;
                }
            }
        }
    }

    private static void CalculateMountains(int?[][] map, int currentHeight = 1)
    {
        bool needFurtherCalculations = false;

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                // Not a mountain cell or already calculated.
                if (map[i][j] != null)
                {
                    continue;
                }

                // Can be calculated.
                if (CheckNeihgborWithHeight(map, i, j, currentHeight))
                {
                    map[i][j] = currentHeight + 1;
                }
                else // Can't be calcuated.
                {
                    needFurtherCalculations = true;
                }
            }
        }

        // Continue calculations if needed.
        if (needFurtherCalculations)
        {
            CalculateMountains(map, currentHeight + 1);
        }
    }

    // Checks if the cell has any neighbor with defined height.
    private static bool CheckNeihgborWithHeight(int?[][] map, int i, int j, int neighborHeight)
    {
        // Neighbor list.
        // No neighbor (cell is on the map edge) => null.
        int?[] neighbors =
        {
            i < map.Length - 1 ? map[i + 1][j] : null,
            i > 0 ? map[i - 1][j] : null,
            j < map[i].Length - 1 ? map[i][j + 1] : null,
            j > 0 ? map[i][j - 1] : null,
        };

        return neighbors.Any(neighbor => neighbor != null && neighbor == neighborHeight);
    }

    // Returns a count of all possible landing spots (>= 0 on the height map).
    private static int GetGroundCount(int?[][] map)
    {
        return map.Select(row => row.Count(cell => cell >= 0))
                  .Sum();
    }

    // Finds all cells that can start the flood.
    private static void Flood(int?[][] map, int waterLevel)
    {
        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                // Cell can't be flooded now or already flooded.
                if (map[i][j] == -1 || map[i][j] > waterLevel)
                {
                    continue;
                }

                // Checking if there is river nearby so cell will be flooded.
                if (CheckNeihgborWithHeight(map, i, j, -1))
                {
                    // Cell may start a big flood if there are other cells with same or lower height nearby.
                    FloodRecursive(map, i, j, waterLevel);
                }
            }
        }
    }

    // Tries to create a big flood.
    private static void FloodRecursive(int?[][] map, int i, int j, int waterLevel)
    {
        // Already flooded (stack overflow protection).
        if (map[i][j] == -1)
        {
            return;
        }

        // Flood the cell.
        map[i][j] = -1;

        // Try to flood neighbors.
        // Top neighbor.
        if (i > 0 && map[i - 1][j] <= waterLevel)
        {
            FloodRecursive(map, i - 1, j, waterLevel);
        }

        // Bottom neighbor.
        if (i < map.Length - 1 && map[i + 1][j] <= waterLevel)
        {
            FloodRecursive(map, i + 1, j, waterLevel);
        }

        // Left neighbor.
        if (j > 0 && map[i][j - 1] <= waterLevel)
        {
            FloodRecursive(map, i, j - 1, waterLevel);
        }

        // Right neighbor.
        if (j < map[i].Length - 1 && map[i][j + 1] <= waterLevel)
        {
            FloodRecursive(map, i, j + 1, waterLevel);
        }
    }
}