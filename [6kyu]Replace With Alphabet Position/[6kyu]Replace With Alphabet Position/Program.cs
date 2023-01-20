using System.Linq;

public static class Kata
{
    public static string AlphabetPosition(string text)
    {
        char[] letters = text.ToLowerInvariant()
                             .Where(x => char.IsLetter(x))
                             .ToArray();

        int[] numbers = new int[letters.Length];

        for (var i = 0; i < letters.Length; i++)
        {
            numbers[i] = letters[i] - 'a' + 1;
        }

        return string.Join(' ', numbers);
    }
}