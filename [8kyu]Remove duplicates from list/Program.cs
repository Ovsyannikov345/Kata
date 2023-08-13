using System;
using System.Linq;

namespace Solution
{
  public static class Program
  {
    public static int[] distinct(int[] sequence)
    {
      return sequence.ToHashSet().ToArray();
    }
  }
}