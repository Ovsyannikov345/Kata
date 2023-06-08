using System;
using System.Text;

public class Digits
{
    public static string Explode(string source)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char digit in source)
        {
            stringBuilder.Append(new string(digit, int.Parse(digit.ToString())));
        }

        return stringBuilder.ToString();
    }
}
