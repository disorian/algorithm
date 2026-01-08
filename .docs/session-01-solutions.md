# Session 1: Practice Exercise Solutions

> **Solutions and explanations for Part 4 exercises**

---

## Exercise 1: Array Rotation

**Problem**: Rotate an array to the right by k steps.

### Solution

```csharp
public class ArrayRotation
{
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;

        // Handle edge cases
        if (n == 0 || k == 0)
            return;

        // Normalize k (handle k > n)
        k = k % n;

        // Three-step reversal approach
        Reverse(nums, 0, n - 1);        // Reverse entire array
        Reverse(nums, 0, k - 1);        // Reverse first k elements
        Reverse(nums, k, n - 1);        // Reverse remaining elements
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            // Swap elements
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;

            start++;
            end--;
        }
    }
}
```

### Explanation

The three-step reversal approach is elegant and efficient:

1. **Reverse the entire array**
   - `[1,2,3,4,5]` becomes `[5,4,3,2,1]`

2. **Reverse the first k elements**
   - For k=2: `[5,4,3,2,1]` becomes `[4,5,3,2,1]`

3. **Reverse the remaining n-k elements**
   - `[4,5,3,2,1]` becomes `[4,5,1,2,3]` ✓

**Why this works**: When you rotate right by k, the last k elements move to the front. By reversing the entire array first, these elements are already at the front (but in wrong order). The two subsequent reversals fix the order.

**Visual example with k=2**:
```
Original:        [1, 2, 3, 4, 5]
After step 1:    [5, 4, 3, 2, 1]  (reverse all)
After step 2:    [4, 5, 3, 2, 1]  (reverse first 2)
After step 3:    [4, 5, 1, 2, 3]  (reverse last 3) ✓
```

### Complexity Analysis

- **Time Complexity**: O(n)
  - Each reversal is O(n) in worst case
  - Three reversals = 3 × O(n) = O(n)

- **Space Complexity**: O(1)
  - Only using a few variables (temp, start, end)
  - No additional data structures

### Alternative Approach (Less Efficient)

```csharp
// Using extra space - O(n) space
public void RotateWithExtraSpace(int[] nums, int k)
{
    int n = nums.Length;
    k = k % n;

    int[] temp = new int[n];

    // Copy elements to new positions
    for (int i = 0; i < n; i++)
    {
        temp[(i + k) % n] = nums[i];
    }

    // Copy back
    Array.Copy(temp, nums, n);
}
// Time: O(n), Space: O(n) - worse than reversal approach
```

---

## Exercise 2: Remove Duplicates from Sorted Array

**Problem**: Remove duplicates in-place, return new length.

### Solution

```csharp
public class RemoveDuplicates
{
    public int RemoveDuplicates(int[] nums)
    {
        // Edge case: empty or single element
        if (nums.Length <= 1)
            return nums.Length;

        // Two-pointer approach
        int writeIndex = 1; // Position to write next unique element

        for (int readIndex = 1; readIndex < nums.Length; readIndex++)
        {
            // Found a new unique element
            if (nums[readIndex] != nums[readIndex - 1])
            {
                nums[writeIndex] = nums[readIndex];
                writeIndex++;
            }
        }

        return writeIndex;
    }
}
```

### Explanation

The **two-pointer technique** is perfect for in-place array modifications:

- **readIndex**: Scans through the array looking for unique elements
- **writeIndex**: Points to where we should write the next unique element

**Step-by-step example**: `[1, 1, 2, 2, 3]`

```
Initial state:
[1, 1, 2, 2, 3]
 w  r              writeIndex=1, readIndex=1

Step 1: nums[1]==nums[0] (1==1), skip
[1, 1, 2, 2, 3]
 w     r           writeIndex=1, readIndex=2

Step 2: nums[2]!=nums[1] (2!=1), write and increment
[1, 2, 2, 2, 3]
    w     r        writeIndex=2, readIndex=3

Step 3: nums[3]==nums[2] (2==2), skip
[1, 2, 2, 2, 3]
    w        r     writeIndex=2, readIndex=4

Step 4: nums[4]!=nums[3] (3!=2), write and increment
[1, 2, 3, 2, 3]
       w        r  writeIndex=3, readIndex=5

Result: [1, 2, 3, _, _], length = 3 ✓
```

### Complexity Analysis

- **Time Complexity**: O(n)
  - Single pass through the array

- **Space Complexity**: O(1)
  - Only two integer variables
  - Modifying array in-place

### Key Insights

1. **Why it works for sorted arrays**: Since duplicates are adjacent, we only need to compare with the previous element.

2. **Why two pointers**: One pointer reads all elements, the other writes only unique ones.

3. **In-place modification**: We overwrite the array as we go, no extra space needed.

---

## Exercise 3: Maximum Subarray Sum (Kadane's Algorithm)

**Problem**: Find contiguous subarray with maximum sum.

### Solution

```csharp
public class MaximumSubarray
{
    public int MaxSubArray(int[] nums)
    {
        // Edge case
        if (nums.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        // Kadane's Algorithm
        int maxSoFar = nums[0];        // Best sum seen so far
        int maxEndingHere = nums[0];   // Best sum ending at current position

        for (int i = 1; i < nums.Length; i++)
        {
            // Key decision: extend current subarray or start new one?
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);

            // Update global maximum
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }
}
```

### Explanation

**Kadane's Algorithm** is a brilliant dynamic programming solution that solves this in O(n) time.

**Core Insight**: At each position, we decide:
- Should we **extend** the current subarray? (add current element)
- Or **start a new** subarray from here? (current element alone)

We choose whichever gives a larger sum!

**Step-by-step example**: `[-2, 1, -3, 4, -1, 2, 1, -5, 4]`

```
Index  Value  maxEndingHere             maxSoFar  Decision
0      -2     -2                        -2        Start
1       1     max(1, -2+1) = 1         1         Start new (1 > -1)
2      -3     max(-3, 1-3) = -2        1         Extend (but negative)
3       4     max(4, -2+4) = 4         4         Start new (4 > 2)
4      -1     max(-1, 4-1) = 3         4         Extend
5       2     max(2, 3+2) = 5          5         Extend
6       1     max(1, 5+1) = 6          6         Extend
7      -5     max(-5, 6-5) = 1         6         Extend
8       4     max(4, 1+4) = 5          6         Extend

Best subarray: [4, -1, 2, 1] with sum = 6 ✓
```

### Why It Works

At each step, `maxEndingHere` represents the best sum we can achieve that **must include** the current element. The key decision is:

```csharp
maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
```

This translates to:
- `nums[i]`: Start a fresh subarray from here
- `maxEndingHere + nums[i]`: Extend the previous subarray

We pick whichever is larger!

### Complexity Analysis

- **Time Complexity**: O(n)
  - Single pass through array
  - Constant work per element

- **Space Complexity**: O(1)
  - Only two variables

### Alternative: Brute Force (Don't Use!)

```csharp
// O(n³) - checking all possible subarrays
public int MaxSubArrayBruteForce(int[] nums)
{
    int maxSum = int.MinValue;

    for (int i = 0; i < nums.Length; i++)           // Start
    {
        for (int j = i; j < nums.Length; j++)       // End
        {
            int sum = 0;
            for (int k = i; k <= j; k++)            // Calculate sum
            {
                sum += nums[k];
            }
            maxSum = Math.Max(maxSum, sum);
        }
    }

    return maxSum;
}
// Time: O(n³) - extremely slow for large arrays!
```

---

## Exercise 4: Two Sum

**Problem**: Find two numbers that add up to target.

### Solution

```csharp
public class TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Hash table to store: value → index
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            // Check if complement exists in map
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }

            // Add current number to map (avoid duplicates)
            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = i;
            }
        }

        // No solution found (problem guarantees one exists)
        throw new ArgumentException("No two sum solution exists");
    }
}
```

### Explanation

The **hash table approach** trades space for time, achieving O(n) instead of O(n²).

**Key Insight**: For each number `x`, we need to find if `target - x` exists in the array.

**Step-by-step example**: `[2, 7, 11, 15]`, target = 9

```
i=0, nums[0]=2
  complement = 9 - 2 = 7
  map is empty, so add: map = {2: 0}

i=1, nums[1]=7
  complement = 9 - 7 = 2
  map contains 2! Found at index 0
  return [0, 1] ✓
```

**Another example**: `[3, 2, 4]`, target = 6

```
i=0, nums[0]=3
  complement = 6 - 3 = 3
  map is empty, add: map = {3: 0}

i=1, nums[1]=2
  complement = 6 - 2 = 4
  map doesn't contain 4, add: map = {3: 0, 2: 1}

i=2, nums[2]=4
  complement = 6 - 4 = 2
  map contains 2 at index 1!
  return [1, 2] ✓
```

### Complexity Analysis

- **Time Complexity**: O(n)
  - Single pass through array
  - Hash table lookup is O(1) average case

- **Space Complexity**: O(n)
  - Hash table stores up to n elements

### Alternative: Brute Force

```csharp
// O(n²) approach - checking all pairs
public int[] TwoSumBruteForce(int[] nums, int target)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                return new int[] { i, j };
            }
        }
    }

    throw new ArgumentException("No solution");
}
// Time: O(n²), Space: O(1)
// Much slower for large arrays!
```

### Follow-up: Sorted Array Version

If the array is **sorted**, we can use **two pointers** for O(1) space:

```csharp
public int[] TwoSumSorted(int[] nums, int target)
{
    int left = 0;
    int right = nums.Length - 1;

    while (left < right)
    {
        int sum = nums[left] + nums[right];

        if (sum == target)
            return new int[] { left, right };
        else if (sum < target)
            left++;   // Need larger sum
        else
            right--;  // Need smaller sum
    }

    throw new ArgumentException("No solution");
}
// Time: O(n), Space: O(1) - but requires sorted array!
```

---

## Exercise 5: Implement Dynamic Array with Tests

**Problem**: Complete the DynamicArray implementation and add comprehensive tests.

### Solution: Complete Test Suite

```csharp
using System;
using System.Diagnostics;

public class DynamicArrayTests
{
    public static void RunTests()
    {
        Console.WriteLine("Running DynamicArray Tests...\n");

        TestAdd();
        TestResize();
        TestIndexer();
        TestInsert();
        TestRemove();
        TestIndexOf();
        TestContains();
        TestClear();
        TestEdgeCases();

        Console.WriteLine("\n✅ All tests passed!");
    }

    private static void TestAdd()
    {
        Console.WriteLine("Testing Add()...");
        var list = new DynamicArray<int>();

        // Test adding elements
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Debug.Assert(list.Count == 3, "Count should be 3");
        Debug.Assert(list[0] == 1, "First element should be 1");
        Debug.Assert(list[1] == 2, "Second element should be 2");
        Debug.Assert(list[2] == 3, "Third element should be 3");

        Console.WriteLine("  ✓ Add() working correctly");
    }

    private static void TestResize()
    {
        Console.WriteLine("Testing Resize behaviour...");
        var list = new DynamicArray<int>();

        int initialCapacity = list.Capacity;

        // Add elements beyond initial capacity
        for (int i = 0; i < initialCapacity + 1; i++)
        {
            list.Add(i);
        }

        Debug.Assert(list.Capacity > initialCapacity,
            "Capacity should increase after exceeding initial capacity");
        Debug.Assert(list.Count == initialCapacity + 1,
            "Count should match number of added elements");

        // Verify all elements are intact after resize
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Assert(list[i] == i,
                $"Element at index {i} should be {i}");
        }

        Console.WriteLine($"  ✓ Resize working correctly (capacity: {initialCapacity} → {list.Capacity})");
    }

    private static void TestIndexer()
    {
        Console.WriteLine("Testing Indexer (get/set)...");
        var list = new DynamicArray<string>();

        list.Add("first");
        list.Add("second");
        list.Add("third");

        // Test getter
        Debug.Assert(list[0] == "first", "Getter should return correct value");
        Debug.Assert(list[1] == "second", "Getter should return correct value");

        // Test setter
        list[1] = "modified";
        Debug.Assert(list[1] == "modified", "Setter should modify value");

        // Test out of range
        try
        {
            _ = list[10];
            Debug.Fail("Should throw IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Expected
        }

        try
        {
            list[-1] = "invalid";
            Debug.Fail("Should throw IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Expected
        }

        Console.WriteLine("  ✓ Indexer working correctly");
    }

    private static void TestInsert()
    {
        Console.WriteLine("Testing Insert()...");
        var list = new DynamicArray<int>();

        // Insert into empty list
        list.Insert(0, 10);
        Debug.Assert(list.Count == 1 && list[0] == 10,
            "Should insert into empty list");

        // Insert at beginning
        list.Insert(0, 5);
        Debug.Assert(list[0] == 5 && list[1] == 10,
            "Should insert at beginning");

        // Insert in middle
        list.Add(15);
        list.Insert(1, 7);
        Debug.Assert(list[0] == 5 && list[1] == 7 && list[2] == 10 && list[3] == 15,
            "Should insert in middle");

        // Insert at end
        list.Insert(list.Count, 20);
        Debug.Assert(list[list.Count - 1] == 20,
            "Should insert at end");

        // Test invalid index
        try
        {
            list.Insert(-1, 0);
            Debug.Fail("Should throw IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Expected
        }

        Console.WriteLine("  ✓ Insert() working correctly");
    }

    private static void TestRemove()
    {
        Console.WriteLine("Testing RemoveAt()...");
        var list = new DynamicArray<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        // Remove from middle
        list.RemoveAt(2); // Remove 3
        Debug.Assert(list.Count == 4, "Count should decrease");
        Debug.Assert(list[2] == 4, "Elements should shift left");

        // Remove from beginning
        list.RemoveAt(0); // Remove 1
        Debug.Assert(list[0] == 2, "First element should shift");

        // Remove from end
        list.RemoveAt(list.Count - 1); // Remove 5
        Debug.Assert(list.Count == 2, "Count should be 2");

        // Test invalid index
        try
        {
            list.RemoveAt(10);
            Debug.Fail("Should throw IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Expected
        }

        Console.WriteLine("  ✓ RemoveAt() working correctly");
    }

    private static void TestIndexOf()
    {
        Console.WriteLine("Testing IndexOf()...");
        var list = new DynamicArray<string>();

        list.Add("apple");
        list.Add("banana");
        list.Add("cherry");
        list.Add("banana"); // Duplicate

        // Find existing elements
        Debug.Assert(list.IndexOf("apple") == 0,
            "Should find first element");
        Debug.Assert(list.IndexOf("banana") == 1,
            "Should find first occurrence");
        Debug.Assert(list.IndexOf("cherry") == 2,
            "Should find element");

        // Find non-existing element
        Debug.Assert(list.IndexOf("orange") == -1,
            "Should return -1 for non-existing element");

        Console.WriteLine("  ✓ IndexOf() working correctly");
    }

    private static void TestContains()
    {
        Console.WriteLine("Testing Contains()...");
        var list = new DynamicArray<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Debug.Assert(list.Contains(10) == true,
            "Should find existing element");
        Debug.Assert(list.Contains(20) == true,
            "Should find existing element");
        Debug.Assert(list.Contains(99) == false,
            "Should not find non-existing element");

        Console.WriteLine("  ✓ Contains() working correctly");
    }

    private static void TestClear()
    {
        Console.WriteLine("Testing Clear()...");
        var list = new DynamicArray<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Clear();

        Debug.Assert(list.Count == 0, "Count should be 0 after clear");

        // Should be able to add after clear
        list.Add(10);
        Debug.Assert(list.Count == 1 && list[0] == 10,
            "Should work after clear");

        Console.WriteLine("  ✓ Clear() working correctly");
    }

    private static void TestEdgeCases()
    {
        Console.WriteLine("Testing Edge Cases...");

        // Empty list operations
        var emptyList = new DynamicArray<int>();
        Debug.Assert(emptyList.Count == 0, "New list should be empty");
        Debug.Assert(emptyList.Contains(1) == false,
            "Empty list shouldn't contain anything");
        Debug.Assert(emptyList.IndexOf(1) == -1,
            "IndexOf on empty list should return -1");

        // Single element
        var singleList = new DynamicArray<int>();
        singleList.Add(42);
        Debug.Assert(singleList.Count == 1, "Count should be 1");
        Debug.Assert(singleList[0] == 42, "Should contain element");

        singleList.RemoveAt(0);
        Debug.Assert(singleList.Count == 0, "Should be empty after removing only element");

        // Multiple resizes
        var growList = new DynamicArray<int>();
        for (int i = 0; i < 100; i++)
        {
            growList.Add(i);
        }
        Debug.Assert(growList.Count == 100, "Should handle multiple resizes");
        for (int i = 0; i < 100; i++)
        {
            Debug.Assert(growList[i] == i, "All elements should be intact");
        }

        Console.WriteLine("  ✓ Edge cases handled correctly");
    }
}
```

### Usage

```csharp
// Run all tests
DynamicArrayTests.RunTests();
```

### Expected Output

```
Running DynamicArray Tests...

Testing Add()...
  ✓ Add() working correctly
Testing Resize behaviour...
  ✓ Resize working correctly (capacity: 4 → 8)
Testing Indexer (get/set)...
  ✓ Indexer working correctly
Testing Insert()...
  ✓ Insert() working correctly
Testing RemoveAt()...
  ✓ RemoveAt() working correctly
Testing IndexOf()...
  ✓ IndexOf() working correctly
Testing Contains()...
  ✓ Contains() working correctly
Testing Clear()...
  ✓ Clear() working correctly
Testing Edge Cases...
  ✓ Edge cases handled correctly

✅ All tests passed!
```

### Test Coverage Summary

| Feature | Test Cases |
|---------|------------|
| **Add** | Basic addition, multiple elements |
| **Resize** | Automatic capacity growth, data integrity |
| **Indexer** | Get/set, out of range exceptions |
| **Insert** | Empty, beginning, middle, end, invalid index |
| **RemoveAt** | Beginning, middle, end, invalid index |
| **IndexOf** | Found, not found, first occurrence |
| **Contains** | Existing and non-existing elements |
| **Clear** | Empty list, reuse after clear |
| **Edge Cases** | Empty list, single element, multiple resizes |

---

## Bonus: Performance Comparison

Here's a comparison of different approaches:

### Array Rotation Performance

```csharp
// Test with 1,000,000 elements
int[] largeArray = Enumerable.Range(1, 1_000_000).ToArray();
int k = 500_000;

// Reversal approach: ~5-10ms ⚡
// Extra space approach: ~15-20ms
// One-by-one rotation: ~10+ seconds 🐌
```

### Two Sum Performance

```csharp
// Test with 10,000 elements
int[] nums = Enumerable.Range(1, 10_000).ToArray();
int target = 19_999;

// Hash table: <1ms ⚡
// Brute force: ~50-100ms 🐌
// For 100,000 elements:
// Hash table: ~5ms ⚡
// Brute force: ~5000ms (5 seconds!) 🐌
```

---

## Key Takeaways

1. **Array Rotation**: Three-step reversal is elegant and O(1) space
2. **Remove Duplicates**: Two-pointer technique for in-place modifications
3. **Maximum Subarray**: Kadane's algorithm is a dynamic programming classic
4. **Two Sum**: Hash tables trade space for time (O(n²) → O(n))
5. **Testing**: Comprehensive tests catch edge cases and ensure correctness

---

## Next Steps

✅ Understood all solutions above
✅ Ran the test suite successfully
✅ Can explain each algorithm to someone else
✅ Ready to tackle Session 2 problems!

---

**Happy Coding! 🚀**
