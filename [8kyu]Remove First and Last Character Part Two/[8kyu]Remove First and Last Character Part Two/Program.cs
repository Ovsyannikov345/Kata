using System;

public static class Kata
{
    public static string Array(string sequence)
    {
        string[] elements = sequence.Split(',', StringSplitOptions.TrimEntries);

        if (elements.Length < 3)
        {
            return null;
        }

        return string.Join(' ', elements[1..^1]);
    }
}