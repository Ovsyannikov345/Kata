using System;
using System.Numerics;

public static class Kata
{
    public static BigInteger Perimeter(int n)
    {
        // Simple cases.
        if (n < 0)
        {
            throw new ArgumentException($"{nameof(n)} must be non-negative.");
        }

        if (n == 0)
        {
            return 4;
        }

        if (n == 1)
        {
            return 6;
        }

        BigInteger perimeter = 6;

        int squareNumber = 2;

        (BigInteger, BigInteger) previousSides = (1, 1);

        while (squareNumber <= n)
        {
            // Adding new square.
            perimeter += 2 * (previousSides.Item1 + previousSides.Item2);

            // Calculating next side.
            BigInteger nextSide = previousSides.Item1 + previousSides.Item2;

            previousSides.Item1 = previousSides.Item2;
            previousSides.Item2 = nextSide;

            squareNumber++;
        }

        return perimeter;
    }
}