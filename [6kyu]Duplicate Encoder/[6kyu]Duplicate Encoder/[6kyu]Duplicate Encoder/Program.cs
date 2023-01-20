using System.Collections.Generic;

public class Kata
{
    public static string DuplicateEncode(string word)
    {
        word = word.ToLowerInvariant();

        Dictionary<char, int> lettersCounts = new Dictionary<char, int>();

        foreach (var letter in word)
        {
            if (lettersCounts.ContainsKey(letter))
            {
                lettersCounts[letter]++;
            }
            else
            {
                lettersCounts.Add(letter, 1);
            }
        }

        char[] letters = word.ToCharArray();

        for (var i = 0; i < letters.Length; i++)
        {
            if (lettersCounts[letters[i]] > 1)
            {
                letters[i] = ')';
            }
            else
            {
                letters[i] = '(';
            }
        }

        return new string(letters);
    }
}