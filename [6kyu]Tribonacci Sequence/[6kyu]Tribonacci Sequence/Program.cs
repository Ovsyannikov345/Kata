using System;
using System.Linq;

namespace _6kyu_Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}

public class Xbonacci
{
    public double[] Tribonacci(double[] signature, int n)
    {
        // Processing case when only part of signature has to be returned.
        if (n <= 3)
        {
            return signature[..n];
        }

        // Prepating sequence array.
        double[] sequence = new double[n];

        Array.Copy(signature, sequence, 3);

        // Calculating each number in sequence.
        for (var i = 3; i < sequence.Length; i++)
        {
            sequence[i] = sequence[(i - 3)..i].Sum();
        }

        return sequence;
    }
}