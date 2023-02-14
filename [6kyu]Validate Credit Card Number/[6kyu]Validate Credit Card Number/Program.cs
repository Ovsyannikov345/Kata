solution solution = new solution();

solution.validate("477 073 360");

public class solution
{
    public bool validate(string cardNumber)
    {
        int[] digits = cardNumber.Where(x => char.IsDigit(x))
                                 .Select(x => int.Parse(x.ToString()))
                                 .ToArray();

        for (var i = digits.Length - 2; i >= 0; i-=2)
        {
            int doubledDigit = digits[i] * 2;

            digits[i] = doubledDigit < 10 ? doubledDigit : doubledDigit - 9;
        }

        return digits.Sum() % 10 == 0;
    }
}