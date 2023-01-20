using System;
using System.Linq;

namespace _7kyu_Vowel_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.GetVowelCount("abracadabra"));
        }
    }
}

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        return str.Count(x => vowels.Contains(x));
    }
}