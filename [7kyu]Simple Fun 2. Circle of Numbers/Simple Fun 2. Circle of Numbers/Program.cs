using System;

namespace Simple_Fun_2._Circle_of_Numbers
{
    internal static class Program
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
        public int CircleOfNumbers(int n, int firstNumber)
        {
            return firstNumber < n / 2 ? firstNumber + n / 2 : firstNumber - n / 2;
        }
    }
}