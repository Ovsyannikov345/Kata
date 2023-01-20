using System.Collections.Generic;

public static class Kata
{
    public static object[] Unflatten(int[] flatArray)
    {
        List<object> unflattened = new List<object>();

        for (var i = 0; i < flatArray.Length; i++)
        {
            if (flatArray[i] < 3)
            {
                unflattened.Add(flatArray[i]);
            }
            else
            {
                if (flatArray.Length - i < flatArray[i])
                {
                    unflattened.Add(flatArray[i..]);
                    break;
                }
                else
                {
                    unflattened.Add(flatArray[i..(i + flatArray[i])]);
                    i += flatArray[i] - 1;
                }
            }
        }

        return unflattened.ToArray();
    }
}