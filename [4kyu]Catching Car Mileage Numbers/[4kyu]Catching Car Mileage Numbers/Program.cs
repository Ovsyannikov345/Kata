using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static int IsInteresting(int number, List<int> awesomePhrases)
    {
        int interestLevel = 2;

        for (var i = 0; i <= 2; i++)
        {
            if (number < 100)
            {
                interestLevel = 1;
                number++;

                continue;
            }

            if (awesomePhrases.Contains(number))
            {
                return interestLevel;
            }

            if (IsFollowedByZeros(number) || IsSameNumber(number) || IsIncrementing(number) || IsDecrementing(number) || IsPalindrome(number))
            {
                return interestLevel;
            }

            interestLevel = 1;
            number++;
        }

        return 0;
    }

    private static bool IsFollowedByZeros(int source)
    {
        string number = source.ToString();

        return number[1..].All(digit => digit == '0');
    }

    private static bool IsSameNumber(int source)
    {
        string number = source.ToString();

        return number.All(digit => digit == number[0]);
    }

    private static bool IsIncrementing(int source)
    {
        string number = source.ToString();

        for (var i = 0; i < number.Length - 1; i++)
        {
            int difference = int.Parse(number.Substring(i + 1, 1)) - int.Parse(number.Substring(i, 1));

            if (difference != 1 && difference != -9)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsDecrementing(int source)
    {
        string number = source.ToString();

        for (var i = 0; i < number.Length - 1; i++)
        {
            int difference = int.Parse(number.Substring(i, 1)) - int.Parse(number.Substring(i + 1, 1));

            if (difference != 1)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPalindrome(int source)
    {
        string number = source.ToString();

        for (var i = 0; i < number.Length; i++)
        {
            if (number[i] != number[^(i + 1)])
            {
                return false;
            }
        }

        return true;
    }
}