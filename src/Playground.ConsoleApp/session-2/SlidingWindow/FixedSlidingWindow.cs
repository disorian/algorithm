using System.Buffers;
using System.Text.RegularExpressions;

namespace Playground.Session2;

public class FixedSlidingWindow
{
    // Example 1: Maximum sum of k consecutive elements
    // Time: O(n), Space: O(1)
    public int MaxSumSubarray(int[] arr, int k)
    {
        if (k == 0 || k > arr.Length)
            throw new ArgumentException("Invalid window size");

        int windowSum = 0;

        for (int i = 0; i < k; i++)
        {
            windowSum += arr[i];
        }

        int maxSum = windowSum;
        for (int i = k; i < arr.Length; i++)
        {
            windowSum = windowSum - arr[i - k] + arr[i];
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }

    // Example 2: Average of subarrays of size K
    // Time: O(n), Space: O(n-k+1)
    /// Given an array of integers and a window size K, 
    ///  find the average of all contiguous subarrays of size K.
    /// Input: arr = [1, 3, 2, 6, -1, 4, 1, 8, 2], k = 5
    /// Output: [2.2, 2.8, 2.4, 3.6, 2.8]
    public double[] FindAverages(int[] arr, int k)
    {
        if (arr.Length < k) return [];

        double[] windowAverages = new double[arr.Length - k + 1];
        double windowSum = 0;

        // first window
        for (int i = 0; i < k; i++)
        {
            windowSum += arr[i];
        }
        windowAverages[0] = windowSum / k;

        // slide window
        for (int i = k; i < arr.Length; i++)
        {
            windowSum = windowSum - arr[i - k] + arr[i];
            windowAverages[i - k + 1] = windowSum / k;
        }

        return windowAverages;
    }

    public double FindMaxAverage(int[] nums, int k)
    {
        if (nums.Length < k) return 0;

        double windowSum = 0;
        // first window
        for (int i = 0; i < k; i++)
        {
            windowSum += nums[i];
        }
        var maxAverage = windowSum / k;

        // slide window
        for (int i = k; i < nums.Length; i++)
        {
            windowSum = windowSum - nums[i - k] + nums[i];
            maxAverage = Math.Max(maxAverage, windowSum / k);
        }

        return maxAverage;
    }

    // Example 3: Contains Duplicate within k distance
    // Time: O(n), Space: O(k)
    /// Contains Duplicate II: Given an integer array nums and an integer k, return true if there are two
    ///  distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    /// In other words, check if there are duplicate elements within a distance of k positions from each other.
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var window = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > k)
                window.Remove(nums[i - k - 1]);

            if (!window.Add(nums[i]))
                return true;
        }

        return false;
    }

    // Example 4: Maximum in each window of size k
    // Time: O(n), Space: O(n)
    /// You are given an array of integers nums, there is a sliding window of size k which is moving 
    ///  from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.
    /// Return the max sliding window.
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == 0 || k == 0) return [];

        var result = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>(); // window monotonic decreasing queue (double ended queue)

        for (int i = 0; i < nums.Length; i++)
        {
            // remove indices outside the window
            while (deque.Count > 0 && deque.First!.Value <= i - k)
                deque.RemoveFirst();

            // remove smaller elements (not useful)
            while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            // add the result when window is complete
            if (i >= k - 1)
                result[i - k + 1] = nums[deque.First!.Value];
        }

        return result;
    }

    public int[] MaxSlidingWindowDescription(int[] nums, int k)
    {
        // Edge cases
        if (nums.Length == 0 || k == 0) return [];

        // Result array: one max value for each window position
        // Number of windows = nums.Length - k + 1
        int[] result = new int[nums.Length - k + 1];

        // Deque stores INDICES (not values) in monotonic decreasing order
        // Front of deque = index of largest element in current window
        var deque = new LinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // STEP 1: Remove indices that are outside the current window
            // Window range: [i-k+1, i]
            // So if deque.First <= i-k, it's outside (too far left)
            while (deque.Count > 0 && deque.First!.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // STEP 2: Maintain monotonic decreasing order
            // Remove all indices whose values are smaller than current element
            // Why? Because nums[i] is:
            //   a) Larger (so it's better for max)
            //   b) More recent (stays in window longer)
            // Therefore, smaller elements will NEVER be the max again
            while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            // STEP 3: Add current index to back of deque
            deque.AddLast(i);

            // STEP 4: Once window is complete (i >= k-1), record the max
            // The front of deque always contains index of max element
            if (i >= k - 1)
            {
                result[i - k + 1] = nums[deque.First!.Value];
            }
        }

        return result;
    }

    public int[] MaxSlidingWindow_Youtube_Wrong(int[] nums, int k)
    {
        var window = new LinkedList<int>();
        int[] output = new int[nums.Length - k + 1];
        int left = 0, right = 0; // left and right of the window

        // while right pointer still in bound
        while (right < nums.Length)
        {
            // pop smaller values forom the deque
            while (window.Count > 0 && window.Last!.Value < nums[right])
                window.RemoveLast();

            window.AddLast(right);

            // remove the left value form the window if it is out of the bount
            if (window.Count > 0 && left > window.First!.Value)
                window.RemoveFirst();

            // check if our window is at least size k before updatting output
            if (right + 1 >= k)
            {
                output[left] = nums[window.First!.Value];
                left++;
            }

            right++;
        }

        return output;
    }
}
