using System;
using System.Collections.Generic;

public class RangeExtraction
{
    public static string Extract(int[] args)
    {
        Array.Reverse(args);

        List<string> result = new List<string>();

        Stack<int> stack = new Stack<int>(args);

        while (stack.Count > 0)
        {
            List<int> sequense = new List<int>();

            while (sequense.Count == 0 || stack.Peek() - sequense[^1] == 1)
            {
                sequense.Add(stack.Pop());

                if (stack.Count == 0)
                {
                    break;
                }
            }

            if (sequense.Count == 1)
            {
                result.Add(sequense[0].ToString());
            }
            else if (sequense.Count == 2)
            {
                result.Add($"{sequense[0]},{sequense[1]}");
            }
            else
            {
                result.Add($"{sequense[0]}-{sequense[^1]}");
            }
        }

        return string.Join(',', result);
    }
}