using System;
using System.Linq;

namespace _7kyu_Suzuki_needs_help_lining_up_his_students
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string[] result = Kata.LineupStudents("Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

public class Kata
{
    public static string[] LineupStudents(string a)
    {
        return a.Split(' ')
                .OrderByDescending(x => x.Length)
                .ThenByDescending(x => x)
                .ToArray();
    }
}