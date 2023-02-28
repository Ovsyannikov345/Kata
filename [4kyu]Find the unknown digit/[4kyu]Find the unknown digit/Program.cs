using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Runes
{
    public static int solveExpression(string expression)
    {
        HashSet<int> possibleDigits;

        // Extracting only numbers from the expression.
        string[] numbers = expression.Split(new char[] { '+', '-', '/', '*', '=' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Checking if there is no leading zero.
        if (numbers.Any(number => number.StartsWith("?") && number.Length > 1))
        {
            possibleDigits = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        else
        {
            possibleDigits = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        // Digits that present in expression.
        HashSet<int> takenDigits = Regex.Matches(expression, @"\d{1}")
                                        .Select(x => int.Parse(x.Value))
                                        .ToHashSet();

        // Leaving only untaken digits.
        possibleDigits.ExceptWith(takenDigits);

        // Trying all of the remaining digits.
        foreach (int digit in possibleDigits)
        {
            if (TryDigit(expression, digit))
            {
                return digit;
            }
        }

        return -1;
    }

    // Tries to substitute the digit.
    private static bool TryDigit(string expression, int digit)
    {
        // Replacing '?'.
        expression = expression.Replace("?", digit.ToString());

        return IsValidExpression(expression);
    }

    // Checks if the expression is valid.
    private static bool IsValidExpression(string expression)
    {
        // Regex that finds the operands.
        Regex regex = new Regex(@"\-{0,1}\d+");

        // Extracting operands.
        int[] numbers = regex.Matches(expression)
                             .Select(x => int.Parse(x.Value))
                             .ToArray();

        // Everything except operands.
        string remainingOperators = regex.Replace(expression, "");

        // First remaining char is operator.
        // In case 'x-y=z', first remaining char will be '='. So processing it like a sum.
        int operationResult = remainingOperators[0] switch
        {
            '+' => numbers[0] + numbers[1],
            '-' => numbers[0] - numbers[1],
            '*' => numbers[0] * numbers[1],
            '/' => numbers[0] / numbers[1],
            _ => numbers[0] + numbers[1],
        };

        // Checking the equality.
        return operationResult == numbers[2];
    }
}