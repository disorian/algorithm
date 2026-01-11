namespace Playground.Basics;

public static class TwoSum
{
    public static int[] CalculateTwoSum(int[] numbers, int target)
    {
        Dictionary<int, int> map = [];

        for (int i = 0; i < numbers.Length; i++)
        {
            int result = target - numbers[i];

            if (map.ContainsKey(result))
                return [map[result], i];

            map.Add(numbers[i], i);
        }

        return [-1, -1];
    }

    public static int[] CalculateTwoSumBruteForce(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [-1, -1];
    }
}

// // Test cases
// var solution = new TwoSum();

// int[] test1 = { 2, 7, 11, 15 };
// int[] result1 = solution.TwoSum(test1, 9);
// // Expected: [0, 1]

// int[] test2 = { 3, 2, 4 };
// int[] result2 = solution.TwoSum(test2, 6);
// // Expected: [1, 2]

// int[] test3 = { 3, 3 };
// int[] result3 = solution.TwoSum(test3, 6);
// // Expected: [0, 1]