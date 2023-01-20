using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        Console.Write("Test: ");
        string test = Console.ReadLine();

        Console.WriteLine(Cryptarithm.Alphametics(test));
    }
}

public static class Cryptarithm
{
    public static string Alphametics(string source)
    {
        //[A, B, C, D]
        //[0, 1, 2, 3]

        char[] letters = source.ToCharArray()
                               .Where(letter => char.IsLetter(letter))
                               .Distinct()
                               .OrderBy(x => x)
                               .ToArray();

        byte[] digits = Enumerable.Range(0, letters.Length)
                                  .Select(x => (byte)x)
                                  .ToArray();

        string equation = ReplaceLetters(source, letters, digits);

        while (!CheckEquation(equation))
        {
            GetNewDigitsCombination(digits);

            //
            //Console.WriteLine(digits.Aggregate("",(string x, byte y) => x + y.ToString()));
            //

            equation = ReplaceLetters(source, letters, digits);
        }

        return equation;
    }

    private static string ReplaceLetters(string source, char[] letters, byte[] digits)
    {
        string equation = new string(source);

        for (var i = 0; i < letters.Length; i++)
        {
            equation = equation.Replace(letters[i].ToString(), digits[i].ToString());
        }

        return equation;
    }

    private static bool CheckEquation(string equation)
    {
        MatchCollection matches = Regex.Matches(equation, @"\d+");

        if (matches.Any(operand => operand.Value.StartsWith('0')))
        {
            return false;
        }

        int[] operands = matches.Select(x => int.Parse(x.Value))
                                .ToArray();

        if (operands[..^1].Aggregate((sum, operand) => sum + operand) == operands[^1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void GetNewDigitsCombination(byte[] digits)
    {
        do
        {
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    break;
                }
                else
                {
                    digits[i] = 0;
                }
            }
        }
        while (!IsUniqueDigits(digits));
    }

    private static bool IsUniqueDigits(byte[] digits)
    {
        for (var i = 0; i < digits.Length - 1; i++)
        {
            for (var j = i + 1; j < digits.Length; j++)
            {
                if (digits[i] == digits[j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}