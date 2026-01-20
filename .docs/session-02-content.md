# Session 2: Basic Problem-Solving Patterns

> **Goal**: Master fundamental algorithmic patterns (Two Pointers, Sliding Window, Prefix Sums, Frequency Counting) and understand hash-based data structures

---

## Table of Contents

- [📚 Part 1: Modern C# Features for Algorithms](#-part-1-modern-c-features-for-algorithms)
  - [1.1 Delegates and Lambda Expressions](#11-delegates-and-lambda-expressions)
  - [1.2 Anonymous Types and Tuples](#12-anonymous-types-and-tuples)
  - [1.3 Nullable Reference Types in Action](#13-nullable-reference-types-in-action)
- [📊 Part 2: Algorithmic Patterns](#-part-2-algorithmic-patterns)
  - [2.1 Two Pointers Technique](#21-two-pointers-technique)
  - [2.2 Sliding Window Pattern](#22-sliding-window-pattern)
  - [2.3 Prefix Sum Technique](#23-prefix-sum-technique)
  - [2.4 Frequency Counting Pattern](#24-frequency-counting-pattern)
- [🔧 Part 3: Hash-Based Data Structures](#-part-3-hash-based-data-structures)
  - [3.1 Understanding Hash Tables](#31-understanding-hash-tables)
  - [3.2 Implementing HashSet from Scratch](#32-implementing-hashset-from-scratch)
  - [3.3 Dictionary vs HashSet vs Hashtable](#33-dictionary-vs-hashset-vs-hashtable)
- [💻 Part 4: Practice Exercises](#-part-4-practice-exercises)
  - [Exercise 1: Container With Most Water (Two Pointers)](#exercise-1-container-with-most-water-two-pointers)
  - [Exercise 2: Longest Substring Without Repeating Characters (Sliding Window)](#exercise-2-longest-substring-without-repeating-characters-sliding-window)
  - [Exercise 3: Subarray Sum Equals K (Prefix Sum + Hash Map)](#exercise-3-subarray-sum-equals-k-prefix-sum--hash-map)
  - [Exercise 4: Valid Anagram (Frequency Counting)](#exercise-4-valid-anagram-frequency-counting)
  - [Exercise 5: Minimum Window Substring (Advanced Sliding Window)](#exercise-5-minimum-window-substring-advanced-sliding-window)
- [🎯 Part 5: Curated Practice Problems](#-part-5-curated-practice-problems)
  - [Two Pointers Problems (20 problems)](#two-pointers-problems-20-problems)
  - [Sliding Window Problems (15 problems)](#sliding-window-problems-15-problems)
  - [Hash Map / Frequency Counting (15 problems)](#hash-map--frequency-counting-15-problems)
  - [Prefix Sum Problems (10 problems)](#prefix-sum-problems-10-problems)
- [📝 Part 6: Implementation Challenge](#-part-6-implementation-challenge)
  - [Challenge: Build a Custom Dictionary with Statistics](#challenge-build-a-custom-dictionary-with-statistics)
- [🏆 Part 7: Assessment & Next Steps](#-part-7-assessment--next-steps)
  - [Completion Criteria](#completion-criteria)
  - [Self-Assessment Quiz](#self-assessment-quiz)
  - [Additional Resources](#additional-resources)
- [📅 Estimated Timeline](#-estimated-timeline)
- [🎓 Tips for Success](#-tips-for-success)
- [Sources](#sources)

---

## 📚 Part 1: Modern C# Features for Algorithms

### 1.1 Delegates and Lambda Expressions

Delegates are type-safe function pointers that enable functional programming patterns essential for LINQ and algorithm implementations.

#### Understanding Delegates

```csharp
// Delegate declaration - defines a function signature
public delegate int BinaryOperation(int a, int b);
public delegate bool Predicate<T>(T item);

// Using built-in delegates (preferred)
// Func<T1, T2, ..., TResult> - returns a value
// Action<T1, T2, ...> - returns void
// Predicate<T> - returns bool

public class DelegateExamples
{
    // Traditional method
    public static int Add(int a, int b) => a + b;
    public static int Multiply(int a, int b) => a * b;

    // Using delegates
    public static void Main()
    {
        // Method group syntax
        BinaryOperation operation = Add;
        Console.WriteLine(operation(5, 3)); // 8

        operation = Multiply;
        Console.WriteLine(operation(5, 3)); // 15

        // Using Func<> (built-in delegate)
        Func<int, int, int> subtract = (a, b) => a - b;
        Console.WriteLine(subtract(10, 3)); // 7

        // Using Action<> (no return value)
        Action<string> print = message => Console.WriteLine(message);
        print("Hello from delegate!");

        // Using Predicate<> (returns bool)
        Predicate<int> isEven = x => x % 2 == 0;
        Console.WriteLine(isEven(4)); // True
        Console.WriteLine(isEven(5)); // False
    }
}
```

#### Lambda Expressions Syntax

```csharp
// Lambda expression syntax: (parameters) => expression-or-statement-block

// No parameters
Func<int> getRandomNumber = () => new Random().Next(1, 100);

// One parameter (parentheses optional)
Func<int, int> square = x => x * x;
Func<int, int> squareAlt = (x) => x * x; // Also valid

// Multiple parameters (parentheses required)
Func<int, int, int> add = (a, b) => a + b;

// Statement block (braces required)
Func<int, int, int> max = (a, b) =>
{
    if (a > b)
        return a;
    return b;
};

// With type inference
Func<string, int> getLength = s => s.Length;

// Explicit type parameters (when inference fails)
Func<string, int> getLengthExplicit = (string s) => s.Length;
```

#### Lambda Expressions in Algorithm Context

```csharp
public class LambdaAlgorithms
{
    // Custom sort with lambda
    public void SortExample()
    {
        int[] numbers = { 5, -2, 8, -10, 3 };

        // Sort by absolute value
        Array.Sort(numbers, (a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
        // Result: [-2, 3, 5, 8, -10]

        // Sort descending
        Array.Sort(numbers, (a, b) => b.CompareTo(a));
    }

    // Filter with lambda
    public List<int> FilterEvens(List<int> numbers)
    {
        return numbers.Where(n => n % 2 == 0).ToList();
    }

    // Transform with lambda
    public List<int> SquareAll(List<int> numbers)
    {
        return numbers.Select(n => n * n).ToList();
    }

    // Custom aggregation
    public int ProductOfAll(List<int> numbers)
    {
        return numbers.Aggregate(1, (product, n) => product * n);
    }

    // Binary search with custom comparator
    public int BinarySearch<T>(T[] array, T target, Func<T, T, int> comparer)
    {
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = comparer(array[mid], target);

            if (comparison == 0)
                return mid;
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

// Usage
var algo = new LambdaAlgorithms();
int[] sortedNumbers = { 1, 3, 5, 7, 9, 11 };

// Search with custom comparator
int index = algo.BinarySearch(
    sortedNumbers,
    7,
    (a, b) => a.CompareTo(b)
);
```

#### Expression Trees (Advanced)

```csharp
using System.Linq.Expressions;

public class ExpressionTreeExample
{
    public void DemonstratExpressionTrees()
    {
        // Lambda expression
        Func<int, int> square = x => x * x;

        // Expression tree (represents the structure)
        Expression<Func<int, int>> squareExpr = x => x * x;

        // Can analyze the expression structure
        Console.WriteLine(squareExpr.Body); // (x * x)
        Console.WriteLine(squareExpr.Parameters[0].Name); // x

        // Compile and execute
        var compiled = squareExpr.Compile();
        Console.WriteLine(compiled(5)); // 25
    }

    // Building expression trees programmatically
    public Expression<Func<int, bool>> BuildGreaterThanExpression(int value)
    {
        var parameter = Expression.Parameter(typeof(int), "x");
        var constant = Expression.Constant(value);
        var greaterThan = Expression.GreaterThan(parameter, constant);

        return Expression.Lambda<Func<int, bool>>(greaterThan, parameter);
    }
}
```

**When to use**:
- LINQ operations (always use lambdas)
- Custom sorting/comparison logic
- Higher-order functions (functions that take functions as parameters)
- Callback mechanisms
- Event handlers (concise syntax)

---

### 1.2 Anonymous Types and Tuples

Anonymous types are compiler-generated classes useful for temporary data structures in algorithms.

```csharp
public class AnonymousTypesExample
{
    public void BasicAnonymousType()
    {
        // Anonymous type creation
        var person = new { Name = "Alice", Age = 30, City = "Sydney" };

        Console.WriteLine(person.Name); // Alice
        Console.WriteLine(person.Age);  // 30

        // person.Age = 31; // Error: properties are read-only
    }

    // Useful in LINQ queries
    public void AnonymousTypesInLINQ()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        var results = numbers.Select(n => new
        {
            Number = n,
            Square = n * n,
            Cube = n * n * n,
            IsEven = n % 2 == 0
        });

        foreach (var item in results)
        {
            Console.WriteLine($"{item.Number}: Square={item.Square}, Cube={item.Cube}, Even={item.IsEven}");
        }
    }

    // Grouping in algorithms
    public void GroupingExample()
    {
        string[] words = { "apple", "banana", "apricot", "blueberry", "avocado" };

        var grouped = words
            .Select(w => new { Word = w, FirstLetter = w[0], Length = w.Length })
            .GroupBy(x => x.FirstLetter)
            .Select(g => new
            {
                Letter = g.Key,
                Words = g.Select(x => x.Word).ToList(),
                Count = g.Count(),
                AverageLength = g.Average(x => x.Length)
            });

        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Letter}: {group.Count} words, avg length: {group.AverageLength:F2}");
            Console.WriteLine($"  Words: {string.Join(", ", group.Words)}");
        }
    }
}
```

#### Tuples - Modern Alternative

```csharp
public class TupleExamples
{
    // Value tuples (C# 7+) - preferred over anonymous types for return values
    public (int Min, int Max) FindMinMax(int[] array)
    {
        if (array.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        int min = array[0], max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min) min = array[i];
            if (array[i] > max) max = array[i];
        }

        return (min, max);
    }

    // Deconstruction
    public void UseTuples()
    {
        int[] numbers = { 5, 2, 8, 1, 9 };

        var (min, max) = FindMinMax(numbers);
        Console.WriteLine($"Min: {min}, Max: {max}");

        // Can also use with var
        var result = FindMinMax(numbers);
        Console.WriteLine($"Min: {result.Min}, Max: {result.Max}");
    }

    // Multiple return values for algorithm results
    public (bool Found, int Index, int Value) BinarySearchDetailed(int[] sortedArray, int target)
    {
        int left = 0, right = sortedArray.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (sortedArray[mid] == target)
                return (true, mid, sortedArray[mid]);
            else if (sortedArray[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return (false, -1, 0);
    }

    // Pattern matching with tuples (C# 10+)
    public string ClassifyPoint((int X, int Y) point) => point switch
    {
        (0, 0) => "Origin",
        var (x, y) when x > 0 && y > 0 => "Quadrant I",
        var (x, y) when x < 0 && y > 0 => "Quadrant II",
        var (x, y) when x < 0 && y < 0 => "Quadrant III",
        var (x, y) when x > 0 && y < 0 => "Quadrant IV",
        (_, 0) => "On X-axis",
        (0, _) => "On Y-axis",
        _ => "Unknown"
    };
}
```

**When to use**:
- Anonymous types: Temporary projections in LINQ queries
- Tuples: Multiple return values, temporary data structures
- Records: Immutable data transfer objects (more permanent)

---

### 1.3 Nullable Reference Types in Action

Building on Session 1, let's see how nullable reference types help prevent bugs in algorithm implementations.

```csharp
#nullable enable

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; }

    public ListNode(int value)
    {
        Value = value;
    }
}

public class LinkedListAlgorithms
{
    // Reverse linked list - null-safe
    public ListNode? Reverse(ListNode? head)
    {
        ListNode? prev = null;
        ListNode? current = head;

        while (current != null)
        {
            ListNode? next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    // Find middle node - null-safe
    public ListNode? FindMiddle(ListNode? head)
    {
        if (head == null) return null;

        ListNode? slow = head;
        ListNode? fast = head;

        while (fast?.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }

    // Detect cycle - null-safe
    public bool HasCycle(ListNode? head)
    {
        if (head == null) return false;

        ListNode? slow = head;
        ListNode? fast = head.Next;

        while (fast != null && fast.Next != null)
        {
            if (slow == fast) return true;

            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return false;
    }
}
```

---

## 📊 Part 2: Algorithmic Patterns

### 2.1 Two Pointers Technique

The Two Pointers technique uses two indices to traverse a data structure (array, list, or string) either toward each other or in the same direction to solve problems efficiently, often reducing time complexity from O(n²) to O(n).

**Source**: [GeeksforGeeks - Two Pointers Technique](https://www.geeksforgeeks.org/dsa/two-pointers-technique/), [USACO Guide - Two Pointers](https://usaco.guide/silver/two-pointers), [Hello Interview - Two-Pointer Overview](https://www.hellointerview.com/learn/code/two-pointers/overview)

#### Pattern 1: Opposite Direction (Convergent Pointers)

```csharp
public class TwoPointersOpposite
{
    // Example 1: Two Sum (sorted array)
    // Time: O(n), Space: O(1)
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0, right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            if (sum == target)
                return new int[] { left, right };
            else if (sum < target)
                left++;  // Need larger sum
            else
                right--; // Need smaller sum
        }

        return new int[] { -1, -1 };
    }

    // Example 2: Valid Palindrome
    // Time: O(n), Space: O(1)
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

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
            int currentHeight = Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, width * currentHeight);

            // Move the pointer with smaller height
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
            // Swap
            (array[left], array[right]) = (array[right], array[left]);
            left++;
            right--;
        }
    }
}
```

#### Pattern 2: Same Direction (Fast and Slow Pointers)

```csharp
public class TwoPointersSameDirection
{
    // Example 1: Remove Duplicates from Sorted Array
    // Time: O(n), Space: O(1)
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int slow = 0; // Points to last unique element

        for (int fast = 1; fast < nums.Length; fast++)
        {
            if (nums[fast] != nums[slow])
            {
                slow++;
                nums[slow] = nums[fast];
            }
        }

        return slow + 1; // Length of unique elements
    }

    // Example 2: Move Zeroes to end
    // Time: O(n), Space: O(1)
    public void MoveZeroes(int[] nums)
    {
        int slow = 0; // Position for next non-zero

        // Move all non-zeros to front
        for (int fast = 0; fast < nums.Length; fast++)
        {
            if (nums[fast] != 0)
            {
                nums[slow] = nums[fast];
                slow++;
            }
        }

        // Fill rest with zeros
        while (slow < nums.Length)
        {
            nums[slow] = 0;
            slow++;
        }
    }

    // Example 3: Remove Element
    // Time: O(n), Space: O(1)
    public int RemoveElement(int[] nums, int val)
    {
        int slow = 0;

        for (int fast = 0; fast < nums.Length; fast++)
        {
            if (nums[fast] != val)
            {
                nums[slow] = nums[fast];
                slow++;
            }
        }

        return slow;
    }

    // Example 4: Partition Array (Quick Sort partition)
    // Time: O(n), Space: O(1)
    public void PartitionArray(int[] nums, int pivot)
    {
        int slow = 0; // Boundary between < pivot and >= pivot

        for (int fast = 0; fast < nums.Length; fast++)
        {
            if (nums[fast] < pivot)
            {
                (nums[slow], nums[fast]) = (nums[fast], nums[slow]);
                slow++;
            }
        }
    }
}
```

#### Pattern 3: Fast and Slow Pointers (Cycle Detection)

```csharp
public class FastSlowPointers
{
    // Floyd's Cycle Detection Algorithm
    // Time: O(n), Space: O(1)
    public bool HasCycle(ListNode? head)
    {
        if (head == null) return false;

        ListNode? slow = head;
        ListNode? fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;

            if (slow == fast) return true;
        }

        return false;
    }

    // Find cycle start
    public ListNode? DetectCycle(ListNode? head)
    {
        if (head == null) return null;

        // Phase 1: Detect if cycle exists
        ListNode? slow = head;
        ListNode? fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;

            if (slow == fast) // Cycle detected
            {
                // Phase 2: Find cycle start
                slow = head;
                while (slow != fast)
                {
                    slow = slow?.Next;
                    fast = fast?.Next;
                }
                return slow;
            }
        }

        return null;
    }

    // Find middle of linked list
    public ListNode? FindMiddle(ListNode? head)
    {
        if (head == null) return null;

        ListNode? slow = head;
        ListNode? fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }
}
```

**When to use Two Pointers**:
- ✅ Array/string is sorted (or can be sorted)
- ✅ Finding pairs or subarrays with specific properties
- ✅ In-place modifications without extra space
- ✅ Palindrome checking
- ✅ Linked list cycle detection
- ✅ Partitioning arrays

---

### 2.2 Sliding Window Pattern

The Sliding Window technique maintains a subset of elements (the "window") as you iterate through data. This window can be fixed or variable in size, allowing efficient processing without unnecessary repetition, often reducing complexity from O(n²) to O(n).

**Source**: [LeetCode - Sliding Window Technique Guide](https://leetcode.com/discuss/post/3722472/sliding-window-technique-a-comprehensive-ix2k/), [GeeksforGeeks - Sliding Window](https://www.geeksforgeeks.org/dsa/window-sliding-technique/), [AlgoCademy - Mastering Sliding Window](https://algocademy.com/blog/mastering-the-sliding-window-technique-a-comprehensive-guide/)

#### Pattern 1: Fixed Window Size

```csharp
public class FixedSlidingWindow
{
    // Example 1: Maximum sum of k consecutive elements
    // Time: O(n), Space: O(1)
    public int MaxSumSubarray(int[] arr, int k)
    {
        if (arr.Length < k)
            throw new ArgumentException("Array size must be >= k");

        // Calculate sum of first window
        int windowSum = 0;
        for (int i = 0; i < k; i++)
        {
            windowSum += arr[i];
        }

        int maxSum = windowSum;

        // Slide the window
        for (int i = k; i < arr.Length; i++)
        {
            windowSum = windowSum - arr[i - k] + arr[i]; // Remove left, add right
            maxSum = Math.Max(maxSum, windowSum);
        }

        return maxSum;
    }

    // Example 2: Average of subarrays of size K
    // Time: O(n), Space: O(n-k+1)
    public double[] FindAverages(int[] arr, int k)
    {
        if (arr.Length < k) return Array.Empty<double>();

        double[] result = new double[arr.Length - k + 1];
        double windowSum = 0;

        // First window
        for (int i = 0; i < k; i++)
        {
            windowSum += arr[i];
        }
        result[0] = windowSum / k;

        // Slide window
        for (int i = k; i < arr.Length; i++)
        {
            windowSum = windowSum - arr[i - k] + arr[i];
            result[i - k + 1] = windowSum / k;
        }

        return result;
    }

    // Example 3: Contains Duplicate within k distance
    // Time: O(n), Space: O(k)
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var window = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Remove element outside window
            if (i > k)
            {
                window.Remove(nums[i - k - 1]);
            }

            // Check if duplicate in window
            if (!window.Add(nums[i]))
                return true;
        }

        return false;
    }

    // Example 4: Maximum in each window of size k
    // Time: O(n), Space: O(n)
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == 0 || k == 0) return Array.Empty<int>();

        int[] result = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>(); // Stores indices

        for (int i = 0; i < nums.Length; i++)
        {
            // Remove indices outside window
            while (deque.Count > 0 && deque.First!.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // Remove smaller elements (not useful)
            while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            // Add to result when window is complete
            if (i >= k - 1)
            {
                result[i - k + 1] = nums[deque.First!.Value];
            }
        }

        return result;
    }
}
```

#### Pattern 2: Variable Window Size

```csharp
public class VariableSlidingWindow
{
    // Example 1: Smallest subarray with sum >= target
    // Time: O(n), Space: O(1)
    public int MinSubArrayLen(int target, int[] nums)
    {
        int minLength = int.MaxValue;
        int windowSum = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            windowSum += nums[right];

            // Shrink window while condition is met
            while (windowSum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                windowSum -= nums[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }

    // Example 2: Longest substring without repeating characters
    // Time: O(n), Space: O(min(n, charset size))
    public int LengthOfLongestSubstring(string s)
    {
        var charSet = new HashSet<char>();
        int maxLength = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // Shrink window until no duplicates
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left]);
                left++;
            }

            charSet.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    // Example 3: Longest substring with at most K distinct characters
    // Time: O(n), Space: O(k)
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        if (k == 0) return 0;

        var charFreq = new Dictionary<char, int>();
        int maxLength = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // Expand window
            charFreq[s[right]] = charFreq.GetValueOrDefault(s[right], 0) + 1;

            // Shrink window if too many distinct chars
            while (charFreq.Count > k)
            {
                charFreq[s[left]]--;
                if (charFreq[s[left]] == 0)
                    charFreq.Remove(s[left]);
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    // Example 4: Find all anagrams in string
    // Time: O(n), Space: O(1) - fixed charset size
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        if (s.Length < p.Length) return result;

        // Frequency map for pattern
        var pFreq = new Dictionary<char, int>();
        foreach (char c in p)
            pFreq[c] = pFreq.GetValueOrDefault(c, 0) + 1;

        var windowFreq = new Dictionary<char, int>();
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // Expand window
            windowFreq[s[right]] = windowFreq.GetValueOrDefault(s[right], 0) + 1;

            // Shrink window if too large
            if (right - left + 1 > p.Length)
            {
                windowFreq[s[left]]--;
                if (windowFreq[s[left]] == 0)
                    windowFreq.Remove(s[left]);
                left++;
            }

            // Check if window matches pattern
            if (right - left + 1 == p.Length &&
                windowFreq.Count == pFreq.Count &&
                windowFreq.All(kvp => pFreq.ContainsKey(kvp.Key) && pFreq[kvp.Key] == kvp.Value))
            {
                result.Add(left);
            }
        }

        return result;
    }
}
```

#### Sliding Window Template

```csharp
public class SlidingWindowTemplate
{
    // Generic template for variable window
    public int SlidingWindowTemplate(int[] arr, int target)
    {
        int left = 0;
        int result = 0; // or int.MaxValue for minimum
        // State variables (sum, count, frequency map, etc.)

        for (int right = 0; right < arr.Length; right++)
        {
            // 1. Expand window: add arr[right] to state

            // 2. Shrink window while condition is violated
            while (/* window condition is violated */)
            {
                // Remove arr[left] from state
                left++;
            }

            // 3. Update result
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
```

**When to use Sliding Window**:
- ✅ Problems about subarrays or substrings
- ✅ Finding max/min length with certain properties
- ✅ Contiguous elements with sum/product conditions
- ✅ Pattern matching in strings
- ✅ When brute force would use nested loops

---

### 2.3 Prefix Sum Technique

Prefix Sum (also called cumulative sum) is a preprocessing technique that allows answering range sum queries in O(1) time after O(n) preprocessing. The prefix sum at index i represents the sum of all elements from index 0 to i.

**Source**: [GeeksforGeeks - Prefix Sum](https://www.geeksforgeeks.org/dsa/prefix-sum-array-implementation-applications-competitive-programming/), [USACO Guide - Prefix Sums](https://usaco.guide/silver/prefix-sums), [AlgoCademy - Mastering Prefix Sum](https://algocademy.com/blog/mastering-prefix-sum-a-powerful-technique-for-efficient-array-computations/)

#### 1D Prefix Sum

```csharp
public class PrefixSum1D
{
    // Build prefix sum array
    // Time: O(n), Space: O(n)
    public int[] BuildPrefixSum(int[] arr)
    {
        int n = arr.Length;
        int[] prefixSum = new int[n + 1]; // Extra space for convenience

        for (int i = 0; i < n; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + arr[i];
        }

        return prefixSum;
    }

    // Range sum query [left, right] inclusive
    // Time: O(1) after O(n) preprocessing
    public int RangeSum(int[] prefixSum, int left, int right)
    {
        return prefixSum[right + 1] - prefixSum[left];
    }

    // Example: Range sum query class
    public class NumArray
    {
        private int[] prefixSum;

        // Constructor: O(n) preprocessing
        public NumArray(int[] nums)
        {
            prefixSum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + nums[i];
            }
        }

        // Query: O(1)
        public int SumRange(int left, int right)
        {
            return prefixSum[right + 1] - prefixSum[left];
        }
    }

    // Example: Subarray sum equals K
    // Time: O(n), Space: O(n)
    public int SubarraySum(int[] nums, int k)
    {
        var prefixSumCount = new Dictionary<int, int>();
        prefixSumCount[0] = 1; // Empty prefix has sum 0

        int count = 0;
        int currentSum = 0;

        foreach (int num in nums)
        {
            currentSum += num;

            // Check if (currentSum - k) exists
            // If yes, there's a subarray with sum k
            if (prefixSumCount.ContainsKey(currentSum - k))
            {
                count += prefixSumCount[currentSum - k];
            }

            prefixSumCount[currentSum] = prefixSumCount.GetValueOrDefault(currentSum, 0) + 1;
        }

        return count;
    }

    // Example: Contiguous array (equal 0s and 1s)
    // Time: O(n), Space: O(n)
    public int FindMaxLength(int[] nums)
    {
        var prefixMap = new Dictionary<int, int>();
        prefixMap[0] = -1; // Prefix sum 0 at index -1

        int maxLength = 0;
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += (nums[i] == 1 ? 1 : -1); // Convert 0 to -1

            if (prefixMap.ContainsKey(sum))
            {
                maxLength = Math.Max(maxLength, i - prefixMap[sum]);
            }
            else
            {
                prefixMap[sum] = i;
            }
        }

        return maxLength;
    }

    // Example: Product of array except self
    // Time: O(n), Space: O(1) excluding output
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        // Left products (prefix)
        result[0] = 1;
        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        // Right products (suffix) - calculate on the fly
        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return result;
    }
}
```

#### 2D Prefix Sum

```csharp
public class PrefixSum2D
{
    // Build 2D prefix sum
    // Time: O(m*n), Space: O(m*n)
    public int[,] BuildPrefixSum2D(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] prefixSum = new int[rows + 1, cols + 1];

        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                prefixSum[i, j] = matrix[i - 1, j - 1]
                                + prefixSum[i - 1, j]      // Top
                                + prefixSum[i, j - 1]      // Left
                                - prefixSum[i - 1, j - 1]; // Remove overlap
            }
        }

        return prefixSum;
    }

    // Range sum query for submatrix [row1, col1] to [row2, col2]
    // Time: O(1) after preprocessing
    public int SumRegion(int[,] prefixSum, int row1, int col1, int row2, int col2)
    {
        return prefixSum[row2 + 1, col2 + 1]
             - prefixSum[row1, col2 + 1]      // Top
             - prefixSum[row2 + 1, col1]      // Left
             + prefixSum[row1, col1];         // Add back overlap
    }

    // Complete implementation
    public class NumMatrix
    {
        private int[,] prefixSum;

        public NumMatrix(int[,] matrix)
        {
            if (matrix.Length == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            prefixSum = new int[rows + 1, cols + 1];

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    prefixSum[i, j] = matrix[i - 1, j - 1]
                                    + prefixSum[i - 1, j]
                                    + prefixSum[i, j - 1]
                                    - prefixSum[i - 1, j - 1];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return prefixSum[row2 + 1, col2 + 1]
                 - prefixSum[row1, col2 + 1]
                 - prefixSum[row2 + 1, col1]
                 + prefixSum[row1, col1];
        }
    }
}
```

**When to use Prefix Sum**:
- ✅ Multiple range sum queries on static array
- ✅ Subarray sum problems
- ✅ 2D matrix range queries
- ✅ Problems requiring cumulative information
- ✅ Converting problems to difference problems

---

### 2.4 Frequency Counting Pattern

Frequency counting using hash maps is a fundamental pattern that involves counting occurrences of elements efficiently, often replacing nested loops with O(n) solutions.

**Source**: [TeddySmith.IO - Frequency Counters](https://teddysmith.io/frequency-counters-algorithm-pattern/), [LeetCode - Mastering Hashtable Patterns](https://leetcode.com/discuss/study-guide/4042753/**-Mastering-Hashtable-Patterns:-A-Comprehensive-Guide/), [GeeksforGeeks - Counting Frequencies](https://www.geeksforgeeks.org/dsa/counting-frequencies-of-array-elements/)

```csharp
public class FrequencyCountingPatterns
{
    // Example 1: First Unique Character
    // Time: O(n), Space: O(1) - fixed charset
    public int FirstUniqChar(string s)
    {
        var freq = new Dictionary<char, int>();

        // Count frequencies
        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }

        // Find first unique
        for (int i = 0; i < s.Length; i++)
        {
            if (freq[s[i]] == 1)
                return i;
        }

        return -1;
    }

    // Example 2: Valid Anagram
    // Time: O(n), Space: O(1) - fixed charset
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var freq = new Dictionary<char, int>();

        // Count s
        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }

        // Subtract t
        foreach (char c in t)
        {
            if (!freq.ContainsKey(c))
                return false;

            freq[c]--;
            if (freq[c] < 0)
                return false;
        }

        return freq.Values.All(v => v == 0);
    }

    // Example 3: Group Anagrams
    // Time: O(n * k log k) where k is max string length
    // Space: O(n * k)
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            // Sort string to get key
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if (!groups.ContainsKey(key))
                groups[key] = new List<string>();

            groups[key].Add(str);
        }

        return groups.Values.ToList<IList<string>>();
    }

    // Example 4: Top K Frequent Elements
    // Time: O(n log k), Space: O(n)
    public int[] TopKFrequent(int[] nums, int k)
    {
        // Count frequencies
        var freq = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            freq[num] = freq.GetValueOrDefault(num, 0) + 1;
        }

        // Use min-heap of size k
        var minHeap = new PriorityQueue<int, int>();

        foreach (var (num, count) in freq)
        {
            minHeap.Enqueue(num, count);

            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        // Extract elements
        int[] result = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            result[i] = minHeap.Dequeue();
        }

        return result;
    }

    // Example 5: Sort Characters By Frequency
    // Time: O(n log n), Space: O(n)
    public string FrequencySort(string s)
    {
        var freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            freq[c] = freq.GetValueOrDefault(c, 0) + 1;
        }

        // Sort by frequency descending
        var sorted = freq.OrderByDescending(kvp => kvp.Value)
                        .ThenBy(kvp => kvp.Key);

        var result = new System.Text.StringBuilder();
        foreach (var (ch, count) in sorted)
        {
            result.Append(ch, count);
        }

        return result.ToString();
    }

    // Example 6: Majority Element (Boyer-Moore Voting)
    // Time: O(n), Space: O(1)
    public int MajorityElement(int[] nums)
    {
        int candidate = nums[0];
        int count = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (count == 0)
            {
                candidate = nums[i];
                count = 1;
            }
            else if (nums[i] == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return candidate;
    }

    // Example 7: Subarray with given sum (using frequency map)
    // Time: O(n), Space: O(n)
    public int SubarraySum(int[] nums, int k)
    {
        var prefixSumFreq = new Dictionary<int, int>();
        prefixSumFreq[0] = 1;

        int count = 0;
        int sum = 0;

        foreach (int num in nums)
        {
            sum += num;

            if (prefixSumFreq.ContainsKey(sum - k))
            {
                count += prefixSumFreq[sum - k];
            }

            prefixSumFreq[sum] = prefixSumFreq.GetValueOrDefault(sum, 0) + 1;
        }

        return count;
    }
}
```

**When to use Frequency Counting**:
- ✅ Finding duplicates or unique elements
- ✅ Anagram problems
- ✅ Counting occurrences
- ✅ Top K elements
- ✅ Character/element frequency analysis

---

## 🔧 Part 3: Hash-Based Data Structures

### 3.1 Understanding Hash Tables

Hash tables provide O(1) average-case time for insert, delete, and lookup operations. Understanding their internals helps you use them effectively.

**Source**: [Microsoft Learn - Hashtable and Dictionary](https://learn.microsoft.com/en-us/dotnet/standard/collections/hashtable-and-dictionary-collection-types), [Medium - Diving into HashSet](https://medium.com/@idlerboris/diving-into-hashset-e1070b23c71a), [GitHub - HashSet and Dictionary Internals](https://github.com/Tyrrrz/interview-questions/blob/master/C#/HashSet%20and%20Dictionary.md)

#### How Hash Tables Work

```csharp
// Conceptual implementation
public class SimpleHashMap<TKey, TValue> where TKey : notnull
{
    private class Entry
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public int HashCode { get; set; }
        public int Next { get; set; } // Index of next entry in chain

        public Entry(TKey key, TValue value, int hashCode)
        {
            Key = key;
            Value = value;
            HashCode = hashCode;
            Next = -1;
        }
    }

    private int[] buckets;     // Bucket array (stores index to entries)
    private Entry[] entries;   // Entry array (stores actual data)
    private int count;
    private int freeList;
    private const double LoadFactor = 0.75;

    public SimpleHashMap(int capacity = 7)
    {
        int size = GetPrime(capacity);
        buckets = new int[size];
        entries = new Entry[size];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = -1;
        }

        freeList = -1;
        count = 0;
    }

    // Add or update key-value pair
    public void Add(TKey key, TValue value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        // Calculate hash code and bucket
        int hashCode = key.GetHashCode() & 0x7FFFFFFF;
        int bucket = hashCode % buckets.Length;

        // Check if key exists
        for (int i = buckets[bucket]; i >= 0; i = entries[i].Next)
        {
            if (entries[i].HashCode == hashCode &&
                EqualityComparer<TKey>.Default.Equals(entries[i].Key, key))
            {
                entries[i].Value = value; // Update existing
                return;
            }
        }

        // Resize if needed
        if (count >= entries.Length * LoadFactor)
        {
            Resize();
            bucket = hashCode % buckets.Length;
        }

        // Add new entry
        int index = count++;
        entries[index] = new Entry(key, value, hashCode);
        entries[index].Next = buckets[bucket];
        buckets[bucket] = index;
    }

    // Get value by key
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        int hashCode = key.GetHashCode() & 0x7FFFFFFF;
        int bucket = hashCode % buckets.Length;

        for (int i = buckets[bucket]; i >= 0; i = entries[i].Next)
        {
            if (entries[i].HashCode == hashCode &&
                EqualityComparer<TKey>.Default.Equals(entries[i].Key, key))
            {
                value = entries[i].Value;
                return true;
            }
        }

        value = default!;
        return false;
    }

    // Resize and rehash
    private void Resize()
    {
        int newSize = GetPrime(buckets.Length * 2);
        int[] newBuckets = new int[newSize];
        Entry[] newEntries = new Entry[newSize];

        for (int i = 0; i < newBuckets.Length; i++)
        {
            newBuckets[i] = -1;
        }

        Array.Copy(entries, 0, newEntries, 0, count);

        for (int i = 0; i < count; i++)
        {
            int bucket = newEntries[i].HashCode % newSize;
            newEntries[i].Next = newBuckets[bucket];
            newBuckets[bucket] = i;
        }

        buckets = newBuckets;
        entries = newEntries;
    }

    // Get next prime number (simplified)
    private int GetPrime(int min)
    {
        for (int i = min | 1; i < int.MaxValue; i += 2)
        {
            if (IsPrime(i))
                return i;
        }
        return min;
    }

    private bool IsPrime(int candidate)
    {
        if (candidate < 2) return false;
        if (candidate == 2) return true;
        if (candidate % 2 == 0) return false;

        int limit = (int)Math.Sqrt(candidate);
        for (int i = 3; i <= limit; i += 2)
        {
            if (candidate % i == 0)
                return false;
        }
        return true;
    }

    public int Count => count;
}
```

#### C# Dictionary<TKey, TValue> Internals

```csharp
public class DictionaryInternals
{
    public void ExplainDictionary()
    {
        /*
         * Dictionary<TKey, TValue> uses:
         *
         * 1. Two arrays:
         *    - buckets[]: Contains index to first entry in chain (-1 if empty)
         *    - entries[]: Contains Entry structs with actual data
         *
         * 2. Entry struct contains:
         *    - hashCode: Cached hash code of key
         *    - next: Index of next entry in collision chain (-1 if last)
         *    - key: The actual key
         *    - value: The actual value
         *
         * 3. Collision resolution: Separate chaining using array indices
         *
         * 4. Load factor: 0.75 (resizes when 75% full)
         *
         * 5. Capacity: Always prime number for better distribution
         *
         * 6. GetHashCode():
         *    - Uses key.GetHashCode()
         *    - ANDs with 0x7FFFFFFF to make positive
         *    - Takes modulo with bucket count to get bucket index
         *
         * 7. Performance:
         *    - Average O(1) for insert, delete, lookup
         *    - Worst O(n) if all keys hash to same bucket
         *    - In practice, very close to O(1)
         */
    }

    // Custom equality comparer example
    public class CaseInsensitiveComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return obj.ToLowerInvariant().GetHashCode();
        }
    }

    public void CustomComparerExample()
    {
        var dict = new Dictionary<string, int>(new CaseInsensitiveComparer());

        dict["Hello"] = 1;
        dict["HELLO"] = 2; // Overwrites previous value

        Console.WriteLine(dict["hello"]); // 2
        Console.WriteLine(dict.Count);    // 1
    }
}
```

#### C# HashSet<T> Internals

```csharp
public class HashSetInternals
{
    public void ExplainHashSet()
    {
        /*
         * HashSet<T> is implemented identically to Dictionary<TKey, TValue>
         * but only stores keys (no values).
         *
         * Key properties:
         * 1. No duplicate elements
         * 2. Unordered collection
         * 3. O(1) Add, Remove, Contains (average case)
         * 4. Set operations: UnionWith, IntersectWith, ExceptWith, etc.
         *
         * Internal structure:
         * - buckets[]: Indices to entries
         * - slots[]: Contains hash code, value, and next index
         * - Same collision resolution as Dictionary
         */
    }

    // Set operations examples
    public void SetOperations()
    {
        var set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        var set2 = new HashSet<int> { 4, 5, 6, 7, 8 };

        // Union: {1, 2, 3, 4, 5, 6, 7, 8}
        var union = new HashSet<int>(set1);
        union.UnionWith(set2);

        // Intersection: {4, 5}
        var intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);

        // Difference: {1, 2, 3}
        var difference = new HashSet<int>(set1);
        difference.ExceptWith(set2);

        // Symmetric difference: {1, 2, 3, 6, 7, 8}
        var symmetricDiff = new HashSet<int>(set1);
        symmetricDiff.SymmetricExceptWith(set2);

        // Subset check
        bool isSubset = set1.IsSubsetOf(set2); // false

        // Superset check
        bool isSuperset = set1.IsSupersetOf(new HashSet<int> { 1, 2 }); // true
    }
}
```

### 3.2 Implementing HashSet from Scratch

```csharp
public class CustomHashSet<T> where T : notnull
{
    private struct Slot
    {
        public int HashCode;
        public T Value;
        public int Next;
    }

    private int[] buckets;
    private Slot[] slots;
    private int count;
    private int freeList;
    private const double LoadFactor = 0.75;
    private readonly IEqualityComparer<T> comparer;

    public CustomHashSet(IEqualityComparer<T>? comparer = null)
    {
        this.comparer = comparer ?? EqualityComparer<T>.Default;
        int size = 7; // Start with prime
        buckets = new int[size];
        slots = new Slot[size];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = -1;
        }

        freeList = -1;
        count = 0;
    }

    public bool Add(T value)
    {
        int hashCode = comparer.GetHashCode(value) & 0x7FFFFFFF;
        int bucket = hashCode % buckets.Length;

        // Check if already exists
        for (int i = buckets[bucket]; i >= 0; i = slots[i].Next)
        {
            if (slots[i].HashCode == hashCode &&
                comparer.Equals(slots[i].Value, value))
            {
                return false; // Already exists
            }
        }

        // Resize if needed
        if (count >= slots.Length * LoadFactor)
        {
            Resize();
            bucket = hashCode % buckets.Length;
        }

        // Add new element
        int index = count++;
        slots[index].HashCode = hashCode;
        slots[index].Value = value;
        slots[index].Next = buckets[bucket];
        buckets[bucket] = index;

        return true;
    }

    public bool Contains(T value)
    {
        int hashCode = comparer.GetHashCode(value) & 0x7FFFFFFF;
        int bucket = hashCode % buckets.Length;

        for (int i = buckets[bucket]; i >= 0; i = slots[i].Next)
        {
            if (slots[i].HashCode == hashCode &&
                comparer.Equals(slots[i].Value, value))
            {
                return true;
            }
        }

        return false;
    }

    public bool Remove(T value)
    {
        int hashCode = comparer.GetHashCode(value) & 0x7FFFFFFF;
        int bucket = hashCode % buckets.Length;
        int last = -1;

        for (int i = buckets[bucket]; i >= 0; last = i, i = slots[i].Next)
        {
            if (slots[i].HashCode == hashCode &&
                comparer.Equals(slots[i].Value, value))
            {
                if (last < 0)
                {
                    buckets[bucket] = slots[i].Next;
                }
                else
                {
                    slots[last].Next = slots[i].Next;
                }

                slots[i].HashCode = -1;
                slots[i].Value = default!;
                slots[i].Next = freeList;
                freeList = i;
                count--;

                return true;
            }
        }

        return false;
    }

    private void Resize()
    {
        int newSize = GetPrime(buckets.Length * 2);
        int[] newBuckets = new int[newSize];
        Slot[] newSlots = new Slot[newSize];

        for (int i = 0; i < newBuckets.Length; i++)
        {
            newBuckets[i] = -1;
        }

        Array.Copy(slots, 0, newSlots, 0, count);

        for (int i = 0; i < count; i++)
        {
            int bucket = newSlots[i].HashCode % newSize;
            newSlots[i].Next = newBuckets[bucket];
            newBuckets[bucket] = i;
        }

        buckets = newBuckets;
        slots = newSlots;
    }

    private int GetPrime(int min)
    {
        // Simplified prime finder
        int[] primes = { 7, 17, 37, 79, 163, 331, 673, 1361, 2729, 5471,
                        10949, 21911, 43853, 87719, 175447, 350899 };

        foreach (int prime in primes)
        {
            if (prime >= min)
                return prime;
        }

        return min;
    }

    public int Count => count;

    public void Clear()
    {
        if (count > 0)
        {
            Array.Clear(buckets, 0, buckets.Length);
            Array.Clear(slots, 0, slots.Length);
            count = 0;
            freeList = -1;
        }
    }
}
```

### 3.3 Dictionary vs HashSet vs Hashtable

```csharp
public class CollectionComparison
{
    public void CompareCollections()
    {
        /*
         * Dictionary<TKey, TValue>:
         * - Generic (type-safe)
         * - Fast (no boxing for value types)
         * - Modern (.NET 2.0+)
         * - Throws exception on duplicate key
         * - NOT thread-safe
         * - Preferred choice in modern C#
         *
         * HashSet<T>:
         * - Generic (type-safe)
         * - Only stores values (no key-value pairs)
         * - Set operations (Union, Intersect, etc.)
         * - Ensures uniqueness
         * - NOT thread-safe
         * - Use for unique collections
         *
         * Hashtable:
         * - Non-generic (object-based)
         * - Boxing for value types (slower)
         * - Legacy (.NET 1.0)
         * - Thread-safe for reads (single writer, multiple readers)
         * - Avoid in new code
         *
         * ConcurrentDictionary<TKey, TValue>:
         * - Thread-safe
         * - Multiple readers and writers
         * - Lock-free for reads
         * - Use for concurrent scenarios
         */
    }

    // Performance comparison
    public void PerformanceTest()
    {
        const int iterations = 1_000_000;

        // Dictionary (fastest)
        var dict = new Dictionary<int, string>();
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            dict[i] = i.ToString();
        }
        sw.Stop();
        Console.WriteLine($"Dictionary: {sw.ElapsedMilliseconds}ms");

        // HashSet
        var set = new HashSet<int>();
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            set.Add(i);
        }
        sw.Stop();
        Console.WriteLine($"HashSet: {sw.ElapsedMilliseconds}ms");

        // Hashtable (slowest due to boxing)
        var hashtable = new System.Collections.Hashtable();
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            hashtable[i] = i.ToString();
        }
        sw.Stop();
        Console.WriteLine($"Hashtable: {sw.ElapsedMilliseconds}ms");
    }
}
```

---

## 💻 Part 4: Practice Exercises

### Exercise 1: Container With Most Water (Two Pointers)

**Problem**: Given array of heights, find two lines that together with x-axis form container with most water.

```csharp
public class ContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        // TODO: Implement using two pointers
        // Time: O(n), Space: O(1)
        // Example: [1,8,6,2,5,4,8,3,7] → 49
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new ContainerWithMostWater();
Console.WriteLine(solution.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 })); // 49
Console.WriteLine(solution.MaxArea(new int[] { 1, 1 })); // 1
```

**Hint**: Start with widest container, move pointer with smaller height inward.

---

### Exercise 2: Longest Substring Without Repeating Characters (Sliding Window)

**Problem**: Find length of longest substring without repeating characters.

```csharp
public class LongestSubstringWithoutRepeating
{
    public int LengthOfLongestSubstring(string s)
    {
        // TODO: Implement using sliding window + HashSet
        // Time: O(n), Space: O(min(n, charset))
        // Example: "abcabcbb" → 3 (abc)
        // Example: "bbbbb" → 1 (b)
        // Example: "pwwkew" → 3 (wke)
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new LongestSubstringWithoutRepeating();
Console.WriteLine(solution.LengthOfLongestSubstring("abcabcbb")); // 3
Console.WriteLine(solution.LengthOfLongestSubstring("bbbbb"));    // 1
Console.WriteLine(solution.LengthOfLongestSubstring("pwwkew"));   // 3
```

**Hint**: Use HashSet to track characters in current window.

---

### Exercise 3: Subarray Sum Equals K (Prefix Sum + Hash Map)

**Problem**: Count number of continuous subarrays whose sum equals k.

```csharp
public class SubarraySumK
{
    public int SubarraySum(int[] nums, int k)
    {
        // TODO: Implement using prefix sum + Dictionary
        // Time: O(n), Space: O(n)
        // Example: [1,1,1], k=2 → 2
        // Example: [1,2,3], k=3 → 2
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new SubarraySumK();
Console.WriteLine(solution.SubarraySum(new int[] { 1, 1, 1 }, 2));    // 2
Console.WriteLine(solution.SubarraySum(new int[] { 1, 2, 3 }, 3));    // 2
Console.WriteLine(solution.SubarraySum(new int[] { 1, -1, 0 }, 0));   // 3
```

**Hint**: Use prefix sum and check if `(currentSum - k)` exists in map.

---

### Exercise 4: Valid Anagram (Frequency Counting)

**Problem**: Check if two strings are anagrams.

```csharp
public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        // TODO: Implement using frequency counting
        // Time: O(n), Space: O(1) - fixed charset
        // Example: "anagram", "nagaram" → true
        // Example: "rat", "car" → false
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new ValidAnagram();
Console.WriteLine(solution.IsAnagram("anagram", "nagaram")); // true
Console.WriteLine(solution.IsAnagram("rat", "car"));         // false
```

---

### Exercise 5: Minimum Window Substring (Advanced Sliding Window)

**Problem**: Find minimum window in `s` that contains all characters of `t`.

```csharp
public class MinimumWindowSubstring
{
    public string MinWindow(string s, string t)
    {
        // TODO: Implement using variable sliding window + frequency maps
        // Time: O(n + m), Space: O(1) - fixed charset
        // Example: s = "ADOBECODEBANC", t = "ABC" → "BANC"
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new MinimumWindowSubstring();
Console.WriteLine(solution.MinWindow("ADOBECODEBANC", "ABC")); // "BANC"
Console.WriteLine(solution.MinWindow("a", "a"));                // "a"
Console.WriteLine(solution.MinWindow("a", "aa"));               // ""
```

**Hint**: Track required characters and current window characters.

---

## 🎯 Part 5: Curated Practice Problems

### Two Pointers Problems (20 problems)

**Easy (10 problems)**:
1. [LeetCode 125 - Valid Palindrome](https://leetcode.com/problems/valid-palindrome/)
2. [LeetCode 167 - Two Sum II](https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/)
3. [LeetCode 344 - Reverse String](https://leetcode.com/problems/reverse-string/)
4. [LeetCode 345 - Reverse Vowels](https://leetcode.com/problems/reverse-vowels-of-a-string/)
5. [LeetCode 283 - Move Zeroes](https://leetcode.com/problems/move-zeroes/)
6. [LeetCode 26 - Remove Duplicates from Sorted Array](https://leetcode.com/problems/remove-duplicates-from-sorted-array/)
7. [LeetCode 27 - Remove Element](https://leetcode.com/problems/remove-element/)
8. [LeetCode 977 - Squares of Sorted Array](https://leetcode.com/problems/squares-of-a-sorted-array/)
9. [LeetCode 392 - Is Subsequence](https://leetcode.com/problems/is-subsequence/)
10. [LeetCode 680 - Valid Palindrome II](https://leetcode.com/problems/valid-palindrome-ii/)

**Medium (10 problems)**:
11. [LeetCode 15 - Three Sum](https://leetcode.com/problems/3sum/)
12. [LeetCode 16 - Three Sum Closest](https://leetcode.com/problems/3sum-closest/)
13. [LeetCode 11 - Container With Most Water](https://leetcode.com/problems/container-with-most-water/)
14. [LeetCode 75 - Sort Colors](https://leetcode.com/problems/sort-colors/)
15. [LeetCode 18 - Four Sum](https://leetcode.com/problems/4sum/)
16. [LeetCode 259 - Three Sum Smaller](https://leetcode.com/problems/3sum-smaller/)
17. [LeetCode 713 - Subarray Product Less Than K](https://leetcode.com/problems/subarray-product-less-than-k/)
18. [LeetCode 986 - Interval List Intersections](https://leetcode.com/problems/interval-list-intersections/)
19. [LeetCode 923 - Three Sum With Multiplicity](https://leetcode.com/problems/3sum-with-multiplicity/)
20. [LeetCode 881 - Boats to Save People](https://leetcode.com/problems/boats-to-save-people/)

**Source**: [Medium - Two Pointers in C#](https://medium.com/@hanxuyang0826/optimizing-code-efficiency-with-two-pointers-and-sliding-window-techniques-in-c-leetcode-problems-b1255873b696), [LeetCode Pattern Guide](https://blog.algomaster.io/p/15-leetcode-patterns)

---

### Sliding Window Problems (15 problems)

**Easy (5 problems)**:
1. [LeetCode 643 - Maximum Average Subarray I](https://leetcode.com/problems/maximum-average-subarray-i/)
2. [LeetCode 1456 - Maximum Vowels in Substring](https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/)
3. [LeetCode 1343 - Number of Sub-arrays of Size K](https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold/)
4. [LeetCode 219 - Contains Duplicate II](https://leetcode.com/problems/contains-duplicate-ii/)
5. [LeetCode 1984 - Minimum Difference Between Highest and Lowest](https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/)

**Medium (10 problems)**:
6. [LeetCode 3 - Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/)
7. [LeetCode 424 - Longest Repeating Character Replacement](https://leetcode.com/problems/longest-repeating-character-replacement/)
8. [LeetCode 438 - Find All Anagrams](https://leetcode.com/problems/find-all-anagrams-in-a-string/)
9. [LeetCode 567 - Permutation in String](https://leetcode.com/problems/permutation-in-string/)
10. [LeetCode 209 - Minimum Size Subarray Sum](https://leetcode.com/problems/minimum-size-subarray-sum/)
11. [LeetCode 1004 - Max Consecutive Ones III](https://leetcode.com/problems/max-consecutive-ones-iii/)
12. [LeetCode 1208 - Get Equal Substrings Within Budget](https://leetcode.com/problems/get-equal-substrings-within-budget/)
13. [LeetCode 1100 - Find K-Length Substrings With No Repeated Characters](https://leetcode.com/problems/find-k-length-substrings-with-no-repeated-characters/)
14. [LeetCode 1052 - Grumpy Bookstore Owner](https://leetcode.com/problems/grumpy-bookstore-owner/)
15. [LeetCode 76 - Minimum Window Substring](https://leetcode.com/problems/minimum-window-substring/) ⭐

**Source**: [LeetCode Sliding Window List](https://leetcode.com/problem-list/sliding-window/), [GitHub - Two Pointer & Sliding Window](https://github.com/saurabhxcod/Two_Pointer_And_Sliding_Window)

---

### Hash Map / Frequency Counting (15 problems)

**Easy (7 problems)**:
1. [LeetCode 1 - Two Sum](https://leetcode.com/problems/two-sum/)
2. [LeetCode 242 - Valid Anagram](https://leetcode.com/problems/valid-anagram/)
3. [LeetCode 383 - Ransom Note](https://leetcode.com/problems/ransom-note/)
4. [LeetCode 387 - First Unique Character](https://leetcode.com/problems/first-unique-character-in-a-string/)
5. [LeetCode 217 - Contains Duplicate](https://leetcode.com/problems/contains-duplicate/)
6. [LeetCode 1207 - Unique Number of Occurrences](https://leetcode.com/problems/unique-number-of-occurrences/)
7. [LeetCode 496 - Next Greater Element I](https://leetcode.com/problems/next-greater-element-i/)

**Medium (8 problems)**:
8. [LeetCode 49 - Group Anagrams](https://leetcode.com/problems/group-anagrams/)
9. [LeetCode 347 - Top K Frequent Elements](https://leetcode.com/problems/top-k-frequent-elements/)
10. [LeetCode 451 - Sort Characters By Frequency](https://leetcode.com/problems/sort-characters-by-frequency/)
11. [LeetCode 560 - Subarray Sum Equals K](https://leetcode.com/problems/subarray-sum-equals-k/)
12. [LeetCode 525 - Contiguous Array](https://leetcode.com/problems/contiguous-array/)
13. [LeetCode 974 - Subarray Sums Divisible by K](https://leetcode.com/problems/subarray-sums-divisible-by-k/)
14. [LeetCode 454 - 4Sum II](https://leetcode.com/problems/4sum-ii/)
15. [LeetCode 380 - Insert Delete GetRandom O(1)](https://leetcode.com/problems/insert-delete-getrandom-o1/)

---

### Prefix Sum Problems (10 problems)

**Easy (4 problems)**:
1. [LeetCode 303 - Range Sum Query - Immutable](https://leetcode.com/problems/range-sum-query-immutable/)
2. [LeetCode 1480 - Running Sum of 1d Array](https://leetcode.com/problems/running-sum-of-1d-array/)
3. [LeetCode 724 - Find Pivot Index](https://leetcode.com/problems/find-pivot-index/)
4. [LeetCode 1991 - Find Middle Index](https://leetcode.com/problems/find-the-middle-index-in-array/)

**Medium (6 problems)**:
5. [LeetCode 304 - Range Sum Query 2D](https://leetcode.com/problems/range-sum-query-2d-immutable/)
6. [LeetCode 238 - Product of Array Except Self](https://leetcode.com/problems/product-of-array-except-self/)
7. [LeetCode 560 - Subarray Sum Equals K](https://leetcode.com/problems/subarray-sum-equals-k/)
8. [LeetCode 930 - Binary Subarrays With Sum](https://leetcode.com/problems/binary-subarrays-with-sum/)
9. [LeetCode 1314 - Matrix Block Sum](https://leetcode.com/problems/matrix-block-sum/)
10. [LeetCode 1546 - Maximum Number of Non-Overlapping Subarrays](https://leetcode.com/problems/maximum-number-of-non-overlapping-subarrays-with-sum-equals-target/)

---

## 📝 Part 6: Implementation Challenge

### Challenge: Build a Custom Dictionary with Statistics

Implement a custom dictionary that tracks access patterns and provides statistics.

```csharp
public class StatsDictionary<TKey, TValue> where TKey : notnull
{
    // TODO: Implement from scratch
    // Features required:
    // 1. Standard dictionary operations (Add, Remove, Get, Contains)
    // 2. Track number of accesses per key
    // 3. Track most accessed keys
    // 4. Track collision statistics
    // 5. Provide load factor information
    // 6. Support custom equality comparer

    // Methods to implement:
    // - void Add(TKey key, TValue value)
    // - bool Remove(TKey key)
    // - bool TryGetValue(TKey key, out TValue value)
    // - bool ContainsKey(TKey key)
    // - void Clear()
    // - int GetAccessCount(TKey key)
    // - IEnumerable<(TKey Key, int AccessCount)> GetMostAccessed(int topN)
    // - double GetLoadFactor()
    // - int GetCollisionCount()

    public int Count { get; }
    public int Capacity { get; }
}

// Test your implementation
var dict = new StatsDictionary<string, int>();
dict.Add("one", 1);
dict.Add("two", 2);
dict.TryGetValue("one", out int value);
dict.TryGetValue("one", out value);
Console.WriteLine(dict.GetAccessCount("one")); // Should be 2
```

---

## 🏆 Part 7: Assessment & Next Steps

### Completion Criteria

You're ready for Session 3 when you can:

✅ **C# Knowledge**:
- [ ] Write and use delegates and lambda expressions
- [ ] Understand when to use anonymous types vs tuples
- [ ] Create custom equality comparers
- [ ] Use LINQ fluently with lambda expressions

✅ **Pattern Mastery**:
- [ ] Identify when to use two pointers vs sliding window
- [ ] Implement both fixed and variable sliding windows
- [ ] Apply prefix sum to optimize range queries
- [ ] Use frequency counting with hash maps

✅ **Data Structure Understanding**:
- [ ] Explain hash table internals (buckets, collision resolution)
- [ ] Understand difference between Dictionary, HashSet, Hashtable
- [ ] Implement basic hash-based structure from scratch
- [ ] Know complexity of hash operations

✅ **Problem-Solving**:
- [ ] Solve 20+ two pointers problems
- [ ] Solve 15+ sliding window problems
- [ ] Solve 15+ hash map problems
- [ ] Solve 10+ prefix sum problems
- [ ] Complete implementation challenge

---

### Self-Assessment Quiz

1. What's the time complexity of two pointers vs brute force for Two Sum?
2. When would you use fixed vs variable sliding window?
3. Explain how collision resolution works in C# Dictionary.
4. Why is prefix sum O(1) for range queries after preprocessing?
5. What's the difference between `Func<>`, `Action<>`, and `Predicate<>`?
6. How does load factor affect hash table performance?

---

### Additional Resources

**Algorithm Patterns**:
- [Two Pointers - GeeksforGeeks](https://www.geeksforgeeks.org/dsa/two-pointers-technique/)
- [Sliding Window - LeetCode Guide](https://leetcode.com/discuss/post/3722472/sliding-window-technique-a-comprehensive-ix2k/)
- [Prefix Sum - USACO Guide](https://usaco.guide/silver/prefix-sums)
- [Hash Tables - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/collections/hashtable-and-dictionary-collection-types)

**C# Features**:
- [Lambda Expressions - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)
- [Delegates - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/standard/delegates-lambdas)
- [KoderHQ - C# Lambda Tutorial](https://www.koderhq.com/tutorial/csharp/lambda/)

**Practice Platforms**:
- [LeetCode Two Pointers Tag](https://leetcode.com/tag/two-pointers/)
- [LeetCode Sliding Window Tag](https://leetcode.com/tag/sliding-window/)
- [HackerRank Hash Tables](https://www.hackerrank.com/domains/data-structures?filters%5Bsubdomains%5D%5B%5D=hash-tables)

---

## 📅 Estimated Timeline

- **Week 1**: C# delegates, lambdas, two pointers (10 problems) - 5-7 hours
- **Week 2**: Sliding window pattern (15 problems) - 6-8 hours
- **Week 3**: Prefix sum + frequency counting (25 problems) - 8-10 hours
- **Week 4**: Hash table implementation + review - 5-6 hours

**Total**: ~24-31 hours of focused learning

---

## 🎓 Tips for Success

1. **Master the templates** - Two pointers and sliding window have clear patterns
2. **Draw diagrams** - Visualize window movement and pointer positions
3. **Practice pattern recognition** - Learn to identify which pattern to use
4. **Understand hash internals** - Knowing how it works helps debug issues
5. **Use LINQ wisely** - Great for readability, but know the underlying complexity
6. **Test edge cases** - Empty arrays, single elements, all duplicates
7. **Time complexity first** - Analyse before coding

---

**Ready to master these patterns? Start with two pointers problems and work your way through. Update your progress tracker as you go. Good luck! 🚀**

## Sources

This session content was researched using current materials from 2026:

**Two Pointers**:
- [GeeksforGeeks - Two Pointers Technique](https://www.geeksforgeeks.org/dsa/two-pointers-technique/)
- [USACO Guide - Two Pointers](https://usaco.guide/silver/two-pointers/)
- [Hello Interview - Two-Pointer Overview](https://www.hellointerview.com/learn/code/two-pointers/overview)
- [Sharpener Tech - Two Pointers Patterns](https://www.sharpener.tech/blog/two-pointers-technique-in-algorithms/)

**Sliding Window**:
- [LeetCode - Sliding Window Comprehensive Guide](https://leetcode.com/discuss/post/3722472/sliding-window-technique-a-comprehensive-ix2k/)
- [GeeksforGeeks - Window Sliding Technique](https://www.geeksforgeeks.org/dsa/window-sliding-technique/)
- [AlgoCademy - Mastering Sliding Window](https://algocademy.com/blog/mastering-the-sliding-window-technique-a-comprehensive-guide/)
- [Medium - Mastering Sliding Window](https://medium.com/@rishu__2701/mastering-sliding-window-techniques-48f819194fd7)

**Hash Tables**:
- [Microsoft Learn - Hashtable and Dictionary](https://learn.microsoft.com/en-us/dotnet/standard/collections/hashtable-and-dictionary-collection-types)
- [Medium - Diving into HashSet](https://medium.com/@idlerboris/diving-into-hashset-e1070b23c71a)
- [GitHub - HashSet and Dictionary Internals](https://github.com/Tyrrrz/interview-questions/blob/master/C#/HashSet%20and%20Dictionary.md)
- [ByteHide - HashSet Tutorial](https://www.bytehide.com/blog/hashset-csharp)

**Prefix Sum**:
- [GeeksforGeeks - Prefix Sum Implementation](https://www.geeksforgeeks.org/dsa/prefix-sum-array-implementation-applications-competitive-programming/)
- [USACO Guide - Prefix Sums](https://usaco.guide/silver/prefix-sums)
- [AlgoCademy - Mastering Prefix Sum](https://algocademy.com/blog/mastering-prefix-sum-a-powerful-technique-for-efficient-array-computations/)

**Frequency Counting**:
- [TeddySmith.IO - Frequency Counters Pattern](https://teddysmith.io/frequency-counters-algorithm-pattern/)
- [LeetCode - Mastering Hashtable Patterns](https://leetcode.com/discuss/study-guide/4042753/**-Mastering-Hashtable-Patterns:-A-Comprehensive-Guide/)
- [GeeksforGeeks - Counting Frequencies](https://www.geeksforgeeks.org/dsa/counting-frequencies-of-array-elements/)

**C# Features**:
- [Microsoft Learn - Lambda Expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)
- [Microsoft Learn - Delegates and Lambdas](https://learn.microsoft.com/en-us/dotnet/standard/delegates-lambdas)
- [KoderHQ - C# Lambda Tutorial](https://www.koderhq.com/tutorial/csharp/lambda/)

**Problem Lists**:
- [Blog AlgoMaster - 15 LeetCode Patterns](https://blog.algomaster.io/p/15-leetcode-patterns)
- [Medium - Two Pointers and Sliding Window in C#](https://medium.com/@hanxuyang0826/optimizing-code-efficiency-with-two-pointers-and-sliding-window-techniques-in-c-leetcode-problems-b1255873b696)
- [GitHub - Two Pointer & Sliding Window Problems](https://github.com/saurabhxcod/Two_Pointer_And_Sliding_Window)
