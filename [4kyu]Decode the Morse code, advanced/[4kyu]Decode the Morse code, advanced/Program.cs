using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class MorseCodeDecoder
{
    // Bit code => Morse code.
    public static string DecodeBits(string bits)
    {
        bits = bits.Trim('0');

        int unitLength = GetUnitLength(bits);

        IEnumerable<string> words = bits.Split(new string('0', 7 * unitLength))
                                        .Select(word => DecodeBitWord(word, unitLength));

        return string.Join("   ", words);
    }

    // Morse code => readable format.
    public static string DecodeMorse(string morseCode)
    {
        IEnumerable<string> words = morseCode.Trim()
                                             .Split("   ")
                                             .Select(word => DecodeWord(word));

        return string.Join(" ", words);
    }

    // Calculates a length of 1 unit.
    private static int GetUnitLength(string bits)
    {
        // Length of unit is the min length of a sequence of 0 or 1.
        MatchCollection matches = Regex.Matches(bits, @"0+|1+");

        return matches.Min(match => match.Value.Length);
    }

    // Word in Morse code => readable word.
    private static string DecodeWord(string morseCode)
    {
        IEnumerable<string> letters = morseCode.Split(' ')
                                               .Select(letter => MorseCode.Get(letter));

        return string.Join("", letters);
    }

    // Word in bit code => word in Morse code.
    private static string DecodeBitWord(string bits, int unitLength)
    {
        IEnumerable<string> letters = bits.Split(new string('0', 3 * unitLength))
                                          .Select(letter => DecodeBitLetter(letter, unitLength));

        return string.Join(" ", letters);
    }

    // Letter in bit code => letter in Morse code.
    private static string DecodeBitLetter(string bits, int unitLength)
    {
        string code = bits.Replace(new string('1', 3 * unitLength), "-") // Replacing '1' with dashes.
                          .Replace(new string('1', unitLength), ".") // Remaining '1' are dots.
                          .Replace("0", ""); // Removing '0'.

        return code;
    }
}