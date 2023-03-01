using System;
using System.Collections.Generic;
using System.Linq;

public class WeightSort
{
	public static string orderWeight(string source)
	{
        string[] weights = source.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(weights, new WeightComparer());

        return string.Join(' ', weights);
	}
}

public class WeightComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        int weightDifference = GetWeight(x) - GetWeight(y);

        if (weightDifference != 0)
        {
            return weightDifference;
        }

        return x.CompareTo(y);
    }

    private static int GetWeight(string number)
    {
        return number.Select(digit => int.Parse(digit.ToString()))
                     .Sum();
    }
}