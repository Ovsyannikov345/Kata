using System;
using System.Linq;

namespace _7kyu_Disemvowel_Trolls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static string Disemvowel(string str)
    {
        char[] vowels = { 'a', 'o', 'u', 'e', 'i', 'A', 'O', 'U', 'E', 'I' };

        return string.Join("", str.Where(x => !vowels.Contains(x)));
    }
}