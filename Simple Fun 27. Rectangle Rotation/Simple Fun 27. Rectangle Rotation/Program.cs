using System;

namespace myjinxin
{
    public class Kata
    {
        public int RectangleRotation(int a, int b)
        {
            int pointsA1 = (int)(a / 2 / Math.Sqrt(2)) * 2 + 1;

            int pointsA2 = a / Math.Sqrt(2) >= pointsA1 ? pointsA1 + 1 : pointsA1 - 1;

            int pointsB1 = (int)(b / 2 / Math.Sqrt(2)) * 2 + 1;

            int pointsB2 = b / Math.Sqrt(2) >= pointsB1 ? pointsB1 + 1 : pointsB1 - 1;

            return pointsA1 * pointsB1 + pointsA2 * pointsB2;
        }
    }
}