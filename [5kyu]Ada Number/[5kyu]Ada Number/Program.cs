using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace myjinxin
{
    public class Kata
    {
        public bool AdaNumber(string line)
        {
            line = line.Replace("_", string.Empty)
                       .ToLowerInvariant();

            // Checking if number is a simple decimal integer.
            if (Regex.IsMatch(line, @"^\d+$"))
            {
                return true;
            }

            // Checking the base.
            string numberBase = new string(line.TakeWhile(x => x != '#').ToArray());

            if (!int.TryParse(numberBase, out int parsedBase) || parsedBase < 2 || parsedBase > 16)
            {
                return false;
            }

            // Checking invalid symbols.
            char[] validSymbols = "#0123456789abcdef".Take(parsedBase + 1).ToArray();

            if (line.SkipWhile(x => x != '#').Except(validSymbols).Any())
            {
                return false;
            }

            // Checking if number is a specific integer.
            if (Regex.IsMatch(line, @$"^{parsedBase}#[0-9abcdef]+#$"))
            {
                return true;
            }

            return false;
        }
    }
}