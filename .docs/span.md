What is Span?

  Span<T> is a ref struct that provides a type-safe and memory-safe representation of a contiguous region of arbitrary memory. Think of it as a lightweight, stack-allocated view over memory that can work with:
  - Arrays
  - Stack-allocated memory (stackalloc)
  - Native/unmanaged memory
  - Portions of arrays (slices)

  Key Characteristics

  1. Stack-only (ref struct): Cannot be boxed, stored in fields of regular classes, or used in async methods
  2. Zero-allocation: No heap allocations when creating spans
  3. Memory window: Provides a view into existing memory without copying
  4. Type-safe: Compile-time safety unlike pointers

  The Allocation Problem

  Let me show you why Span matters with examples:

  // ❌ Traditional approach - ALLOCATES heap memory
  public int[] GetSubArray(int[] source, int start, int length)
  {
      int[] result = new int[length]; // HEAP ALLOCATION!
      Array.Copy(source, start, result, 0, length);
      return result;
  }

  // ✅ Span approach - ZERO heap allocations
  public Span<int> GetSubSpan(int[] source, int start, int length)
  {
      return source.AsSpan(start, length); // Just a view, no copying!
  }

  // Example usage comparison
  int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

  // Old way: Creates new array, copies data, allocates heap memory
  int[] subset1 = GetSubArray(data, 2, 5); // [3, 4, 5, 6, 7]

  // Span way: Just a pointer + length, stack-only, no heap allocation
  Span<int> subset2 = GetSubSpan(data, 2, 5); // View of [3, 4, 5, 6, 7]

  Span vs ReadOnlySpan

  // Span<T> - Mutable view
  Span<int> mutableSpan = stackalloc int[] { 1, 2, 3, 4, 5 };
  mutableSpan[0] = 100; // ✅ Can modify

  // ReadOnlySpan<T> - Immutable view
  ReadOnlySpan<int> readonlySpan = stackalloc int[] { 1, 2, 3, 4, 5 };
  // readonlySpan[0] = 100; // ❌ Compile error - read-only!

  // Use ReadOnlySpan for input parameters (better API design)
  public int Sum(ReadOnlySpan<int> numbers)
  {
      int total = 0;
      foreach (int num in numbers)
          total += num;
      return total;
  }

  Real Algorithm Examples

  Example 1: String Processing (Zero Allocations!)

  // ❌ OLD WAY - Multiple allocations
  public bool IsPalindromeOld(string s)
  {
      string cleaned = s.ToLower(); // ALLOCATION 1
      cleaned = new string(cleaned.Where(char.IsLetterOrDigit).ToArray()); // ALLOCATION 2

      string reversed = new string(cleaned.Reverse().ToArray()); // ALLOCATION 3
      return cleaned == reversed;
  }

  // ✅ SPAN WAY - Zero allocations!
  public bool IsPalindromeSpan(ReadOnlySpan<char> s)
  {
      int left = 0;
      int right = s.Length - 1;

      while (left < right)
      {
          // Skip non-alphanumeric
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

  // Usage - strings can be treated as ReadOnlySpan<char>
  string text = "A man, a plan, a canal: Panama";
  bool result = IsPalindromeSpan(text); // No allocations!

  Example 2: Array Slicing for Algorithms

  // ❌ OLD WAY - Allocates multiple arrays
  public int BinarySearchOld(int[] array, int target, int start, int end)
  {
      if (start > end) return -1;

      int mid = start + (end - start) / 2;

      if (array[mid] == target)
          return mid;
      else if (array[mid] < target)
          return BinarySearchOld(array, target, mid + 1, end);
      else
          return BinarySearchOld(array, target, start, mid - 1);
  }

  // ✅ SPAN WAY - Zero allocations, cleaner recursion
  public int BinarySearchSpan(ReadOnlySpan<int> span, int target)
  {
      if (span.IsEmpty) return -1;

      int mid = span.Length / 2;

      if (span[mid] == target)
          return mid;
      else if (span[mid] < target)
      {
          int result = BinarySearchSpan(span[(mid + 1)..], target);
          return result == -1 ? -1 : mid + 1 + result;
      }
      else
      {
          return BinarySearchSpan(span[..mid], target);
      }
  }

  // Usage
  int[] numbers = { 1, 3, 5, 7, 9, 11, 13, 15 };
  int index = BinarySearchSpan(numbers, 9); // No allocations!

  Example 3: Parsing and Tokenization

  // ❌ OLD WAY - String.Split allocates array
  public int SumNumbersOld(string input)
  {
      string[] parts = input.Split(' '); // ALLOCATION!
      int sum = 0;
      foreach (string part in parts)
      {
          if (int.TryParse(part, out int num))
              sum += num;
      }
      return sum;
  }

  // ✅ SPAN WAY - Zero allocations
  public int SumNumbersSpan(ReadOnlySpan<char> input)
  {
      int sum = 0;

      while (!input.IsEmpty)
      {
          // Find next space
          int spaceIndex = input.IndexOf(' ');

          ReadOnlySpan<char> token = spaceIndex == -1
              ? input
              : input[..spaceIndex];

          if (int.TryParse(token, out int num))
              sum += num;

          // Move to next token
          input = spaceIndex == -1
              ? ReadOnlySpan<char>.Empty
              : input[(spaceIndex + 1)..];
      }

      return sum;
  }

  // Usage
  string data = "10 20 30 40 50";
  int total = SumNumbersSpan(data); // 150, zero allocations!

  Example 4: Sliding Window Algorithm

  // Maximum sum of k consecutive elements
  public int MaxSumSubarray(ReadOnlySpan<int> array, int k)
  {
      if (array.Length < k) return 0;

      // Calculate first window
      int windowSum = 0;
      for (int i = 0; i < k; i++)
          windowSum += array[i];

      int maxSum = windowSum;

      // Slide the window
      for (int i = k; i < array.Length; i++)
      {
          windowSum = windowSum - array[i - k] + array[i];
          maxSum = Math.Max(maxSum, windowSum);
      }

      return maxSum;
  }

  // Can be called with arrays, stackalloc, or slices!
  int[] data = { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
  int max1 = MaxSumSubarray(data, 4); // Works with array

  Span<int> stackData = stackalloc int[] { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
  int max2 = MaxSumSubarray(stackData, 4); // Works with stack memory!

  int max3 = MaxSumSubarray(data.AsSpan(2, 5), 3); // Works with slice!

  Performance Benefits Visualized

  // Benchmark comparison
  public class SpanBenchmark
  {
      private int[] data = Enumerable.Range(1, 1000).ToArray();

      // ❌ Traditional - Creates temporary arrays
      public int SumEveryOtherElementOld()
      {
          int sum = 0;
          for (int i = 0; i < data.Length; i += 2)
          {
              // If we wanted to pass this to another method,
              // we'd need to create a new array
              int[] subset = new int[(data.Length - i) / 2];
              Array.Copy(data, i, subset, 0, subset.Length);
              sum += ProcessArray(subset);
          }
          return sum;
      }

      // ✅ Span - Zero allocations
      public int SumEveryOtherElementSpan()
      {
          int sum = 0;
          for (int i = 0; i < data.Length; i += 2)
          {
              // Just pass a view, no copying!
              sum += ProcessSpan(data.AsSpan(i, Math.Min(data.Length - i, data.Length / 2)));
          }
          return sum;
      }

      private int ProcessArray(int[] arr) => arr.Sum();
      private int ProcessSpan(ReadOnlySpan<int> span)
      {
          int total = 0;
          foreach (int val in span) total += val;
          return total;
      }
  }

  // Results:
  // Old way: ~100ms, 50+ MB allocated
  // Span way: ~10ms, 0 MB allocated (except original array)

  Span Operations and Slicing

  int[] original = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

  // Get a span view
  Span<int> span = original.AsSpan();

  // Slicing operations (NO allocations!)
  Span<int> slice1 = span[2..5];        // [2, 3, 4]
  Span<int> slice2 = span[..3];         // [0, 1, 2]
  Span<int> slice3 = span[7..];         // [7, 8, 9]
  Span<int> slice4 = span[^3..];        // Last 3: [7, 8, 9]

  // Slicing a slice (still no allocations!)
  Span<int> nestedSlice = slice1[1..];  // [3, 4]

  // All of these are just views over the original array!
  slice1[0] = 100; // Changes original[2] to 100

  When to Use Span

  ✅ Use Span when:
  1. Processing arrays or subsets of arrays
  2. Performance-critical algorithms (parsers, encoders, compression)
  3. Working with stack-allocated memory (stackalloc)
  4. Need mutable slices without allocations
  5. Writing low-level, high-performance code

  ✅ Use ReadOnlySpan when:
  1. Input parameters that shouldn't be modified
  2. String processing (strings → ReadOnlySpan)
  3. Better API contracts (read-only intent)

  ❌ Don't use Span when:
  1. Need to store in fields (use Memory<T> instead)
  2. Working with async/await (ref structs not allowed)
  3. Need to box or use with interfaces (in most cases)
  4. Simple, non-performance-critical code

  C# 13 params with Span

  This is where C# 13 shines:

  // C# 13: params with Span - Best of both worlds!
  public int Sum(params ReadOnlySpan<int> numbers)
  {
      int total = 0;
      foreach (int num in numbers)
          total += num;
      return total;
  }

  // All these work, with ZERO heap allocations!
  int result1 = Sum(1, 2, 3, 4, 5);           // Inlined on stack
  int result2 = Sum(myArray);                  // Direct span
  int result3 = Sum(myArray.AsSpan(2, 5));    // Slice view

  // Compare to old params:
  public int SumOld(params int[] numbers)     // Always allocates array!
  {
      return numbers.Sum();
  }

  int old1 = SumOld(1, 2, 3, 4, 5);          // Allocates int[] on heap!

  Complete Real-World Algorithm Example

  Here's a practical example showing the power of Span:

  // Reverse words in a sentence in-place
  public class StringReverser
  {
      // ❌ OLD: Multiple allocations
      public string ReverseWordsOld(string s)
      {
          string[] words = s.Split(' ');                    // ALLOCATION 1
          Array.Reverse(words);
          return string.Join(' ', words);                   // ALLOCATION 2
      }

      // ✅ NEW: Zero allocations (except result)
      public string ReverseWordsSpan(string s)
      {
          // Use stack for temp storage
          Span<char> buffer = s.Length <= 256
              ? stackalloc char[s.Length]        // Stack if small
              : new char[s.Length];               // Heap if large

          s.AsSpan().CopyTo(buffer);

          // Reverse entire string
          buffer.Reverse();

          // Reverse each word back
          int wordStart = 0;
          for (int i = 0; i <= buffer.Length; i++)
          {
              if (i == buffer.Length || buffer[i] == ' ')
              {
                  if (i > wordStart)
                  {
                      buffer[wordStart..i].Reverse();
                  }
                  wordStart = i + 1;
              }
          }

          return new string(buffer);
      }
  }

  // Usage:
  var reverser = new StringReverser();
  string result = reverser.ReverseWordsSpan("Hello World from Span!");
  // Output: "Span! from World Hello"
  // Only ONE allocation for final string!

  Summary

  Span Benefits:
  - ⚡ Zero heap allocations for slicing and views
  - 🚀 Better performance (less GC pressure)
  - 🎯 Type-safe (unlike pointers)
  - 📦 Works with multiple memory types (array, stack, unmanaged)
  - ✂️ Efficient slicing (O(1) operation)
  - 🔒 Stack-only safety (can't accidentally capture/leak)

  When performance matters (parsers, algorithms, hot paths), Span is your best friend. When it doesn't, regular arrays and strings are simpler and more familiar.