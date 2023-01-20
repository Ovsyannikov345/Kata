using System;

namespace Range_Bit_Counting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

namespace myjinxin
{
    public class Kata
    {
        public int RangeBitCount(int a, int b)
        {
            int count = 0;

            while (a <= b)
            {
                count += GetBitsCount(a);
                a++;
            }

            return count;
        }

        public static int GetBitsCount(int number)
        {
            int count = 0;

            while (number > 0)
            {
                if (number % 2 == 1)
                {
                    count++;
                }

                number >>= 1;
            }

            return count;
        }
    }
}