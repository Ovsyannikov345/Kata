using System;
using System.Collections.Generic;

namespace _6kyu_Valid_Braces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Brace.validBraces("()[]{}");
        }
    }
}

public class Brace
{
    public static bool validBraces(string braces)
    {
        Stack<char> bracesOrder = new Stack<char>();

        foreach (var symbol in braces)
        {
            switch (symbol)
            {
                case '(':
                case '[':
                case '{':
                    bracesOrder.Push(symbol);
                    break;
                case ')':
                case ']':
                case '}':
                    if (bracesOrder.Count > 0 && CompareBraces(bracesOrder.Peek(), symbol))
                    {
                        bracesOrder.Pop();
                    }
                    else
                    {
                        return false;
                    }

                    break;
            }
        }

        return bracesOrder.Count == 0;
    }

    private static bool CompareBraces(char firstBrace, char secondBrace)
    {
        switch (firstBrace)
        {
            case '(':
                if (secondBrace == ')')
                {
                    return true;
                }

                break;
            case '[':
                if (secondBrace == ']')
                {
                    return true;
                }

                break;
            case '{':
                if (secondBrace == '}')
                {
                    return true;
                }

                break;
        }

        return false;
    }
}