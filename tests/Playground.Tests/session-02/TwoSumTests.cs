namespace Playground.Tests.Session2;

using Playground.Session2;

public class TwoSumTests
{
    // Helper method to execute the TwoSum algorithm
    private static (int, int) TwoSum(int[] numbers, int target)
    {
        var twoPointers = new TwoPointersOppositeDirection();
        return twoPointers.TwoSum(numbers, target);
    }

    #region Basic Functionality Tests

    [Fact]
    public void TwoSum_FindsCorrectPair_ReturnsIndices()
    {
        // Arrange
        var numbers = new[] { 2, 7, 11, 15 };
        var target = 9;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 1), result);
    }

    [Fact]
    public void TwoSum_PairAtEnds_ReturnsFirstAndLastIndices()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var target = 6;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 4), result);
    }

    [Fact]
    public void TwoSum_PairInMiddle_ReturnsCorrectIndices()
    {
        // Arrange
        var numbers = new[] { 1, 3, 5, 7, 9, 11 };
        var target = 12;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        // Multiple valid pairs exist: (1,4) for 3+9=12 or (0,5) for 1+11=12
        Assert.Equal(12, numbers[result.Item1] + numbers[result.Item2]);
        Assert.True(result.Item1 >= 0 && result.Item2 >= 0);
        Assert.True(result.Item1 < result.Item2);
    }

    [Fact]
    public void TwoSum_AdjacentPair_ReturnsAdjacentIndices()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4 };
        var target = 7;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((2, 3), result); // 3 + 4 = 7
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void TwoSum_TwoElements_ReturnsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 1, 2 };
        var target = 3;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 1), result);
    }

    [Fact]
    public void TwoSum_NoPairExists_ReturnsMinusOneMinusOne()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4 };
        var target = 10;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((-1, -1), result);
    }

    [Fact]
    public void TwoSum_TargetTooSmall_ReturnsMinusOneMinusOne()
    {
        // Arrange
        var numbers = new[] { 5, 10, 15, 20 };
        var target = 10;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((-1, -1), result);
    }

    [Fact]
    public void TwoSum_TargetTooLarge_ReturnsMinusOneMinusOne()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4 };
        var target = 100;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((-1, -1), result);
    }

    #endregion

    #region Negative Numbers

    [Fact]
    public void TwoSum_WithNegativeNumbers_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { -5, -2, 0, 3, 7 };
        var target = 5;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((1, 4), result); // -2 + 7 = 5
    }

    [Fact]
    public void TwoSum_AllNegativeNumbers_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { -10, -8, -5, -3, -1 };
        var target = -11;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        // Multiple valid pairs exist: (1,3) for -8+(-3)=-11 or (0,4) for -10+(-1)=-11
        Assert.Equal(-11, numbers[result.Item1] + numbers[result.Item2]);
        Assert.True(result.Item1 >= 0 && result.Item2 >= 0);
        Assert.True(result.Item1 < result.Item2);
    }

    [Fact]
    public void TwoSum_NegativeTarget_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { -5, -3, -1, 2, 4 };
        var target = -4;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((1, 2), result); // -3 + (-1) = -4
    }

    #endregion

    #region Duplicate Values

    [Fact]
    public void TwoSum_WithDuplicates_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 1, 2, 2, 3, 4 };
        var target = 4;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        // Multiple valid pairs exist: (1,2) for 2+2=4 or (0,3) for 1+3=4
        Assert.Equal(4, numbers[result.Item1] + numbers[result.Item2]);
        Assert.True(result.Item1 >= 0 && result.Item2 >= 0);
        Assert.True(result.Item1 < result.Item2);
    }

    [Fact]
    public void TwoSum_AllSameNumbers_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 5, 5, 5, 5 };
        var target = 10;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 3), result); // 5 + 5 = 10 (leftmost and rightmost)
    }

    #endregion

    #region Zero Handling

    [Fact]
    public void TwoSum_WithZeros_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 0, 0, 1, 2, 3 };
        var target = 0;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 1), result); // 0 + 0 = 0
    }

    [Fact]
    public void TwoSum_ZeroInPair_FindsCorrectPair()
    {
        // Arrange
        var numbers = new[] { -3, -1, 0, 2, 4 };
        var target = 2;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((2, 3), result); // 0 + 2 = 2
    }

    #endregion

    #region Large Arrays

    [Fact]
    public void TwoSum_LargeArray_FindsCorrectPair()
    {
        // Arrange
        var numbers = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            numbers[i] = i + 1;
        }
        var target = 1999;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((998, 999), result); // 999 + 1000 = 1999
    }

    [Fact]
    public void TwoSum_LargeArrayNoPair_ReturnsMinusOneMinusOne()
    {
        // Arrange
        var numbers = new int[100];
        for (int i = 0; i < 100; i++)
        {
            numbers[i] = i * 2; // Even numbers only
        }
        var target = 101; // Odd number, impossible with even numbers

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((-1, -1), result);
    }

    #endregion

    #region Special Values

    [Fact]
    public void TwoSum_LargePositiveNumbers_HandlesCorrectly()
    {
        // Arrange
        var numbers = new[] { 1, 100, 1000, 10000, 100000 };
        var target = 101;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 1), result); // 1 + 100 = 101
    }

    [Fact]
    public void TwoSum_MinMaxValues_HandlesCorrectly()
    {
        // Arrange
        var numbers = new[] { int.MinValue, -1, 0, 1, int.MaxValue };
        var target = int.MaxValue + int.MinValue; // This equals -1

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 4), result); // int.MinValue + int.MaxValue = -1
    }

    #endregion

    #region Multiple Possible Pairs

    [Fact]
    public void TwoSum_MultiplePossiblePairs_ReturnsAValidPair()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4, 5, 6 };
        var target = 7;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        // The two-pointer approach will find one of the valid pairs
        // Verify that the sum equals the target
        Assert.Equal(7, numbers[result.Item1] + numbers[result.Item2]);
        Assert.True(result.Item1 >= 0 && result.Item2 >= 0);
        Assert.True(result.Item1 < result.Item2);
    }

    #endregion

    #region Boundary Tests

    [Fact]
    public void TwoSum_FirstTwoElements_ReturnsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 1, 5, 10, 20, 30 };
        var target = 6;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((0, 1), result); // 1 + 5 = 6
    }

    [Fact]
    public void TwoSum_LastTwoElements_ReturnsCorrectPair()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 40, 50 };
        var target = 90;

        // Act
        var result = TwoSum(numbers, target);

        // Assert
        Assert.Equal((3, 4), result); // 40 + 50 = 90
    }

    #endregion
}
