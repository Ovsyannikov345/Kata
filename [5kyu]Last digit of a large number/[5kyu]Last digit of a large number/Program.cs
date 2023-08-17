using System;
using System.Collections.Generic;
using System.Numerics;

namespace Solution
{
    class LastDigit
    {
        public static int GetLastDigit(BigInteger n1, BigInteger n2)
        {
            if (n2 == 0)
            {
                return 1;
            }

            Dictionary<int, int[]> endings = new()
            {
                [0] = new int[] { 0 },
                [1] = new int[] { 1 },
                [2] = new int[] { 2, 4, 8, 6 },
                [3] = new int[] { 3, 9, 7, 1 },
                [4] = new int[] { 4, 6 },
                [5] = new int[] { 5 },
                [6] = new int[] { 6 },
                [7] = new int[] { 7, 9, 3, 1 },
                [8] = new int[] { 8, 4, 2, 6 },
                [9] = new int[] { 9, 1 },
            };

            int lastDigit = (int)(n1 % 10);

            int[] possibleEndings = endings[lastDigit];

            int endingIndex;

            if ((int)(n2 % possibleEndings.Length) == 0)
            {
                endingIndex = possibleEndings.Length - 1;
            }
            else
            {
                endingIndex = (int)(n2 % possibleEndings.Length) - 1;
            }

            return possibleEndings[endingIndex];
        }
    }
}