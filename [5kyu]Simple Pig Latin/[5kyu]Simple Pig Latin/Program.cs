using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Kata
{
    public static string PigIt(string str)
    {
        MatchCollection matches = Regex.Matches(str, @"\w+");

        StringBuilder stringBuilder = new StringBuilder(str);

        foreach (Match match in matches)
        {
            stringBuilder.Replace(match.Value, TranslateWord(match.Value), match.Index + stringBuilder.Length - str.Length, match.Length);
        }

        return stringBuilder.ToString();
    }

    private static string TranslateWord(string word)
    {
        if (word.Length == 1)
        {
            return word + "ay";
        }

        return word[1..] + word[0] + "ay";
    }
}