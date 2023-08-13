using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RomanConvert
{
	public static string Solution(int number)
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
}