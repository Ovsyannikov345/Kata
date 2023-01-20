using System.Collections.Generic;
using System.Linq;

public static class Intervals
{
    public static int SumIntervals((int, int)[] source)
    {
        // Empty sequence handling.
        if (source is null || source.Length == 0)
        {
            return 0;
        }

        // Sorting intervals by starts.
        List<(int start, int end)> intervals = source.OrderBy(x => x.Item1)
                                                     .ToList();

        // Checking each pair of adjacent intervals.
        for (var i = 0; i < intervals.Count - 1; i++)
        {
            // Checking for overlap.
            if (intervals[i + 1].start <= intervals[i].end)
            {
                // Checking if fisrt interval contains whole second interval.
                if (intervals[i + 1].end <= intervals[i].end)
                {
                    intervals.RemoveAt(i + 1);
                }
                else
                {
                    intervals[i] = (intervals[i].start, intervals[i + 1].end);
                    intervals.RemoveAt(i + 1);
                }

                i--;
            }
        }

        // Calculating total length.
        int total = intervals.Select(interval => interval.end - interval.start)
                             .Aggregate((total, interval) => total + interval);

        return total;
    }
}