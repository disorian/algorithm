public class C169MajorityElement
{
    public int MajorityElement(int[] nums)
    {
        int candidate = 0;
        int count = 0;

        foreach (var current in nums)
        {
            if (count == 0)
                candidate = current;

            count += (current == candidate) ? 1 : -1;
        }

        return candidate;
    }


    /// <summary>
    /// Solution 1: Boyer-Moore Voting Algorithm (Optimal)
    /// Time Complexity: O(n) - Single pass through array
    /// Space Complexity: O(1) - Only two variables
    /// Best approach for this problem.
    /// </summary>
    public int MajorityElement_(int[] nums)
    {
        int candidate = 0;
        int count = 0;

        // Find the candidate using Boyer-Moore voting
        foreach (int num in nums)
        {
            // When count reaches 0, select new candidate
            if (count == 0)
            {
                candidate = num;
            }

            // Increment if matches candidate, decrement otherwise
            count += (num == candidate) ? 1 : -1;
        }

        // Problem guarantees majority exists, so no verification needed
        return candidate;
    }

    /// <summary>
    /// Solution 2: HashMap/Dictionary Counting
    /// Time Complexity: O(n) - Single pass to count frequencies
    /// Space Complexity: O(n) - Dictionary stores up to n unique elements
    /// More intuitive but uses extra space.
    /// </summary>
    public int MajorityElement_HashMap(int[] nums)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        int majorityThreshold = nums.Length / 2;

        foreach (int num in nums)
        {
            // Increment count for this number
            if (!counts.ContainsKey(num))
            {
                counts[num] = 0;
            }
            counts[num]++;

            // Return as soon as we find element with > n/2 occurrences
            if (counts[num] > majorityThreshold)
            {
                return num;
            }
        }

        // Should never reach here if majority element exists
        return -1;
    }

    /// <summary>
    /// Solution 3: Sorting
    /// Time Complexity: O(n log n) - Dominated by sorting
    /// Space Complexity: O(1) or O(n) depending on sort implementation
    /// Simple and elegant: the middle element must be the majority.
    /// </summary>
    public int MajorityElement_Sorting(int[] nums)
    {
        // Sort the array
        Array.Sort(nums);

        // The middle element must be the majority element
        // Since majority appears > n/2 times, it will always occupy the middle position
        return nums[nums.Length / 2];
    }

    /// <summary>
    /// Solution 4: Divide and Conquer
    /// Time Complexity: O(n log n) - T(n) = 2T(n/2) + O(n)
    /// Space Complexity: O(log n) - Recursion call stack
    /// Demonstrates recursive problem-solving approach.
    /// </summary>
    public int MajorityElement_DivideConquer(int[] nums)
    {
        return MajorityElementRecursive(nums, 0, nums.Length - 1);
    }

    private int MajorityElementRecursive(int[] nums, int left, int right)
    {
        // Base case: single element is always the majority
        if (left == right)
        {
            return nums[left];
        }

        // Divide: find middle point
        int mid = left + (right - left) / 2;

        // Conquer: find majority in left and right halves
        int leftMajority = MajorityElementRecursive(nums, left, mid);
        int rightMajority = MajorityElementRecursive(nums, mid + 1, right);

        // If both halves agree on the majority, return it
        if (leftMajority == rightMajority)
        {
            return leftMajority;
        }

        // Combine: count occurrences of both candidates in current range
        int leftCount = CountInRange(nums, leftMajority, left, right);
        int rightCount = CountInRange(nums, rightMajority, left, right);

        // Return the one with more occurrences
        return leftCount > rightCount ? leftMajority : rightMajority;
    }

    private int CountInRange(int[] nums, int target, int left, int right)
    {
        int count = 0;
        for (int i = left; i <= right; i++)
        {
            if (nums[i] == target)
            {
                count++;
            }
        }
        return count;
    }

    /// <summary>
    /// Wrong implementation (kept for reference)
    /// Issues:
    /// 1. trackList[number]++ returns the OLD value before increment (post-increment)
    /// 2. Should be: trackList.TryGetValue(number, out var count) ? count + 1 : 1
    /// 3. Returns the count instead of the number itself
    /// </summary>
    public int MajorityElement_Wrong(int[] nums)
    {
        int majorityCount = nums.Length / 2;
        Dictionary<int, int> trackList = [];

        foreach (var number in nums)
        {
            trackList[number] = trackList[number]++; // Bug: post-increment issue
            if (trackList[number] > majorityCount)
                return trackList[number]; // Bug: returns count, not the number
        }

        return -1;
    }
}
