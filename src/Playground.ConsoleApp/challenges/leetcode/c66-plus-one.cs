namespace Playground.ConsoleApp.Challenges.Leetcode;

public class C66PlusOne
{
    public int[] PlusOne(int[] digits)
    {
        if (digits.Length == 0 || digits.Length > 100)
            throw new ArgumentOutOfRangeException("Invalid array length");

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }

        int[] results = new int[digits.Length + 1];
        results[0] = 1;

        return results;
    }
}
