namespace Playground.Tests.Session2;

using Playground.Session2;

public class FixedSlidingWindowTests
{
    // Helper method to execute the MaxSumSubarray algorithm
    private static int MaxSumSubarray(int[] arr, int k)
    {
        var fixedSlidingWindow = new FixedSlidingWindow();
        return fixedSlidingWindow.MaxSumSubarray(arr, k);
    }

    #region Basic Functionality Tests

    [Fact]
    public void MaxSumSubarray_BasicExample_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 2, 1, 5, 1, 3, 2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(9, result); // [5, 1, 3] = 9
    }

    [Fact]
    public void MaxSumSubarray_WindowAtStart_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 10, 5, 2, 1, 3, 2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(17, result); // [10, 5, 2] = 17
    }

    [Fact]
    public void MaxSumSubarray_WindowAtEnd_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 1, 2, 3, 4, 5, 6 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(15, result); // [4, 5, 6] = 15
    }

    [Fact]
    public void MaxSumSubarray_WindowInMiddle_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 1, 2, 10, 8, 5, 3, 2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(23, result); // [10, 8, 5] = 23
    }

    [Fact]
    public void MaxSumSubarray_AllWindows_FindsMaximum()
    {
        // Arrange
        var arr = new[] { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
        var k = 4;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(39, result); // [4, 2, 10, 23] = 39
    }

    #endregion

    #region Edge Cases - Array Size

    [Fact]
    public void MaxSumSubarray_WindowSizeEqualsArraySize_ReturnsArraySum()
    {
        // Arrange
        var arr = new[] { 5, 10, 15, 20 };
        var k = 4;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(50, result); // [5, 10, 15, 20] = 50
    }

    [Fact]
    public void MaxSumSubarray_WindowSizeOne_ReturnsMaxElement()
    {
        // Arrange
        var arr = new[] { 3, 1, 8, 2, 5 };
        var k = 1;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(8, result); // Maximum single element
    }

    [Fact]
    public void MaxSumSubarray_WindowSizeTwo_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 1, 3, 2, 6, 4 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(10, result); // [6, 4] = 10
    }

    [Fact]
    public void MaxSumSubarray_TwoElementArray_WindowSizeTwo_ReturnsSum()
    {
        // Arrange
        var arr = new[] { 7, 3 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(10, result); // [7, 3] = 10
    }

    [Fact]
    public void MaxSumSubarray_SingleElementArray_WindowSizeOne_ReturnsElement()
    {
        // Arrange
        var arr = new[] { 42 };
        var k = 1;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(42, result);
    }

    #endregion

    #region Exception Tests

    [Fact]
    public void MaxSumSubarray_WindowSizeLargerThanArray_ThrowsArgumentException()
    {
        // Arrange
        var arr = new[] { 1, 2, 3 };
        var k = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => MaxSumSubarray(arr, k));
    }

    [Fact]
    public void MaxSumSubarray_WindowSizeZero_ThrowsArgumentException()
    {
        // Arrange
        var arr = new[] { 1, 2, 3 };
        var k = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => MaxSumSubarray(arr, k));
    }

    [Fact]
    public void MaxSumSubarray_EmptyArray_ThrowsArgumentException()
    {
        // Arrange
        var arr = Array.Empty<int>();
        var k = 1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => MaxSumSubarray(arr, k));
    }

    #endregion

    #region Negative Numbers

    [Fact]
    public void MaxSumSubarray_AllNegativeNumbers_ReturnsLeastNegativeSum()
    {
        // Arrange
        var arr = new[] { -5, -10, -3, -8, -2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(-13, result); // [-3, -8, -2] = -13 (least negative)
    }

    [Fact]
    public void MaxSumSubarray_MixedPositiveNegative_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { -2, 10, -3, 8, -5, 6 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(15, result); // [10, -3, 8] = 15
    }

    [Fact]
    public void MaxSumSubarray_NegativeThenPositive_FindsMaximum()
    {
        // Arrange
        var arr = new[] { -10, -5, 1, 2, 3, 4 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(9, result); // [2, 3, 4] = 9
    }

    [Fact]
    public void MaxSumSubarray_AlternatingSignsWithNegative_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 5, -3, 8, -2, 10, -4 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(8, result); // [-2, 10] = 8
    }

    #endregion

    #region Zero Handling

    [Fact]
    public void MaxSumSubarray_WithZeros_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 0, 5, 0, 3, 2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(8, result); // [5, 0, 3] = 8
    }

    [Fact]
    public void MaxSumSubarray_AllZeros_ReturnsZero()
    {
        // Arrange
        var arr = new[] { 0, 0, 0, 0 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxSumSubarray_ZerosAndNegatives_ReturnsZero()
    {
        // Arrange
        var arr = new[] { -5, 0, 0, -3, -2 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(0, result); // [0, 0] = 0
    }

    #endregion

    #region Duplicate Values

    [Fact]
    public void MaxSumSubarray_AllSamePositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        var arr = new[] { 5, 5, 5, 5, 5 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(15, result); // [5, 5, 5] = 15
    }

    [Fact]
    public void MaxSumSubarray_DuplicatePatterns_FindsMaximum()
    {
        // Arrange
        var arr = new[] { 3, 3, 9, 9, 3, 3 };
        var k = 2;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(18, result); // [9, 9] = 18
    }

    #endregion

    #region Large Arrays

    [Fact]
    public void MaxSumSubarray_LargeArray_FindsCorrectSum()
    {
        // Arrange
        var arr = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            arr[i] = i % 10; // Pattern: 0,1,2,3,4,5,6,7,8,9,0,1,2...
        }
        var k = 5;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(35, result); // [5,6,7,8,9] or [6,7,8,9,0] = 35
    }

    [Fact]
    public void MaxSumSubarray_LargeWindowLargeArray_HandlesCorrectly()
    {
        // Arrange
        var arr = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            arr[i] = i % 100;
        }
        var k = 50;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        // Window [50-99] gives maximum sum
        int expectedSum = 0;
        for (int i = 50; i < 100; i++)
        {
            expectedSum += i;
        }
        Assert.Equal(expectedSum, result);
    }

    #endregion

    #region Special Values

    [Fact]
    public void MaxSumSubarray_LargePositiveNumbers_HandlesCorrectly()
    {
        // Arrange
        var arr = new[] { 1000, 2000, 3000, 4000, 5000 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(12000, result); // [3000, 4000, 5000] = 12000
    }

    [Fact]
    public void MaxSumSubarray_IntMaxBoundary_HandlesWithoutOverflow()
    {
        // Arrange
        var arr = new[] { int.MaxValue / 4, int.MaxValue / 4, int.MaxValue / 4, 1 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        // First window should be maximum without overflow
        Assert.True(result > 0);
    }

    #endregion

    #region Sliding Window Verification

    [Fact]
    public void MaxSumSubarray_MultipleWindows_VerifiesCorrectSliding()
    {
        // Arrange
        var arr = new[] { 1, 2, 3, 4, 5 };
        var k = 3;
        // Windows: [1,2,3]=6, [2,3,4]=9, [3,4,5]=12

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void MaxSumSubarray_DecreasingValues_FindsFirstWindow()
    {
        // Arrange
        var arr = new[] { 10, 8, 6, 4, 2 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(24, result); // [10, 8, 6] = 24
    }

    [Fact]
    public void MaxSumSubarray_IncreasingValues_FindsLastWindow()
    {
        // Arrange
        var arr = new[] { 1, 3, 5, 7, 9 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(21, result); // [5, 7, 9] = 21
    }

    #endregion

    #region Performance Characteristics

    [Fact]
    public void MaxSumSubarray_TimeComplexityVerification_CompletesQuickly()
    {
        // Arrange
        var arr = new int[100000];
        for (int i = 0; i < 100000; i++)
        {
            arr[i] = i % 1000;
        }
        var k = 1000;

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = MaxSumSubarray(arr, k);
        stopwatch.Stop();

        // Assert
        // O(n) algorithm should complete in reasonable time (< 100ms for 100k elements)
        Assert.True(stopwatch.ElapsedMilliseconds < 100,
            $"Algorithm took {stopwatch.ElapsedMilliseconds}ms, expected O(n) performance");
        Assert.True(result > 0);
    }

    #endregion

    #region Boundary Window Positions

    [Fact]
    public void MaxSumSubarray_MaxAtStartBoundary_ReturnsFirstWindow()
    {
        // Arrange
        var arr = new[] { 100, 50, 25, 1, 1, 1 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(175, result); // [100, 50, 25] = 175
    }

    [Fact]
    public void MaxSumSubarray_MaxAtEndBoundary_ReturnsLastWindow()
    {
        // Arrange
        var arr = new[] { 1, 1, 1, 25, 50, 100 };
        var k = 3;

        // Act
        var result = MaxSumSubarray(arr, k);

        // Assert
        Assert.Equal(175, result); // [25, 50, 100] = 175
    }

    #endregion

    #region FindAverages Tests

    // Helper method to execute the FindAverages algorithm
    private static double[] FindAverages(int[] arr, int k)
    {
        var fixedSlidingWindow = new FixedSlidingWindow();
        return fixedSlidingWindow.FindAverages(arr, k);
    }

    // Helper to compare double arrays with tolerance
    private static void AssertArrayEquals(double[] expected, double[] actual, double tolerance = 0.001)
    {
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.True(Math.Abs(expected[i] - actual[i]) < tolerance,
                $"Expected {expected[i]} at index {i}, but got {actual[i]}");
        }
    }

    [Fact]
    public void FindAverages_DocumentationExample_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 };
        var k = 5;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1,3,2,6,-1]=11/5=2.2, [3,2,6,-1,4]=14/5=2.8,
        //          [2,6,-1,4,1]=12/5=2.4, [6,-1,4,1,8]=18/5=3.6,
        //          [-1,4,1,8,2]=14/5=2.8
        var expected = new[] { 2.2, 2.8, 2.4, 3.6, 2.8 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_BasicExample_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { 1, 2, 3, 4, 5, 6 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1,2,3]=6/3=2.0, [2,3,4]=9/3=3.0,
        //          [3,4,5]=12/3=4.0, [4,5,6]=15/3=5.0
        var expected = new[] { 2.0, 3.0, 4.0, 5.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_WindowSizeOne_ReturnsAllElements()
    {
        // Arrange
        var arr = new[] { 5, 10, 15, 20 };
        var k = 1;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 5.0, 10.0, 15.0, 20.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_WindowSizeEqualsArrayLength_ReturnsSingleAverage()
    {
        // Arrange
        var arr = new[] { 2, 4, 6, 8, 10 };
        var k = 5;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 6.0 }; // (2+4+6+8+10)/5 = 30/5 = 6
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_TwoElementArray_WindowSizeTwo_ReturnsSingleAverage()
    {
        // Arrange
        var arr = new[] { 10, 20 };
        var k = 2;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 15.0 }; // (10+20)/2 = 15
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_WithNegativeNumbers_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { -5, -2, 3, 6, -1 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [-5,-2,3]=-4/3=-1.333, [-2,3,6]=7/3=2.333, [3,6,-1]=8/3=2.667
        var expected = new[] { -1.333, 2.333, 2.667 };
        AssertArrayEquals(expected, result, 0.001);
    }

    [Fact]
    public void FindAverages_AllSameNumbers_ReturnsSameAverage()
    {
        // Arrange
        var arr = new[] { 7, 7, 7, 7, 7 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 7.0, 7.0, 7.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_WithZeros_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { 0, 5, 0, 10, 0 };
        var k = 2;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [0,5]=2.5, [5,0]=2.5, [0,10]=5.0, [10,0]=5.0
        var expected = new[] { 2.5, 2.5, 5.0, 5.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_AllZeros_ReturnsZeroAverages()
    {
        // Arrange
        var arr = new[] { 0, 0, 0, 0 };
        var k = 2;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 0.0, 0.0, 0.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_WindowSizeTwo_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
        var k = 2;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1,4]=2.5, [4,2]=3.0, [2,10]=6.0, [10,23]=16.5,
        //          [23,3]=13.0, [3,1]=2.0, [1,0]=0.5, [0,20]=10.0
        var expected = new[] { 2.5, 3.0, 6.0, 16.5, 13.0, 2.0, 0.5, 10.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_LargeNumbers_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { 1000, 2000, 3000, 4000, 5000 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1000,2000,3000]=2000, [2000,3000,4000]=3000, [3000,4000,5000]=4000
        var expected = new[] { 2000.0, 3000.0, 4000.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_DecimalAverages_ReturnsCorrectPrecision()
    {
        // Arrange
        var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1,2,3]=2.0, [2,3,4]=3.0, [3,4,5]=4.0, [4,5,6]=5.0,
        //          [5,6,7]=6.0, [6,7,8]=7.0, [7,8,9]=8.0, [8,9,10]=9.0
        var expected = new[] { 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_FractionalAverages_ReturnsCorrectValues()
    {
        // Arrange
        var arr = new[] { 1, 1, 1, 2, 2, 2 };
        var k = 2;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [1,1]=1.0, [1,1]=1.0, [1,2]=1.5, [2,2]=2.0, [2,2]=2.0
        var expected = new[] { 1.0, 1.0, 1.5, 2.0, 2.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_SingleElementArray_WindowSizeOne_ReturnsElement()
    {
        // Arrange
        var arr = new[] { 42 };
        var k = 1;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        var expected = new[] { 42.0 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_VerifiesSlidingWindowMechanism()
    {
        // Arrange
        var arr = new[] { 10, 20, 30, 40, 50 };
        var k = 3;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // This test explicitly verifies the sliding window works correctly
        // Window 1: [10,20,30] = 60/3 = 20.0
        // Window 2: [20,30,40] = 90/3 = 30.0 (removed 10, added 40)
        // Window 3: [30,40,50] = 120/3 = 40.0 (removed 20, added 50)
        var expected = new[] { 20.0, 30.0, 40.0 };
        AssertArrayEquals(expected, result);

        // Verify each window's average increased by exactly 10
        Assert.Equal(10.0, result[1] - result[0], 3);
        Assert.Equal(10.0, result[2] - result[1], 3);
    }

    [Fact]
    public void FindAverages_LargeArray_PerformanceTest()
    {
        // Arrange
        var arr = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            arr[i] = i % 100;
        }
        var k = 50;

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = FindAverages(arr, k);
        stopwatch.Stop();

        // Assert
        Assert.Equal(10000 - 50 + 1, result.Length);
        // O(n) algorithm should complete quickly (< 50ms for 10k elements)
        Assert.True(stopwatch.ElapsedMilliseconds < 50,
            $"Algorithm took {stopwatch.ElapsedMilliseconds}ms, expected O(n) performance");
    }

    [Fact]
    public void FindAverages_MixedPositiveNegativeWithDecimals_ReturnsCorrectAverages()
    {
        // Arrange
        var arr = new[] { -10, 5, -3, 8, 12, -6 };
        var k = 4;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Windows: [-10,5,-3,8]=0/4=0.0, [5,-3,8,12]=22/4=5.5, [-3,8,12,-6]=11/4=2.75
        var expected = new[] { 0.0, 5.5, 2.75 };
        AssertArrayEquals(expected, result);
    }

    [Fact]
    public void FindAverages_ResultArrayHasCorrectSize()
    {
        // Arrange
        var arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var k = 4;

        // Act
        var result = FindAverages(arr, k);

        // Assert
        // Array length = 10, window size = 4
        // Expected windows: 10 - 4 + 1 = 7
        Assert.Equal(7, result.Length);
    }

    #endregion

    #region MaxSlidingWindow Tests

    // Helper method to execute the MaxSlidingWindow algorithm
    private static int[] MaxSlidingWindow(int[] nums, int k)
    {
        var fixedSlidingWindow = new FixedSlidingWindow();
        return fixedSlidingWindow.MaxSlidingWindow(nums, k);
    }

    #region Basic Functionality Tests

    [Fact]
    public void MaxSlidingWindow_BasicExample_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 1, 3, -1, -3, 5, 3, 6, 7 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,3,-1]=3, [3,-1,-3]=3, [-1,-3,5]=5, [-3,5,3]=5, [5,3,6]=6, [3,6,7]=7
        var expected = new[] { 3, 3, 5, 5, 6, 7 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_IncreasingSequence_ReturnsRightmostElements()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5, 6 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,2,3]=3, [2,3,4]=4, [3,4,5]=5, [4,5,6]=6
        var expected = new[] { 3, 4, 5, 6 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_DecreasingSequence_ReturnsLeftmostElements()
    {
        // Arrange
        var nums = new[] { 6, 5, 4, 3, 2, 1 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [6,5,4]=6, [5,4,3]=5, [4,3,2]=4, [3,2,1]=3
        var expected = new[] { 6, 5, 4, 3 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_PeakInMiddle_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 1, 2, 5, 3, 2, 1 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,2,5]=5, [2,5,3]=5, [5,3,2]=5, [3,2,1]=3
        var expected = new[] { 5, 5, 5, 3 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Edge Cases - Array and Window Size

    [Fact]
    public void MaxSlidingWindow_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        var nums = Array.Empty<int>();
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MaxSlidingWindow_WindowSizeZero_ReturnsEmptyArray()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5 };
        var k = 0;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MaxSlidingWindow_WindowSizeOne_ReturnsAllElements()
    {
        // Arrange
        var nums = new[] { 5, 3, 8, 2, 9, 1 };
        var k = 1;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Each element is its own window
        var expected = new[] { 5, 3, 8, 2, 9, 1 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_SingleElement_ReturnsElement()
    {
        // Arrange
        var nums = new[] { 42 };
        var k = 1;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        var expected = new[] { 42 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_WindowSizeEqualsArrayLength_ReturnsSingleMax()
    {
        // Arrange
        var nums = new[] { 3, 1, 8, 2, 5, 4 };
        var k = 6;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Only one window containing all elements
        var expected = new[] { 8 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_WindowSizeTwo_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 1, 5, 2, 7, 3 };
        var k = 2;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,5]=5, [5,2]=5, [2,7]=7, [7,3]=7
        var expected = new[] { 5, 5, 7, 7 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_TwoElements_WindowSizeTwo_ReturnsMax()
    {
        // Arrange
        var nums = new[] { 7, 3 };
        var k = 2;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        var expected = new[] { 7 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Negative Numbers

    [Fact]
    public void MaxSlidingWindow_AllNegativeNumbers_ReturnsLeastNegative()
    {
        // Arrange
        var nums = new[] { -5, -8, -3, -9, -2, -7 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [-5,-8,-3]=-3, [-8,-3,-9]=-3, [-3,-9,-2]=-2, [-9,-2,-7]=-2
        var expected = new[] { -3, -3, -2, -2 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_MixedPositiveNegative_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { -2, 10, -3, 8, -5, 6, -1 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [-2,10,-3]=10, [10,-3,8]=10, [-3,8,-5]=8, [8,-5,6]=8, [-5,6,-1]=6
        var expected = new[] { 10, 10, 8, 8, 6 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_NegativeToPositive_ReturnsCorrectTransition()
    {
        // Arrange
        var nums = new[] { -10, -5, 0, 5, 10 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [-10,-5,0]=0, [-5,0,5]=5, [0,5,10]=10
        var expected = new[] { 0, 5, 10 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Duplicate Values

    [Fact]
    public void MaxSlidingWindow_AllSameValues_ReturnsConstantArray()
    {
        // Arrange
        var nums = new[] { 7, 7, 7, 7, 7 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // All windows have the same maximum
        var expected = new[] { 7, 7, 7 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_DuplicateMaximums_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 1, 5, 5, 2, 5, 3 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,5,5]=5, [5,5,2]=5, [5,2,5]=5, [2,5,3]=5
        var expected = new[] { 5, 5, 5, 5 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_RepeatingPattern_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 3, 3, 9, 9, 3, 3, 9, 9 };
        var k = 4;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [3,3,9,9]=9, [3,9,9,3]=9, [9,9,3,3]=9, [9,3,3,9]=9, [3,3,9,9]=9
        var expected = new[] { 9, 9, 9, 9, 9 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Zero Handling

    [Fact]
    public void MaxSlidingWindow_WithZeros_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 0, 5, 0, 3, 0, 2 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [0,5,0]=5, [5,0,3]=5, [0,3,0]=3, [3,0,2]=3
        var expected = new[] { 5, 5, 3, 3 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_AllZeros_ReturnsZeroArray()
    {
        // Arrange
        var nums = new[] { 0, 0, 0, 0, 0 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        var expected = new[] { 0, 0, 0 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_ZerosAndNegatives_ReturnsZeroWhenPresent()
    {
        // Arrange
        var nums = new[] { -5, 0, -3, 0, -2 };
        var k = 2;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [-5,0]=0, [0,-3]=0, [-3,0]=0, [0,-2]=0
        var expected = new[] { 0, 0, 0, 0 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Result Array Size Verification

    [Fact]
    public void MaxSlidingWindow_ResultArrayHasCorrectSize_SmallArray()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Array length = 5, window size = 3
        // Expected windows: 5 - 3 + 1 = 3
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void MaxSlidingWindow_ResultArrayHasCorrectSize_LargeWindow()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var k = 7;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Array length = 10, window size = 7
        // Expected windows: 10 - 7 + 1 = 4
        Assert.Equal(4, result.Length);
    }

    #endregion

    #region Monotonic Deque Behavior Tests

    [Fact]
    public void MaxSlidingWindow_MaxAtWindowStart_HandlesCorrectly()
    {
        // Arrange - maximum is at the start of each window
        var nums = new[] { 10, 1, 2, 8, 1, 2, 6, 1, 2 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [10,1,2]=10, [1,2,8]=8, [2,8,1]=8, [8,1,2]=8, [1,2,6]=6, [2,6,1]=6, [6,1,2]=6
        var expected = new[] { 10, 8, 8, 8, 6, 6, 6 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_MaxAtWindowEnd_HandlesCorrectly()
    {
        // Arrange - maximum is at the end of each window
        var nums = new[] { 1, 2, 10, 1, 2, 8, 1, 2, 6 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,2,10]=10, [2,10,1]=10, [10,1,2]=10, [1,2,8]=8, [2,8,1]=8, [8,1,2]=8, [1,2,6]=6
        var expected = new[] { 10, 10, 10, 8, 8, 8, 6 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_MaxAtWindowMiddle_HandlesCorrectly()
    {
        // Arrange - maximum is in the middle of each window
        var nums = new[] { 1, 10, 2, 1, 8, 2, 1, 6, 2 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,10,2]=10, [10,2,1]=10, [2,1,8]=8, [1,8,2]=8, [8,2,1]=8, [2,1,6]=6, [1,6,2]=6
        var expected = new[] { 10, 10, 8, 8, 8, 6, 6 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Large Arrays and Performance

    [Fact]
    public void MaxSlidingWindow_LargeArray_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            nums[i] = i % 10; // Pattern: 0,1,2,3,4,5,6,7,8,9,0,1,2...
        }
        var k = 5;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        Assert.Equal(1000 - 5 + 1, result.Length);
        // First window [0,1,2,3,4] has max 4
        Assert.Equal(4, result[0]);
        // Many windows will have max 9
        Assert.Contains(9, result);
    }

    [Fact]
    public void MaxSlidingWindow_PerformanceTest_CompletesQuickly()
    {
        // Arrange
        var nums = new int[100000];
        for (int i = 0; i < 100000; i++)
        {
            nums[i] = i % 1000;
        }
        var k = 100;

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = MaxSlidingWindow(nums, k);
        stopwatch.Stop();

        // Assert
        Assert.Equal(100000 - 100 + 1, result.Length);
        // O(n) algorithm should complete in reasonable time (< 100ms for 100k elements)
        Assert.True(stopwatch.ElapsedMilliseconds < 100,
            $"Algorithm took {stopwatch.ElapsedMilliseconds}ms, expected O(n) performance");
    }

    #endregion

    #region Special Patterns

    [Fact]
    public void MaxSlidingWindow_AlternatingHighLow_ReturnsCorrectMaxValues()
    {
        // Arrange
        var nums = new[] { 1, 10, 1, 10, 1, 10, 1 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,10,1]=10, [10,1,10]=10, [1,10,1]=10, [10,1,10]=10, [1,10,1]=10
        var expected = new[] { 10, 10, 10, 10, 10 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_PyramidPattern_ReturnsCorrectMaxValues()
    {
        // Arrange - values increase then decrease
        var nums = new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1,2,3]=3, [2,3,4]=4, [3,4,5]=5, [4,5,4]=5, [5,4,3]=5, [4,3,2]=4, [3,2,1]=3
        var expected = new[] { 3, 4, 5, 5, 5, 4, 3 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_ValleyPattern_ReturnsCorrectMaxValues()
    {
        // Arrange - values decrease then increase
        var nums = new[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [5,4,3]=5, [4,3,2]=4, [3,2,1]=3, [2,1,2]=2, [1,2,3]=3, [2,3,4]=4, [3,4,5]=5
        var expected = new[] { 5, 4, 3, 2, 3, 4, 5 };
        Assert.Equal(expected, result);
    }

    #endregion

    #region Boundary Cases

    [Fact]
    public void MaxSlidingWindow_MaxAtBothEnds_HandlesCorrectly()
    {
        // Arrange
        var nums = new[] { 10, 2, 3, 4, 5, 6, 7, 8, 10 };
        var k = 5;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [10,2,3,4,5]=10, [2,3,4,5,6]=6, [3,4,5,6,7]=7, [4,5,6,7,8]=8, [5,6,7,8,10]=10
        var expected = new[] { 10, 6, 7, 8, 10 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_LargeNumbers_HandlesCorrectly()
    {
        // Arrange
        var nums = new[] { 1000, 2000, 3000, 4000, 5000 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [1000,2000,3000]=3000, [2000,3000,4000]=4000, [3000,4000,5000]=5000
        var expected = new[] { 3000, 4000, 5000 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_IntMaxBoundary_HandlesCorrectly()
    {
        // Arrange
        var nums = new[] { int.MaxValue, 1, 2, int.MaxValue - 1, 3 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [MaxValue,1,2]=MaxValue, [1,2,MaxValue-1]=MaxValue-1, [2,MaxValue-1,3]=MaxValue-1
        var expected = new[] { int.MaxValue, int.MaxValue - 1, int.MaxValue - 1 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MaxSlidingWindow_IntMinBoundary_HandlesCorrectly()
    {
        // Arrange
        var nums = new[] { int.MinValue, -1, -2, int.MinValue + 1, -3 };
        var k = 3;

        // Act
        var result = MaxSlidingWindow(nums, k);

        // Assert
        // Windows: [MinValue(-2147483648),-1,-2]=-1, [-1,-2,MinValue+1(-2147483647)]=-1, [-2,MinValue+1(-2147483647),-3]=-2
        var expected = new[] { -1, -1, -2 };
        Assert.Equal(expected, result);
    }

    #endregion

    #endregion
}
