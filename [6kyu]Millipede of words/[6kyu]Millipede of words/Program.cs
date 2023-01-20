using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static bool Millipede(string[] words)
    {
        if (words.All(word => word.Length == 1) && words.Any(word => word != words[0]))
        {
            return false;
        }

        List<char> firstLetters = words.Select(word => word[0]).ToList();

        List<char> lastLetters = words.Select(word => word[^1]).ToList();

        for (var i = 0; i < firstLetters.Count; i++)
        {
            int index = lastLetters.IndexOf(firstLetters[i]);

            if (index != -1)
            {
                firstLetters.RemoveAt(i);
                lastLetters.RemoveAt(index);
                i--;
            }
        }

        return firstLetters.Count <= 1 && lastLetters.Count <= 1;
    }
}