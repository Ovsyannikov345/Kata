using System;

namespace _7kyu_Automorphic_Number
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
    public static string positiveResult { get; } = "Automorphic";

    public static string negativeResult { get; } = "Not!!";

    public static string Automorphic(int n)
    {
        string value = n.ToString();

        string squareValue = (n * n).ToString();

        if (squareValue.EndsWith(value))
        {
            return positiveResult;
        }
        else
        {
            return negativeResult;
        }
    }
}