using System;

namespace Get_the_Middle_Character
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
    public static string GetMiddle(string text)
    {
        int centerIndex = text.Length / 2;

        return text.Length % 2 == 1 ? text[centerIndex..(centerIndex + 1)] : text[(centerIndex - 1)..(centerIndex + 1)];
    }
}