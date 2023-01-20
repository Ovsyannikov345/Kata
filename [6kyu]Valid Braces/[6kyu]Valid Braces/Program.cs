using System;

namespace _6kyu_Valid_Braces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Brace
{
    public static bool validBraces(string braces)
    {
        int parenthesesCount = 0;

        int bracketsCount = 0;

        int curlyBracesCount = 0;

        foreach (var symbol in braces)
        {
            switch (symbol)
            {
                case '(':
                    parenthesesCount++;
                    break;
                case '[':
                    bracketsCount++;
                    break;
                case '{':
                    curlyBracesCount++;
                    break;
                case ')':
                    parenthesesCount--;

                    if (parenthesesCount < 0)
                    {
                        return false;
                    }

                    break;
                case ']':
                    bracketsCount--;

                    if (bracketsCount < 0)
                    {
                        return false;
                    }

                    break;
                case '}':
                    curlyBracesCount--;

                    if (curlyBracesCount < 0)
                    {
                        return false;
                    }

                    break;
            }
        }

        return parenthesesCount == 0 && bracketsCount == 0 && curlyBracesCount == 0;
    }
}