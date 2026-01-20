# CLAUDE.md - Session Content Generation Instructions

> **Purpose**: This file contains mandatory instructions for Claude Code when generating C# Algorithm Learning Session content.

---

## 📋 Core Principles

### 1. Research-First Approach

**MANDATORY**: Before generating ANY session content, you MUST:

1. **Read the Learning Plan** (`/workspace/.docs/csharp-algorithm-learning-plan.md`)
   - Understand the session structure and topics
   - Review session objectives and practice goals
   - Check prerequisites and recommended platforms

2. **Read the Progress Tracker** (`/workspace/.docs/learning-progress.md`)
   - Check which sessions are completed
   - Review problems already solved
   - Understand current skill level
   - Check for blockers or challenges

3. **Conduct Web Research** - Use WebSearch tool for each major topic:
   ```
   Required searches per session:
   - Main topic + "tutorial 2026 best practices"
   - Main topic + "algorithm pattern guide 2026"
   - "C# [specific feature] tutorial 2026"
   - "LeetCode [pattern] problems list 2026"
   - "[Data structure] implementation from scratch C# 2026"
   ```

4. **Validate Sources**:
   - Prefer official documentation (Microsoft Learn, LeetCode, GeeksforGeeks)
   - Use recent materials (2025-2026)
   - Cross-reference multiple sources
   - Verify code examples work with modern C# (C# 13-14)

---

## 🎯 Content Structure Requirements

### Session File Format

Each session MUST follow this exact structure:

```markdown
# Session [N]: [Title]

> **Goal**: [Clear, concise learning objective]

---

## 📚 Part 1: Modern C# Features (20-30% of content)

[C# language features relevant to this session]
- Always include practical algorithm examples
- Show modern C# 13-14 features when applicable
- Compare old vs new syntax
- Include "When to use" sections

---

## 📊 Part 2: [Main Topic] (50-60% of content)

### 2.1 [Subtopic 1]

[Concept explanation]

**Source**: [Citation with hyperlinks]

#### Pattern/Technique Description

```csharp
// Complete, runnable code examples
// Include time/space complexity comments
// Add explanatory comments
```

**Time Complexity**: O(?)
**Space Complexity**: O(?)

**When to use**:
- ✅ [Use case 1]
- ✅ [Use case 2]
- ❌ [When NOT to use]

[Repeat for each subtopic]

---

## 🔧 Part 3: [Implementation/Advanced Topic] (10-20% of content)

[Deep dive into implementation details]
- Internal workings
- Custom implementations from scratch
- Performance considerations
- Comparison of approaches

---

## 💻 Part 4: Practice Exercises (Required)

### Exercise 1: [Problem Name]

**Problem**: [Clear problem statement]

```csharp
public class [ClassName]
{
    public [ReturnType] [MethodName]([Parameters])
    {
        // TODO: Implement
        // Time: O(?), Space: O(?)
        throw new NotImplementedException();
    }
}

// Test cases
[Test examples with expected output]
```

**Hints**:
<details>
<summary>Hint 1</summary>
[First hint]
</details>

<details>
<summary>Hint 2</summary>
[Second hint]
</details>

<details>
<summary>Solution</summary>

```csharp
[Complete working solution with comments]
```

**Explanation**:
[Step-by-step explanation of the solution]

**Time Complexity**: O(?)
**Space Complexity**: O(?)

</details>

---

## 🎯 Part 5: Curated Practice Problems

### [Category] Problems (X problems)

**Easy (Y problems)**:
1. [LeetCode ### - Problem Name](URL) - [Pattern/Topic]
2. [Problem 2]
...

**Medium (Z problems)**:
[Continue listing]

**Source**: [Citation for problem list curation]

---

## 🏆 Part 6: Assessment & Next Steps

### Completion Criteria

You're ready for Session [N+1] when you can:

✅ **C# Knowledge**:
- [ ] [Specific skill 1]
- [ ] [Specific skill 2]

✅ **[Main Topic] Mastery**:
- [ ] [Specific skill 1]
- [ ] [Specific skill 2]

✅ **Problem-Solving**:
- [ ] Solve X+ problems independently
- [ ] [Other criteria]

---

### Self-Assessment Quiz

1. [Question 1 testing understanding]
2. [Question 2]
...

---

### Additional Resources

**[Topic] Resources**:
- [Resource 1 with URL]
- [Resource 2 with URL]

**Practice Platforms**:
- [Platform with specific section URL]

---

## 📅 Estimated Timeline

- **Week 1**: [Topics] - X-Y hours
- **Week 2**: [Topics] - X-Y hours
...

**Total**: ~X-Y hours of focused learning

---

## 🎓 Tips for Success

1. [Actionable tip 1]
2. [Actionable tip 2]
...

---

## Sources

This session content was researched using current materials from 2026:

**[Topic 1]**:
- [Source 1 with full title and URL]
- [Source 2 with full title and URL]

**[Topic 2]**:
- [Continue listing sources]

[ALL web search sources MUST be cited here with hyperlinks]
```

---

## ✅ Quality Standards

### Code Examples

**MUST include**:
- ✅ Complete, compilable code (no pseudocode)
- ✅ Time and space complexity analysis
- ✅ Explanatory comments
- ✅ Edge case handling
- ✅ Modern C# syntax (C# 13-14 where applicable)
- ✅ Null safety (`#nullable enable`)
- ✅ Proper error handling
- ✅ Test cases with expected output

**MUST NOT include**:
- ❌ Incomplete code snippets without context
- ❌ Pseudocode when real code is expected
- ❌ Outdated C# syntax (avoid pre-C# 10 patterns)
- ❌ Missing complexity analysis
- ❌ Untested or broken examples

### Exercises and Solutions

**Format for EVERY exercise**:

```markdown
### Exercise [N]: [Problem Name] ([Pattern/Technique])

**Problem**: [Clear, unambiguous problem statement with examples]

**Input**: [Input format]
**Output**: [Output format]
**Constraints**: [Any constraints]

**Examples**:
```
Input: [example input]
Output: [example output]
Explanation: [why]
```

```csharp
public class [ClassName]
{
    public [ReturnType] [MethodName]([Parameters])
    {
        // TODO: Implement [brief description]
        // Time: O(?), Space: O(?)
        throw new NotImplementedException();
    }
}

// Test cases
var solution = new [ClassName]();
[Test case 1 with expected output]
[Test case 2 with expected output]
[Edge case tests]
```

<details>
<summary>💡 Hint 1 - [General approach]</summary>

[First hint about approach/pattern to use]
</details>

<details>
<summary>💡 Hint 2 - [Key insight]</summary>

[Second hint about key insight or optimization]
</details>

<details>
<summary>💡 Hint 3 - [Implementation detail]</summary>

[Third hint about implementation detail]
</details>

<details>
<summary>✅ Solution</summary>

```csharp
public class [ClassName]
{
    public [ReturnType] [MethodName]([Parameters])
    {
        // [Step-by-step solution with detailed comments]
        // Comment explaining each section

        // Edge case handling
        if ([edge case])
            return [appropriate value];

        // Main logic with clear variable names
        [Implementation]

        return [result];
    }
}
```

**Explanation**:

1. **Approach**: [Explain the overall strategy]
2. **Algorithm**: [Step-by-step breakdown]
   - Step 1: [What and why]
   - Step 2: [What and why]
   - ...
3. **Edge Cases**: [How edge cases are handled]
4. **Optimization**: [Any optimizations applied]

**Complexity Analysis**:
- **Time Complexity**: O(?)
  - [Explain why - count loops, recursion depth, etc.]
- **Space Complexity**: O(?)
  - [Explain why - auxiliary space used]

**Example Walkthrough**:
```
Input: [example]
Step 1: [state after step 1]
Step 2: [state after step 2]
...
Output: [final result]
```

**Alternative Approaches**:
<details>
<summary>Approach 2 - [Alternative method]</summary>

[Different solution approach with trade-offs]
</details>

</details>
```

---

## 📊 Problem Curation Standards

### Problem Selection Criteria

For EACH pattern/topic, curate problems that:

1. **Cover Difficulty Range**:
   - 40-50% Easy (build confidence, learn pattern)
   - 40-50% Medium (apply pattern, handle variations)
   - 0-10% Hard (master pattern, complex scenarios)

2. **Progress Naturally**:
   - Start with pattern template problems
   - Move to single-variation problems
   - End with multi-variation or combination problems

3. **Are Recent and Relevant**:
   - Prefer problems from 2020+
   - Include classic problems (Two Sum, etc.)
   - Match current interview trends

4. **Have Quality Resources**:
   - Available on multiple platforms
   - Have discussion/editorial sections
   - Community-validated solutions exist

### Minimum Problem Counts per Session

- **Pattern Introduction**: 15-20 problems minimum
- **Data Structure Topic**: 25-30 problems minimum
- **Advanced Topic**: 20-25 problems minimum
- **Combined Topics**: 30-40 problems minimum

### Problem List Format

```markdown
### [Pattern/Topic] Problems (X total)

**Easy (Y problems)**:
1. [LeetCode 123 - Problem Name](https://leetcode.com/problems/slug/) - [Brief description/pattern]
2. [HackerRank - Problem Name](URL) - [Brief description]
...

**Medium (Z problems)**:
[Continue with same format]

**Hard (W problems)** (Optional):
[Advanced problems]

**Source**: [List research sources for problem curation]
```

---

## 🔍 Research Requirements

### Before Writing Content

1. **Web Search for Each Major Topic** (5-8 searches minimum):
   - Main algorithm/pattern tutorial
   - C# specific implementation guide
   - LeetCode problem lists
   - Best practices and pitfalls
   - Real-world applications

2. **Source Quality Criteria**:
   - ✅ Official documentation (Microsoft, LeetCode, HackerRank)
   - ✅ Established tutorial sites (GeeksforGeeks, AlgoCademy, USACO)
   - ✅ Reputable blogs (from known engineers/educators)
   - ✅ Recent content (2024-2026)
   - ❌ Avoid AI-generated sites without verification
   - ❌ Avoid outdated tutorials (pre-2020 unless classic)

3. **Verification Steps**:
   - Cross-reference explanations from 3+ sources
   - Verify code examples compile and run
   - Check complexity analysis matches consensus
   - Validate problem difficulty ratings

### Citation Requirements

**Every section MUST have sources**:
- In-line citations: `**Source**: [Title](URL), [Title](URL)`
- Final section: Complete source list with categories
- ALL web searches MUST be cited

**Citation Format**:
```markdown
**Source**: [GeeksforGeeks - Two Pointers Technique](https://www.geeksforgeeks.org/dsa/two-pointers-technique/), [USACO Guide - Two Pointers](https://usaco.guide/silver/two-pointers)
```

---

## 📝 Content Writing Standards

### Explanations

**MUST include**:
- Clear concept introduction
- Real-world analogies where helpful
- Visual descriptions (since no images)
- Step-by-step breakdowns
- Common pitfalls and how to avoid
- When to use / when NOT to use

**Example of good explanation**:
```markdown
### Two Pointers Technique

The Two Pointers technique uses two indices to traverse a data structure
efficiently, often reducing time complexity from O(n²) to O(n).

**How it works**:
Imagine you're searching for a pair of numbers that sum to a target in a
sorted array. Instead of checking every possible pair (n² comparisons),
you start with pointers at both ends. If the sum is too small, move the
left pointer right. If too large, move the right pointer left. You're
guaranteed to find the pair or determine it doesn't exist in just n steps.

**Visual walkthrough**:
```
Array: [1, 3, 5, 7, 9, 11], target = 12
Step 1: L=1, R=11, sum=12 ✓ Found!

Array: [1, 3, 5, 7, 9, 11], target = 10
Step 1: L=1, R=11, sum=12 (too large, R--)
Step 2: L=1, R=9,  sum=10 ✓ Found!
```
```

### Code Comments

**Every code example needs**:
- File/class-level comment explaining purpose
- Complexity analysis in comments
- Section comments for logical blocks
- Inline comments for non-obvious logic
- Parameter/return value documentation

**Example**:
```csharp
/// <summary>
/// Two Sum II - Sorted array variation using two pointers
/// Time: O(n), Space: O(1)
/// </summary>
public int[] TwoSum(int[] numbers, int target)
{
    // Use two pointers starting from opposite ends
    int left = 0, right = numbers.Length - 1;

    while (left < right)
    {
        int sum = numbers[left] + numbers[right];

        if (sum == target)
            return new int[] { left, right };
        else if (sum < target)
            left++;  // Need larger sum, move left pointer right
        else
            right--; // Need smaller sum, move right pointer left
    }

    return new int[] { -1, -1 }; // Not found
}
```

---

## 🔄 Progress Tracking Updates

### After Creating Each Session

**MUST update** `/workspace/.docs/learning-progress.md`:

1. **Update Session 2 Details**:
```markdown
#### Session [N]: [Title]
- **Status**: 🟡 Ready to Start
- **Started**: [Date content generated]
- **Completed**: -
- **Problems Solved**: 0 / [Total count]
- **Implementations**:
  - [ ] [Implementation 1 with problem count]
  - [ ] [Implementation 2]
- **Notes**: Session [N] content generated with comprehensive coverage of [topics]. [X] curated problems ready.
```

2. **Update Overall Progress**:
```markdown
**Current Session**: Session [N]
**Sessions Completed**: [N-1] / 12
**Overall Progress**: [X]% (Session [N] ready to start)
```

3. **Update Session Request History**:
```markdown
| 2026-01-[XX] | Session [N] | 🟡 Ready to Start |
```

4. **Update Next Week Focus**:
```markdown
### Next Week (Session [N])
- [ ] [Goal 1]
- [ ] [Goal 2 with problem counts]
...
```

---

## 🚫 Anti-Patterns to Avoid

### Content Quality

**NEVER**:
- ❌ Generate content without web research
- ❌ Copy-paste from a single source
- ❌ Include incomplete code examples
- ❌ Omit complexity analysis
- ❌ Forget to cite sources
- ❌ Use outdated C# syntax
- ❌ Skip test cases
- ❌ Provide solutions without explanations
- ❌ Include broken or untested code
- ❌ Use vague problem statements
- ❌ Forget collapsible solution sections
- ❌ Omit hints for exercises

### Lazy Content Indicators

If you catch yourself doing ANY of these, STOP and redo:
- ❌ "// Implementation here" without actual code
- ❌ "Similar to previous example" without showing code
- ❌ Copying exact text from one source without synthesis
- ❌ Missing "When to use" sections
- ❌ No alternative approaches mentioned
- ❌ Generic "Solve problems to practice" without specific list
- ❌ Citing sources you didn't actually search
- ❌ Explaining concepts you haven't researched

---

## ✨ Excellence Standards

### What Makes Great Session Content

1. **Comprehensive Research**:
   - 8-10 web searches per session
   - Multiple sources for each topic
   - Cross-verified information
   - Latest best practices (2026)

2. **Practical Focus**:
   - Every concept has runnable code
   - Multiple examples per pattern
   - Real LeetCode problems
   - Implementation challenges

3. **Clear Progression**:
   - Easy → Medium → Hard
   - Simple → Complex variations
   - Concepts build on each other
   - Clear prerequisites stated

4. **Complete Solutions**:
   - Multiple hints (progressive disclosure)
   - Fully commented code
   - Complexity analysis
   - Alternative approaches
   - Example walkthroughs

5. **Rich Context**:
   - When to use / not use
   - Common pitfalls
   - Performance considerations
   - Real-world applications
   - Interview tips

---

## 📋 Pre-Flight Checklist

Before considering a session complete, verify:

- [ ] Read learning plan for session requirements
- [ ] Read progress tracker for context
- [ ] Conducted 8+ web searches with current results (2026)
- [ ] Cited all sources with hyperlinks
- [ ] Included modern C# features (C# 13-14)
- [ ] All code examples are complete and compilable
- [ ] Every code block has complexity analysis
- [ ] All exercises have collapsible hint sections
- [ ] All exercises have collapsible solution sections
- [ ] Solutions include step-by-step explanations
- [ ] Solutions include complexity analysis
- [ ] Curated 40+ problems with URLs
- [ ] Problems categorized by difficulty
- [ ] Assessment criteria clearly defined
- [ ] Self-assessment quiz included
- [ ] Additional resources listed with URLs
- [ ] Timeline estimation provided
- [ ] Tips for success included
- [ ] Sources section complete with all citations
- [ ] Updated learning-progress.md file
- [ ] Followed exact markdown structure
- [ ] No lazy content patterns present
- [ ] No hallucinated information

---

## 🎯 Success Metrics

A session is considered HIGH QUALITY when:

1. **Research Depth**: 10+ unique, recent sources cited
2. **Code Quality**: 15+ complete, tested code examples
3. **Problem Coverage**: 50+ curated problems across difficulties
4. **Exercise Quality**: 5+ exercises with full hint/solution structure
5. **Explanation Clarity**: Non-expert can understand concepts
6. **Practical Value**: Can directly start solving problems after reading
7. **Modern Standards**: Uses C# 13-14 features appropriately
8. **Completeness**: No "TODO" or placeholder sections remain

---

## 🔧 Template Variables

When creating content, use these variables:

- `[N]` = Session number
- `[Title]` = Session title from learning plan
- `[Main Topic]` = Primary algorithm/data structure topic
- `[X]` = Number of problems/hours/percentage
- `[Date]` = Current date (YYYY-MM-DD)

---

## 📚 Recommended Research Sources

### Primary Sources (ALWAYS check these)

1. **Official Documentation**:
   - [Microsoft Learn - C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
   - [Microsoft Learn - Collections](https://learn.microsoft.com/en-us/dotnet/standard/collections/)

2. **Algorithm Learning**:
   - [LeetCode](https://leetcode.com/) - Problem lists and discussions
   - [GeeksforGeeks DSA](https://www.geeksforgeeks.org/dsa/dsa-tutorial-learn-data-structures-and-algorithms/)
   - [USACO Guide](https://usaco.guide/) - Competitive programming

3. **C# Specific**:
   - [C# Corner](https://www.c-sharpcorner.com/)
   - [Dot Net Perls](https://www.dotnetperls.com/)
   - [Code Maze](https://code-maze.com/)

### Pattern-Specific Sources

Search for: "[Pattern name] algorithm tutorial 2026 comprehensive guide"
- Example: "sliding window algorithm tutorial 2026 comprehensive guide"

### Problem Curation

Search for: "LeetCode [pattern] problems list 2026"
- Example: "LeetCode two pointers problems list 2026"

---

## 🎓 Session Generation Workflow

1. **Preparation** (5-10 minutes):
   - Read learning plan for session N
   - Read progress tracker
   - Identify topics, prerequisites, goals

2. **Research** (15-20 minutes):
   - Web search for each major topic
   - Collect sources, verify quality
   - Note down key concepts and examples

3. **Outline** (5 minutes):
   - Structure content following template
   - Identify code examples needed
   - Plan problem sets

4. **Write** (30-45 minutes):
   - Follow markdown structure exactly
   - Write explanations in own words (synthesize sources)
   - Create complete code examples
   - Build exercises with hints/solutions

5. **Curate Problems** (10-15 minutes):
   - Search for problem lists
   - Verify URLs work
   - Categorize by difficulty
   - Ensure variety and progression

6. **Review** (10 minutes):
   - Check against pre-flight checklist
   - Verify all code compiles
   - Ensure all sources cited
   - Check for lazy patterns

7. **Update Progress** (5 minutes):
   - Update learning-progress.md
   - Update session status
   - Update statistics

**Total Time**: ~90-120 minutes per session for quality content

---

## 💡 Tips for Claude Code

- Use TodoWrite to track session creation steps
- Run multiple WebSearch calls in parallel for efficiency
- Ask user questions if session requirements are unclear
- Proactively check for previous session completion
- Always read both plan and progress files before starting
- Synthesize information from multiple sources, don't copy verbatim
- When unsure about complexity, research and verify
- Test code logic mentally before including
- Use modern C# idioms (pattern matching, ranges, etc.)

---

**Remember**: Quality over speed. Better to take time and produce exceptional content than rush and create mediocre material. The user's learning success depends on the quality of these sessions.
