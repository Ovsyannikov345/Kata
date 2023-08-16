using System;
using System.Linq;

public class Kata
{
    public static int FindEvenIndex(int[] arr)
    {
        int rightSum = arr.Skip(1).Sum();

        if (rightSum == 0)
        {
            return 0;
        }

        int leftSum = 0;

        for (var i = 1; i < arr.Length; i++)
        {
            leftSum += arr[i - 1];
            rightSum -= arr[i];

            if (rightSum == leftSum)
            {
                return i;
            }
        }

        return -1;
    }
}