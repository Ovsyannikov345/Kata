using System.Linq;

public class Kata
{
    public static bool IsValidWalk(string[] walk)
    {
        if (walk.Length != 10)
        {
            return false;
        }

        if (walk.Count(x => x == "n") != walk.Count(x => x == "s"))
        {
            return false;
        }

        if (walk.Count(x => x == "e") != walk.Count(x => x == "w"))
        {
            return false;
        }

        return true;
    }
}