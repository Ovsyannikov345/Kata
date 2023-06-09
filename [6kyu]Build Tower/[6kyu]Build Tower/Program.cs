public class Kata
{
    public static string[] TowerBuilder(int floorsCount)
    {
        string[] tower = new string[floorsCount];

        int width = floorsCount * 2 - 1;

        for (var i = 0; i < tower.Length; i++)
        {
            int blocksCount = i * 2 + 1;

            int spacesCount = (width - blocksCount) / 2;

            tower[i] = string.Concat(new string(' ', spacesCount), new string('*', blocksCount), new string(' ', spacesCount));
        }

        return tower;
    }
}