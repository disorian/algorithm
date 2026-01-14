namespace Playground.ConsoleApp.Challenges.Leetcode;

public class C88MergeSortedArray
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var k = m + n - 1;
        m--;
        n--;
        for (int i = k; i >= 0; i--)
        {
            if (m >= 0 && n >= 0)
                nums1[i] = (nums1[m] >= nums2[n]) ? nums1[m--] : nums2[n--];
            else if (m >= 0)
                nums1[i] = nums1[m--];
            else if (n >= 0)
                nums1[i] = nums2[n--];
        }
    }

    public void MergeAlt(int[] nums1, int m, int[] nums2, int n) // AI optimal
    {
        // Three pointers: p1 for nums1, p2 for nums2, p for placement position
        int p1 = m - 1;      // Last valid element in nums1
        int p2 = n - 1;      // Last element in nums2
        int p = m + n - 1;   // Last position in nums1 (where we place elements)

        // Merge from right to left
        while (p1 >= 0 && p2 >= 0)
        {
            // Compare and place the larger element at position p
            if (nums1[p1] > nums2[p2])
            {
                nums1[p] = nums1[p1];
                p1--;
            }
            else
            {
                nums1[p] = nums2[p2];
                p2--;
            }
            p--;
        }

        // If elements remain in nums2, copy them to nums1
        // (If elements remain in nums1, they're already in correct position)
        while (p2 >= 0)
        {
            nums1[p] = nums2[p2];
            p2--;
            p--;
        }
    }
}
