using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _6kyu_Stop_gninnipS_My_sdroW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Kata
{
    public static string SpinWords(string sentence)
    {
        // Finding words that should be spinned(length >= 5).
        MatchCollection matches = Regex.Matches(sentence, @"\w{5,}");

        foreach (Match match in matches)
        {
            // Reversing word.
            string word = match.Value;

            string reversedWord = string.Join("", word.Reverse());

            // Replacing current word with it's reversed version.
            sentence = sentence.Replace(word, reversedWord);
        }

        return sentence;
    }
}