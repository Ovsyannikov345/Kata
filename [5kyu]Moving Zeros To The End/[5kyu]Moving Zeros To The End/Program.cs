public class Kata
{
    public static int[] MoveZeroes(int[] arr)
    {
        int[] result = new int[arr.Length];

        int placementIndex = 0;

        foreach (var item in arr)
        {
            if (item != 0)
            {
                result[placementIndex++] = item;
            }
        }

        return result;
    }
}