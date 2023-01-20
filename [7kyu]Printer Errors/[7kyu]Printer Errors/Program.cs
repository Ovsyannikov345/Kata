using System;
using System.Text.RegularExpressions;

namespace _7kyu_Printer_Errors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Printer
{
    public static string PrinterError(string sequence)
    {
        string allowedPattern = @"[a-m]{1}";

        int errorsCount = sequence.Length - Regex.Matches(sequence, allowedPattern).Count;

        return $"{errorsCount}/{sequence.Length}";
    }
}
