using System;
using System.Collections.Generic;

public static class Kata
{
    public static string ExpandedForm(long number)
    {
        List<long> parts = new();

        long i = 10;

        while (number != 0)
        {
            long part = number % i;

            if (part != 0)
            {
                parts.Add(part);
                number -= part;
            }

            i *= 10;
        }

        parts.Reverse();

        return string.Join(" + ", parts);
    }
}