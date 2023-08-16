using System;

public static class Kata
{
    public static int TrailingZeros(int n)
    {
        // Just some mathematic formulas.
        int kMax = (int)Math.Log(n, 5);

        int zerosCount = 0;

        for (var k = 1; k <= kMax; k++)
        {
            zerosCount += (int)(n / Math.Pow(5, k));
        }

        return zerosCount;
    }
}