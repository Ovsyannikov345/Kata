public static class Kata
{
    public static string Rgb(int r, int g, int b)
    {
        return ConvertToHex(r) + ConvertToHex(g) + ConvertToHex(b);
    }

    private static string ConvertToHex(int number)
    {
        if (number < 0)
        {
            number = 0;
        }
        else if (number > 255)
        {
            number = 255;
        }

        return number.ToString("X2");
    }
}