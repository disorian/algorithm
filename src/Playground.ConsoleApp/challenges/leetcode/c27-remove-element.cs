namespace Playground.Basics.Challenges;

public partial class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;

        int writeIndex = 0;

        for (int readIndex = 0; readIndex < nums.Length; readIndex++)
        {
            if (nums[readIndex] != val)
            {
                nums[writeIndex++] = nums[readIndex];
            }
        }

        return writeIndex;
    }
}