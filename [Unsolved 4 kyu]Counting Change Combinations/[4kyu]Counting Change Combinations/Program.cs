using System;
using System.Collections.Generic;
using System.Linq;

namespace _4kyu_Counting_Change_Combinations
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.CountCombinations(10000, new[] { 1,2,3,4 }));
        }
    }
}

public static class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        int maxCoinsCount = money / coins.Min();

        List<List<int>> combinations = GetAllCombinations(money, coins, maxCoinsCount);

        List<List<int>> uniqueCombinations = GetUniqueCombinations(combinations);

        return uniqueCombinations.Count;
    }

    private static List<List<int>> GetAllCombinations(int amount, int[] coins, int remainingIterations)
    {
        if (remainingIterations == 0)
        {
            List<List<int>> result = new List<List<int>>();

            foreach (int coin in coins)
            {
                result.Add(new List<int> { coin });
            }

            return result;
        }

        List<List<int>> totalCombinations = new List<List<int>>();

        foreach (int coin in coins)
        {
            List<List<int>> currentCombinations = GetAllCombinations(amount, coins, remainingIterations - 1)
                                                 .ToList();

            foreach (List<int> combination in currentCombinations)
            {
                int combinationSum = combination.Sum();

                if (combinationSum == amount)
                {
                    totalCombinations.Add(combination);
                }
                else if (combinationSum + coin <= amount)
                {
                    combination.Add(coin);
                    totalCombinations.Add(combination);
                }
            }
        }

        return totalCombinations;
    }

    private static List<List<int>> GetUniqueCombinations(List<List<int>> combinations)
    {
        List<List<int>> uniqueCombinations = new List<List<int>>();

        foreach (List<int> combination in combinations)
        {
            combination.Sort();

            if (uniqueCombinations.Exists(x => x.SequenceEqual(combination)))
            {
                continue;
            }

            uniqueCombinations.Add(combination);
        }

        return uniqueCombinations;
    }
}