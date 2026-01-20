# C# Arrays and Collections Guide

A comprehensive guide to understanding arrays and collection types in C#, including use cases, performance characteristics, and practical examples.

## Table of Contents
- [Arrays](#arrays)
- [Generic Collections](#generic-collections)
- [Non-Generic Collections](#non-generic-collections)
- [Specialised Collections](#specialised-collections)
- [Concurrent Collections](#concurrent-collections)
- [Immutable Collections](#immutable-collections)
- [Performance Comparison](#performance-comparison)
- [Selection Guide](#selection-guide)

---

## Arrays

### Array (T[])

**Description:** Fixed-size, contiguous memory block storing elements of the same type. The most basic collection type in C#.

**Characteristics:**
- Fixed size (cannot grow or shrink)
- Zero-based indexing
- Best performance for random access
- Stored contiguously in memory
- Value types stored inline, reference types store references

**Use Cases:**
- Known, fixed number of elements
- Performance-critical scenarios requiring fast random access
- Interop with native code
- When you need multi-dimensional data structures

**Example:**
```csharp
// Single-dimensional array
int[] numbers = new int[5];
numbers[0] = 10;
numbers[1] = 20;

// Array initializer syntax
string[] names = { "Alice", "Bob", "Charlie" };

// Multi-dimensional array (rectangular)
int[,] matrix = new int[3, 3];
matrix[0, 0] = 1;
matrix[0, 1] = 2;

// Jagged array (array of arrays)
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] { 1, 2, 3 };
jaggedArray[1] = new int[] { 4, 5 };
jaggedArray[2] = new int[] { 6, 7, 8, 9 };

// Iterating over arrays
foreach (var name in names)
{
    Console.WriteLine(name);
}

// Using LINQ with arrays
var filteredNumbers = numbers.Where(n => n > 15).ToArray();
```

**Time Complexity:**
- Access: O(1)
- Search: O(n)
- Insertion/Deletion: N/A (fixed size)

---

## Generic Collections

Generic collections provide type safety and better performance than non-generic collections. They're part of the `System.Collections.Generic` namespace.

### List\<T\>

**Description:** Dynamic array that automatically grows as elements are added. The most commonly used collection type.

**Characteristics:**
- Dynamic size (grows automatically)
- Backed by an array internally
- Doubles capacity when full
- Maintains insertion order
- Allows duplicates

**Use Cases:**
- General-purpose collection when size isn't known upfront
- When you need indexed access
- Building lists dynamically
- When order matters

**Example:**
```csharp
// Creating and initialising a List
List<string> fruits = new List<string>();
fruits.Add("Apple");
fruits.Add("Banana");
fruits.Add("Cherry");

// Collection initializer syntax
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// Adding multiple items
fruits.AddRange(new[] { "Date", "Elderberry" });

// Inserting at specific position
fruits.Insert(1, "Apricot"); // Insert at index 1

// Removing items
fruits.Remove("Banana"); // Remove by value
fruits.RemoveAt(0); // Remove by index
fruits.RemoveAll(f => f.StartsWith("A")); // Remove with predicate

// Accessing items
string firstFruit = fruits[0];
int count = fruits.Count;

// Searching
bool hasBanana = fruits.Contains("Banana");
int index = fruits.IndexOf("Cherry");
string found = fruits.Find(f => f.Length > 5);
List<string> longNames = fruits.FindAll(f => f.Length > 5);

// Sorting
numbers.Sort(); // Ascending
numbers.Sort((a, b) => b.CompareTo(a)); // Descending

// Converting to array
string[] fruitArray = fruits.ToArray();

// Iterating
foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}

// Capacity management
List<int> preAllocated = new List<int>(100); // Initial capacity
preAllocated.TrimExcess(); // Reduce capacity to actual count
```

**Time Complexity:**
- Access: O(1)
- Search: O(n)
- Insertion (at end): O(1) amortised, O(n) when resizing
- Insertion (at position): O(n)
- Deletion: O(n)

---

### Dictionary\<TKey, TValue\>

**Description:** Hash table-based collection storing key-value pairs. Provides fast lookups by key.

**Characteristics:**
- Keys must be unique
- Fast lookups by key
- Unordered (insertion order not guaranteed)
- Uses `GetHashCode()` and `Equals()` for key comparison
- Values can be null (for reference types)

**Use Cases:**
- Fast lookups by unique identifier
- Caching data
- Counting occurrences
- Mapping relationships between entities

**Example:**
```csharp
// Creating a Dictionary
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("Alice", 30);
ages.Add("Bob", 25);

// Collection initializer syntax
Dictionary<string, string> capitals = new Dictionary<string, string>
{
    { "Australia", "Canberra" },
    { "France", "Paris" },
    { "Japan", "Tokyo" }
};

// Adding or updating with indexer
ages["Charlie"] = 35; // Adds if doesn't exist, updates if exists

// Checking if key exists
if (ages.ContainsKey("Alice"))
{
    Console.WriteLine($"Alice is {ages["Alice"]} years old");
}

// Safe retrieval with TryGetValue (recommended)
if (ages.TryGetValue("David", out int davidAge))
{
    Console.WriteLine($"David is {davidAge} years old");
}
else
{
    Console.WriteLine("David not found");
}

// Removing items
ages.Remove("Bob");

// Iterating over key-value pairs
foreach (KeyValuePair<string, int> kvp in ages)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Iterating over keys or values only
foreach (string name in ages.Keys)
{
    Console.WriteLine(name);
}

foreach (int age in ages.Values)
{
    Console.WriteLine(age);
}

// Example: Counting word occurrences
string text = "the quick brown fox jumps over the lazy dog";
Dictionary<string, int> wordCount = new Dictionary<string, int>();

foreach (string word in text.Split(' '))
{
    if (wordCount.ContainsKey(word))
    {
        wordCount[word]++;
    }
    else
    {
        wordCount[word] = 1;
    }
}

// Modern approach using CollectionsMarshal or GetValueRefOrAddDefault (C# 11+)
// Or simpler with TryGetValue:
foreach (string word in text.Split(' '))
{
    if (!wordCount.TryGetValue(word, out int count))
    {
        count = 0;
    }
    wordCount[word] = count + 1;
}
```

**Time Complexity:**
- Access: O(1) average, O(n) worst case
- Search: O(1) average, O(n) worst case
- Insertion: O(1) average, O(n) worst case
- Deletion: O(1) average, O(n) worst case

---

### HashSet\<T\>

**Description:** Unordered collection of unique elements. Optimised for fast lookups and set operations.

**Characteristics:**
- No duplicates allowed
- Unordered
- Fast lookups, additions, and removals
- Supports mathematical set operations (union, intersection, etc.)

**Use Cases:**
- Removing duplicates from a collection
- Fast membership testing
- Set operations (union, intersection, difference)
- When order doesn't matter but uniqueness does

**Example:**
```csharp
// Creating a HashSet
HashSet<int> numbers = new HashSet<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(2); // Duplicate, won't be added

// Collection initializer
HashSet<string> fruits = new HashSet<string> { "Apple", "Banana", "Cherry" };

// Adding multiple items
fruits.UnionWith(new[] { "Date", "Elderberry" });

// Checking membership
bool hasApple = fruits.Contains("Apple"); // Fast O(1) operation

// Removing duplicates from a list
List<int> numbersWithDuplicates = new List<int> { 1, 2, 2, 3, 3, 3, 4 };
HashSet<int> uniqueNumbers = new HashSet<int>(numbersWithDuplicates);

// Set operations
HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

// Union (all elements from both sets)
HashSet<int> union = new HashSet<int>(setA);
union.UnionWith(setB); // { 1, 2, 3, 4, 5, 6, 7, 8 }

// Intersection (common elements)
HashSet<int> intersection = new HashSet<int>(setA);
intersection.IntersectWith(setB); // { 4, 5 }

// Difference (elements in A but not in B)
HashSet<int> difference = new HashSet<int>(setA);
difference.ExceptWith(setB); // { 1, 2, 3 }

// Symmetric difference (elements in either set but not both)
HashSet<int> symmetricDiff = new HashSet<int>(setA);
symmetricDiff.SymmetricExceptWith(setB); // { 1, 2, 3, 6, 7, 8 }

// Subset/superset checks
bool isSubset = setA.IsSubsetOf(setB);
bool isSuperset = setA.IsSupersetOf(setB);
bool overlaps = setA.Overlaps(setB);

// Example: Finding unique visitors
HashSet<string> uniqueVisitors = new HashSet<string>();
uniqueVisitors.Add("user123");
uniqueVisitors.Add("user456");
uniqueVisitors.Add("user123"); // Won't be added again

Console.WriteLine($"Total unique visitors: {uniqueVisitors.Count}");
```

**Time Complexity:**
- Access: N/A (no indexing)
- Search: O(1) average, O(n) worst case
- Insertion: O(1) average, O(n) worst case
- Deletion: O(1) average, O(n) worst case

---

### Queue\<T\>

**Description:** First-In-First-Out (FIFO) collection. Elements are added at the end and removed from the beginning.

**Characteristics:**
- FIFO ordering
- No random access
- Efficient enqueue and dequeue operations

**Use Cases:**
- Task scheduling
- Breadth-first search algorithms
- Message queues
- Processing items in order of arrival

**Example:**
```csharp
// Creating a Queue
Queue<string> customers = new Queue<string>();

// Enqueueing items (adding to end)
customers.Enqueue("Alice");
customers.Enqueue("Bob");
customers.Enqueue("Charlie");

// Checking the front item without removing
string next = customers.Peek(); // "Alice"

// Dequeuing items (removing from front)
string served = customers.Dequeue(); // "Alice"
Console.WriteLine($"Serving: {served}");

// Checking if queue is empty
if (customers.Count > 0)
{
    string nextCustomer = customers.Dequeue(); // "Bob"
}

// TryDequeue (safer, C# 9+)
if (customers.TryDequeue(out string customer))
{
    Console.WriteLine($"Serving: {customer}");
}

// Checking if an item exists
bool hasCharlie = customers.Contains("Charlie");

// Converting to array (maintains order)
string[] customerArray = customers.ToArray();

// Example: Breadth-First Search
Queue<TreeNode> nodesToVisit = new Queue<TreeNode>();
nodesToVisit.Enqueue(rootNode);

while (nodesToVisit.Count > 0)
{
    TreeNode current = nodesToVisit.Dequeue();
    Console.WriteLine(current.Value);

    foreach (TreeNode child in current.Children)
    {
        nodesToVisit.Enqueue(child);
    }
}

// Example: Task processing
Queue<Action> taskQueue = new Queue<Action>();
taskQueue.Enqueue(() => Console.WriteLine("Task 1"));
taskQueue.Enqueue(() => Console.WriteLine("Task 2"));
taskQueue.Enqueue(() => Console.WriteLine("Task 3"));

while (taskQueue.Count > 0)
{
    Action task = taskQueue.Dequeue();
    task.Invoke();
}
```

**Time Complexity:**
- Enqueue: O(1)
- Dequeue: O(1)
- Peek: O(1)
- Search: O(n)

---

### Stack\<T\>

**Description:** Last-In-First-Out (LIFO) collection. Elements are added and removed from the same end (top).

**Characteristics:**
- LIFO ordering
- No random access
- Efficient push and pop operations

**Use Cases:**
- Undo/redo functionality
- Expression evaluation
- Depth-first search algorithms
- Backtracking algorithms
- Call stack simulation

**Example:**
```csharp
// Creating a Stack
Stack<string> browserHistory = new Stack<string>();

// Pushing items (adding to top)
browserHistory.Push("google.com");
browserHistory.Push("github.com");
browserHistory.Push("stackoverflow.com");

// Checking the top item without removing
string current = browserHistory.Peek(); // "stackoverflow.com"

// Popping items (removing from top)
string lastVisited = browserHistory.Pop(); // "stackoverflow.com"
Console.WriteLine($"Going back from: {lastVisited}");

// TryPop (safer, C# 9+)
if (browserHistory.TryPop(out string page))
{
    Console.WriteLine($"Going back from: {page}");
}

// Checking if stack is empty
if (browserHistory.Count > 0)
{
    string previousPage = browserHistory.Pop(); // "google.com"
}

// Example: Undo functionality
Stack<string> undoStack = new Stack<string>();
Stack<string> redoStack = new Stack<string>();

void PerformAction(string action)
{
    undoStack.Push(action);
    redoStack.Clear(); // Clear redo stack on new action
}

void Undo()
{
    if (undoStack.TryPop(out string action))
    {
        redoStack.Push(action);
        Console.WriteLine($"Undid: {action}");
    }
}

void Redo()
{
    if (redoStack.TryPop(out string action))
    {
        undoStack.Push(action);
        Console.WriteLine($"Redid: {action}");
    }
}

// Example: Depth-First Search
Stack<TreeNode> nodesToVisit = new Stack<TreeNode>();
nodesToVisit.Push(rootNode);

while (nodesToVisit.Count > 0)
{
    TreeNode current = nodesToVisit.Pop();
    Console.WriteLine(current.Value);

    foreach (TreeNode child in current.Children)
    {
        nodesToVisit.Push(child);
    }
}

// Example: Balanced parentheses checker
bool IsBalanced(string expression)
{
    Stack<char> stack = new Stack<char>();

    foreach (char c in expression)
    {
        if (c == '(' || c == '[' || c == '{')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == ']' || c == '}')
        {
            if (stack.Count == 0) return false;

            char top = stack.Pop();
            if ((c == ')' && top != '(') ||
                (c == ']' && top != '[') ||
                (c == '}' && top != '{'))
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}
```

**Time Complexity:**
- Push: O(1)
- Pop: O(1)
- Peek: O(1)
- Search: O(n)

---

### LinkedList\<T\>

**Description:** Doubly-linked list allowing efficient insertion and removal at any position.

**Characteristics:**
- Each node contains value and references to previous/next nodes
- No indexing (must traverse to find elements)
- Efficient insertion/removal anywhere in the list
- More memory overhead than List<T>

**Use Cases:**
- Frequent insertions/deletions in middle of collection
- Implementing custom data structures (queues, stacks)
- When you need bidirectional traversal
- LRU (Least Recently Used) caches

**Example:**
```csharp
// Creating a LinkedList
LinkedList<string> playlist = new LinkedList<string>();

// Adding items
LinkedListNode<string> song1 = playlist.AddLast("Song A");
LinkedListNode<string> song2 = playlist.AddLast("Song B");
LinkedListNode<string> song3 = playlist.AddLast("Song C");

// Adding at specific positions
playlist.AddFirst("Intro");
playlist.AddAfter(song1, "Song A.5");
playlist.AddBefore(song3, "Song B.5");

// Removing items
playlist.Remove("Song B"); // Remove by value
playlist.Remove(song1); // Remove by node
playlist.RemoveFirst();
playlist.RemoveLast();

// Traversing forward
LinkedListNode<string> currentNode = playlist.First;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Next;
}

// Traversing backward
currentNode = playlist.Last;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Previous;
}

// Finding a node
LinkedListNode<string> foundNode = playlist.Find("Song C");
if (foundNode != null)
{
    Console.WriteLine($"Found: {foundNode.Value}");
}

// Example: LRU Cache implementation
public class LRUCache<TKey, TValue>
{
    private readonly int _capacity;
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> _cache;
    private readonly LinkedList<(TKey Key, TValue Value)> _lruList;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<TKey, LinkedListNode<(TKey, TValue)>>(capacity);
        _lruList = new LinkedList<(TKey, TValue)>();
    }

    public TValue Get(TKey key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            // Move to front (most recently used)
            _lruList.Remove(node);
            _lruList.AddFirst(node);
            return node.Value.Value;
        }

        throw new KeyNotFoundException();
    }

    public void Put(TKey key, TValue value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            // Update existing value
            _lruList.Remove(node);
            _cache.Remove(key);
        }
        else if (_cache.Count >= _capacity)
        {
            // Remove least recently used (last item)
            var lruNode = _lruList.Last;
            _lruList.RemoveLast();
            _cache.Remove(lruNode.Value.Key);
        }

        // Add new item to front
        var newNode = _lruList.AddFirst((key, value));
        _cache[key] = newNode;
    }
}
```

**Time Complexity:**
- Access: O(n)
- Search: O(n)
- Insertion (at position): O(1) if you have the node, O(n) to find position
- Deletion (at position): O(1) if you have the node, O(n) to find position

---

### SortedList\<TKey, TValue\>

**Description:** Collection of key-value pairs sorted by key. Implemented as a sorted array.

**Characteristics:**
- Keys must be unique and sortable
- Maintains sorted order by key
- Slower insertions/deletions than Dictionary
- Better memory efficiency than SortedDictionary
- Supports indexed access

**Use Cases:**
- Need both fast lookups and sorted order
- Memory-constrained environments
- Infrequent modifications with frequent lookups
- Need indexed access to sorted data

**Example:**
```csharp
// Creating a SortedList
SortedList<int, string> rankings = new SortedList<int, string>();

// Adding items (automatically sorted by key)
rankings.Add(3, "Bronze");
rankings.Add(1, "Gold");
rankings.Add(2, "Silver");

// Accessing by key
string firstPlace = rankings[1]; // "Gold"

// Accessing by index (sorted order)
string topRanking = rankings.Values[0]; // "Gold"
int topKey = rankings.Keys[0]; // 1

// Getting index of key
int index = rankings.IndexOfKey(2); // Returns 1

// Getting index of value
int valueIndex = rankings.IndexOfValue("Bronze"); // Returns 2

// Iterating (in sorted order)
foreach (KeyValuePair<int, string> kvp in rankings)
{
    Console.WriteLine($"Rank {kvp.Key}: {kvp.Value}");
}

// Example: Event timeline
SortedList<DateTime, string> timeline = new SortedList<DateTime, string>();
timeline.Add(new DateTime(2024, 1, 15), "Project kickoff");
timeline.Add(new DateTime(2024, 2, 1), "First milestone");
timeline.Add(new DateTime(2024, 3, 1), "Second milestone");

// Automatically sorted by date
foreach (var entry in timeline)
{
    Console.WriteLine($"{entry.Key:d}: {entry.Value}");
}
```

**Time Complexity:**
- Access by key: O(log n)
- Access by index: O(1)
- Search: O(log n)
- Insertion: O(n)
- Deletion: O(n)

---

### SortedDictionary\<TKey, TValue\>

**Description:** Collection of key-value pairs sorted by key. Implemented as a binary search tree.

**Characteristics:**
- Keys must be unique and sortable
- Maintains sorted order by key
- Faster insertions/deletions than SortedList
- More memory overhead than SortedList
- No indexed access

**Use Cases:**
- Need sorted key-value pairs with frequent modifications
- When insertion/deletion performance matters more than memory
- Don't need indexed access

**Example:**
```csharp
// Creating a SortedDictionary
SortedDictionary<string, int> scores = new SortedDictionary<string, int>();

// Adding items (automatically sorted by key)
scores.Add("Charlie", 85);
scores.Add("Alice", 95);
scores.Add("Bob", 90);

// Accessing by key
int aliceScore = scores["Alice"];

// Iterating (in sorted order by key)
foreach (KeyValuePair<string, int> kvp in scores)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
// Output:
// Alice: 95
// Bob: 90
// Charlie: 85

// Example: Word frequency sorted alphabetically
SortedDictionary<string, int> wordFreq = new SortedDictionary<string, int>();
string text = "the quick brown fox jumps over the lazy dog";

foreach (string word in text.Split(' '))
{
    if (wordFreq.ContainsKey(word))
    {
        wordFreq[word]++;
    }
    else
    {
        wordFreq[word] = 1;
    }
}

// Words are automatically in alphabetical order
foreach (var kvp in wordFreq)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
```

**Time Complexity:**
- Access: O(log n)
- Search: O(log n)
- Insertion: O(log n)
- Deletion: O(log n)

---

### SortedSet\<T\>

**Description:** Collection of unique elements maintained in sorted order. Implemented as a binary search tree.

**Characteristics:**
- No duplicates
- Automatically sorted
- Supports set operations
- Supports range operations

**Use Cases:**
- Need unique, sorted elements
- Range queries (elements between two values)
- Set operations on sorted data
- Maintaining a sorted collection with frequent modifications

**Example:**
```csharp
// Creating a SortedSet
SortedSet<int> numbers = new SortedSet<int>();

// Adding items (automatically sorted and de-duplicated)
numbers.Add(5);
numbers.Add(1);
numbers.Add(3);
numbers.Add(1); // Duplicate, won't be added

// Iterating (in sorted order)
foreach (int num in numbers)
{
    Console.WriteLine(num); // Output: 1, 3, 5
}

// Range operations
var subset = numbers.GetViewBetween(2, 5); // Elements >= 2 and <= 5

// Getting min and max
int min = numbers.Min; // 1
int max = numbers.Max; // 5

// Set operations (same as HashSet, but maintains order)
SortedSet<int> setA = new SortedSet<int> { 1, 2, 3, 4, 5 };
SortedSet<int> setB = new SortedSet<int> { 4, 5, 6, 7, 8 };

setA.UnionWith(setB); // { 1, 2, 3, 4, 5, 6, 7, 8 }

// Example: Leaderboard with unique scores
SortedSet<int> leaderboard = new SortedSet<int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); // Descending

leaderboard.Add(100);
leaderboard.Add(250);
leaderboard.Add(180);
leaderboard.Add(250); // Duplicate, won't be added

Console.WriteLine("Top 3 scores:");
foreach (int score in leaderboard.Take(3))
{
    Console.WriteLine(score);
}

// Example: Finding elements in range
SortedSet<DateTime> appointments = new SortedSet<DateTime>
{
    new DateTime(2024, 1, 15, 9, 0, 0),
    new DateTime(2024, 1, 15, 11, 0, 0),
    new DateTime(2024, 1, 15, 14, 0, 0),
    new DateTime(2024, 1, 15, 16, 0, 0)
};

// Get appointments between 10 AM and 3 PM
var morningAppointments = appointments.GetViewBetween(
    new DateTime(2024, 1, 15, 10, 0, 0),
    new DateTime(2024, 1, 15, 15, 0, 0)
);
```

**Time Complexity:**
- Access: O(log n)
- Search: O(log n)
- Insertion: O(log n)
- Deletion: O(log n)

---

## Non-Generic Collections

Non-generic collections are part of `System.Collections` namespace. They store objects as `object` type, requiring boxing/unboxing for value types. **Generally avoided in modern C# in favour of generic collections.**

### ArrayList

**Description:** Dynamic array storing objects. Legacy collection, replaced by `List<T>`.

**Avoid using:** Use `List<T>` instead for type safety and better performance.

**Example (legacy code):**
```csharp
// Legacy - Don't use in new code
ArrayList list = new ArrayList();
list.Add(1); // Boxing occurs
list.Add("text"); // No type safety!
int value = (int)list[0]; // Unboxing required, runtime type checking

// Modern equivalent
List<int> numbers = new List<int>();
numbers.Add(1); // No boxing
// numbers.Add("text"); // Compile-time error - type safe!
int value = numbers[0]; // No casting required
```

---

### Hashtable

**Description:** Non-generic hash table storing key-value pairs. Legacy collection, replaced by `Dictionary<TKey, TValue>`.

**Avoid using:** Use `Dictionary<TKey, TValue>` instead.

**Example (legacy code):**
```csharp
// Legacy - Don't use in new code
Hashtable table = new Hashtable();
table.Add("key1", 123);
table.Add("key2", "value");
int value = (int)table["key1"]; // Casting required

// Modern equivalent
Dictionary<string, int> dict = new Dictionary<string, int>();
dict.Add("key1", 123);
int value = dict["key1"]; // Type safe, no casting
```

---

## Specialised Collections

Collections in `System.Collections.Specialized` namespace designed for specific scenarios.

### NameValueCollection

**Description:** Collection of associated string keys and string values. Can have multiple values per key.

**Use Cases:**
- HTTP headers
- Configuration settings
- Query strings
- When you need multiple values for the same key

**Example:**
```csharp
using System.Collections.Specialized;

// Creating a NameValueCollection
NameValueCollection headers = new NameValueCollection();

// Adding items
headers.Add("Content-Type", "application/json");
headers.Add("Authorization", "Bearer token123");
headers.Add("Accept", "application/json");
headers.Add("Accept", "text/html"); // Multiple values for same key

// Accessing values
string contentType = headers["Content-Type"];

// Getting all values for a key
string[] acceptValues = headers.GetValues("Accept");
// Returns: ["application/json", "text/html"]

// Iterating
foreach (string key in headers.AllKeys)
{
    Console.WriteLine($"{key}: {headers[key]}");
}

// Example: Parsing query string
NameValueCollection queryString = new NameValueCollection();
queryString.Add("search", "c# collections");
queryString.Add("page", "1");
queryString.Add("filter", "tutorials");
queryString.Add("filter", "examples"); // Multiple filters

string[] filters = queryString.GetValues("filter");
Console.WriteLine($"Filters: {string.Join(", ", filters)}");
```

---

### OrderedDictionary

**Description:** Hybrid collection providing both indexed access and key-based access. Maintains insertion order.

**Use Cases:**
- Need both indexed and key-based access
- Order of insertion matters
- Small to medium collections

**Example:**
```csharp
using System.Collections.Specialized;

// Creating an OrderedDictionary
OrderedDictionary config = new OrderedDictionary();

// Adding items (maintains insertion order)
config.Add("server", "localhost");
config.Add("port", 5432);
config.Add("database", "mydb");

// Accessing by key
string server = (string)config["server"];

// Accessing by index (maintains insertion order)
string firstValue = (string)config[0]; // "localhost"

// Inserting at specific index
config.Insert(1, "protocol", "https");

// Iterating (in insertion order)
foreach (DictionaryEntry entry in config)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}
```

---

### BitArray

**Description:** Compact array of bit values (true/false). More memory-efficient than `bool[]` for large boolean arrays.

**Use Cases:**
- Bit flags
- Memory-efficient boolean storage
- Bit manipulation operations
- Bloom filters

**Example:**
```csharp
using System.Collections;

// Creating a BitArray
BitArray bits = new BitArray(8);

// Setting individual bits
bits[0] = true;
bits[1] = false;
bits[2] = true;

// Creating from byte
byte value = 0b10101010;
BitArray bitsFromByte = new BitArray(new byte[] { value });

// Bit operations
BitArray a = new BitArray(new bool[] { true, false, true, false });
BitArray b = new BitArray(new bool[] { true, true, false, false });

BitArray andResult = a.And(b); // Bitwise AND
BitArray orResult = a.Or(b);   // Bitwise OR
BitArray xorResult = a.Xor(b); // Bitwise XOR
BitArray notResult = a.Not();   // Bitwise NOT

// Example: Permissions system
[Flags]
enum Permissions
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    Delete = 8
}

BitArray userPermissions = new BitArray(4);
userPermissions[(int)Math.Log2((int)Permissions.Read)] = true;
userPermissions[(int)Math.Log2((int)Permissions.Write)] = true;

// Check if user has write permission
bool canWrite = userPermissions[1];
```

---

## Concurrent Collections

Thread-safe collections in `System.Collections.Concurrent` namespace designed for multi-threaded scenarios.

### ConcurrentDictionary\<TKey, TValue\>

**Description:** Thread-safe dictionary supporting concurrent reads and writes.

**Use Cases:**
- Shared state in multi-threaded applications
- Caching in web applications
- Lock-free data structures

**Example:**
```csharp
using System.Collections.Concurrent;

// Creating a ConcurrentDictionary
ConcurrentDictionary<string, int> cache = new ConcurrentDictionary<string, int>();

// Adding items (thread-safe)
cache.TryAdd("key1", 100);

// Updating items atomically
cache.AddOrUpdate("key1",
    addValue: 1,                          // Value if key doesn't exist
    updateValueFactory: (key, oldValue) => oldValue + 1); // Update function

// Getting or adding (atomic operation)
int value = cache.GetOrAdd("key2", key => ExpensiveOperation(key));

// Trying to update
cache.TryUpdate("key1", newValue: 200, comparisonValue: 100);

// Trying to remove
cache.TryRemove("key1", out int removedValue);

// Example: Thread-safe counter
ConcurrentDictionary<string, int> wordCount = new ConcurrentDictionary<string, int>();

Parallel.ForEach(documents, document =>
{
    foreach (string word in document.Split(' '))
    {
        wordCount.AddOrUpdate(word, 1, (key, count) => count + 1);
    }
});

// Example: Caching expensive operations
int ExpensiveOperation(string key)
{
    Thread.Sleep(1000); // Simulate expensive operation
    return key.Length * 100;
}
```

---

### ConcurrentQueue\<T\>

**Description:** Thread-safe FIFO queue.

**Example:**
```csharp
using System.Collections.Concurrent;

ConcurrentQueue<string> taskQueue = new ConcurrentQueue<string>();

// Producer thread
Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        taskQueue.Enqueue($"Task {i}");
    }
});

// Consumer thread
Task.Run(() =>
{
    while (true)
    {
        if (taskQueue.TryDequeue(out string task))
        {
            Console.WriteLine($"Processing: {task}");
        }
        else
        {
            Thread.Sleep(10);
        }
    }
});
```

---

### ConcurrentStack\<T\>

**Description:** Thread-safe LIFO stack.

**Example:**
```csharp
using System.Collections.Concurrent;

ConcurrentStack<int> stack = new ConcurrentStack<int>();

// Multiple threads can push safely
Parallel.For(0, 100, i =>
{
    stack.Push(i);
});

// Multiple threads can pop safely
Parallel.For(0, 100, i =>
{
    if (stack.TryPop(out int value))
    {
        Console.WriteLine($"Popped: {value}");
    }
});
```

---

### ConcurrentBag\<T\>

**Description:** Thread-safe unordered collection optimised for scenarios where the same thread both adds and removes items.

**Use Cases:**
- Work-stealing algorithms
- Thread-local storage with sharing
- Producer-consumer patterns where threads produce and consume their own items

**Example:**
```csharp
using System.Collections.Concurrent;

ConcurrentBag<int> bag = new ConcurrentBag<int>();

// Multiple threads adding items
Parallel.For(0, 1000, i =>
{
    bag.Add(i);
});

// Processing items (order not guaranteed)
Parallel.ForEach(bag, item =>
{
    Console.WriteLine($"Processing: {item}");
});

// Example: Work-stealing algorithm
ConcurrentBag<WorkItem> workItems = new ConcurrentBag<WorkItem>();

// Add initial work
foreach (var item in initialWork)
{
    workItems.Add(item);
}

// Workers process and potentially add more work
Parallel.For(0, Environment.ProcessorCount, workerId =>
{
    while (workItems.TryTake(out WorkItem item))
    {
        var result = ProcessWork(item);

        // Add new work items if needed
        if (result.GeneratesMoreWork)
        {
            workItems.Add(result.NewWorkItem);
        }
    }
});
```

---

### BlockingCollection\<T\>

**Description:** Thread-safe collection with blocking and bounding capabilities. Wrapper around any `IProducerConsumerCollection<T>`.

**Use Cases:**
- Producer-consumer patterns
- Bounded queues with backpressure
- Pipeline processing

**Example:**
```csharp
using System.Collections.Concurrent;

// Creating a bounded blocking collection (max 10 items)
BlockingCollection<string> queue = new BlockingCollection<string>(boundedCapacity: 10);

// Producer thread
Task producer = Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        queue.Add($"Item {i}"); // Blocks if queue is full
        Console.WriteLine($"Produced: Item {i}");
    }
    queue.CompleteAdding(); // Signal no more items will be added
});

// Consumer thread
Task consumer = Task.Run(() =>
{
    foreach (string item in queue.GetConsumingEnumerable())
    {
        Thread.Sleep(100); // Simulate processing
        Console.WriteLine($"Consumed: {item}");
    }
});

await Task.WhenAll(producer, consumer);

// Example: Pipeline with multiple stages
BlockingCollection<RawData> stage1Output = new BlockingCollection<RawData>(100);
BlockingCollection<ProcessedData> stage2Output = new BlockingCollection<ProcessedData>(100);

// Stage 1: Data ingestion
Task stage1 = Task.Run(() =>
{
    foreach (var data in dataSource)
    {
        stage1Output.Add(data);
    }
    stage1Output.CompleteAdding();
});

// Stage 2: Data processing
Task stage2 = Task.Run(() =>
{
    foreach (var raw in stage1Output.GetConsumingEnumerable())
    {
        var processed = Process(raw);
        stage2Output.Add(processed);
    }
    stage2Output.CompleteAdding();
});

// Stage 3: Data storage
Task stage3 = Task.Run(() =>
{
    foreach (var processed in stage2Output.GetConsumingEnumerable())
    {
        SaveToDatabase(processed);
    }
});

await Task.WhenAll(stage1, stage2, stage3);
```

---

## Immutable Collections

Immutable collections in `System.Collections.Immutable` namespace that cannot be modified after creation. Operations return new instances.

### ImmutableList\<T\>

**Description:** Immutable version of List<T>. All modifications return a new instance.

**Use Cases:**
- Functional programming patterns
- Thread-safe sharing without locking
- Undo/redo with structural sharing
- Snapshots of state

**Example:**
```csharp
using System.Collections.Immutable;

// Creating an immutable list
ImmutableList<int> original = ImmutableList.Create(1, 2, 3);

// "Modifying" returns a new instance
ImmutableList<int> modified = original.Add(4);

Console.WriteLine(original.Count); // 3 (unchanged)
Console.WriteLine(modified.Count); // 4 (new instance)

// Builder for efficient bulk operations
ImmutableList<int>.Builder builder = ImmutableList.CreateBuilder<int>();
for (int i = 0; i < 1000; i++)
{
    builder.Add(i);
}
ImmutableList<int> largeList = builder.ToImmutable();

// Example: State management with history
public class StateManager<T>
{
    private ImmutableList<T> _history = ImmutableList<T>.Empty;
    private int _currentIndex = -1;

    public void AddState(T state)
    {
        // Remove any future states if we're not at the end
        _history = _history.RemoveRange(_currentIndex + 1, _history.Count - _currentIndex - 1);
        _history = _history.Add(state);
        _currentIndex++;
    }

    public T Undo()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            return _history[_currentIndex];
        }
        throw new InvalidOperationException("Nothing to undo");
    }

    public T Redo()
    {
        if (_currentIndex < _history.Count - 1)
        {
            _currentIndex++;
            return _history[_currentIndex];
        }
        throw new InvalidOperationException("Nothing to redo");
    }
}
```

---

### ImmutableDictionary\<TKey, TValue\>

**Description:** Immutable version of Dictionary<TKey, TValue>.

**Example:**
```csharp
using System.Collections.Immutable;

// Creating an immutable dictionary
ImmutableDictionary<string, int> original = ImmutableDictionary.Create<string, int>()
    .Add("one", 1)
    .Add("two", 2);

// "Modifying" returns a new instance
ImmutableDictionary<string, int> modified = original.Add("three", 3);

// Example: Configuration that can be safely shared across threads
public class ConfigurationSnapshot
{
    public ImmutableDictionary<string, string> Settings { get; }

    public ConfigurationSnapshot(IDictionary<string, string> settings)
    {
        Settings = settings.ToImmutableDictionary();
    }

    public ConfigurationSnapshot UpdateSetting(string key, string value)
    {
        var newSettings = Settings.SetItem(key, value);
        return new ConfigurationSnapshot(newSettings);
    }
}
```

---

### ImmutableHashSet\<T\>, ImmutableQueue\<T\>, ImmutableStack\<T\>

Similar immutable versions of their mutable counterparts.

---

## Performance Comparison

| Collection | Access | Search | Insert | Delete | Memory | Notes |
|------------|--------|--------|--------|--------|--------|-------|
| **Array** | O(1) | O(n) | N/A | N/A | Low | Fixed size, best for known size |
| **List\<T\>** | O(1) | O(n) | O(1)* | O(n) | Low | General purpose, dynamic |
| **LinkedList\<T\>** | O(n) | O(n) | O(1)** | O(1)** | Medium | Good for frequent insert/delete |
| **Dictionary\<K,V\>** | O(1) | O(1) | O(1) | O(1) | Medium | Fast lookups by key |
| **HashSet\<T\>** | N/A | O(1) | O(1) | O(1) | Medium | Unique items, set operations |
| **SortedList\<K,V\>** | O(log n) | O(log n) | O(n) | O(n) | Low | Sorted, indexed access |
| **SortedDictionary\<K,V\>** | O(log n) | O(log n) | O(log n) | O(log n) | Medium | Sorted, no indexed access |
| **SortedSet\<T\>** | O(log n) | O(log n) | O(log n) | O(log n) | Medium | Sorted unique items |
| **Queue\<T\>** | N/A | O(n) | O(1) | O(1) | Low | FIFO operations |
| **Stack\<T\>** | N/A | O(n) | O(1) | O(1) | Low | LIFO operations |

\* O(1) amortised for Add, O(n) when resizing
\*\* O(1) if you have the node reference, O(n) to find the node

---

## Selection Guide

### Use **Array** when:
- Size is fixed and known at compile time
- Maximum performance for random access is critical
- Working with native code interop
- Need multi-dimensional data structures

### Use **List\<T\>** when:
- Size is not known upfront
- Need indexed access and dynamic sizing
- General-purpose collection (default choice)
- Building collections incrementally

### Use **Dictionary\<TKey, TValue\>** when:
- Need fast lookups by unique key
- Mapping relationships between entities
- Counting occurrences
- Caching data by identifier

### Use **HashSet\<T\>** when:
- Need unique elements only
- Performing set operations (union, intersection)
- Fast membership testing is important
- Order doesn't matter

### Use **SortedDictionary\<K,V\>** or **SortedList\<K,V\>** when:
- Need key-value pairs in sorted order
- Frequent modifications: Use SortedDictionary
- Memory-constrained or need indexed access: Use SortedList
- Need range queries

### Use **SortedSet\<T\>** when:
- Need unique elements in sorted order
- Performing set operations on sorted data
- Need range queries
- Finding min/max efficiently

### Use **Queue\<T\>** when:
- FIFO processing is required
- Task scheduling
- Breadth-first algorithms

### Use **Stack\<T\>** when:
- LIFO processing is required
- Implementing undo functionality
- Depth-first algorithms
- Expression evaluation

### Use **LinkedList\<T\>** when:
- Frequent insertions/deletions in middle of collection
- Need bidirectional traversal
- Implementing custom data structures
- Order of elements matters and changes frequently

### Use **Concurrent Collections** when:
- Multiple threads accessing the collection
- Need thread-safe operations without manual locking
- Building producer-consumer patterns
- Implementing thread-safe caches

### Use **Immutable Collections** when:
- Need thread-safe sharing without locks
- Implementing functional patterns
- Need snapshots of state
- Implementing undo/redo with structural sharing

---

## Best Practices

1. **Prefer Generic Collections**: Always use generic collections (`List<T>`) over non-generic (`ArrayList`) for type safety and performance.

2. **Choose Based on Operations**: Select collections based on your most frequent operations (access, search, insert, delete).

3. **Pre-allocate Capacity**: If you know the size, specify capacity to avoid resizing:
   ```csharp
   var list = new List<int>(capacity: 1000);
   var dict = new Dictionary<string, int>(capacity: 1000);
   ```

4. **Use Correct Equality Comparison**: For custom types in Dictionary/HashSet, override `GetHashCode()` and `Equals()` or provide `IEqualityComparer<T>`.

5. **Avoid Boxing**: Don't use non-generic collections with value types to avoid boxing overhead.

6. **Consider Memory**: Arrays and List<T> are most memory-efficient. Dictionaries and sets have overhead.

7. **Thread Safety**: Use concurrent collections for multi-threaded scenarios, don't manually lock generic collections.

8. **Immutability**: Consider immutable collections for thread-safe sharing and functional patterns.

9. **LINQ Integration**: All collections work with LINQ, but materialising results (`ToList()`, `ToArray()`) has cost.

10. **Collection Initializers**: Use collection initializer syntax for readability:
    ```csharp
    var list = new List<string> { "a", "b", "c" };
    var dict = new Dictionary<string, int> { ["key1"] = 1, ["key2"] = 2 };
    ```

---

## Summary

C# provides a rich set of collection types, each optimised for specific scenarios:

- **Arrays**: Fixed-size, fastest access, lowest memory overhead
- **List\<T\>**: Dynamic array, general-purpose collection
- **Dictionary\<K,V\>**: Fast key-based lookups, unique keys
- **HashSet\<T\>**: Unique elements, set operations, fast membership testing
- **Sorted Collections**: Maintain order, support range queries
- **Queue/Stack**: Specialised FIFO/LIFO operations
- **LinkedList**: Efficient insertion/deletion anywhere
- **Concurrent Collections**: Thread-safe operations
- **Immutable Collections**: Thread-safe sharing, functional patterns

Choose the appropriate collection based on your specific requirements for access patterns, modification frequency, ordering needs, uniqueness constraints, and concurrency requirements.
