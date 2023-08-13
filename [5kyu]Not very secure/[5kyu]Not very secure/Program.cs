using System.Text.RegularExpressions;

public class Kata
{
    public static bool Alphanumeric(string str)
    {
        var validPart = Regex.Matches(str, @"[a-zA-Z0-9]+");

        return validPart.Count == 1 && validPart[0].Value.Length == str.Length;
    }
}