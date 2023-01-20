using System;
using System.Collections.Generic;

namespace _6kyu_Collatz
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
    public static string Collatz(int n)
    {
        List<int> collatzList = new List<int>() { n };

        while (n != 1)
        {
            if (n % 2 == 0)
            {
                n = n / 2;
            }
            else
            {
                n = n * 3 + 1;
            }

            collatzList.Add(n);
        }

        return string.Join("->", collatzList);
    }
}