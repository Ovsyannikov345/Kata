using System;

namespace _7kyu_Reverse_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

namespace Solution
{
    public static class Program
    {
        public static int[] reverseList(int[] list)
        {
            int[] reversed = new int[list.Length];
            
            for (var i = 0; i < reversed.Length; i++)
            {
                reversed[i] = list[^(i + 1)];
            }

            return reversed;
        }
    }
}