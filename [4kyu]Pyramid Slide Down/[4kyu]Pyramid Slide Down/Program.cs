public class PyramidSlideDown
{
    public static int LongestSlideDown(int[][] pyramid)
    {
        for (var i = pyramid.Length - 2; i >= 0; i--)
        {
            for (var j = 0; j < pyramid[i].Length; j++)
            {
                if (pyramid[i + 1][j] > pyramid[i + 1][j + 1])
                {
                    pyramid[i][j] += pyramid[i + 1][j];
                }
                else
                {
                    pyramid[i][j] += pyramid[i + 1][j + 1];
                }
            }
        }

        return pyramid[0][0];
    }
}