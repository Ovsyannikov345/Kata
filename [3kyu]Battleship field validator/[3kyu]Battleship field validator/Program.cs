using System;

namespace _3kyu_Battleship_field_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

            Console.WriteLine(Solution.BattleshipField.ValidateBattlefield(field));
        }
    }
}

namespace Solution
{
    public static class BattleshipField
    {
        // Each element represents the required count of ships of each type.
        // requiredCount[0] - Submarines.
        // requiredCount[1] - Destroyers.
        // requiredCount[2] - Cruisers.
        // requiredCount[3] - Battleships.
        public static readonly int[] requiredShipsCount = { 4, 3, 2, 1 };

        // Ships shouldn't be bigger than this value.
        public static readonly int maxShipLength = 4;

        public static bool ValidateBattlefield(int[,] sourceField)
        {
            // Checking the form of the field.
            if (sourceField == null || sourceField.GetLength(0) != sourceField.GetLength(1))
            {
                return false;
            }

            // Creating the copy of the field so it will not change the source parameter.
            int fieldSize = sourceField.GetLength(0);

            int[,] field = new int[fieldSize, fieldSize];

            Array.Copy(sourceField, field, fieldSize * fieldSize);

            // Checking for overlap and contact.
            if (CheckOverlapAndContact(field))
            {
                return false;
            }

            int[] shipsCount = new int[] { 0, 0, 0, 0 };

            // Finding the point of the ship. It will always be the left or the top point.
            for (var i = 0; i < fieldSize; i++)
            {
                for (var j = 0; j < fieldSize; j++)
                {
                    if (field[i, j] == 1)
                    {
                        // Getting the ship length and removing it from the field.
                        int shipLength = GetShipLength(field, i, j);

                        if (shipLength > maxShipLength) // Length should not be bigger than the max length.
                        {
                            return false;
                        }
                        else // Increasing the count otherwise.
                        {
                            shipsCount[shipLength - 1] += 1;
                        }
                    }
                }
            }

            // Comparing ships count and required ships count.
            for (var i = 0; i < shipsCount.Length; i++)
            {
                // Values should not be different.
                if (shipsCount[i] != requiredShipsCount[i])
                {
                    return false;
                }
            }

            // If the field has passed all checks, it's valid and ready to be played:D
            return true;
        }

        /// <summary>
        /// Checks the field for overlap or contact of ships.
        /// </summary>
        /// <param name="field">Field to check.</param>
        /// <returns>True if there is an ovelap or contact. False otherwise.</returns>
        private static bool CheckOverlapAndContact(int[,] field)
        {
            int fieldSize = field.GetLength(0);

            // Checking all points with 1 except points on the edges.
            for (var i = 1; i < fieldSize - 1; i++)
            {
                for (var j = 1; j < fieldSize - 1; j++)
                {
                    if (field[i, j] == 0)
                    {
                        continue;
                    }

                    // Checking for the ship on the corner and checking the ship to be straight line.
                    if (field[i - 1, j - 1] == 1 || field[i - 1, j + 1] == 1 || field[i + 1, j + 1] == 1 || field[i + 1, j - 1] == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Calculates the length of the ship that occupies the given point.
        /// Method also removes the current ship from the field.
        /// </summary>
        /// <param name="field">Field with ships.</param>
        /// <param name="row">First index of the point.</param>
        /// <param name="column">Second index of the point.</param>
        /// <returns>The length of the ship that occupies the given point.</returns>
        private static int GetShipLength(int[,] field, int row, int column)
        {
            // It should be mentioned that in the main method we are checking field from the top left corner.
            // So the ship is always downward or rightward.
            int fieldSize = field.GetLength(0);

            int shipLength = 0;

            if (field[row + 1, column] == 1) // If the ship is downward.
            {
                // Counting the size of ship and removing the ship from the field.
                while (field[row, column] == 1 && row < fieldSize)
                {
                    shipLength++;
                    field[row, column] = 0;
                    row++;
                }
            }
            else if (field[row, column + 1] == 1) // If the ship is rightward.
            {
                // Counting the size of ship and removing the ship from the field.
                while (field[row, column] == 1 && column < fieldSize)
                {
                    shipLength++;
                    field[row, column] = 0;
                    column++;
                }
            }
            else // The ship has size 1 otherwise
            {
                shipLength = 1;
                field[row, column] = 0;
            }

            return shipLength;
        }
    }
}
