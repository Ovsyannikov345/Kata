using System;
using System.Collections.Generic;

namespace Magnitude_
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Magnitude.SqrModulus(new List<object> { "cart", 3, 4, 3, 4 }));
        }
    }
}

public static class Magnitude
{
    // Represents the list that should be returned if something goes wrong.
    private static List<object> exceptionList = new List<object> { false, -1, 1 };

    public static List<object> SqrModulus(List<object> source)
    {
        // Checking the form of list.
        if (source is null || source.Count == 0 || source.Count % 2 == 0)
        {
            return exceptionList;
        }
        
        // Checking the first element.
        if (!(source[0] is string) || ((string)source[0] != "cart" && (string)source[0] != "polar"))
        {
            return exceptionList;
        }

        // Checking other elements.
        for (var i = 1; i < source.Count; i++)
        {
            if (!(source[i] is int))
            {
                return exceptionList;
            }
        }

        // Calculating the sum of modulus depending on the form of complex numbers.
        int sumOfModulus = 0;

        if ((string)source[0] == "cart")
        {
            for (var i = 1; i < source.Count; i += 2)
            {
                sumOfModulus += (int)source[i] * (int)source[i] + (int)source[i + 1] * (int)source[i + 1];
            }
        }
        else
        {
            for (var i = 1; i < source.Count; i += 2)
            {
                sumOfModulus += (int)source[i] * (int)source[i];
            }
        }

        // Calculating the greatest number got by rearranging the digits of sum.
        char[] digitsOfSum = sumOfModulus.ToString().ToCharArray();

        Array.Sort(digitsOfSum);
        Array.Reverse(digitsOfSum);

        int greatestSum = int.Parse(string.Join("", digitsOfSum));

        // Returning the result.
        return new List<object> { true, sumOfModulus, greatestSum };
    }
}