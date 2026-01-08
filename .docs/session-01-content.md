# Session 1: C# Fundamentals Refresh + Complexity Analysis

> **Goal**: Refresh modern C# features and master Big O notation for algorithm analysis

---

## 📚 Part 1: Modern C# Features (C# 10-14)

### 1.1 Records and Init-Only Properties

Records provide immutable reference types perfect for data-centric applications.

```csharp
// Traditional class
public class PersonClass
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Record (C# 9+) - immutable by default
public record Person(string Name, int Age);

// Record with init-only properties
public record Employee
{
    public string Name { get; init; }
    public int Age { get; init; }
    public decimal Salary { get; init; }
}

// Usage
var person = new Person("Alice", 30);
var employee = new Employee { Name = "Bob", Age = 25, Salary = 75000 };

// Records provide value-based equality
var person1 = new Person("Alice", 30);
var person2 = new Person("Alice", 30);
Console.WriteLine(person1 == person2); // True (value equality)

// With expression for non-destructive mutation
var olderPerson = person with { Age = 31 };
```

**When to use**: Immutable data transfer objects, value objects, configuration objects.

---

### 1.2 Pattern Matching (C# 10+)

Enhanced pattern matching for more expressive code.

```csharp
// Type patterns
object obj = "Hello";
if (obj is string s)
{
    Console.WriteLine($"String length: {s.Length}");
}

// Property patterns
public record Point(int X, int Y);

string Classify(Point point) => point switch
{
    { X: 0, Y: 0 } => "Origin",
    { X: > 0, Y: > 0 } => "Quadrant 1",
    { X: < 0, Y: > 0 } => "Quadrant 2",
    { X: < 0, Y: < 0 } => "Quadrant 3",
    { X: > 0, Y: < 0 } => "Quadrant 4",
    { X: 0 } => "On X-axis",
    { Y: 0 } => "On Y-axis",
    _ => "Unknown"
};

// List patterns (C# 11)
int[] numbers = { 1, 2, 3, 4, 5 };
var result = numbers switch
{
    [] => "Empty",
    [var x] => $"Single element: {x}",
    [var first, .., var last] => $"First: {first}, Last: {last}",
    _ => "Multiple elements"
};

// Relational patterns in algorithms
int GetGrade(int score) => score switch
{
    >= 90 => 'A',
    >= 80 => 'B',
    >= 70 => 'C',
    >= 60 => 'D',
    _ => 'F'
};
```

**Algorithm use cases**: Simplifying conditional logic, state machines, tree/graph traversal logic.

---

### 1.3 LINQ (Language Integrated Query)

Functional programming for collections - essential for algorithm implementation.

```csharp
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Query syntax
var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

// Method syntax (preferred in algorithm code)
var evenNumbersMethod = numbers.Where(n => n % 2 == 0);

// Common LINQ operations for algorithms
var doubled = numbers.Select(n => n * 2);
var sum = numbers.Sum();
var max = numbers.Max();
var sorted = numbers.OrderBy(n => n);
var grouped = numbers.GroupBy(n => n % 3);

// Advanced LINQ for problem-solving
var pairs = numbers.SelectMany(
    (x, i) => numbers.Skip(i + 1).Select(y => (x, y))
);

// Aggregate for custom operations
var factorial = Enumerable.Range(1, 5)
    .Aggregate(1, (acc, n) => acc * n); // 120

// Any, All for validation
bool hasEven = numbers.Any(n => n % 2 == 0);
bool allPositive = numbers.All(n => n > 0);

// Take/Skip for pagination and sliding windows
var firstFive = numbers.Take(5);
var skipFirstThree = numbers.Skip(3);

// Distinct for removing duplicates (O(n) with HashSet internally)
int[] duplicates = { 1, 2, 2, 3, 3, 3, 4 };
var unique = duplicates.Distinct();
```

**Performance notes**:
- LINQ uses deferred execution (lazy evaluation)
- Most LINQ operations are O(n), but `OrderBy` is O(n log n)
- Be aware of multiple enumeration (enumerate once or use `.ToList()`)

---

### 1.4 Generics and Constraints

Type-safe data structures and algorithms.

```csharp
// Generic method
public T FindMax<T>(T[] array) where T : IComparable<T>
{
    if (array.Length == 0)
        throw new ArgumentException("Array cannot be empty");

    T max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i].CompareTo(max) > 0)
            max = array[i];
    }
    return max;
}

// Generic class for data structures
public class Stack<T>
{
    private T[] items;
    private int top;

    public Stack(int capacity = 10)
    {
        items = new T[capacity];
        top = -1;
    }

    public void Push(T item)
    {
        if (top == items.Length - 1)
            Resize();
        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");
        return items[top--];
    }

    public bool IsEmpty() => top == -1;

    private void Resize()
    {
        Array.Resize(ref items, items.Length * 2);
    }
}

// Multiple constraints
public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public Node(T value) => Value = value;
    }

    private Node? root;

    public void Insert(T value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node? node, T value)
    {
        if (node == null)
            return new Node(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = InsertRec(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = InsertRec(node.Right, value);

        return node;
    }
}
```

---

### 1.5 Nullable Reference Types (C# 8+)

Avoid null reference exceptions in algorithm code.

```csharp
#nullable enable

public class ListNode
{
    public int Value { get; set; }
    public ListNode? Next { get; set; } // Explicitly nullable

    public ListNode(int value)
    {
        Value = value;
        Next = null;
    }
}

// Safe null handling
public int? FindValue(ListNode? head, int target)
{
    ListNode? current = head;

    while (current != null)
    {
        if (current.Value == target)
            return current.Value;
        current = current.Next;
    }

    return null; // Not found
}

// Null-coalescing and null-conditional operators
string GetName(Person? person) => person?.Name ?? "Unknown";
int GetLength(int[]? array) => array?.Length ?? 0;
```

---

### 1.6 Extension Methods

Extend types without modification - useful for adding algorithm operations.

```csharp
public static class ArrayExtensions
{
    // Extension method for binary search
    public static int BinarySearch<T>(this T[] array, T target)
        where T : IComparable<T>
    {
        int left = 0, right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = array[mid].CompareTo(target);

            if (comparison == 0)
                return mid;
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    // Check if array is sorted
    public static bool IsSorted<T>(this T[] array) where T : IComparable<T>
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(array[i - 1]) < 0)
                return false;
        }
        return true;
    }

    // Print array (debugging)
    public static void Print<T>(this T[] array)
    {
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}

// Usage
int[] numbers = { 1, 3, 5, 7, 9 };
int index = numbers.BinarySearch(5); // Using extension method
bool sorted = numbers.IsSorted();
numbers.Print();
```

---

### 1.7 C# 13 Features (Released November 2024)

C# 13 brings powerful enhancements for algorithm implementation and performance.

#### 1.7.1 params Collections Enhancement

The `params` keyword now works with any collection type, not just arrays.

```csharp
// Traditional params with array (C# 1.0+)
public int SumArray(params int[] numbers)
{
    return numbers.Sum();
}

// C# 13: params with List<T>
public int SumList(params List<int> numbers)
{
    return numbers.Sum();
}

// C# 13: params with Span<T> - zero allocation!
public int SumSpan(params ReadOnlySpan<int> numbers)
{
    int sum = 0;
    foreach (int num in numbers)
        sum += num;
    return sum;
}

// C# 13: params with IEnumerable<T>
public void PrintItems<T>(params IEnumerable<T> items)
{
    foreach (var item in items)
        Console.WriteLine(item);
}

// Usage - all of these work!
SumArray(1, 2, 3, 4, 5);
SumList(1, 2, 3, 4, 5);
SumSpan(1, 2, 3, 4, 5); // Most efficient!
PrintItems("a", "b", "c");
```

**Algorithm benefit**: Use `ReadOnlySpan<T>` for zero-allocation algorithm implementations.

#### 1.7.2 New Lock Type

System.Threading.Lock provides better performance and debugging for thread synchronization.

```csharp
// Old style (still works)
private readonly object _lock = new object();

public void OldStyleLock()
{
    lock (_lock)
    {
        // Critical section
    }
}

// C# 13: New Lock type with better performance
private readonly Lock _newLock = new Lock();

public void NewStyleLock()
{
    lock (_newLock)
    {
        // Critical section - better performance
    }
}

// Use case: Thread-safe data structure for algorithms
public class ThreadSafeQueue<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly Lock _lock = new Lock();

    public void Enqueue(T item)
    {
        lock (_lock)
        {
            _queue.Enqueue(item);
        }
    }

    public bool TryDequeue(out T item)
    {
        lock (_lock)
        {
            if (_queue.Count > 0)
            {
                item = _queue.Dequeue();
                return true;
            }
            item = default!;
            return false;
        }
    }
}
```

**Algorithm benefit**: Better performance for concurrent algorithms and parallel processing.

#### 1.7.3 ref struct Enhancements

`ref struct` types can now implement interfaces, enabling zero-allocation generic code.

```csharp
// C# 13: ref struct can implement interfaces
public interface IComparable<T>
{
    int CompareTo(T other);
}

public ref struct Point : IComparable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Can now implement interface methods
    public int CompareTo(Point other)
    {
        int xCompare = X.CompareTo(other.X);
        return xCompare != 0 ? xCompare : Y.CompareTo(other.Y);
    }
}

// Use in generic algorithms
public T FindMin<T>(ReadOnlySpan<T> items) where T : IComparable<T>
{
    if (items.Length == 0)
        throw new ArgumentException("Span cannot be empty");

    T min = items[0];
    for (int i = 1; i < items.Length; i++)
    {
        if (items[i].CompareTo(min) < 0)
            min = items[i];
    }
    return min;
}
```

**Algorithm benefit**: Write generic, high-performance algorithms without heap allocations.

#### 1.7.4 Partial Properties

Split property definitions across multiple files - useful for large algorithm implementations.

```csharp
// File: Graph.cs
public partial class Graph
{
    public partial int VertexCount { get; set; }
    public partial int EdgeCount { get; set; }
}

// File: Graph.Properties.cs
public partial class Graph
{
    // Implementation in separate file
    public partial int VertexCount { get; set; } = 0;
    public partial int EdgeCount { get; set; } = 0;
}
```

**Algorithm benefit**: Better code organisation for complex data structures.

#### 1.7.5 New Escape Sequence `\e`

```csharp
// C# 13: \e represents the ESCAPE character (ASCII 27)
string ansiReset = "\e[0m";
string ansiRed = "\e[31m";

// Useful for console-based algorithm visualization
public void HighlightValue(int value, bool highlight)
{
    if (highlight)
        Console.Write($"\e[31m{value}\e[0m "); // Red
    else
        Console.Write($"{value} ");
}
```

---

### 1.8 C# 14 Features (Released November 2025)

C# 14 introduces game-changing features for cleaner, more expressive code.

#### 1.8.1 Extension Members

Define extension properties, not just methods!

```csharp
// Traditional extension method (C# 3.0+)
public static class ArrayExtensions
{
    public static int Sum(this int[] array)
    {
        int sum = 0;
        foreach (int num in array)
            sum += num;
        return sum;
    }
}

// C# 14: Extension properties!
public static class ArrayExtensions
{
    // Extension property - no parentheses needed
    public static int Sum(this int[] array)
    {
        get
        {
            int sum = 0;
            foreach (int num in array)
                sum += num;
            return sum;
        }
    }

    // Extension property for checking if sorted
    public static bool IsSorted(this int[] array)
    {
        get
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }
    }

    // Extension property with sophisticated logic
    public static int Max(this int[] array)
    {
        get
        {
            if (array.Length == 0)
                throw new InvalidOperationException("Array is empty");

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
    }
}

// Usage - cleaner syntax!
int[] numbers = { 5, 2, 8, 1, 9 };
int sum = numbers.Sum;       // Property, not method!
bool sorted = numbers.IsSorted;
int max = numbers.Max;

// Compare to old way:
int sumOld = numbers.Sum();  // Method call with parentheses
```

**Algorithm benefit**: More readable code, especially for computed properties like `array.Length` or `list.Count`.

#### 1.8.2 field Keyword

Direct access to backing fields in properties - less boilerplate!

```csharp
// Traditional property with backing field
public class Node
{
    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            if (value < 0)
                throw new ArgumentException("Value must be non-negative");
            _value = value;
        }
    }
}

// C# 14: Using field keyword - no backing field needed!
public class Node
{
    public int Value
    {
        get => field;  // 'field' is the implicit backing field
        set
        {
            if (value < 0)
                throw new ArgumentException("Value must be non-negative");
            field = value;  // Direct access to backing field
        }
    }
}

// Real algorithm example: Lazy-evaluated property
public class Graph
{
    private List<Edge>? _cachedEdges;

    // C# 14: Cleaner with field keyword
    public List<Edge> Edges
    {
        get
        {
            field ??= ComputeEdges(); // field is the backing field
            return field;
        }
    }

    private List<Edge> ComputeEdges()
    {
        // Expensive computation
        return new List<Edge>();
    }
}

// Another example: Validation in setter
public class BinarySearchTree<T> where T : IComparable<T>
{
    public T Root
    {
        get => field;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (field != null && value.CompareTo(field) == 0)
                return; // No change

            field = value;
            InvalidateCache();
        }
    }

    private void InvalidateCache() { /* ... */ }
}
```

**Algorithm benefit**: Cleaner property implementation, especially with validation logic.

#### 1.8.3 Null-Conditional Assignment

Safely assign to properties only if the receiver is not null.

```csharp
// Traditional null check
public void UpdateNode(TreeNode? node, int value)
{
    if (node != null)
    {
        node.Value = value;
    }
}

// C# 14: Null-conditional assignment
public void UpdateNode(TreeNode? node, int value)
{
    node?.Value = value;  // Assigns only if node is not null!
}

// Real algorithm examples
public class LinkedList<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }
    }

    public Node? Head { get; set; }

    // Update head value if exists
    public void UpdateHead(T value)
    {
        Head?.Value = value;  // Clean and safe!
    }

    // Set next of last node
    public void SetTail(Node newTail)
    {
        Node? current = Head;
        while (current?.Next != null)
            current = current.Next;

        current?.Next = newTail;  // Works even if list is empty
    }
}

// Graph example
public class Graph
{
    public class Vertex
    {
        public int Id { get; set; }
        public bool Visited { get; set; }
    }

    public void MarkVertexVisited(Vertex? vertex)
    {
        vertex?.Visited = true;  // Much cleaner than if (vertex != null)
    }

    // BFS example
    public void BreadthFirstSearch(Vertex? start)
    {
        var queue = new Queue<Vertex>();
        start?.Visited = true;  // Mark start as visited if not null

        if (start != null)
            queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var neighbor in GetNeighbors(current))
            {
                neighbor?.Visited = true;  // Safe marking
                if (neighbor != null)
                    queue.Enqueue(neighbor);
            }
        }
    }

    private List<Vertex?> GetNeighbors(Vertex vertex) => new();
}
```

**Algorithm benefit**: Cleaner null-safe code in tree/graph algorithms.

#### 1.8.4 Improved Scripting (Single-File Execution)

```bash
# C# 14: Run a single .cs file without project file!
dotnet run MyAlgorithm.cs

# Great for quick algorithm testing and competitive programming
```

```csharp
// MyAlgorithm.cs - Single file, no .csproj needed!
using System;
using System.Linq;

var numbers = Console.ReadLine()!
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

int result = MaxSubarraySum(numbers);
Console.WriteLine(result);

int MaxSubarraySum(int[] arr)
{
    int maxSoFar = arr[0];
    int maxEndingHere = arr[0];

    for (int i = 1; i < arr.Length; i++)
    {
        maxEndingHere = Math.Max(arr[i], maxEndingHere + arr[i]);
        maxSoFar = Math.Max(maxSoFar, maxEndingHere);
    }

    return maxSoFar;
}
```

**Algorithm benefit**: Perfect for competitive programming and quick algorithm prototyping.

---

### 1.9 Key Takeaways: Modern C# for Algorithms

**C# 10-12 Foundation**:
- Records for immutable data structures
- Pattern matching for cleaner control flow
- LINQ for functional-style algorithms
- Nullable reference types for safety

**C# 13 Performance**:
- `params ReadOnlySpan<T>` for zero-allocation algorithms
- New `Lock` type for concurrent algorithms
- `ref struct` interfaces for high-performance generics

**C# 14 Expressiveness**:
- Extension properties for cleaner API
- `field` keyword for less boilerplate
- Null-conditional assignment for safer code
- Single-file scripts for rapid prototyping

**Pro Tip**: Use C# 14's single-file execution for solving LeetCode problems quickly, then apply C# 13's performance features when optimizing solutions!

---

## 📊 Part 2: Big O Notation & Complexity Analysis

### 2.1 Understanding Big O Notation

Big O describes how an algorithm's runtime or space requirements grow as input size increases.

**Common Time Complexities (from best to worst)**:

```
O(1)         Constant     - Array access, hash table lookup
O(log n)     Logarithmic  - Binary search, balanced tree operations
O(n)         Linear       - Array traversal, linear search
O(n log n)   Linearithmic - Efficient sorting (merge sort, quick sort)
O(n²)        Quadratic    - Nested loops, bubble sort
O(n³)        Cubic        - Triple nested loops
O(2ⁿ)        Exponential  - Recursive fibonacci (naive), subset generation
O(n!)        Factorial    - Permutation generation
```

**Visual growth (n = 100)**:
- O(1): 1 operation
- O(log n): ~7 operations
- O(n): 100 operations
- O(n log n): ~664 operations
- O(n²): 10,000 operations
- O(2ⁿ): 1,267,650,600,228,229,401,496,703,205,376 operations 😱

---

### 2.2 Analyzing Time Complexity

#### Example 1: O(1) - Constant Time

```csharp
// Array access - always takes same time regardless of array size
public int GetFirstElement(int[] array)
{
    return array[0]; // O(1)
}

// Hash table operations
public bool ContainsKey(Dictionary<string, int> dict, string key)
{
    return dict.ContainsKey(key); // O(1) average case
}
```

#### Example 2: O(n) - Linear Time

```csharp
// Single loop through array
public int FindMax(int[] array)
{
    int max = array[0]; // O(1)

    for (int i = 1; i < array.Length; i++) // O(n)
    {
        if (array[i] > max) // O(1)
            max = array[i]; // O(1)
    }

    return max; // O(1)
}
// Total: O(1) + O(n) * O(1) + O(1) = O(n)

// Linear search
public int LinearSearch(int[] array, int target)
{
    for (int i = 0; i < array.Length; i++) // O(n) worst case
    {
        if (array[i] == target)
            return i;
    }
    return -1;
}
// Best case: O(1) - found at first position
// Average case: O(n/2) = O(n)
// Worst case: O(n) - not found or at end
```

#### Example 3: O(log n) - Logarithmic Time

```csharp
// Binary search on sorted array
public int BinarySearch(int[] sortedArray, int target)
{
    int left = 0, right = sortedArray.Length - 1;

    while (left <= right) // Runs log₂(n) times
    {
        int mid = left + (right - left) / 2;

        if (sortedArray[mid] == target)
            return mid;
        else if (sortedArray[mid] < target)
            left = mid + 1;  // Eliminate left half
        else
            right = mid - 1; // Eliminate right half
    }

    return -1;
}
// Each iteration eliminates half the search space
// n → n/2 → n/4 → n/8 → ... → 1
// Number of divisions = log₂(n)
```

#### Example 4: O(n²) - Quadratic Time

```csharp
// Bubble sort - nested loops
public void BubbleSort(int[] array)
{
    int n = array.Length;

    for (int i = 0; i < n - 1; i++) // Outer loop: n times
    {
        for (int j = 0; j < n - i - 1; j++) // Inner loop: n times
        {
            if (array[j] > array[j + 1])
            {
                // Swap
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}
// Total: n * n = O(n²)

// Finding all pairs in array
public List<(int, int)> FindAllPairs(int[] array)
{
    var pairs = new List<(int, int)>();

    for (int i = 0; i < array.Length; i++) // n times
    {
        for (int j = i + 1; j < array.Length; j++) // n times
        {
            pairs.Add((array[i], array[j]));
        }
    }

    return pairs;
}
// O(n²) - every element paired with every other element
```

#### Example 5: O(n log n) - Linearithmic Time

```csharp
// Merge sort
public void MergeSort(int[] array, int left, int right)
{
    if (left < right)
    {
        int mid = left + (right - left) / 2;

        MergeSort(array, left, mid);      // T(n/2)
        MergeSort(array, mid + 1, right); // T(n/2)
        Merge(array, left, mid, right);   // O(n)
    }
}
// Recurrence: T(n) = 2T(n/2) + O(n)
// Solution: O(n log n)
// log n levels, each doing n work = n * log n

// Sorting then searching (common pattern)
public bool ContainsDuplicate(int[] array)
{
    Array.Sort(array); // O(n log n)

    for (int i = 1; i < array.Length; i++) // O(n)
    {
        if (array[i] == array[i - 1])
            return true;
    }

    return false;
}
// Total: O(n log n) + O(n) = O(n log n) - largest term dominates
```

---

### 2.3 Space Complexity

Space complexity measures additional memory used by algorithm (excluding input).

```csharp
// O(1) space - constant extra space
public int Sum(int[] array)
{
    int total = 0; // One variable
    for (int i = 0; i < array.Length; i++)
    {
        total += array[i];
    }
    return total;
}

// O(n) space - space grows with input
public int[] CreateCopy(int[] array)
{
    int[] copy = new int[array.Length]; // n extra space
    for (int i = 0; i < array.Length; i++)
    {
        copy[i] = array[i];
    }
    return copy;
}

// O(log n) space - recursive binary search (call stack)
public int BinarySearchRecursive(int[] array, int target, int left, int right)
{
    if (left > right)
        return -1;

    int mid = left + (right - left) / 2;

    if (array[mid] == target)
        return mid;
    else if (array[mid] < target)
        return BinarySearchRecursive(array, target, mid + 1, right);
    else
        return BinarySearchRecursive(array, target, left, mid - 1);
}
// Call stack depth = log n (each call halves the problem)

// O(n) space - recursive linear search (worst case call stack)
public int LinearSearchRecursive(int[] array, int target, int index = 0)
{
    if (index >= array.Length)
        return -1;

    if (array[index] == target)
        return index;

    return LinearSearchRecursive(array, target, index + 1);
}
// Call stack depth = n (worst case)
```

---

### 2.4 Rules for Big O Analysis

1. **Drop constants**: O(2n) → O(n), O(3n + 5) → O(n)
2. **Drop lower-order terms**: O(n² + n) → O(n²), O(n log n + n) → O(n log n)
3. **Different inputs = different variables**: O(a + b), O(a * b)
4. **Best/Average/Worst cases**: Specify which you're analysing

```csharp
// Example: Different inputs
public void PrintPairs(int[] a, int[] b)
{
    foreach (int x in a)        // O(a)
    {
        foreach (int y in b)    // O(b)
        {
            Console.WriteLine($"{x}, {y}");
        }
    }
}
// Time: O(a * b), NOT O(n²) - different inputs!

// Example: Dropping constants and lower terms
public void Example(int[] array)
{
    // Step 1: O(n)
    for (int i = 0; i < array.Length; i++)
        Console.WriteLine(array[i]);

    // Step 2: O(n)
    for (int i = 0; i < array.Length; i++)
        Console.WriteLine(array[i]);

    // Step 3: O(n²)
    for (int i = 0; i < array.Length; i++)
        for (int j = 0; j < array.Length; j++)
            Console.WriteLine(array[i] + array[j]);
}
// Total: O(n) + O(n) + O(n²) = O(2n + n²) = O(n²)
```

---

## 🔧 Part 3: Arrays and Lists Implementation

### 3.1 Understanding Arrays

Arrays are contiguous blocks of memory with O(1) random access.

```csharp
// Fixed-size array
int[] fixedArray = new int[5];
fixedArray[0] = 10; // O(1) access
int value = fixedArray[2]; // O(1) read

// Array initialization
int[] numbers = { 1, 2, 3, 4, 5 };
int[] zeros = new int[10]; // All elements initialized to 0

// Multi-dimensional arrays
int[,] matrix = new int[3, 3]; // 2D array (rectangular)
int[][] jagged = new int[3][]; // Jagged array (array of arrays)

// Common operations and their complexity
// Access: O(1)
// Search: O(n)
// Insert at end: O(1) if space available, O(n) if resize needed
// Insert at beginning/middle: O(n) - must shift elements
// Delete: O(n) - must shift elements
```

### 3.2 Implementing a Dynamic Array (List)

```csharp
public class DynamicArray<T>
{
    private T[] items;
    private int count;
    private const int DefaultCapacity = 4;

    public int Count => count;
    public int Capacity => items.Length;

    public DynamicArray()
    {
        items = new T[DefaultCapacity];
        count = 0;
    }

    // O(1) amortised
    public void Add(T item)
    {
        if (count == items.Length)
            Resize();

        items[count++] = item;
    }

    // O(1)
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }

    // O(n) - need to shift elements
    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();

        if (count == items.Length)
            Resize();

        // Shift elements to the right
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }

        items[index] = item;
        count++;
    }

    // O(n) - need to shift elements
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        // Shift elements to the left
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[--count] = default!;
    }

    // O(n)
    public int IndexOf(T item)
    {
        for (int i = 0; i < count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(items[i], item))
                return i;
        }
        return -1;
    }

    // O(n)
    public bool Contains(T item) => IndexOf(item) != -1;

    // O(1)
    public void Clear()
    {
        Array.Clear(items, 0, count);
        count = 0;
    }

    // O(n) - but amortised O(1) for Add operations
    private void Resize()
    {
        int newCapacity = items.Length * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(items, newArray, count);
        items = newArray;
    }
}

// Usage example
var list = new DynamicArray<int>();
list.Add(1);        // O(1) amortised
list.Add(2);        // O(1) amortised
list.Add(3);        // O(1) amortised
list.Insert(1, 10); // O(n)
list.RemoveAt(0);   // O(n)
int value = list[0]; // O(1)
```

**Key insight**: Doubling capacity ensures amortised O(1) insertions.
- If we resize by 1 each time: n operations cost 1 + 2 + 3 + ... + n = O(n²)
- If we double each time: n operations cost 1 + 2 + 4 + 8 + ... = O(n)

---

## 💻 Part 4: Practice Exercises

### Exercise 1: Array Rotation

**Problem**: Rotate an array to the right by k steps.

```csharp
// Starter code
public class ArrayRotation
{
    public void Rotate(int[] nums, int k)
    {
        // TODO: Implement array rotation
        // Example: [1,2,3,4,5], k=2 → [4,5,1,2,3]
        // Time: O(n), Space: O(1)
    }
}

// Test cases
var solution = new ArrayRotation();

int[] test1 = { 1, 2, 3, 4, 5 };
solution.Rotate(test1, 2);
// Expected: [4, 5, 1, 2, 3]

int[] test2 = { -1, -100, 3, 99 };
solution.Rotate(test2, 3);
// Expected: [-100, 3, 99, -1]
```

**Hints**:
1. Handle k > array.Length (use modulo)
2. Consider reversing parts of the array
3. Three-step reverse approach

---

### Exercise 2: Remove Duplicates from Sorted Array

**Problem**: Remove duplicates in-place, return new length.

```csharp
public class RemoveDuplicates
{
    public int RemoveDuplicates(int[] nums)
    {
        // TODO: Remove duplicates in-place
        // Example: [1,1,2,2,3] → [1,2,3,_,_], return 3
        // Time: O(n), Space: O(1)
        // Use two-pointer technique
    }
}

// Test cases
var solution = new RemoveDuplicates();

int[] test1 = { 1, 1, 2 };
int len1 = solution.RemoveDuplicates(test1);
// Expected: len1 = 2, nums = [1, 2, ...]

int[] test2 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
int len2 = solution.RemoveDuplicates(test2);
// Expected: len2 = 5, nums = [0, 1, 2, 3, 4, ...]
```

---

### Exercise 3: Maximum Subarray Sum (Kadane's Algorithm)

**Problem**: Find contiguous subarray with maximum sum.

```csharp
public class MaximumSubarray
{
    public int MaxSubArray(int[] nums)
    {
        // TODO: Find maximum subarray sum
        // Example: [-2,1,-3,4,-1,2,1,-5,4] → 6 (subarray [4,-1,2,1])
        // Time: O(n), Space: O(1)
        // Kadane's algorithm
    }
}

// Test cases
var solution = new MaximumSubarray();

int[] test1 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
Console.WriteLine(solution.MaxSubArray(test1)); // Expected: 6

int[] test2 = { 1 };
Console.WriteLine(solution.MaxSubArray(test2)); // Expected: 1

int[] test3 = { 5, 4, -1, 7, 8 };
Console.WriteLine(solution.MaxSubArray(test3)); // Expected: 23
```

---

### Exercise 4: Two Sum

**Problem**: Find two numbers that add up to target.

```csharp
public class TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        // TODO: Find indices of two numbers that add to target
        // Example: [2, 7, 11, 15], target = 9 → [0, 1]
        // Time: O(n), Space: O(n)
        // Use hash table (Dictionary)
    }
}

// Test cases
var solution = new TwoSum();

int[] test1 = { 2, 7, 11, 15 };
int[] result1 = solution.TwoSum(test1, 9);
// Expected: [0, 1]

int[] test2 = { 3, 2, 4 };
int[] result2 = solution.TwoSum(test2, 6);
// Expected: [1, 2]

int[] test3 = { 3, 3 };
int[] result3 = solution.TwoSum(test3, 6);
// Expected: [0, 1]
```

---

### Exercise 5: Implement Dynamic Array with Tests

**Problem**: Complete the DynamicArray implementation and add tests.

```csharp
// TODO: Implement comprehensive unit tests for DynamicArray
// Test cases to cover:
// 1. Adding elements
// 2. Resizing behaviour
// 3. Indexer operations
// 4. Insert at various positions
// 5. Remove operations
// 6. IndexOf and Contains
// 7. Edge cases (empty array, single element, etc.)

public class DynamicArrayTests
{
    public static void RunTests()
    {
        TestAdd();
        TestResize();
        TestInsert();
        TestRemove();
        TestIndexOf();
        TestEdgeCases();

        Console.WriteLine("All tests passed!");
    }

    private static void TestAdd()
    {
        var list = new DynamicArray<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Debug.Assert(list.Count == 3);
        Debug.Assert(list[0] == 1);
        Debug.Assert(list[2] == 3);
    }

    // TODO: Implement remaining tests
}
```

---

## 🎯 Part 5: Curated Practice Problems

### Beginner Level (LeetCode Easy)

Complete these problems to master arrays and basic complexity analysis:

1. **[26. Remove Duplicates from Sorted Array](https://leetcode.com/problems/remove-duplicates-from-sorted-array/)** - Two pointers
2. **[27. Remove Element](https://leetcode.com/problems/remove-element/)** - Two pointers
3. **[53. Maximum Subarray](https://leetcode.com/problems/maximum-subarray/)** - Kadane's algorithm
4. **[66. Plus One](https://leetcode.com/problems/plus-one/)** - Array manipulation
5. **[88. Merge Sorted Array](https://leetcode.com/problems/merge-sorted-array/)** - Two pointers
6. **[118. Pascal's Triangle](https://leetcode.com/problems/pascals-triangle/)** - 2D arrays
7. **[121. Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/)** - Array traversal
8. **[169. Majority Element](https://leetcode.com/problems/majority-element/)** - Boyer-Moore voting
9. **[189. Rotate Array](https://leetcode.com/problems/rotate-array/)** - Array rotation
10. **[217. Contains Duplicate](https://leetcode.com/problems/contains-duplicate/)** - HashSet

### String Problems (Easy)

11. **[125. Valid Palindrome](https://leetcode.com/problems/valid-palindrome/)** - Two pointers
12. **[242. Valid Anagram](https://leetcode.com/problems/valid-anagram/)** - Hash table
13. **[387. First Unique Character](https://leetcode.com/problems/first-unique-character-in-a-string/)** - Hash table
14. **[392. Is Subsequence](https://leetcode.com/problems/is-subsequence/)** - Two pointers
15. **[344. Reverse String](https://leetcode.com/problems/reverse-string/)** - Two pointers

### HackerRank C# Track

16. **[Arrays: Left Rotation](https://www.hackerrank.com/challenges/ctci-array-left-rotation)**
17. **[2D Array - DS (Hourglass)](https://www.hackerrank.com/challenges/2d-array)**
18. **[Dynamic Array](https://www.hackerrank.com/challenges/dynamic-array)**
19. **[Sparse Arrays](https://www.hackerrank.com/challenges/sparse-arrays)**
20. **[Array Manipulation](https://www.hackerrank.com/challenges/crush)** - Prefix sum technique

---

## 📝 Part 6: Complexity Analysis Exercises

Analyse the time and space complexity of these code snippets:

### Exercise A

```csharp
public int Example(int n)
{
    int sum = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            sum += i * j;
        }
    }
    return sum;
}
```

**Question**: What is the time complexity? What is the space complexity?

---

### Exercise B

```csharp
public void Example(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }

    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length; j++)
        {
            Console.WriteLine(array[i] + array[j]);
        }
    }
}
```

**Question**: What is the overall time complexity?

---

### Exercise C

```csharp
public int Fibonacci(int n)
{
    if (n <= 1)
        return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

**Question**: What is the time complexity? Can you draw the recursion tree? How can we optimise this?

---

### Exercise D

```csharp
public void PrintPairs(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            Console.WriteLine($"{array[i]}, {array[j]}");
        }
    }
}
```

**Question**: What is the exact number of iterations? What is the Big O complexity?

---

## 🏆 Part 7: Assessment & Next Steps

### Completion Criteria

You're ready for Session 2 when you can:

✅ **C# Knowledge**:
- [ ] Explain and use records, init properties, and pattern matching
- [ ] Write LINQ queries using method syntax
- [ ] Create generic classes and methods with constraints
- [ ] Use nullable reference types correctly
- [ ] Write extension methods

✅ **Big O Understanding**:
- [ ] Analyse time complexity of any algorithm
- [ ] Understand space complexity and call stack depth
- [ ] Identify O(1), O(log n), O(n), O(n log n), O(n²) patterns
- [ ] Apply Big O rules (drop constants, drop lower terms)

✅ **Implementation Skills**:
- [ ] Implement dynamic array from scratch with correct complexity
- [ ] Solve 15+ array problems on LeetCode/HackerRank
- [ ] Explain amortised analysis for array resizing

✅ **Problem-Solving**:
- [ ] Solve problems without looking at solutions first
- [ ] Identify when to use HashSet vs Array vs List
- [ ] Write clean, tested C# code

---

### Self-Assessment Quiz

1. What's the difference between O(n) and O(2n)? Why do we drop constants?
2. What's the time complexity of accessing an element in a hash table? Why?
3. Explain why doubling array capacity gives amortised O(1) insertion.
4. When would you use a record instead of a class in C#?
5. What's the space complexity of recursive binary search?

---

### Additional Resources

**C# Learning**:
- [Microsoft C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [C# 10 and C# 11 What's New](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/)
- [W3Resource C# Exercises](https://www.w3resource.com/csharp-exercises/)

**Big O & Algorithms**:
- [Big O Cheat Sheet](https://www.bigocheatsheet.com/)
- [Visualising Data Structures](https://visualgo.net/en)
- [Time Complexity Analysis - GeeksforGeeks](https://www.geeksforgeeks.org/understanding-time-complexity-simple-examples/)

**Practice Platforms**:
- [LeetCode Study Plans](https://leetcode.com/studyplan/)
- [HackerRank C# Track](https://www.hackerrank.com/domains/tutorials/10-days-of-csharp)
- [CodeSignal Arcade](https://app.codesignal.com/arcade)

---

## 📅 Estimated Timeline

- **Week 1**: C# features refresh + Big O theory (3-4 hours)
- **Week 1-2**: Array problems (10-15 problems, 5-8 hours)
- **Week 2**: Implementation exercises (5-7 hours)
- **Week 2**: Review and assessment (2-3 hours)

**Total**: ~15-20 hours of focused learning

---

## 🎓 Tips for Success

1. **Code by hand first** - Before typing, plan your approach on paper
2. **Analyse before optimising** - Understand the problem before coding
3. **Test with edge cases** - Empty arrays, single elements, duplicates
4. **Review solutions** - After solving, read others' approaches on LeetCode
5. **Use LINQ judiciously** - Great for readability, but know the underlying complexity
6. **Write tests** - Practice writing unit tests for your implementations
7. **Time yourself** - Spend 20-30 minutes before looking at hints

---

**Ready to dive in? Start with the C# features examples, then tackle the array problems. Update your progress tracker as you go. Good luck! 🚀**
