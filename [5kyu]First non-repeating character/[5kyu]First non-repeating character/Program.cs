using System;
using System.Collections.Generic;

public class Kata
{
    public static string FirstNonRepeatingLetter(string text)
    {
        char[] symbols = text.ToLower().ToCharArray();

        HashSet<char> foundSymbols = new();

        List<char> uniqueSymbols = new();

        foreach (char symbol in symbols)
        {
            if (!foundSymbols.Add(symbol))
            {
                uniqueSymbols.Remove(symbol);
            }
            else
            {
                uniqueSymbols.Add(symbol);
            }
        }

        if (uniqueSymbols.Count == 0)
        {
            return "";
        }

        if (text.IndexOf(uniqueSymbols[0]) != -1)
        {
            return uniqueSymbols[0].ToString();
        }
        else
        {
            return uniqueSymbols[0].ToString().ToUpper();
        }
    }
}