using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
    public static int CountSmileys(string[] smileys)
    {
        return smileys.Count(e => IsSmiley(e));
    }

    private static bool IsSmiley(string text) => Regex.IsMatch(text, @"^[:;][-~]{0,1}[)D]$");
}