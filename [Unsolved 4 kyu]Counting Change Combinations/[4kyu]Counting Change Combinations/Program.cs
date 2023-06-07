using System;

public static class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        Array.Sort(coins);
        Array.Reverse(coins);

        return CountCombinationsRecursive(money, coins);
    }

    private static int CountCombinationsRecursive(int money, int[] coins)
    {
        if (money == 0)
        {
            return 1;
        }

        if (money < 0 || coins.Length == 0)
        {
            return 0;
        }

        int combinationsCount = 0;

        for (var i = 0; i < money / coins[0] + 1; i++)
        {
            combinationsCount += CountCombinationsRecursive(money - coins[0] * i, coins[1..]);
        }

        return combinationsCount;
    }
}