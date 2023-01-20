using System;
using System.Collections.Generic;
using System.Linq;

namespace _4kyu_Counting_Change_Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "udshfguwaoehfasdvdfhweiutr";

            test = string.Join("", test.OrderBy(x => x).ToArray());

            Console.WriteLine(test);
        }
    }
}

public static class Kata
{
    public static int CountCombinations(int money, int[] coins)
    {
        int maxCoinsCount = money / coins.Min();

        List<List<int>> combinations = new List<List<int>>();

        foreach (var coin in coins)
        {
            combinations.Add(new List<int>() { coin });
        }


    }

    public static string[] GetAllCombinations(int[] initCoins, string[] combinations, int money, int limit)
    {
        // Выход из рекурсии.
        if (limit == 0)
        {
            return combinations;
        }

        // Декартово произведение.
        combinations = combinations.SelectMany(u => initCoins, (x, y) => string.Concat(x, y)).ToArray();

        // Удалнение комбинаций превыщающих сумму денег.

        // Удаление повторов.

        // Новая итерация.
    }
}