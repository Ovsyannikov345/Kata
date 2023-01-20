using System;

public static class Kata
{
    public static string AddBinary(int a, int b)
    {
        a += b;

        return Convert.ToString(a, 2);
    }
}