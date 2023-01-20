using System;
using System.Collections.Generic;
using System.Linq;

namespace _7kyu_Square_Every_Digit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.SquareDigits(9119));
        }
    }
}

public class Kata
{
    public static int SquareDigits(int n)
    {
        string result = string.Join("", n.ToString()
                                         .Select(x => int.Parse(x.ToString())) // Parsing each digit.
                                         .Select(x => x * x)); // Squaring each digit.

        return int.Parse(result);
    }
}