using System;
using System.Text;

namespace Mumbling
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Accumul
{
    public static string Accum(string source)
    {
        source = source.ToLowerInvariant();

        StringBuilder sb = new StringBuilder();

        // Adding all letters in source string.
        for (var i = 0; i < source.Length; i++)
        {
            // First letter should be upper cased.
            sb.Append(char.ToUpperInvariant(source[i]));

            // Others should be lower cased.
            for (var j = 0; j < i; j++)
            {
                sb.Append(source[i]);
            }

            // Adding separator.
            sb.Append("-");
        }

        string result = sb.ToString();

        // Returning result without last separator if it exists.
        return result[..result.LastIndexOf('-')];
    }
}