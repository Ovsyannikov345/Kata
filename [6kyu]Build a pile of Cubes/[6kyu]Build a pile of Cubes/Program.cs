using System;

public class ASum
{
	public static long findNb(long volume)
	{
		int largestSize = 0;

		while (volume > 0)
        {
			largestSize++;
			volume -= (long)Math.Pow(largestSize, 3);
        }

		if (volume == 0)
        {
			return largestSize;
        }

		return -1;
	}
}
