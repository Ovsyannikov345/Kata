using System;
using System.Collections.Generic;
public class Dinglemouse
{
    public class HelpSaveChristmas : IComparer<string>
    {
        public int Compare(string line1, string line2)
        {
            if (line1[0] == 'O')
            {
                return -1;
            }
            else if (line2[0] == 'O')
            {
                return 1;
            }
            else if (line1[0] == 'a')
            {
                return 1;
            }
            else if (line2[0] == 'a')
            {
                return -1;
            }
            else
            {
                return int.Parse(line2[0..2]) - int.Parse(line1[0..2]);
            }
        }
    }
}