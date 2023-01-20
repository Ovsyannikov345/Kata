using System.Runtime.CompilerServices;
using System;
using System.Linq;

public class Kata
{
  public static string DuplicateEncode(string word)
  {
    foreach (var letter in word)
    {
        if (letter == '(' || letter == ')')
        {
            continue;
        }

        int letterCount = word.Count(x => x == letter);

        if (letterCount > 1)
        {
            word.Replace(letter, ')');
        }
        else
        {
            word.Replace(letter, '(');
        }
    }

    return word;
  }
}