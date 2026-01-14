using static Playground.Basics.Challenges.Solution;

namespace Playground.Tests.Session01.Challenges;

/// <summary>
/// Tests for Maximum Subarray Sum - Kadane's Algorithm for finding the contiguous subarray with the largest sum.
/// </summary>
public class MaxSubArrayTests
{
    [Fact]
    public void KadanesAlgorithm_MixedNumbersWithNegatives_ReturnsCorrectMaximum()
    {
        // Arrange
        int[] numbers = [-2, 1, -3, 4, -1, 2, 1, -5, 4];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(6, result); // Subarray [4, -1, 2, 1] has sum 6
    }

    [Fact]
    public void KadanesAlgorithm_SingleElement_ReturnsThatElement()
    {
        // Arrange
        int[] numbers = [1];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void KadanesAlgorithm_AllPositiveNumbers_ReturnsSum()
    {
        // Arrange
        int[] numbers = [5, 4, -1, 7, 8];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(23, result); // All elements sum to 23
    }

    [Fact]
    public void KadanesAlgorithm_AllNegativeNumbers_ReturnsLargestNegative()
    {
        // Arrange
        int[] numbers = [-5, -2, -8, -1, -4];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(-1, result); // -1 is the largest element
    }

    [Fact]
    public void KadanesAlgorithm_SingleNegativeElement_ReturnsThatElement()
    {
        // Arrange
        int[] numbers = [-10];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(-10, result);
    }

    [Fact]
    public void KadanesAlgorithm_TwoElements_ReturnsMaximum()
    {
        // Arrange
        int[] numbers = [3, -2];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void KadanesAlgorithm_TwoElementsBothNegative_ReturnsLarger()
    {
        // Arrange
        int[] numbers = [-3, -2];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(-2, result);
    }

    [Fact]
    public void KadanesAlgorithm_AlternatingPositiveNegative_ReturnsCorrectMaximum()
    {
        // Arrange
        int[] numbers = [1, -2, 3, -4, 5, -6, 7];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(7, result); // Last element [7] is the maximum subarray
    }

    [Fact]
    public void KadanesAlgorithm_ZeroIncluded_HandlesCorrectly()
    {
        // Arrange
        int[] numbers = [-2, 0, -1, 3, -4, 2];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(3, result); // Subarray [3] has sum 3
    }

    [Fact]
    public void KadanesAlgorithm_AllZeros_ReturnsZero()
    {
        // Arrange
        int[] numbers = [0, 0, 0, 0];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void KadanesAlgorithm_LargePositiveFollowedByNegatives_ReturnsLargePositive()
    {
        // Arrange
        int[] numbers = [100, -50, -25, -10];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(100, result); // First element is the maximum
    }

    [Fact]
    public void KadanesAlgorithm_NegativesFollowedByLargePositive_ReturnsLargePositive()
    {
        // Arrange
        int[] numbers = [-50, -25, -10, 100];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(100, result); // Last element is the maximum
    }

    [Fact]
    public void KadanesAlgorithm_MultipleMaximumSubarrays_ReturnsMaximum()
    {
        // Arrange - both [5] and [5] have the same maximum sum
        int[] numbers = [5, -3, 5, -3];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(7, result); // Subarray [5, -3, 5] has sum 7
    }

    [Fact]
    public void KadanesAlgorithm_LargeArray_HandlesEfficiently()
    {
        // Arrange
        int[] numbers = [.. Enumerable.Range(1, 100)]; // [1, 2, 3, ..., 100]

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(5050, result); // Sum of 1 to 100 = 100 * 101 / 2 = 5050
    }

    [Fact]
    public void KadanesAlgorithm_LargeArrayWithNegatives_HandlesEfficiently()
    {
        // Arrange - pattern of 10 positive, 5 negative values
        List<int> numbersList = [];
        for (int i = 0; i < 10; i++)
        {
            numbersList.AddRange([10, 10, 10, 10, 10, 10, 10, 10, 10, 10, -5, -5, -5, -5, -5]);
        }
        int[] numbers = [.. numbersList];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(775, result); // The entire array: 10 iterations * (100 - 25) + 25 from first iteration = 775
    }

    [Fact]
    public void KadanesAlgorithm_MaxIntValue_HandlesCorrectly()
    {
        // Arrange
        int[] numbers = [int.MaxValue, -1, 1];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void KadanesAlgorithm_VeryLargeNegativeWithZero_ReturnsZero()
    {
        // Arrange
        int[] numbers = [-1000000, -500000, 0, -100000];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(0, result); // 0 is the largest element
    }

    [Fact]
    public void KadanesAlgorithm_PositiveNegativeBalance_ReturnsCorrectMaximum()
    {
        // Arrange
        int[] numbers = [2, -1, 2, -1, 2, -1, 2];

        // Act
        int result = MaxSubArray(numbers);

        // Assert
        Assert.Equal(5, result); // Entire array sums to 5
    }
}
