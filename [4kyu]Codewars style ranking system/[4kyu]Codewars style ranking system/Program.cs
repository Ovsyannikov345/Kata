using System;
using System.Collections.Generic;

public class User
{
    public int rank = -8;

    public int progress = 0;

    private readonly List<int> rankList = new List<int>() { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };

    public void incProgress(int actRank)
    {
        if (actRank < -8 || actRank == 0 || actRank > 8)
        {
            throw new ArgumentException("Invalid rank.");
        }

        if (rank == 8)
        {
            throw new ArgumentException("Max rank reached.");
        }

        progress += CalculateProgress(actRank);


        int increasedRankIndex = rankList.IndexOf(rank) + progress / 100;

        if (increasedRankIndex < rankList.Count)
        {
            rank = rankList[increasedRankIndex];
            progress %= 100;
        }
        else
        {
            rank = 8;
        }

        if (rank == 8)
        {
            progress = 0;
        }
    }

    private int CalculateProgress(int actRank)
    {
        int difference = rankList.IndexOf(actRank) - rankList.IndexOf(rank);

        return difference switch
        {
            < -1 => 0,
            -1 => 1,
            0 => 3,
            _ => 10 * difference * difference,
        };
    }
}