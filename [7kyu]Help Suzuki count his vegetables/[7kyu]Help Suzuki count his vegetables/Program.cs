using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _7kyu_Help_Suzuki_count_his_vegetables
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string str2 =
    "mushroom chopsticks chopsticks turnip mushroom carrot mushroom cabbage mushroom carrot tofu pepper cabbage " +
    "potato cucumber mushroom mushroom potato turnip chopsticks cabbage celery celery turnip pepper chopsticks " +
    "potato potato onion cabbage cucumber onion pepper onion cabbage potato tofu carrot cabbage cabbage turnip " +
    "mushroom cabbage cabbage cucumber cabbage chopsticks turnip pepper onion pepper onion mushroom turnip carrot " +
    "carrot tofu onion tofu chopsticks chopsticks chopsticks mushroom cucumber chopsticks carrot potato cabbage cabbage " +
    "carrot mushroom chopsticks mushroom celery turnip onion carrot turnip cucumber carrot potato mushroom turnip " +
    "mushroom cabbage tofu turnip turnip turnip mushroom tofu potato pepper turnip potato turnip celery carrot turnip";

        List<Tuple<int, string>> result = Suzuki.CountVegetables(str2);
            
            foreach (Tuple<int, string> item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

public class Suzuki
{
    public static List<Tuple<int, string>> CountVegetables(string source)
    {
        List<string> allowedVegetables = new List<string>(SuzukiHelper.Veggies);

        List<string> vegetableList = new List<string>(source.Split(' '));

        List<Tuple<int, string>> countedVegetables = new List<Tuple<int, string>>();

        // Removing vegetables that are not allowed.
        for (var i = 0; i < vegetableList.Count; i++)
        {
            if (!allowedVegetables.Contains(vegetableList[i]))
            {
                vegetableList.RemoveAt(i);
                i--;
            }
        }

        // Counting vegetables.
        while (vegetableList.Count > 0)
        {
            string currentVegetable = vegetableList[0];

            int count = 0;

            // Getting the count of occurrences of current vegetable and removing them.
            for (var i = 0; i < vegetableList.Count; i++)
            {
                if (vegetableList[i] == currentVegetable)
                {
                    count++;
                    vegetableList.RemoveAt(i);
                    i--;
                }
            }

            // Adding new tuple of count and current vegetable.
            countedVegetables.Add(new Tuple<int, string>(count, currentVegetable));
        }

        // Sotring the tuples using special comparer.
        countedVegetables.Sort(new TupleComparer());

        return countedVegetables;
    }
}

/// <summary>
/// Compares tuples with the count of each vegetable in descending order.
/// If the count of two vegetables is the same compares in reverse alphabetical order
/// </summary>
public class TupleComparer : IComparer<Tuple<int, string>>
{
    public int Compare(Tuple<int, string> x, Tuple<int, string> y)
    {
        // Compairing counts.
        if (x.Item1 != y.Item1)
        {
            return y.Item1 - x.Item1;
        }

        // Comparing names.
        for (var i = 0; i < x.Item2.Length && i < y.Item2.Length; i++)
        {
            if (x.Item2[i] != y.Item2[i])
            {
                return y.Item2[i] - x.Item2[i];
            }
        }

        return 0;
    }
}

public class SuzukiHelper
{
    public static string[] Veggies { get; } = { "cabbage", "carrot", "cucumber", "onion", "pepper", "potato" };
}