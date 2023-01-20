using System;
using System.Text.RegularExpressions;

namespace Message_Validator
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
    public static bool isAValidMessage(string text)
    {
        // Cheching for an empty string.
        if (text == string.Empty)
        {
            return true;
        }

        // First char always must be a digit.
        if (!char.IsDigit(text[0]))
        {
            return false;
        }

        // Dividing text into numbers and messages.
        string numberPattern = @"[0-9]+";

        string messagePattern = @"[a-zA-Z]+";

        MatchCollection numbers = Regex.Matches(text, numberPattern);

        MatchCollection messages = Regex.Matches(text, messagePattern);

        // Counts must be equal.
        if (numbers.Count != messages.Count)
        {
            return false;
        }

        // Comparing numbers with messages length.
        for (var i = 0; i < numbers.Count; i++)
        {
            if (int.Parse(numbers[i].Value) != messages[i].Length)
            {
                return false;
            }
        }

        return true;
    }
}