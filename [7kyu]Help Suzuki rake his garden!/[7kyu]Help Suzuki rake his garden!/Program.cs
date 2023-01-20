using System;

namespace _7kyu_Help_Suzuki_rake_his_garden_
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
    public static string[] AllowedElements { get; } = { "rock", "gravel" };

    public static string ReplacingElement { get; } = "gravel";

    public static string RakeGarden(string garden)
    {
        string[] elements = garden.Split(' ');

        foreach (var element in elements)
        {
            if (!Array.Exists(AllowedElements, allowedElement => element == allowedElement))
            {
                garden = garden.Replace(element, ReplacingElement);
            }
        }

        return garden;
    }
}