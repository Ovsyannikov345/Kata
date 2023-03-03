using System;
using System.Collections.Generic;
using System.Linq;

public static class Permutations
{
    public static List<string> SinglePermutations(string source)
    {
        List<string> permutations = GetPermutations(source);

        permutations = permutations.Distinct()
                                   .ToList();

        return permutations;
    }

    // Calculates all possible (non-unique) permutations.
    private static List<string> GetPermutations(string remainingLetters)
    {
        // One possible permutation.
        if (remainingLetters.Length == 1)
        {
            return new List<string> { remainingLetters[0].ToString() };
        }

        // List of all possible permutations for current string.
        List<string> totalPermutations = new List<string>();

        for (var i = 0; i < remainingLetters.Length; i++)
        {
            // Taking a letter.
            char letter = remainingLetters[i];

            // Getting all permutations without taken letter.
            List<string> permutations = GetPermutations(remainingLetters.Remove(i, 1));

            // Appending the letter to all permutations.
            for (var j = 0; j < permutations.Count; j++)
            {
                permutations[j] = letter + permutations[j];
            }

            // Adding the permutations to total permutations.
            permutations.ForEach(permutation => totalPermutations.Add(permutation));
        }

        // Returning total permutations for current string.
        return totalPermutations;
    }
}