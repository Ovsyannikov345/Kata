using System;
using System.Collections.Generic;

public class Decompose
{
    public string decompose(long number)
    {
        List<long> result = DecomposeRecursive(number * number, number - 1, out bool success);

        if (success)
        {
            return string.Join(' ', result);
        }

        return null;
    }

    private List<long> DecomposeRecursive(long remainingSum, long number, out bool success)
    {
        success = false;

        if (number == 0 && remainingSum == 0)
        {
            success = true;
            return new List<long>();
        }

        while (number > 0)
        {
            List<long> numbers;

            if (remainingSum < 2 * number * number)
            {
                numbers = DecomposeRecursive(remainingSum - number * number, (long)Math.Sqrt(remainingSum - number * number), out success);
            }
            else
            {
                numbers = DecomposeRecursive(remainingSum - number * number, number - 1, out success);
                
            }

            if (success)
            {
                numbers.Add(number);

                return numbers;
            }

            number--;
        }

        return new List<long>();
    }
}