using System;
using System.Linq;

namespace _7kyu_Balanced_Number
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
    public static string BalancedNumber(int num)
    {
        string number = num.ToString();

        int centerIndex = number.Length / 2;

        int leftSum = number.Length % 2 == 0 ? GetSumOfDigits(number[..(centerIndex - 1)]) : GetSumOfDigits(number[..centerIndex]);

        int rightSum = GetSumOfDigits(number[(centerIndex + 1)..]);

        return leftSum == rightSum ? "Balanced" : "Not Balanced";
    }

    public static int GetSumOfDigits(string number)
    {
        return number.Select(x => int.Parse(x.ToString()))
                     .Sum();
    }
}