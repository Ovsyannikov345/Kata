using System;

namespace _7kyu_Row_Weights
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Kata
{
    public static int[] RowWeights(int[] weights)
    {
        int firstTeamWeight = 0;

        int secondTeamWeight = 0;

        for (var i = 0; i < weights.Length; i++)
        {
            if (i % 2 == 0)
            {
                firstTeamWeight += weights[i];
            }
            else
            {
                secondTeamWeight += weights[i];
            }
        }

        return new int[] { firstTeamWeight, secondTeamWeight };
    }
}