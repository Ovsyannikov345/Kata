using System;
using System.Collections.Generic;

public static class Kata
{
    public static int MinDistance(int n)
    {
        List<int> factors = new List<int>();

        int limit = (int)Math.Sqrt(n);

        // Adding all factors except square root.
        for (var i = 1; i < limit; i++)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                factors.Add(n / i);
            }
        }

        // Adding square root as factor if needed.
        if (n % limit == 0)
        {
            factors.Add(limit);
        }

        // Finding min difference between factors.
        factors.Sort();

        int minDistance = int.MaxValue;

        for (var i = 0; i < factors.Count - 1; i++)
        {
            if (factors[i + 1] - factors[i] < minDistance)
            {
                minDistance = factors[i + 1] - factors[i];
            }
        }

        return minDistance;
    }
}