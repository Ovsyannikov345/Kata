using System.Collections.Generic;
using System.Linq;

public static class Mixing
{
    public static string Mix(string s1, string s2)
    {
        Dictionary<char, int> lettersCounts1 = CountLowerLetters(s1);

        Dictionary<char, int> lettersCounts2 = CountLowerLetters(s2);

        List<(char letter, int count, char owner)> lettersCounts = MergeDictionaries(lettersCounts1, lettersCounts2)
                                                                  .OrderByDescending(x => x.count)
                                                                  .ThenBy(x => x.owner)
                                                                  .ThenBy(x => x.letter)
                                                                  .ToList();

        return GetStringRepresentation(lettersCounts);
    }

    // Counts letters and returns a dictionary.
    // Key = letter.
    // Value = it's count.
    private static Dictionary<char, int> CountLowerLetters(string text)
    {
        Dictionary<char, int> lettersCounts = new Dictionary<char, int>();

        foreach (char letter in text)
        {
            // Not a valid symbol.
            if (!char.IsLower(letter))
            {
                continue;
            }

            // Letter hasn't been counted.
            if (!lettersCounts.ContainsKey(letter))
            {
                int count = text.Count(x => x == letter);

                // Letter should occur more than once.
                if (count > 1)
                {
                    lettersCounts.Add(letter, count);
                }
            }
        }

        return lettersCounts;
    }

    // Merges two dictionaries into one list.
    // Key = letter.
    // Value = it's count.
    // Owner = number of the dictionary (1/2 or '=' if both).
    private static List<(char letter, int count, char owner)> MergeDictionaries(Dictionary<char, int> dictionary1, Dictionary<char, int> dictionary2)
    {
        // Removing duplicates if possible (if count is not equal).
        foreach (char key in dictionary1.Keys)
        {
            // Duplicate exists.
            if (dictionary2.ContainsKey(key))
            {
                // Leaving the one with more occurences.
                if (dictionary1[key] > dictionary2[key])
                {
                    dictionary2.Remove(key);
                }
                else if (dictionary1[key] < dictionary2[key])
                {
                    dictionary1.Remove(key);
                }
            }
        }

        List<(char letter, int count, char owner)> mergeResult = new();

        // Merging the dictionaries.
        foreach (char key in dictionary1.Keys)
        {
            // Both are owners.
            if (dictionary2.ContainsKey(key))
            {
                mergeResult.Add((key, dictionary1[key], '='));
            }
            else // First is owner.
            {
                mergeResult.Add((key, dictionary1[key], '1'));
            }
        }

        foreach (char key in dictionary2.Keys)
        {
            // Second is owner.
            if (!dictionary1.ContainsKey(key))
            {
                mergeResult.Add((key, dictionary2[key], '2'));
            }
        }

        return mergeResult;
    }

    // Converts list into required string format.
    private static string GetStringRepresentation(List<(char letter, int count, char owner)> lettersCounts)
    {
        IEnumerable<string> stringRepresentations = lettersCounts.Select(x => $"{x.owner}:{new string(x.letter, x.count)}");

        return string.Join('/', stringRepresentations);
    }
}