using System;
using System.Collections.Generic;

namespace _7kyu_Ordered_Count_of_Characters
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<char, int>> result = Solution.Kata.OrderedCount("abracadabra");

            foreach (var pair in result)
            {
                Console.WriteLine(pair.ToString());
            }
        }
    }
}

namespace Solution
{
    public class Kata
    {
        public static List<Tuple<char, int>> OrderedCount(string input)
        {
            List<Tuple<char, int>> result = new List<Tuple<char, int>>();

            List<char> letters = new List<char>(input.ToCharArray());

            while (letters.Count > 0)
            {
                // Memorising the current letter.
                char currentLetter = letters[0];

                int count = 0;

                // Counting all occurrences of current letter and removing them.
                for (var j = 0; j < letters.Count; j++)
                {
                    if (letters[j] == currentLetter)
                    {
                        count++;
                        letters.RemoveAt(j);
                        j--;
                    }
                }

                // Creating new tuple with current letter and it's count.
                result.Add(Tuple.Create(currentLetter, count));
            }

            return result;
        }
    }
}