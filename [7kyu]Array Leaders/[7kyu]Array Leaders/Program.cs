using System;
using System.Collections.Generic;
using System.Linq;

namespace _7kyu_Array_Leaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static int[] ArrayLeaders(int[] numbers)
    {
        List<int> result = new List<int>();

        int sum = numbers.Sum();

        foreach (var number in numbers)
        {
            sum -= number;

            if (number > sum)
            {
                result.Add(number);
            }
        }

        return result.ToArray();
    }
}