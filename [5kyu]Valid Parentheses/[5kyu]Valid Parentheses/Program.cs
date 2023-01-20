using System;
using System.Collections.Generic;

namespace _5kyu_Valid_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Parentheses.ValidParentheses("()"));
        }
    }
}

public class Parentheses
{
    public static bool ValidParentheses(string input)
    {
        List<char> symbols = new List<char>(input);

        // Finding first pair of brackets.
        int openIndex = symbols.IndexOf('(');

        int closeIndex = symbols.IndexOf(')');

        // Processing pairs until we can't find the full pair.
        while (openIndex != -1 && closeIndex != -1)
        {
            // Opening bracket should be first.
            if (closeIndex < openIndex)
            {
                return false;
            }

            // Removing current pair.
            symbols.RemoveAt(openIndex);
            symbols.RemoveAt(closeIndex - 1);

            // Finding the next pair.
            openIndex = symbols.IndexOf('(');
            closeIndex = symbols.IndexOf(')');
        }

        // Checking if there is a bracket that has no pair.
        return openIndex == -1 && closeIndex == -1;
    }
}