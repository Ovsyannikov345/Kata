using System;

public class Tournament
{
    public static (int, int)[][] BuildMatchesTable(int teamsCount)
    {
        // Simple case.
        if (teamsCount == 2)
        {
            return new[] { new[] { (1, 2) } };
        }

        // Preparing matches table.
        (int, int)[][] matchesTable = new (int, int)[teamsCount - 1][];

        for (var i = 0; i < matchesTable.Length; i++)
        {
            matchesTable[i] = new (int, int)[teamsCount / 2];
        }

        // Preparing table where each row represents a match.
        // Looks like:
        // 6 1
        // 5 2
        // 4 3
        int[,] teamsPool = new int[teamsCount / 2, 2];

        for (var i = 0; i < teamsCount / 2; i++)
        {
            teamsPool[i, 0] = teamsCount - i;
            teamsPool[i, 1] = i + 1;
        }

        // Transfering each row from the teamsPool to the matchTable and rotating the pool after each round.
        for (var round = 0; round < teamsCount - 1; round++)
        {
            for (var game = 0; game < teamsCount / 2; game++)
            {
                
                matchesTable[round][game] = (teamsPool[game, 0], teamsPool[game, 1]);
            }

            RotatePool();
        }

        return matchesTable;

        void RotatePool()
        {
            // Pool should be rotated clockwise, but 1 should stay in place.
            // Example
            // 6 1    5 1
            // 5 2 => 4 6
            // 4 3    3 2
            var tempTeamNumber = teamsPool[0, 0];

            for (var i = 0; i < teamsCount / 2 - 1; i++)
            {
                teamsPool[i, 0] = teamsPool[i + 1, 0];
            }

            teamsPool[teamsCount / 2 - 1, 0] = teamsPool[teamsCount / 2 - 1, 1];

            for (var i = teamsCount / 2 - 1; i > 1; i--)
            {
                teamsPool[i, 1] = teamsPool[i - 1, 1];
            }

            teamsPool[1, 1] = tempTeamNumber;
        }
    }
}