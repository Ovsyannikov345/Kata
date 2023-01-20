using System;
using System.Linq;

public static class Kata
{
    public static int Score(int[] dice)
    {
        foreach (int d in dice)
        {
            Console.Write(d + " ");
        }

        int onesCount = dice.Count(x => x == 1);

        int fivesCount = dice.Count(x => x == 5);

        int score = 0;

        if (onesCount >= 3)
        {
            score += 1000;
            onesCount -= 3;
        }

        while (onesCount > 0)
        {
            score += 100;
            onesCount--;
        }

        if (fivesCount >= 3)
        {
            score += 500;
            fivesCount -= 3;
        }

        while (fivesCount > 0)
        {
            score += 50;
            fivesCount--;
        }

        score += dice.Count(x => x == 2) >= 3 ? 200 : 0;
        score += dice.Count(x => x == 3) >= 3 ? 300 : 0;
        score += dice.Count(x => x == 4) >= 3 ? 400 : 0;
        score += dice.Count(x => x == 6) >= 3 ? 600 : 0;

        return score;
    }
}