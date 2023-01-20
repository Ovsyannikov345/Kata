public class HumanTimeFormat
{
    private const int secondsInYear = 31_536_000;

    private const int secondsInDay = 86_400;

    private const int secondsInHour = 3_600;

    private const int secondsInMinute = 60;

    public static string formatDuration(int seconds)
    {
        if (seconds == 0)
        {
            return "now";
        }

        // Format: [years, days, hours, minutes, seconds]
        int[] timeInfo = new int[5];

        // Years.
        timeInfo[0] = seconds / secondsInYear;
        seconds = seconds % secondsInYear;

        // Days.
        timeInfo[1] = seconds / secondsInDay;
        seconds = seconds % secondsInDay;

        // Hours.
        timeInfo[2] = seconds / secondsInHour;
        seconds = seconds % secondsInHour;

        // Minutes.
        timeInfo[3] = seconds / secondsInMinute;
        seconds = seconds % secondsInMinute;

        // Seconds.
        timeInfo[4] = seconds;

        // Constructing a string.
        string humanFormat = string.Empty;

        if (timeInfo[0] != 0)
        {
            humanFormat += timeInfo[0] > 1 ? $"{timeInfo[0]} years" : $"{timeInfo[0]} year";
        }

        if (timeInfo[1] != 0)
        {
            if (humanFormat.Length != 0)
            {
                humanFormat += ", ";
            }

            humanFormat += timeInfo[1] > 1 ? $"{timeInfo[1]} days" : $"{timeInfo[1]} day";
        }

        if (timeInfo[2] != 0)
        {
            if (humanFormat.Length != 0)
            {
                humanFormat += ", ";
            }

            humanFormat += timeInfo[2] > 1 ? $"{timeInfo[2]} hours" : $"{timeInfo[2]} hour";
        }

        if (timeInfo[3] != 0)
        {
            if (humanFormat.Length != 0)
            {
                humanFormat += ", ";
            }

            humanFormat += timeInfo[3] > 1 ? $"{timeInfo[3]} minutes" : $"{timeInfo[3]} minute";
        }

        if (timeInfo[4] != 0)
        {
            if (humanFormat.Length != 0)
            {
                humanFormat += ", ";
            }

            humanFormat += timeInfo[4] > 1 ? $"{timeInfo[4]} seconds" : $"{timeInfo[4]} second";
        }

        // Replacing last comma with " and " if needed.
        int lastCommaIndex = humanFormat.LastIndexOf(',');

        if (lastCommaIndex != -1)
        {
            humanFormat = humanFormat[..lastCommaIndex] + " and " + humanFormat[(lastCommaIndex + 2)..];
        }

        return humanFormat;
    }
}