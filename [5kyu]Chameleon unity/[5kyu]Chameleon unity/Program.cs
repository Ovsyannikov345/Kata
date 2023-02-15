using System;
using System.Collections;
using System.Linq;

public static class Kata
{
    public static int Chameleon(int[] chameleons, int desiredColor)
    {
        // Already desired chameleons (reserve for equalizing other colors).
        int desired = chameleons[desiredColor];

        // Other colored chameleons.
        chameleons = chameleons.Where((x, i) => i != desiredColor).ToArray();

        // The difference that should be compensated by desired.
        int unpaired = Math.Abs(chameleons[0] - chameleons[1]);

        // Already equal.
        if (unpaired == 0)
        {
            return chameleons[0];
        }

        // Can't become equal.
        if (unpaired % 3 != 0 || unpaired / 3 > desired)
        {
            return -1;
        }

        // Some math logic.
        int meetingsToEqualize = unpaired / 3;

        int meetingsToDesiredColor = chameleons.Max() - meetingsToEqualize;

        return meetingsToEqualize + meetingsToDesiredColor;
    }
}