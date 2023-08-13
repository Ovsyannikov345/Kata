using System.Text.RegularExpressions;

public static class Kata
{
    public static string RemoveUrlAnchor(string url) => Regex.Replace(url, @"#.*", "");
}