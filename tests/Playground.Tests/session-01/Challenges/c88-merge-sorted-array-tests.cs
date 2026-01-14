using Playground.ConsoleApp.Challenges.Leetcode;

namespace Playground.Tests.Session01.Challenges;

public class C88MergeSortedArrayTests
{
    [Fact]
    public void Merge_Example1_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 2, 5, 6 };
        var n = 3;
        var expected = new[] { 1, 2, 2, 3, 5, 6 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_Example2_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1 };
        var m = 1;
        var nums2 = Array.Empty<int>();
        var n = 0;
        var expected = new[] { 1 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_Example3_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 0 };
        var m = 0;
        var nums2 = new[] { 1 };
        var n = 1;
        var expected = new[] { 1 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_AllNums2ElementsLarger_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 4, 5, 6 };
        var n = 3;
        var expected = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_AllNums2ElementsSmaller_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 4, 5, 6, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 1, 2, 3 };
        var n = 3;
        var expected = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_InterleavedElements_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 3, 5, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 2, 4, 6 };
        var n = 3;
        var expected = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_DuplicateElements_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 1, 1, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 1, 1, 1 };
        var n = 3;
        var expected = new[] { 1, 1, 1, 1, 1, 1 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_SingleElementInEachArray_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 2, 0 };
        var m = 1;
        var nums2 = new[] { 1 };
        var n = 1;
        var expected = new[] { 1, 2 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_NegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { -3, -1, 0, 0, 0 };
        var m = 2;
        var nums2 = new[] { -2, 0, 1 };
        var n = 3;
        var expected = new[] { -3, -2, -1, 0, 1 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_AllNegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { -6, -4, -2, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { -5, -3, -1 };
        var n = 3;
        var expected = new[] { -6, -5, -4, -3, -2, -1 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_LargeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1000000000, 0 };
        var m = 1;
        var nums2 = new[] { -1000000000 };
        var n = 1;
        var expected = new[] { -1000000000, 1000000000 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_Nums1Empty_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 0, 0, 0 };
        var m = 0;
        var nums2 = new[] { 1, 2, 3 };
        var n = 3;
        var expected = new[] { 1, 2, 3 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_UnequalArraySizes_MoreInNums1_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 3, 4, 5, 0, 0 };
        var m = 5;
        var nums2 = new[] { 6, 7 };
        var n = 2;
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_UnequalArraySizes_MoreInNums2_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 0, 0, 0, 0, 0 };
        var m = 2;
        var nums2 = new[] { 3, 4, 5, 6, 7 };
        var n = 5;
        var expected = new[] { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_AlternatingDuplicates_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 2, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 1, 2, 3 };
        var n = 3;
        var expected = new[] { 1, 1, 2, 2, 2, 3 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_ZeroValues_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 0, 0, 0, 0, 0 };
        var m = 2;
        var nums2 = new[] { 0, 0, 0 };
        var n = 3;
        var expected = new[] { 0, 0, 0, 0, 0 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_SingleElementNums2_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 3, 5, 7, 0 };
        var m = 4;
        var nums2 = new[] { 4 };
        var n = 1;
        var expected = new[] { 1, 3, 4, 5, 7 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_SingleElementNums1_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 4, 0, 0, 0, 0 };
        var m = 1;
        var nums2 = new[] { 1, 3, 5, 7 };
        var n = 4;
        var expected = new[] { 1, 3, 4, 5, 7 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }

    [Fact]
    public void Merge_ConsecutiveNumbers_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C88MergeSortedArray();
        var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 4, 5, 6 };
        var n = 3;
        var expected = new[] { 1, 2, 3, 4, 5, 6 };

        // Act
        solution.Merge(nums1, m, nums2, n);

        // Assert
        Assert.Equal(expected, nums1);
    }
}
