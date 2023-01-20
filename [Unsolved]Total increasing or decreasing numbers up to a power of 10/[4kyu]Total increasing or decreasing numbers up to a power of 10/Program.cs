using System;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _4kyu_Total_increasing_or_decreasing_numbers_up_to_a_power_of_10
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //for (var i = 0; i <= 30; i++)
            //{
            //    stopwatch.Start();

            //    Console.WriteLine("Argument: " + i);
            //    Console.WriteLine("Result: " + TotalIncreasingOrDecreasingNumbers.TotalIncDec(i));

            //    stopwatch.Stop();
            //    Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}ms.\n");
            //}
            
            //Console.ReadKey();

            for (var i = 2; i <= 10; i++)
            {
                Console.WriteLine("Argument: " + i);

                stopwatch.Start();
                Console.WriteLine("Result 1: " + TotalIncreasingOrDecreasingNumbers.GetIncreasingRecursive(9, i));
                stopwatch.Stop();
                Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}ms.");

                stopwatch.Restart();
                Console.WriteLine("Result 2: " + TotalIncreasingOrDecreasingNumbers.GetIncreasingRecursive2(9, i));
                stopwatch.Stop();
                Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}ms.\n");
            }
        }
    }
}

public class TotalIncreasingOrDecreasingNumbers
{
    public static BigInteger TotalIncDec(int x)
    {
        if (x == 0)
        {
            return 1;
        }

        BigInteger count = 0;

        for (var i = 0; i <= 9; i++)
        {
            //Console.WriteLine("Increasing");
            count += GetIncreasingRecursive(i, x);
            //Console.WriteLine("Decreasing");
            count += GetDecreasingRecursive(i, x);
        }

        count -= 10;

        count -= (x - 1) * 10;

        return count;
    }

    public static int GetIncreasingRecursive(int currentNumber, int limit)
    {
        if (limit == 0)
        {
            return 0;
        }

        //for (var i = 2; i > limit; i--)
        //{
        //    Console.Write("--");
        //}

        //Console.Write(currentNumber);
        //Console.WriteLine();

        int count = 1;

        for (var i = 1; i <= currentNumber; i++)
        {
            count += GetIncreasingRecursive(i, limit - 1);
        }

        return count;
    }

    public static int GetIncreasingRecursive2(int currentNumber, int limit)
    {
        if (limit == 0 || currentNumber > 9)
        {
            return 0;
        }

        return 1 + GetIncreasingRecursive2(currentNumber - 1, limit) + GetIncreasingRecursive2(currentNumber, limit - 1); 
    }

    public static int GetDecreasingRecursive(int currentNumber, int limit)
    {
        if (limit == 0)
        {
            return 0;
        }

        //for (var i = 2; i > limit; i--)
        //{
        //    Console.Write("--");
        //}

        //Console.Write(currentNumber);
        //Console.WriteLine();

        int count = 1;

        for (var i = 9; i >= currentNumber; i--)
        {
            count += GetDecreasingRecursive(i, limit - 1);
        }

        return count;
    }
}