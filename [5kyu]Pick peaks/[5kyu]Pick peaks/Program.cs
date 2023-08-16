using System;
using System.Collections.Generic;

public static class PickPeaks
{
    public static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        Dictionary<string, List<int>> peaks = new Dictionary<string, List<int>>()
        {
            ["pos"] = new List<int>(),
            ["peaks"] = new List<int>(),
        };

        // Peaks are impossible.
        if (arr.Length < 3)
        {
            return peaks;
        }

        // Checking all elements except edges.
        for (var i = 1; i < arr.Length - 1; i++)
        {
            // Checking left side.
            if (arr[i - 1] >= arr[i])
            {
                continue;
            }

            // Checking right side.
            int j = i + 1;

            while (j < arr.Length)
            {
                // No peak.
                if (arr[j] > arr[i])
                {
                    break;
                }

                // Peak is found, adding the peak or the plateau start to the dictionary.
                if (arr[j] < arr[i])
                {
                    peaks["pos"].Add(i);
                    peaks["peaks"].Add(arr[i]);
                    break;
                }

                j++;
            }

            // Moving the pointer to the end of the plateau or it will stay on the peak.
            i = j - 1;
        }

        return peaks;
    }
}