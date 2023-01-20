using System;

namespace _6kyu_Who_likes_it
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public static class Kata
{
    public static string Likes(string[] names) => names.Length switch
    {
        0 => "no one likes this",
        1 => $"{names[0]} likes this",
        2 => $"{names[0]} and {names[1]} like this",
        3 => $"{names[0]}, {names[1]} and {names[2]} like this",
        _ => $"{names[0]}, {names[1]} and {names.Length - 2} others like this",
    };
}