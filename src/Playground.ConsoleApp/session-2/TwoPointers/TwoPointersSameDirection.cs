namespace Playground.Session2;

public class TwoPointersSameDirection // fast and slow
{
    // Example 1: Remove Duplicates from Sorted Array
    // Time: O(n), Space: O(1)
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int slow = 1; // write index

        for (int fast = 1; fast < nums.Length; fast++) // read index
        {
            if (nums[fast] != nums[slow])
                nums[slow++] = nums[fast];
        }

        return slow + 1;
    }

    // Example 2: Move Zeroes to end
    // Time: O(n), Space: O(1)
    public void MoveZeroes(int[] nums)
    {
        int slow = 0; // write index

        // move all none-zeros in front
        for (int fast = 0; fast < nums.Length; fast++) // read index
        {
            if (nums[fast] != 0)
                nums[slow++] = nums[fast];
        }

        // fill the rest with zeros
        while (slow < nums.Length)
            nums[slow++] = 0;
    }

    // Example 3: Remove Element
    // Time: O(n), Space: O(1)
    public int RemoveElement(int[] nums, int val)
    {
        int slow = 0;

        for (int fast = 0; fast < nums.Length; fast++)
        {
            if (nums[fast] != val)
                nums[slow++] = nums[fast];
        }

        return slow;
    }

    // Example 4: Partition Array (Quick Sort partition)
    // Time: O(n), Space: O(1)
    // e.g. nums = [9,12,5,10,14,3,10], pivot = 10
    // Output: [9,5,3,10,10,12,14]
    public void PartitionArray(int[] nums, int pivot)
    {
        int slow = 0; // boundary index

        for (int fast = 0; fast < nums.Length; fast++) // read index
        {
            if (nums[fast] < pivot)
            {
                (nums[slow], nums[fast]) = (nums[fast], nums[slow]);
                slow++;
            }
        }
    }
}