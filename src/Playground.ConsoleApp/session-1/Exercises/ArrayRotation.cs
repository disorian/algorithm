namespace Playground.Basics;

public static class ArrayRotation
{
    // Space Complexity: O(1) - only uses a few variables
    // Time Complexity: O(n) - three passes through the array
    public static void Rotate(int[] numbers, int position)
    {
        int n = numbers.Length;
        if (n == 0 || position == 0)
            return;

        // Normalize k (handle k > n)
        int k = position % n;

        // Three-step reversal approach
        Reverse(numbers, 0, n - 1);     // Reverse entire array
        Reverse(numbers, 0, k - 1);     // Reverse first k elements
        Reverse(numbers, k, n - 1);     // Reverse remaining elements
    }

    private static void Reverse(int[] numbers, int start, int end)
    {
        while (start < end)
            (numbers[end], numbers[start]) = (numbers[start++], numbers[end--]);
    }

    // Using extra space - O(n) space
    // Time: O(n), Space: O(n) - worse than reversal approach
    public static void RotateAlt(int[] numbers, int position)
    {
        int n = numbers.Length;
        if (numbers.Length == 0 || position == 0)
            return;

        int k = position % n;

        int[] temp = new int[n];

        for (int i = 0; i < n; i++)
        {
            temp[(i + k) % n] = numbers[i];
        }

        Array.Copy(temp, numbers, n);
    }
}