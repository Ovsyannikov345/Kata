using System;
using System.Linq;

namespace _6kyu_Fibonacci__Tribonacci_and_friends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Xbonacci
{
    public double[] xbonacci(double[] signature, int n)
    {
        // Processing case when only part of signature has to be returned.
        if (n <= signature.Length)
        {
            return signature[..n];
        }

        // Prepating sequence array.
        double[] sequence = new double[n];

        Array.Copy(signature, sequence, signature.Length);

        // Calculating each number in sequence.
        for (var i = signature.Length; i < sequence.Length; i++)
        {
            sequence[i] = sequence[(i - signature.Length)..i].Sum();
        }

        return sequence;
    }
}