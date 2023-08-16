using System;
using System.Text.RegularExpressions;

public class StripCommentsSolution
{
    public static string StripComments(string text, string[] symbols)
    {
        string[] lines = text.Split(new char[] { '\n' });

        string commentSymbols = string.Join("", symbols);

        for (var i = 0; i < lines.Length; i++)
        {
            lines[i] = Regex.Replace(lines[i], $@"\s*[{commentSymbols}]+.*$", "").TrimEnd();
        }

        return string.Join("\n", lines);
    }
}