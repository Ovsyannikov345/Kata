using System;
using System.Collections.Generic;

namespace Counting_Duplicates
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.DuplicateCount("aabBcde"));
        }
    }
}

public class Kata
{
    public static int DuplicateCount(string str)
    {
        // Preparing the initial string.
        str = str.ToLowerInvariant();

        // Converting it to the list of chars.
        List<char> letters = new List<char>(str.ToCharArray());

        int duplicateCount = 0;

        // Checking all letters in list.
        for (var i = 0; i < letters.Count - 1; i++)
        {
            // Comparing current letter to other letters in list.
            for (var j = i + 1; j < letters.Count; j++)
            {
                // If the duplicate was found, all occurrences of current letter should be removed.
                if (letters[i] == letters[j])
                {
                    duplicateCount++;

                    char duplicateLetter = letters[i];

                    letters.RemoveAll(letter => letter == duplicateLetter);
                    i--;

                    break;
                }
            }
        }

        return duplicateCount;
    }
}