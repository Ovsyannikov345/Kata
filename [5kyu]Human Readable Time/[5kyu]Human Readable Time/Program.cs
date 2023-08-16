public static class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        return $"{seconds / 3600:D2}:{seconds % 3600 / 60:D2}:{seconds % 60:D2}";
    }
}