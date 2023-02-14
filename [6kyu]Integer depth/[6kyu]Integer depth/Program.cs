namespace Solution
{
    public class Kata
    {
        public static int ComputeDepth(int number)
        {
            List<int> digits = GetListOfDigits(number);

            List<int> reachedDigits = new List<int>(digits);

            int iterationsCount = 1;

            while (reachedDigits.Count != 10)
            {
                iterationsCount++;

                digits = GetListOfDigits(number * iterationsCount);

                reachedDigits = reachedDigits.Union(digits)
                                             .ToList();
            }

            return iterationsCount;
        }

        private static List<int> GetListOfDigits(int number)
        {
            return number.ToString()
                         .Select(x => int.Parse(x.ToString()))
                         .ToList();
        }
    }
}