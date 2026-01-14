namespace Playground.Tests.Session01.Challenges;

public class C169MajorityElementTests
{
    private readonly C169MajorityElement _solution;

    public C169MajorityElementTests()
    {
        _solution = new C169MajorityElement();
    }

    #region Basic Functionality Tests

    [Fact]
    public void MajorityElement_Example1_ReturnsThree()
    {
        // Arrange
        int[] nums = [3, 2, 3];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MajorityElement_Example2_ReturnsTwo()
    {
        // Arrange
        int[] nums = [2, 2, 1, 1, 1, 2, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void MajorityElement_AllSameElements_ReturnsThatElement()
    {
        // Arrange
        int[] nums = [7, 7, 7, 7, 7];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void MajorityElement_SingleElement_ReturnsThatElement()
    {
        // Arrange
        int[] nums = [5];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void MajorityElement_TwoElements_ReturnsMajority()
    {
        // Arrange
        int[] nums = [1, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MajorityElement_ThreeElementsWithMajority_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 2, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result); // 1 appears 2 times out of 3
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void MajorityElement_MajorityAtBeginning_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [5, 5, 5, 1, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void MajorityElement_MajorityAtEnd_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 2, 5, 5, 5];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void MajorityElement_MajorityScattered_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 3, 1, 2, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MajorityElement_AlternatingPattern_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [1, 2, 1, 2, 1, 2, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result); // 1 appears 4 times, 2 appears 3 times
    }

    #endregion

    #region Negative Numbers

    [Fact]
    public void MajorityElement_NegativeNumbers_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [-1, -1, -1, 2, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void MajorityElement_AllNegative_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [-5, -5, -5, -5, -3];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(-5, result);
    }

    [Fact]
    public void MajorityElement_MixedPositiveNegative_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [3, -1, 3, -1, 3];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(3, result);
    }

    #endregion

    #region Zero Values

    [Fact]
    public void MajorityElement_ZeroIsMajority_ReturnsZero()
    {
        // Arrange
        int[] nums = [0, 0, 0, 1, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MajorityElement_AllZeros_ReturnsZero()
    {
        // Arrange
        int[] nums = [0, 0, 0, 0, 0];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region Large Arrays

    [Fact]
    public void MajorityElement_LargeArrayAllSame_ReturnsCorrect()
    {
        // Arrange
        int[] nums = new int[10000];
        Array.Fill(nums, 42);

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void MajorityElement_LargeArrayWithMajority_ReturnsCorrect()
    {
        // Arrange - Create array with 50001 elements where 1 appears 25001 times
        int[] nums = new int[50001];
        for (int i = 0; i < 25001; i++)
        {
            nums[i] = 1;
        }
        for (int i = 25001; i < 50001; i++)
        {
            nums[i] = i % 10; // Fill with various numbers
        }

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MajorityElement_LargeArray_CompletesInReasonableTime()
    {
        // Arrange
        int[] nums = new int[50000];
        for (int i = 0; i < 25001; i++)
        {
            nums[i] = 7;
        }
        for (int i = 25001; i < 50000; i++)
        {
            nums[i] = i % 100;
        }

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int result = _solution.MajorityElement(nums);
        stopwatch.Stop();

        // Assert
        Assert.Equal(7, result);
        Assert.True(stopwatch.ElapsedMilliseconds < 100,
            $"Processing took {stopwatch.ElapsedMilliseconds}ms, expected < 100ms");
    }

    #endregion

    #region Boundary Values

    [Fact]
    public void MajorityElement_MaxIntValue_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [int.MaxValue, int.MaxValue, int.MaxValue, 1, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void MajorityElement_MinIntValue_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [int.MinValue, int.MinValue, int.MinValue, 1, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(int.MinValue, result);
    }

    [Fact]
    public void MajorityElement_ExtremeValues_ReturnsCorrect()
    {
        // Arrange
        int[] nums = [int.MaxValue, int.MinValue, int.MaxValue, int.MinValue, int.MaxValue];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(int.MaxValue, result);
    }

    #endregion

    #region Minimum Majority Count

    [Fact]
    public void MajorityElement_ExactlyHalfPlusOne_ReturnsCorrect()
    {
        // Arrange - Array of 5 elements, majority appears 3 times (exactly n/2 + 1)
        int[] nums = [1, 1, 1, 2, 3];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MajorityElement_MinimumMajorityInEvenLength_ReturnsCorrect()
    {
        // Arrange - Array of 6 elements, majority appears 4 times (more than 3)
        int[] nums = [5, 5, 5, 5, 1, 2];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(5, result);
    }

    #endregion

    #region Property-Based Tests

    [Theory]
    [InlineData(new[] { 1, 1, 2 }, 1)]
    [InlineData(new[] { 3, 3, 4 }, 3)]
    [InlineData(new[] { 6, 5, 5 }, 5)]
    [InlineData(new[] { 10, 10, 10, 20, 20 }, 10)]
    public void MajorityElement_VariousInputs_ReturnsExpected(int[] nums, int expected)
    {
        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 1, 1 }, 1)]
    [InlineData(new[] { 2, 2, 2, 2, 2, 2 }, 2)]
    [InlineData(new[] { 7, 7, 7 }, 7)]
    public void MajorityElement_AllSameElement_ReturnsThatElement(int[] nums, int expected)
    {
        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region Algorithm Verification

    [Fact]
    public void MajorityElement_BoyerMoorePattern_WorksCorrectly()
    {
        // Arrange - Test case that exercises the cancellation logic
        int[] nums = [1, 2, 3, 1, 1, 1, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result); // 1 appears 5 times out of 7
    }

    [Fact]
    public void MajorityElement_MultipleCountResets_ReturnsCorrect()
    {
        // Arrange - Array that causes count to reset to 0 multiple times
        int[] nums = [1, 2, 1, 2, 1, 2, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result); // 1 appears 4 times, 2 appears 3 times
    }

    [Fact]
    public void MajorityElement_MajorityNeverLeadsUntilEnd_ReturnsCorrect()
    {
        // Arrange - Majority element only becomes clear near the end
        int[] nums = [2, 3, 4, 1, 1, 1, 1, 1];

        // Act
        int result = _solution.MajorityElement(nums);

        // Assert
        Assert.Equal(1, result); // 1 appears 5 times out of 8
    }

    #endregion

    #region Real-World Scenarios

    [Fact]
    public void MajorityElement_VotingScenario_ReturnsWinner()
    {
        // Arrange - Simulates a voting scenario where candidate 5 wins
        int[] votes = [5, 3, 5, 7, 5, 3, 5, 5];

        // Act
        int winner = _solution.MajorityElement(votes);

        // Assert
        Assert.Equal(5, winner); // Candidate 5 has 5 votes out of 8
    }

    [Fact]
    public void MajorityElement_DataStreamScenario_ReturnsFrequentValue()
    {
        // Arrange - Simulates finding most frequent value in a data stream
        int[] dataStream = [100, 200, 100, 300, 100, 400, 100];

        // Act
        int mostFrequent = _solution.MajorityElement(dataStream);

        // Assert
        Assert.Equal(100, mostFrequent);
    }

    #endregion

    #region Alternative Solutions Tests

    [Theory]
    [InlineData(new[] { 3, 2, 3 }, 3)]
    [InlineData(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 1, 2 }, 1)]
    [InlineData(new[] { -1, -1, -1, 2, 2 }, -1)]
    public void MajorityElement_HashMap_AllTestCases_ReturnsCorrect(int[] nums, int expected)
    {
        // Act
        int result = _solution.MajorityElement_HashMap(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 3, 2, 3 }, 3)]
    [InlineData(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 1, 2 }, 1)]
    [InlineData(new[] { -1, -1, -1, 2, 2 }, -1)]
    public void MajorityElement_Sorting_AllTestCases_ReturnsCorrect(int[] nums, int expected)
    {
        // Arrange - Create copy since sorting modifies the array
        int[] numsCopy = (int[])nums.Clone();
        bool wasAlreadySorted = nums.SequenceEqual(nums.OrderBy(x => x));

        // Act
        int result = _solution.MajorityElement_Sorting(numsCopy);

        // Assert
        Assert.Equal(expected, result);

        // Only verify array was sorted if it wasn't already sorted
        if (!wasAlreadySorted)
        {
            Assert.NotEqual(nums, numsCopy); // Array was sorted (changed)
        }
    }

    [Theory]
    [InlineData(new[] { 3, 2, 3 }, 3)]
    [InlineData(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 1, 2 }, 1)]
    [InlineData(new[] { -1, -1, -1, 2, 2 }, -1)]
    public void MajorityElement_DivideConquer_AllTestCases_ReturnsCorrect(int[] nums, int expected)
    {
        // Act
        int result = _solution.MajorityElement_DivideConquer(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MajorityElement_AllSolutionsAgree_OnVariousInputs()
    {
        // Arrange
        int[][] testCases = [
            [3, 2, 3],
            [2, 2, 1, 1, 1, 2, 2],
            [1],
            [1, 1, 2],
            [7, 7, 7, 7, 7],
            [1, 2, 1, 2, 1],
            [-1, -1, -1, 2, 2],
            [0, 0, 0, 1, 2],
            [int.MaxValue, int.MaxValue, int.MaxValue, 1, 2]
        ];

        foreach (var nums in testCases)
        {
            // Make copies for sorting (which modifies the array)
            int[] numsCopy = (int[])nums.Clone();

            // Act
            int resultBoyerMoore = _solution.MajorityElement(nums);
            int resultHashMap = _solution.MajorityElement_HashMap(nums);
            int resultSorting = _solution.MajorityElement_Sorting(numsCopy);
            int resultDivideConquer = _solution.MajorityElement_DivideConquer(nums);

            // Assert - All solutions should agree
            Assert.Equal(resultBoyerMoore, resultHashMap);
            Assert.Equal(resultBoyerMoore, resultSorting);
            Assert.Equal(resultBoyerMoore, resultDivideConquer);
        }
    }

    [Fact]
    public void MajorityElement_Sorting_MiddleElementIsAlwaysMajority()
    {
        // Arrange - Test the core principle: after sorting, middle element is majority
        int[][] testCases = [
            [1, 1, 1, 2, 2],          // Majority at beginning after sort
            [2, 2, 1, 1, 1],          // Majority at end after sort
            [1, 2, 1, 2, 1],          // Majority scattered
            [5, 5, 5, 5, 5, 5, 1, 2, 3] // Overwhelming majority
        ];

        foreach (var nums in testCases)
        {
            // Act
            int[] sorted = (int[])nums.Clone();
            Array.Sort(sorted);
            int middle = sorted[sorted.Length / 2];

            // Assert - Verify middle element has >n/2 occurrences
            int count = nums.Count(x => x == middle);
            Assert.True(count > nums.Length / 2,
                $"Middle element {middle} appears {count} times, need >{nums.Length / 2}");
        }
    }

    [Fact]
    public void MajorityElement_DivideConquer_RecursionWorks()
    {
        // Arrange - Test case that exercises recursive splitting
        int[] nums = [1, 1, 2, 2, 2, 1, 1, 1];
        // Left half [1,1,2,2]: no clear majority in left subarray
        // Right half [2,1,1,1]: 1 is majority in right subarray
        // Overall: 1 appears 5 times (majority)

        // Act
        int result = _solution.MajorityElement_DivideConquer(nums);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MajorityElement_HashMap_EarlyTermination()
    {
        // Arrange - Majority element appears early, should return quickly
        int[] nums = new int[10001];
        for (int i = 0; i < 5001; i++)
        {
            nums[i] = 1; // Majority element
        }
        for (int i = 5001; i < 10001; i++)
        {
            nums[i] = i; // All different values
        }

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int result = _solution.MajorityElement_HashMap(nums);
        stopwatch.Stop();

        // Assert
        Assert.Equal(1, result);
        // HashMap should terminate as soon as it finds element with >n/2 count
        Assert.True(stopwatch.ElapsedMilliseconds < 50,
            $"HashMap took {stopwatch.ElapsedMilliseconds}ms, should terminate early");
    }

    [Fact]
    public void MajorityElement_Performance_CompareAllSolutions()
    {
        // Arrange - Large array to compare performance
        int[] nums = new int[10000];
        for (int i = 0; i < 5001; i++)
        {
            nums[i] = 42;
        }
        for (int i = 5001; i < 10000; i++)
        {
            nums[i] = i % 100;
        }

        long boyerMooreTime, hashMapTime, sortingTime, divideConquerTime;

        // Act & Measure Boyer-Moore
        var sw = System.Diagnostics.Stopwatch.StartNew();
        int r1 = _solution.MajorityElement(nums);
        boyerMooreTime = sw.ElapsedMilliseconds;

        // Act & Measure HashMap
        sw.Restart();
        int r2 = _solution.MajorityElement_HashMap(nums);
        hashMapTime = sw.ElapsedMilliseconds;

        // Act & Measure Sorting
        sw.Restart();
        int r3 = _solution.MajorityElement_Sorting((int[])nums.Clone());
        sortingTime = sw.ElapsedMilliseconds;

        // Act & Measure Divide & Conquer
        sw.Restart();
        int r4 = _solution.MajorityElement_DivideConquer(nums);
        divideConquerTime = sw.ElapsedMilliseconds;

        // Assert - All should return same result
        Assert.Equal(r1, r2);
        Assert.Equal(r1, r3);
        Assert.Equal(r1, r4);

        // Log performance (for informational purposes)
        // Boyer-Moore should typically be fastest or tied with HashMap
        Assert.True(boyerMooreTime <= hashMapTime * 2,
            $"Boyer-Moore ({boyerMooreTime}ms) should be competitive with HashMap ({hashMapTime}ms)");
    }

    [Fact]
    public void MajorityElement_Sorting_DoesNotModifyOriginalWhenCopied()
    {
        // Arrange
        int[] original = [3, 2, 3, 1];
        int[] copy = (int[])original.Clone();

        // Act
        _solution.MajorityElement_Sorting(copy);

        // Assert - Original should be unchanged
        Assert.Equal([3, 2, 3, 1], original);
        // Copy should be sorted
        Assert.NotEqual(original, copy);
    }

    [Fact]
    public void MajorityElement_DivideConquer_HandlesOddAndEvenLengths()
    {
        // Arrange & Act & Assert - Odd length
        int[] oddLength = [1, 1, 1, 2, 3];
        Assert.Equal(1, _solution.MajorityElement_DivideConquer(oddLength));

        // Arrange & Act & Assert - Even length
        int[] evenLength = [1, 1, 1, 1, 2, 3];
        Assert.Equal(1, _solution.MajorityElement_DivideConquer(evenLength));
    }

    [Fact]
    public void MajorityElement_HashMap_HandlesMultipleUniqueElements()
    {
        // Arrange - Array with many unique elements but clear majority
        // Length 11, need >5.5 = 6 occurrences for majority
        int[] nums = [1, 2, 3, 4, 5, 5, 5, 5, 5, 5, 6];

        // Act
        int result = _solution.MajorityElement_HashMap(nums);

        // Assert
        Assert.Equal(5, result); // 5 appears 6 times out of 11
    }

    #endregion
}
