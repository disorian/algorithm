namespace Playground.Tests.Arrays;

using Playground.Basics;

public class RemoveDuplicatesTests
{
    [Fact]
    public void RemoveDuplicatesFromArray_WithConsecutiveDuplicates_ReturnsUniqueCount()
    {
        // Arrange
        int[] numbers = [1, 1, 2, 2, 3];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(3, count);
        Assert.Equal([1, 2, 3, 2, 3], actual);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithEmptyArray_ReturnsZero()
    {
        // Arrange
        int[] numbers = [];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(0, count);
        Assert.Empty(actual);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithSingleElement_ReturnsSingleElement()
    {
        // Arrange
        int[] numbers = [42];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(1, count);
        Assert.Equal([42], actual);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithNoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(5, count);
        Assert.Equal([1, 2, 3, 4, 5], actual);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithAllDuplicates_ReturnsOne()
    {
        // Arrange
        int[] numbers = [7, 7, 7, 7, 7];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(1, count);
        Assert.Equal(7, actual[0]);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithMultipleDuplicatePairs_ReturnsUniqueElements()
    {
        // Arrange
        int[] numbers = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(5, count);
        // First 5 elements should be unique values
        Assert.Equal(0, actual[0]);
        Assert.Equal(1, actual[1]);
        Assert.Equal(2, actual[2]);
        Assert.Equal(3, actual[3]);
        Assert.Equal(4, actual[4]);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithTwoElements_NoDuplicates_ReturnsBoth()
    {
        // Arrange
        int[] numbers = [1, 2];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(2, count);
        Assert.Equal([1, 2], actual);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithTwoElements_BothDuplicates_ReturnsOne()
    {
        // Arrange
        int[] numbers = [5, 5];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(1, count);
        Assert.Equal(5, actual[0]);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithNegativeNumbers_ReturnsUniqueCount()
    {
        // Arrange
        int[] numbers = [-3, -3, -1, -1, 0, 0, 2, 2];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(4, count);
        Assert.Equal(-3, actual[0]);
        Assert.Equal(-1, actual[1]);
        Assert.Equal(0, actual[2]);
        Assert.Equal(2, actual[3]);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_WithLongSequenceOfDuplicates_ReturnsCorrectCount()
    {
        // Arrange
        int[] numbers = [1, 1, 1, 1, 1, 2, 3, 3, 3, 4, 4, 4, 4];

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Equal(4, count);
        Assert.Equal(1, actual[0]);
        Assert.Equal(2, actual[1]);
        Assert.Equal(3, actual[2]);
        Assert.Equal(4, actual[3]);
    }

    [Fact]
    public void RemoveDuplicatesFromArray_ModifiesOriginalArray_InPlace()
    {
        // Arrange
        int[] numbers = [1, 1, 2, 3, 3];
        int[] originalReference = numbers;

        // Act
        var (count, actual) = RemoveDuplicates.RemoveDuplicatesFromArray(numbers);

        // Assert
        Assert.Same(originalReference, actual); // Verifies in-place modification
        Assert.Equal(3, count);
    }
}