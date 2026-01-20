namespace Playground.Session2;

public class TwoPointersOppositeDirection
{
    // Example 1: Two Sum (sorted array)
    // Time: O(n), Space: O(1)
    public (int, int) TwoSum(int[] numbers, int target)
    {
        int left = 0, right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            if (sum == target)
                return (left, right);
            else if (sum < target)
                left++;
            else
                right--;
        }

        return (-1, -1);
    }

    // Example 2: Valid Palindrome
    // Time: O(n), Space: O(1)
    ///
    /// Examples of palindromes:
    // Words: "racecar," "level," "noon," "kayak," "radar"
    // Numbers: 121, 1331, 12321
    // Phrases:
    // "A man, a plan, a canal: Panama"
    // "Madam, I'm Adam"
    // "Never odd or even"
    // Dates: Some dates can be palindromes too, like 02/02/2020
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return true;

        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            // Skip non-alphanumeric characters
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;

            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }

    // Example 3: Container With Most Water
    // Time: O(n), Space: O(1)
    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int width = right - left;
            int currentHight = Math.Min(height[left], height[right]);

            int currentArea = width * currentHight;

            maxArea = Math.Max(maxArea, currentArea);

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }

    // Example 4: Reverse array in-place
    // Time: O(n), Space: O(1)
    public void ReverseArray(int[] array)
    {
        int left = 0, right = array.Length - 1;

        while (left < right)
        {
            (array[left], array[right]) = (array[right], array[left]);

            left++;
            right--;
        }
    }
}