namespace Playground.Tests.Session2;

using Playground.Session2;

public class PartitionArrayTests
{
    // Helper method to execute the PartitionArray algorithm
    private static void PartitionArray(int[] nums, int pivot)
    {
        var twoPointers = new TwoPointersSameDirection();
        twoPointers.PartitionArray(nums, pivot);
    }

    // Helper method to verify partition invariant
    private static bool IsValidPartition(int[] nums, int pivot)
    {
        // Find the boundary: first element >= pivot
        int boundary = 0;
        while (boundary < nums.Length && nums[boundary] < pivot)
        {
            boundary++;
        }

        // Verify all elements before boundary are < pivot
        for (int i = 0; i < boundary; i++)
        {
            if (nums[i] >= pivot)
                return false;
        }

        // Verify all elements from boundary onwards are >= pivot
        for (int i = boundary; i < nums.Length; i++)
        {
            if (nums[i] < pivot)
                return false;
        }

        return true;
    }

    #region Basic Functionality Tests

    [Fact]
    public void PartitionArray_MixedElements_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { 3, 9, 1, 8, 4, 2, 7 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        // Elements < 5: 3, 1, 4, 2 should be on the left
        // Elements >= 5: 9, 8, 7 should be on the right
        Assert.Equal(4, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_ExampleFromComment_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { 9, 12, 5, 10, 14, 3, 10 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        // Elements < 10: 9, 5, 3
        // Elements >= 10: 12, 10, 14, 10
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(4, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_AllElementsLessThanPivot_NoChange()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5 };
        var pivot = 10;
        var originalNums = (int[])nums.Clone();

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(5, nums.Count(x => x < pivot));
        Assert.Equal(0, nums.Count(x => x >= pivot));
        // All elements should remain (order might change but all < pivot)
        Assert.Equal(originalNums.OrderBy(x => x), nums.OrderBy(x => x));
    }

    [Fact]
    public void PartitionArray_AllElementsGreaterThanOrEqualPivot_NoSwaps()
    {
        // Arrange
        var nums = new[] { 10, 15, 20, 25, 30 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(0, nums.Count(x => x < pivot));
        Assert.Equal(5, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_ElementsEqualToPivot_MovedToRight()
    {
        // Arrange
        var nums = new[] { 5, 5, 5, 5, 5 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(0, nums.Count(x => x < pivot));
        Assert.Equal(5, nums.Count(x => x >= pivot));
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void PartitionArray_SingleElement_LessThanPivot()
    {
        // Arrange
        var nums = new[] { 5 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Single(nums);
        Assert.Equal(5, nums[0]);
    }

    [Fact]
    public void PartitionArray_SingleElement_GreaterThanPivot()
    {
        // Arrange
        var nums = new[] { 15 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Single(nums);
        Assert.Equal(15, nums[0]);
    }

    [Fact]
    public void PartitionArray_SingleElement_EqualToPivot()
    {
        // Arrange
        var nums = new[] { 10 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Single(nums);
        Assert.Equal(10, nums[0]);
    }

    [Fact]
    public void PartitionArray_TwoElements_AlreadyPartitioned()
    {
        // Arrange
        var nums = new[] { 5, 15 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(5, nums[0]);
        Assert.Equal(15, nums[1]);
    }

    [Fact]
    public void PartitionArray_TwoElements_NeedsSwap()
    {
        // Arrange
        var nums = new[] { 15, 5 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(5, nums[0]);
        Assert.Equal(15, nums[1]);
    }

    [Fact]
    public void PartitionArray_EmptyArray_NoError()
    {
        // Arrange
        var nums = Array.Empty<int>();
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.Empty(nums);
    }

    #endregion

    #region Pivot Variations

    [Fact]
    public void PartitionArray_PivotIsMinimum_AllToRight()
    {
        // Arrange
        var nums = new[] { 5, 3, 8, 1, 9 };
        var pivot = 1;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(0, nums.Count(x => x < pivot));
        Assert.Equal(5, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_PivotIsMaximumPlusOne_AllToLeft()
    {
        // Arrange
        var nums = new[] { 5, 3, 8, 1, 9 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(5, nums.Count(x => x < pivot));
        Assert.Equal(0, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_PivotIsMedian_SplitsEvenly()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(4, nums.Count(x => x < pivot));
        Assert.Equal(5, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_NegativePivot_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { -5, 3, -1, 8, -10, 0 };
        var pivot = 0;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    #endregion

    #region Duplicate Elements

    [Fact]
    public void PartitionArray_WithDuplicates_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { 5, 2, 8, 2, 9, 2, 1 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(4, nums.Count(x => x < pivot)); // 2, 2, 2, 1
        Assert.Equal(3, nums.Count(x => x >= pivot)); // 5, 8, 9
    }

    [Fact]
    public void PartitionArray_MultiplePivotValues_AllToRight()
    {
        // Arrange
        var nums = new[] { 5, 10, 5, 10, 5, 10 };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot)); // Three 5s
        Assert.Equal(3, nums.Count(x => x >= pivot)); // Three 10s
    }

    [Fact]
    public void PartitionArray_AllDuplicatesLessThanPivot_NoChange()
    {
        // Arrange
        var nums = new[] { 3, 3, 3, 3 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.All(nums, x => Assert.Equal(3, x));
    }

    [Fact]
    public void PartitionArray_AllDuplicatesGreaterThanPivot_NoSwaps()
    {
        // Arrange
        var nums = new[] { 7, 7, 7, 7 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.All(nums, x => Assert.Equal(7, x));
    }

    #endregion

    #region Negative Numbers

    [Fact]
    public void PartitionArray_AllNegativeNumbers_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { -5, -10, -3, -8, -1 };
        var pivot = -5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(2, nums.Count(x => x < pivot)); // -10, -8
        Assert.Equal(3, nums.Count(x => x >= pivot)); // -5, -3, -1
    }

    [Fact]
    public void PartitionArray_MixedPositiveNegative_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { -5, 10, -3, 8, -1, 2 };
        var pivot = 0;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot)); // -5, -3, -1
        Assert.Equal(3, nums.Count(x => x >= pivot)); // 10, 8, 2
    }

    #endregion

    #region Large Arrays

    [Fact]
    public void PartitionArray_LargeArray_PartitionsCorrectly()
    {
        // Arrange
        var nums = Enumerable.Range(1, 100).ToArray();
        var pivot = 50;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(49, nums.Count(x => x < pivot));
        Assert.Equal(51, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_LargeArrayReversed_PartitionsCorrectly()
    {
        // Arrange
        var nums = Enumerable.Range(1, 100).Reverse().ToArray();
        var pivot = 50;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(49, nums.Count(x => x < pivot));
        Assert.Equal(51, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_LargeArrayWithDuplicates_PartitionsCorrectly()
    {
        // Arrange
        var nums = new int[1000];
        for (int i = 0; i < 500; i++) nums[i] = 3;
        for (int i = 500; i < 1000; i++) nums[i] = 7;
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(500, nums.Count(x => x < pivot));
        Assert.Equal(500, nums.Count(x => x >= pivot));
    }

    #endregion

    #region Already Partitioned

    [Fact]
    public void PartitionArray_AlreadyPartitioned_RemainsValid()
    {
        // Arrange
        var nums = new[] { 1, 2, 3, 10, 20, 30 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
    }

    [Fact]
    public void PartitionArray_ReversePartitioned_GetsFixed()
    {
        // Arrange
        var nums = new[] { 10, 20, 30, 1, 2, 3 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    #endregion

    #region Alternating Pattern

    [Fact]
    public void PartitionArray_AlternatingSmallLarge_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { 1, 10, 2, 20, 3, 30 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_AlternatingLargeSmall_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { 10, 1, 20, 2, 30, 3 };
        var pivot = 5;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    #endregion

    #region Boundary Values

    [Fact]
    public void PartitionArray_WithIntMaxValue_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { int.MaxValue, 5, int.MaxValue, 3, int.MaxValue };
        var pivot = 10;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(2, nums.Count(x => x < pivot));
        Assert.Equal(3, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_WithIntMinValue_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { int.MinValue, 5, int.MinValue, 3, int.MinValue };
        var pivot = 0;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(3, nums.Count(x => x < pivot));
        Assert.Equal(2, nums.Count(x => x >= pivot));
    }

    [Fact]
    public void PartitionArray_MixedExtremeValues_PartitionsCorrectly()
    {
        // Arrange
        var nums = new[] { int.MinValue, int.MaxValue, 0, -1, 1 };
        var pivot = 0;

        // Act
        PartitionArray(nums, pivot);

        // Assert
        Assert.True(IsValidPartition(nums, pivot));
        Assert.Equal(2, nums.Count(x => x < pivot)); // int.MinValue, -1
        Assert.Equal(3, nums.Count(x => x >= pivot)); // int.MaxValue, 0, 1
    }

    #endregion
}
