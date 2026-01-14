namespace Playground.Basics.Challenges;

public partial class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 1)
            return nums.Length;

        int writeIndex = 1;

        for (int readIndex = 1; readIndex < nums.Length; readIndex++)
        {
            if (nums[readIndex] != nums[readIndex - 1])
                nums[writeIndex++] = nums[readIndex];
        }

        return writeIndex;
    }
}
