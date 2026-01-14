using static System.Math;

namespace Playground.Basics.Challenges;

public partial class Solution
{
    public static int MaxSubArray(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int currentSum = nums[0];
        int maxSum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentSum = Max(nums[i], nums[i] + currentSum);
            maxSum = Max(currentSum, maxSum);
        }

        return maxSum;
    }
}