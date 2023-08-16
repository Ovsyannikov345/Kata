public class Kata
{
    public static string High(string source)
    {
        string[] words = source.Split();

        int maxScore = GetScore(words[0]);

        int winnerIndex = 0;

        for (var i = 1; i < words.Length; i++)
        {
            int score = GetScore(words[i]);

            if (score > maxScore)
            {
                maxScore = score;
                winnerIndex = i;
            }
        }

        return words[winnerIndex];
    }

    private static int GetScore(string word)
    {
        int score = 0;

        foreach (char letter in word)
        {
            score += letter - 96;
        }

        return score;
    }
}