using System.Linq;

public class Persist
{
	public static int Persistence(long number)
	{
		int iterations = 0;

		while (number > 9)
        {
			number = number.ToString()
						   .Select(x => int.Parse(x.ToString()))
						   .Aggregate((x, y) => x * y);

			iterations++;
        }

		return iterations;
	}
}