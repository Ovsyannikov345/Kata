using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        // Empty sequence protection.
        if (!iterable.Any())
        {
            return Enumerable.Empty<T>();
        }

        List<T> result = new List<T>();

        // Element which copies should be ignored.
        T currentElement = iterable.First();

        result.Add(currentElement);

        foreach (T element in iterable)
        {
            // Adding element that differs.
            if (!element.Equals(currentElement))
            {
                currentElement = element;
                result.Add(currentElement);
            }
        }

        return result;
    }
}