using System;
using System.Linq;

namespace How_many_stairs_will_Suzuki_climb_in_20_years
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Kata
{
    public static long StairsIn20(int[][] stairs)
    {
        return stairs.Select(x => x.Sum())
                     .Sum() * 20;
    }
}