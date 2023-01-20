using System;
using System.Collections.Generic;
using System.Linq;

namespace _6kyu_Rectangle_into_Squares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = SqInRect.sqInRect(32, 72);

            foreach (var t in test)
            {
                Console.WriteLine(t);
            }
        }
    }
}

//public class SqInRect
//{
//    public static List<int> sqInRect(int length, int width)
//    {
//        if (length == width)
//        {
//            return null;
//        }

//        List<int> result = new List<int>();

//        int remainingArea = length * width;

//        int[] possibleSizes = Enumerable.Range(1, Math.Min(length, width))
//                                        .Reverse()
//                                        .ToArray();

//        foreach (var size in possibleSizes)
//        {
//            while (remainingArea != 0)
//        }
//    }
//}

public class SqInRect
{
    public static List<int> sqInRect(int length, int width)
    {
        // Validation.
        if (length == width)
        {
            return null;
        }

        // Making length bigger than width.
        if (length < width)
        {
            (length, width) = (width, length);
        }

        List<int> result = new List<int>();

        // Since width is the lowest value, it represents the size of current square.
        // So calculations are running until it reaches 0.
        while (width > 0)
        {
            // The count of squares of the same size is unknown, so adding them until they fit.
            while (width <= length)
            {
                result.Add(width);

                length -= width;
            }

            // When the squares of the same size don't fit anymore, they are removed from the rectangle.
            // So length and width of the rectangle are switched.
            (length, width) = (width, length);
        }

        return result;
    }
}