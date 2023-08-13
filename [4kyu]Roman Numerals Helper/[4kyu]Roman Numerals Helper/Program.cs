using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RomanNumerals
{
    public static string ToRoman(int number)
    {
        Dictionary<int, string> convertingPairs = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        StringBuilder romanNumber = new StringBuilder();

        while (number != 0)
        {
            var pair = convertingPairs.First(pair => pair.Key <= number);

            romanNumber.Append(pair.Value);
            number -= pair.Key;
        }

        return romanNumber.ToString();
    }

    public static int FromRoman(string romanNumber)
    {
        Dictionary<char, int> convertingPairs = new Dictionary<char, int>()
        {
            ['M'] = 1000,
            ['D'] = 500,
            ['C'] = 100,
            ['L'] = 50,
            ['X'] = 10,
            ['V'] = 5,
            ['I'] = 1,
        };

        int number = 0;

        for (var i = 0; i < romanNumber.Length - 1; i++)
        {
            if (convertingPairs[romanNumber[i]] < convertingPairs[romanNumber[i + 1]])
            {
                number -= convertingPairs[romanNumber[i]];
            }
            else
            {
                number += convertingPairs[romanNumber[i]];
            }
        }

        number += convertingPairs[romanNumber[^1]];

        return number;
    }
}