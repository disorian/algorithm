# C# Algorithm Mastery - Enhanced Progressive Learning Plan v2.0

> **Updated**: 2026-01-20 - Enhanced with NeetCode roadmap analysis

## 📋 Plan Overview

This comprehensive learning plan combines C# mastery with systematic algorithm and data structure learning, incorporating the best elements from multiple sources including [NeetCode roadmap](https://neetcode.io/roadmap), Blind 75, and industry best practices.

**Estimated Duration**: 12-24 weeks (1-2 weeks per session depending on pace)

**Key Enhancements from v1.0**:
- ✅ Added **Intervals Pattern** (Session 4)
- ✅ Enhanced **Bit Manipulation** (Session 2 + Session 12)
- ✅ Added **Math & Geometry** (Session 9)
- ✅ Added more **Binary Search** (Session 3)
- ✅ Cross-referenced with NeetCode 150/250

---

## Phase 1: Foundation & C# Refresh (Sessions 1-3)

### Session 1: C# Fundamentals Refresh + Complexity Analysis

**C# Topics**:
- Modern C# features (C# 10-14)
- LINQ and functional programming concepts
- Collections and generics
- Pattern matching and switch expressions
- Records and init-only properties
- C# 13: params collections, new Lock type, ref struct enhancements
- C# 14: Extension members, field keyword, null-conditional assignment

**Algorithm Topics**:
- Big O notation fundamentals
- Time complexity analysis
- Space complexity analysis
- Best/average/worst case analysis
- Amortised analysis introduction

**Data Structures**:
- Arrays (single and multi-dimensional)
- Lists and dynamic arrays
- Basic complexity analysis
- Array manipulation techniques

**Practice Goals**:
- 15-20 Easy problems on arrays and strings
- Implement dynamic array from scratch
- Master array traversal patterns

**Recommended Platforms**:
- HackerRank's C# track (structured tutorials)
- LeetCode Easy problems (Arrays & Hashing tag)
- W3Resource C# exercises

**NeetCode Alignment**: Arrays & Hashing (9 problems from Blind 75)

---

### Session 2: Basic Problem-Solving Patterns + Bit Manipulation Basics

**C# Topics**:
- Extension methods
- Delegates and events
- Lambda expressions and expression trees
- Anonymous types and tuples
- Nullable reference types
- LINQ operators deep dive

**Algorithm Topics**:
- Two pointers technique (convergent, same-direction, fast-slow)
- Sliding window pattern (fixed and variable)
- Prefix sums and cumulative operations
- Frequency counting with hash maps
- **NEW: Bit manipulation basics** ⭐

**Bit Manipulation Fundamentals**:
- Binary representation and operations
- Bitwise operators (&, |, ^, ~, <<, >>)
- Common bit manipulation patterns
- XOR properties and tricks
- Bit masks and flags
- Counting set bits
- Power of two checks

**Data Structures**:
- HashSet<T> and Dictionary<TKey, TValue>
- Hash table internals (buckets, collision resolution)
- Hash functions and distribution
- Custom equality comparers

**Practice Goals**:
- 20 two pointers problems
- 15 sliding window problems
- 15 hash map/frequency counting problems
- 10 prefix sum problems
- **10 bit manipulation problems** ⭐

**Bit Manipulation Problems** (Easy):
1. Single Number (XOR trick)
2. Number of 1 Bits (Hamming weight)
3. Counting Bits
4. Missing Number
5. Power of Two
6. Power of Four
7. Reverse Bits (basic)
8. Binary Number with Alternating Bits
9. Hamming Distance
10. Complement of Base 10 Integer

**Recommended Platforms**:
- CodeSignal Arcade Mode
- LeetCode Easy-Medium problems
- HackerRank interview preparation kit

**NeetCode Alignment**:
- Two Pointers (5 problems)
- Sliding Window (6 problems)
- Bit Manipulation basics (7 problems)

---

### Session 3: Recursion, Backtracking + Binary Search

**C# Topics**:
- Stack traces and call stack
- Recursion optimization in C#
- Tail recursion and TCO limitations
- Memory management in recursive calls
- Recursive data structure design

**Algorithm Topics**:
- Recursion fundamentals (base cases, recursive cases)
- Backtracking introduction
- Pruning and optimization
- **Binary search and variations** ⭐
- Search space reduction techniques

**Binary Search Mastery**:
- Classic binary search
- Binary search on sorted arrays
- Binary search on rotated arrays
- Binary search on 2D matrices
- Binary search for answer (finding minimum/maximum)
- Lower bound / upper bound
- Search in infinite sorted array

**Data Structures**:
- Stack (LIFO) - array-based and linked
- Queue (FIFO) - array-based and linked
- Deque (double-ended queue)
- Monotonic stack and queue
- Applications in algorithms

**Practice Goals**:
- 20 recursion problems
- 10 backtracking problems (basics)
- **15 binary search problems** ⭐
- Implement stack and queue from scratch
- Implement monotonic stack/queue

**Binary Search Problems**:
1. Binary Search (classic)
2. Search Insert Position
3. Find First and Last Position
4. Search in Rotated Sorted Array
5. Find Minimum in Rotated Sorted Array
6. Search a 2D Matrix
7. Koko Eating Bananas
8. Find Peak Element
9. Single Element in Sorted Array
10. Median of Two Sorted Arrays (hard)

**Recommended Platforms**:
- W3Resource recursion exercises
- LeetCode recursion + binary search study plans
- HackerRank recursion challenges

**NeetCode Alignment**:
- Stack (7 problems)
- Backtracking (9 problems)
- Binary Search (7 problems)

---

## Phase 2: Core Data Structures (Sessions 4-6)

### Session 4: Linked Lists + Intervals Pattern

**Algorithm Topics**:
- Fast and slow pointer technique (Floyd's algorithm)
- Cycle detection
- List reversal patterns
- Merge operations
- **Intervals pattern** ⭐

**Intervals Pattern Mastery**:
- Sorting intervals
- Merging overlapping intervals
- Interval intersection
- Interval insertion
- Interval scheduling problems
- Sweep line technique
- Priority queue with intervals

**Data Structures**:
- Singly linked lists
- Doubly linked lists
- Circular linked lists
- Priority queues (heap-based)
- Interval tree (introduction)

**Practice Goals**:
- 25 linked list problems
- **15 intervals problems** ⭐
- 10 priority queue problems
- Implement all list types from scratch
- Implement min/max heap

**Intervals Problems**:
1. Merge Intervals ⭐
2. Insert Interval ⭐
3. Non-overlapping Intervals ⭐
4. Meeting Rooms (Easy)
5. Meeting Rooms II (Medium) ⭐
6. Interval List Intersections
7. Minimum Number of Arrows to Burst Balloons
8. Employee Free Time
9. Remove Covered Intervals
10. Count Days Without Meetings
11. My Calendar I, II, III
12. Range Module
13. Data Stream as Disjoint Intervals
14. Maximum CPU Load
15. Minimum Meeting Rooms (variations)

**Recommended Platforms**:
- LeetCode Medium problems
- HackerRank data structures track

**NeetCode Alignment**:
- Linked List (6 problems)
- Intervals (6 problems from Blind 75) ⭐
- Heap / Priority Queue (3 problems)

---

### Session 5: Trees Part 1 - Binary Trees & BST

**Algorithm Topics**:
- Tree traversals (inorder, preorder, postorder)
- Level-order traversal (BFS)
- Depth-first search (DFS)
- Recursive vs iterative approaches
- Tree construction from traversals
- Lowest Common Ancestor (LCA)
- Path finding algorithms

**Data Structures**:
- Binary trees
- Binary Search Trees (BST)
- Tree properties and invariants
- Balanced vs unbalanced trees

**Practice Goals**:
- 30 tree problems (traversals, BST operations, path finding)
- Implement binary tree and BST from scratch
- Master all traversal methods

**Recommended Platforms**:
- LeetCode tree problems (Easy to Medium)
- CodeSignal tree challenges

**NeetCode Alignment**: Trees (15 problems from Blind 75)

---

### Session 6: Trees Part 2 - Advanced Trees

**Algorithm Topics**:
- Self-balancing trees (AVL, Red-Black conceptual)
- Tree rotations
- Heap operations (heapify, heap sort, k-way merge)
- Trie operations (insert, search, prefix matching)
- Segment tree basics (range queries, point updates)

**Data Structures**:
- AVL trees
- Red-Black trees (conceptual understanding)
- Heaps (min-heap, max-heap)
- Tries (prefix trees)
- Segment trees (introduction)
- Fenwick trees (introduction)

**Practice Goals**:
- 25 advanced tree problems
- Implement heap from scratch
- Implement trie from scratch
- Understand segment tree operations

**Recommended Platforms**:
- LeetCode Medium-Hard tree problems
- Codeforces tree problems

**NeetCode Alignment**:
- Tries (3 problems)
- Heap/Priority Queue advanced (additional problems)

---

## Phase 3: Advanced Algorithms (Sessions 7-9)

### Session 7: Graph Algorithms Part 1

**Algorithm Topics**:
- Graph representations (adjacency list, adjacency matrix, edge list)
- Breadth-First Search (BFS) and applications
- Depth-First Search (DFS) and applications
- Topological sort (Kahn's algorithm, DFS-based)
- Cycle detection in directed and undirected graphs
- Connected components (DFS/BFS/Union-Find)
- Bipartite graph detection

**Data Structures**:
- Adjacency list
- Adjacency matrix
- Edge list
- Union-Find (Disjoint Set Union with path compression and union by rank)

**Practice Goals**:
- 25 graph traversal and basic graph problems
- Implement all graph representations
- Implement Union-Find with optimisations

**Recommended Platforms**:
- LeetCode graph problems
- HackerRank graph challenges

**NeetCode Alignment**: Graphs (13 problems from Blind 75)

---

### Session 8: Graph Algorithms Part 2 - Shortest Paths & MST

**Algorithm Topics**:
- Shortest path algorithms:
  - Dijkstra's algorithm (single-source shortest path)
  - Bellman-Ford algorithm (handles negative weights)
  - Floyd-Warshall algorithm (all-pairs shortest path)
  - A* search (heuristic-based)
- Minimum Spanning Tree:
  - Kruskal's algorithm (greedy + Union-Find)
  - Prim's algorithm (greedy + priority queue)
- Network flow (introduction)

**Data Structures**:
- Weighted graphs
- Priority queues for graphs
- Path reconstruction
- Edge relaxation

**Practice Goals**:
- 20 shortest path problems
- 10 MST problems
- Implement Dijkstra, Bellman-Ford, Kruskal, Prim

**Recommended Platforms**:
- LeetCode Medium-Hard graphs
- HackerRank advanced graph problems

**NeetCode Alignment**: Advanced Graphs

---

### Session 9: Greedy Algorithms, Divide-and-Conquer + Math & Geometry

**Algorithm Topics**:
- Greedy strategy and proof of correctness
- Activity selection problem
- Huffman coding
- Divide-and-Conquer paradigm
- Master theorem for recurrence relations
- **Math & Geometry problems** ⭐

**Math & Geometry Topics**:
- Matrix manipulation (rotation, transpose, spiral)
- Coordinate geometry
- Mathematical formulas and properties
- Number theory basics
- Computational geometry basics
- Grid-based problems

**Classic Problems**:
- Interval scheduling
- Fractional knapsack
- Merge sort and variations
- Quick sort and variations
- Binary search variations (from Session 3)

**Math & Geometry Problems**:
1. Rotate Image ⭐
2. Spiral Matrix ⭐
3. Set Matrix Zeroes ⭐
4. Happy Number
5. Plus One
6. Pow(x, n)
7. Sqrt(x)
8. Valid Square
9. Rectangle Overlap
10. Rectangle Area
11. Largest Rectangle in Histogram
12. Max Points on a Line
13. Detect Squares
14. Number of Boomerangs
15. Convex Polygon

**Practice Goals**:
- 25 greedy problems
- 15 divide-and-conquer problems
- **15 math & geometry problems** ⭐
- Implement sorting algorithms from scratch

**Recommended Platforms**:
- Codewars
- LeetCode curated lists
- GeeksforGeeks practice

**NeetCode Alignment**:
- Greedy (8 problems)
- Math & Geometry (problems from Blind 75)

---

## Phase 4: Mastery & Advanced Techniques (Sessions 10-12)

### Session 10: Dynamic Programming Part 1

**Algorithm Topics**:
- Memoisation (top-down DP)
- Tabulation (bottom-up DP)
- Identifying DP problems (optimal substructure, overlapping subproblems)
- State definition and transition
- Base cases and boundary conditions

**Patterns**:
- 1D DP (Fibonacci, climbing stairs, house robber)
- 2D DP (grid problems, unique paths)
- String DP (edit distance basics)
- DP with arrays

**Practice Goals**:
- 30 DP problems (Easy to Medium)
- Understand pattern recognition for DP
- Master both memoisation and tabulation

**Recommended Platforms**:
- LeetCode DP study plan
- HackerRank DP challenges

**NeetCode Alignment**: 1-D Dynamic Programming (12 problems from Blind 75)

---

### Session 11: Dynamic Programming Part 2

**Algorithm Topics**:
- Advanced DP patterns
- Optimisation techniques (space optimisation, rolling arrays)
- DP with state compression (bitmask DP)
- Multi-dimensional DP

**Patterns**:
- Knapsack problems (0/1, unbounded, bounded)
- Longest Common Subsequence (LCS) and variations
- Longest Increasing Subsequence (LIS) and variations
- Matrix chain multiplication
- DP on trees and graphs
- Palindrome DP
- State machine DP

**Practice Goals**:
- 25 Medium-Hard DP problems
- Implement all classic DP algorithms
- Master space optimisation techniques

**Recommended Platforms**:
- LeetCode Medium-Hard DP
- Codeforces DP problems

**NeetCode Alignment**: 2-D Dynamic Programming (11 problems from Blind 75)

---

### Session 12: Advanced Topics - Bit Manipulation, String Algorithms & System Design

**Algorithm Topics**:
- **Advanced bit manipulation** ⭐
- Advanced string algorithms:
  - KMP (Knuth-Morris-Pratt)
  - Rabin-Karp
  - Z-algorithm
  - Manacher's algorithm
- Rolling hash techniques

**Bit Manipulation Advanced**:
- Bit manipulation DP
- Gray code
- Bitwise operations on ranges
- Bit counting optimisations
- Bitset techniques
- Submask enumeration

**Advanced Bit Problems**:
1. Reverse Bits (advanced)
2. Sum of Two Integers (no +/-)
3. Single Number II (appearing 3 times)
4. Single Number III (two unique)
5. Bitwise AND of Numbers Range
6. Maximum XOR of Two Numbers
7. Total Hamming Distance
8. Concatenation of Consecutive Binary Numbers
9. XOR Queries of a Subarray
10. Find XOR Sum of All Pairs
11. Minimum XOR Sum of Two Arrays
12. Maximum Genetic Difference Query
13. Maximum Strong Pair XOR
14. Shortest Impossible Sequence
15. Count Triplets with XOR Equal to Key

**Data Structures**:
- Binary Indexed Trees (Fenwick Tree)
- Segment Trees with lazy propagation
- Suffix arrays (introduction)
- Trie variations (bitwise trie)

**System Design**:
- Choosing the right data structure
- Trade-offs in algorithm design
- Real-world problem solving
- Performance optimisation
- Memory vs time trade-offs

**Practice Goals**:
- **15 advanced bit manipulation problems** ⭐
- 10 advanced string algorithm problems
- 15 mixed Hard problems
- Mock interviews
- System design scenarios

**Recommended Platforms**:
- LeetCode Hard problems
- CodeSignal company challenges
- Mock interview platforms (Pramp, interviewing.io)

**NeetCode Alignment**:
- Bit Manipulation advanced (7 problems from Blind 75)
- Complete coverage of all patterns

---

## 🎯 Practice Distribution Per Session

- **40%** - Implement data structures and algorithms from scratch in C#
- **40%** - Solve problems on platforms (LeetCode/HackerRank/CodeSignal)
- **20%** - Review solutions, understand different approaches, optimise code

---

## 📊 Updated Problem Count Summary

| Session | Topics | Problem Count | Notable Additions |
|---------|--------|---------------|-------------------|
| Session 1 | C# + Arrays | 15-20 | Foundation |
| Session 2 | Patterns + Hash + **Bit Basics** | 30-35 | +10 Bit Manip |
| Session 3 | Recursion + Backtracking + **Binary Search** | 40-45 | +15 Binary Search |
| Session 4 | Linked Lists + **Intervals** | 50-55 | +15 Intervals ⭐ |
| Session 5 | Binary Trees + BST | 30 | - |
| Session 6 | Advanced Trees | 25 | - |
| Session 7 | Graph Basics | 25 | - |
| Session 8 | Graph Advanced | 30 | - |
| Session 9 | Greedy + D&C + **Math & Geo** | 55 | +15 Math & Geo ⭐ |
| Session 10 | DP Part 1 | 30 | - |
| Session 11 | DP Part 2 | 25 | - |
| Session 12 | Advanced + **Bit Advanced** | 45 | +15 Bit Manip Adv ⭐ |
| **TOTAL** | **All Topics** | **~390-405** | **+50 problems** |

---

## 📖 Recommended Resources

### Books
- **The Modern C# Challenge** by Rod Stephens - Problem-solving toolkit with C#-specific techniques
- **Data Structures and Algorithms in C#** - Comprehensive reference
- **Cracking the Coding Interview** - Interview preparation classic

### Online Resources
- [NeetCode.io Roadmap](https://neetcode.io/roadmap) - Curated problem sets with video explanations ⭐
- [NeetCode 150](https://neetcode.io/practice/practice/neetcode150) - Essential coding interview problems
- [NeetCode 250](https://neetcode.io/practice/practice/neetcode250) - Comprehensive beginner-friendly plan
- [C# Sharp programming Exercises - w3resource](https://www.w3resource.com/csharp-exercises/)
- [Data Structures and Algorithms Roadmap](https://roadmap.sh/datastructures-and-algorithms)
- [DSA Tutorial - GeeksforGeeks](https://www.geeksforgeeks.org/dsa/dsa-tutorial-learn-data-structures-and-algorithms/)
- [Complete Roadmap To Learn DSA](https://www.geeksforgeeks.org/dsa/complete-roadmap-to-learn-dsa-from-scratch/)
- [Mastering Algorithms and Data Structures in C# - CodeSignal](https://codesignal.com/learn/paths/mastering-algorithms-and-data-structures-in-csharp)

---

## 📝 Assessment Criteria for Session Completion

To consider a session complete and move to the next, you should:

1. ✅ Complete at least 80% of recommended practice problems
2. ✅ Implement required data structures from scratch with tests
3. ✅ Understand time/space complexity of all solutions
4. ✅ Solve at least 3-5 problems without looking at solutions
5. ✅ Review and understand multiple approaches to key problems
6. ✅ Can explain the pattern/algorithm to someone else

---

## 🚀 How to Use This Plan

1. **Start with Session 1** - Don't skip ahead, foundation is critical
2. **Request session content**: "Generate content for Session [number]"
3. **Track your progress** in `learning-progress.md`
4. **Cross-reference** with NeetCode problems for additional practice
5. **Take notes** on challenging concepts
6. **Review** previous sessions periodically (spaced repetition)
7. **Join communities**: LeetCode discussions, Reddit r/csharp, r/leetcode

---

## 💡 Tips for Success

- **Consistency over intensity**: Regular practice (1-2 hours daily) beats marathon sessions
- **Understand, don't memorise**: Focus on understanding patterns, not memorising solutions
- **Pattern recognition**: After 3-5 problems of same type, identify the underlying pattern
- **Write clean code**: Practice writing production-quality C# code with proper naming and structure
- **Time yourself**: Practice under time constraints (45 minutes per medium problem)
- **Explain your solutions**: Use the Feynman technique - teach to learn
- **Review others' solutions**: Learn different approaches and optimisations on LeetCode discussions
- **Mock interviews**: Practice with peers or platforms like Pramp once comfortable
- **Build a problem bank**: Keep notes on problems you found challenging
- **Use NeetCode videos**: Watch video explanations for problems you struggle with

---

## 🎯 Alignment with Industry Standards

This plan comprehensively covers:

✅ **NeetCode 150/250** - All topics covered with additional depth
✅ **Blind 75** - All problems mapped across sessions
✅ **FAANG Interview Patterns** - All common patterns included
✅ **LeetCode Top Interview Questions** - Covered throughout
✅ **System Design Basics** - Introduced in Session 12

---

## 🔄 Version History

- **v2.0** (2026-01-20): Added Intervals, Enhanced Bit Manipulation, Added Math & Geometry, Added more Binary Search, Cross-referenced with NeetCode roadmap
- **v1.0** (2026-01-15): Initial comprehensive learning plan

---

## 📚 Next Steps

Ready to begin? Here's your roadmap:

1. ✅ Read through this entire plan
2. ✅ Set up your practice environment (IDE, LeetCode account, NeetCode account)
3. ✅ Request: **"Generate content for Session 1"**
4. ✅ Create your `learning-progress.md` tracking document
5. ✅ Join online communities for support
6. ✅ Set a consistent daily practice schedule
7. ✅ Start with Session 1 and work progressively

---

**Ready to master C# algorithms? Request Session 1 content and start your journey to coding interview success! 🚀**

---

## Sources & References

- [NeetCode Roadmap](https://neetcode.io/roadmap)
- [NeetCode 150 - Coding Interview Questions](https://neetcode.io/practice/practice/neetcode150)
- [NeetCode 250 - Complete Beginner Study Plan](https://neetcode.io/practice/practice/neetcode250)
- [GitHub - NeetCode DSA Roadmap](https://github.com/bhanuprasadChesetti/neetcode-dsa-roadmap)
- [How to use the NeetCode roadmap](https://www.educative.io/blog/neetcode-roadmap)
- [Blind 75 LeetCode Problems](https://neetcode.io/practice/practice/blind75)
- [LeetCode Problem Patterns](https://blog.algomaster.io/p/15-leetcode-patterns)
