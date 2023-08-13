using System;
using System.Collections.Generic;

public static class RomanDecode
{
    private static Dictionary<char, int> convertingPairs = new Dictionary<char, int>()
    {
        ['M'] = 1000,
        ['D'] = 500,
        ['C'] = 100,
        ['L'] = 50,
        ['X'] = 10,
        ['V'] = 5,
        ['I'] = 1,
    };

    public static int Solution(string romanNumber)
	{
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