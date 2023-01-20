using System;
using System.Text.RegularExpressions;

namespace Solution
{
    public static class Kata
    {
        public static string RemoveParentheses(string source)
        {
            string text = source;

            while (text.Contains('('))
            {
                text = Regex.Replace(text, @"[(]{1}[^()]*[)]{1}", string.Empty);
            }

            return text;
        }
    }
}