using System.Collections.Generic;
using System.Linq;

class MorseCodeDecoder
{
	public static string Decode(string morseCode)
	{
		IEnumerable<string> words = morseCode.Trim()
											 .Split("   ")
											 .Select(word => DecodeWord(word));

		return string.Join(" ", words);
	}

	private static string DecodeWord(string morseCode)
    {
		IEnumerable<string> letters = morseCode.Split(' ')
											   .Select(x => MorseCode.Get(x));

		return string.Join("", letters);
    }
}