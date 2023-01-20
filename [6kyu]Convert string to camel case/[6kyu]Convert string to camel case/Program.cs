using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string ToCamelCase(string str)
    {
        List<char> letters = str.ToList();

        int index = letters.FindIndex(letter => letter == '-' || letter == '_');

        while (index != -1)
        {
            letters.RemoveAt(index);
            letters[index] = char.ToUpperInvariant(letters[index]);

            index = letters.FindIndex(letter => letter == '-' || letter == '_');
        }

        return string.Join("", letters);
    }
}