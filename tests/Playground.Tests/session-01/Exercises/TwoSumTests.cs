namespace Playground.Tests.Exercises;

using Playground.Basics;

/// <summary>
/// Tests for Two Sum - finding two indices of numbers that add up to a target value.
/// </summary>
public class TwoSumTests
{
    #region Basic Functionality Tests

    [Fact]
    public void CalculateTwoSum_WithValidPair_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [2, 7, 11, 15];
        int target = 9;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithPairAtEnd_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [3, 2, 4];
        int target = 6;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([1, 2], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithMultiplePairs_ReturnsFirstPair()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];
        int target = 6;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([1, 3], actual);
    }

    #endregion

    #region Edge Cases with Duplicates

    [Fact]
    public void CalculateTwoSum_WithDuplicateNumbers_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [3, 3];
        int target = 6;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithDuplicatesInArray_ReturnsValidPair()
    {
        // Arrange
        int[] numbers = [1, 1, 1, 1];
        int target = 2;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 1], actual);
    }

    #endregion

    #region Negative Numbers and Zero

    [Fact]
    public void CalculateTwoSum_WithNegativeNumbers_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [-3, 4, 3, 90];
        int target = 0;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 2], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithAllNegativeNumbers_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [-1, -2, -3, -4, -5];
        int target = -8;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([2, 4], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithZeroInArray_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [0, 4, 3, 0];
        int target = 0;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 3], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithNegativeTarget_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [1, -2, -3, 4];
        int target = -5;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([1, 2], actual);
    }

    #endregion

    #region Large Numbers

    [Fact]
    public void CalculateTwoSum_WithLargeNumbers_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [1000000, 2000000, 3000000];
        int target = 5000000;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([1, 2], actual);
    }

    #endregion

    #region No Solution Cases

    [Fact]
    public void CalculateTwoSum_WithNoValidPair_ReturnsMinusOneMinusOne()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4];
        int target = 10;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([-1, -1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithSingleElement_ReturnsMinusOneMinusOne()
    {
        // Arrange
        int[] numbers = [5];
        int target = 5;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([-1, -1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithEmptyArray_ReturnsMinusOneMinusOne()
    {
        // Arrange
        int[] numbers = [];
        int target = 0;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([-1, -1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WhenSameElementNeededTwice_ReturnsMinusOneMinusOne()
    {
        // Arrange
        int[] numbers = [1, 2, 3];
        int target = 2;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([-1, -1], actual);
    }

    #endregion

    #region Two Element Arrays

    [Fact]
    public void CalculateTwoSum_WithTwoElementsValid_ReturnsCorrectIndices()
    {
        // Arrange
        int[] numbers = [5, 10];
        int target = 15;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([0, 1], actual);
    }

    [Fact]
    public void CalculateTwoSum_WithTwoElementsInvalid_ReturnsMinusOneMinusOne()
    {
        // Arrange
        int[] numbers = [5, 10];
        int target = 20;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([-1, -1], actual);
    }

    #endregion

    #region Order and Index Verification

    [Fact]
    public void CalculateTwoSum_ReturnsIndicesInAscendingOrder()
    {
        // Arrange
        int[] numbers = [1, 5, 3, 7];
        int target = 8;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.True(actual[0] < actual[1], "First index should be less than second index");
    }

    [Fact]
    public void CalculateTwoSum_ReturnsActualIndices_NotValues()
    {
        // Arrange
        int[] numbers = [15, 2, 7, 11];
        int target = 9;

        // Act
        var actual = TwoSum.CalculateTwoSum(numbers, target);

        // Assert
        Assert.Equal([1, 2], actual);
        Assert.Equal(2, numbers[actual[0]]);
        Assert.Equal(7, numbers[actual[1]]);
    }

    #endregion
}