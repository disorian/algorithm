namespace Playground.Basics;

using static Math;

public static class MaximumSubarray
{
    public static int KadanesAlgorithm(int[] numbers)
    {
        int currentSum = numbers[0];
        int bestSum = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            currentSum = Max(numbers[i], currentSum + numbers[i]); // extend or reset array
            bestSum = Max(currentSum, bestSum);     // update the best sum
        }

        return bestSum;
    }

    public static int GreedyAlgorithm(int[] numbers)
    {
        int bestSum = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i; j < numbers.Length; j++)
            {
                int sum = 0;
                for (int k = i; k <= j; k++)
                {
                    sum += numbers[k];
                }

                bestSum = Max(bestSum, sum);
            }
        }

        return bestSum;
    }
}
