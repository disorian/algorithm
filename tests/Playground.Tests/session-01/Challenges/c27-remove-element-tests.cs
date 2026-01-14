namespace Playground.Tests.Session01.Challenges;

using Playground.Basics.Challenges;

public class RemoveElementTests
{
    [Fact]
    public void RemoveElement_WithExample1_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [3, 2, 2, 3];
        int val = 3;
        int[] expectedNums = [2, 2];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithExample2_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
        int val = 2;
        int[] expectedNums = [0, 0, 1, 3, 4];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        Array.Sort(expectedNums);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithEmptyArray_ReturnsZero()
    {
        // Arrange
        int[] nums = [];
        int val = 1;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(0, k);
    }

    [Fact]
    public void RemoveElement_WithSingleElementToRemove_ReturnsZero()
    {
        // Arrange
        int[] nums = [3];
        int val = 3;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(0, k);
    }

    [Fact]
    public void RemoveElement_WithSingleElementToKeep_ReturnsOne()
    {
        // Arrange
        int[] nums = [2];
        int val = 3;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(1, k);
        Assert.Equal(2, nums[0]);
    }

    [Fact]
    public void RemoveElement_WithAllElementsToRemove_ReturnsZero()
    {
        // Arrange
        int[] nums = [7, 7, 7, 7, 7];
        int val = 7;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(0, k);
    }

    [Fact]
    public void RemoveElement_WithNoElementsToRemove_ReturnsOriginalLength()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5];
        int val = 6;
        int[] expectedNums = [1, 2, 3, 4, 5];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithTwoElements_FirstShouldBeRemoved_ReturnsOne()
    {
        // Arrange
        int[] nums = [3, 2];
        int val = 3;
        int[] expectedNums = [2];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithTwoElements_SecondShouldBeRemoved_ReturnsOne()
    {
        // Arrange
        int[] nums = [2, 3];
        int val = 3;
        int[] expectedNums = [2];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithTwoElements_BothShouldBeRemoved_ReturnsZero()
    {
        // Arrange
        int[] nums = [3, 3];
        int val = 3;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(0, k);
    }

    [Fact]
    public void RemoveElement_WithAlternatingPattern_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [1, 2, 1, 2, 1, 2];
        int val = 2;
        int[] expectedNums = [1, 1, 1];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithValueAtBeginning_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [5, 5, 5, 1, 2, 3];
        int val = 5;
        int[] expectedNums = [1, 2, 3];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithValueAtEnd_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [1, 2, 3, 5, 5, 5];
        int val = 5;
        int[] expectedNums = [1, 2, 3];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithValueInMiddle_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [1, 2, 5, 5, 5, 3, 4];
        int val = 5;
        int[] expectedNums = [1, 2, 3, 4];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithZeroValue_ReturnsCorrectCount()
    {
        // Arrange
        int[] nums = [0, 1, 2, 0, 3, 0, 4];
        int val = 0;
        int[] expectedNums = [1, 2, 3, 4];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_WithMaxConstraintValues_ReturnsCorrectCount()
    {
        // Arrange - testing boundary conditions
        int[] nums = [50, 50, 25, 0, 50, 1, 50];
        int val = 50;
        int[] expectedNums = [0, 1, 25];

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedNums.Length, k);
        Array.Sort(nums, 0, k);
        Array.Sort(expectedNums);
        for (int i = 0; i < k; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_ModifiesOriginalArray_InPlace()
    {
        // Arrange
        int[] nums = [1, 2, 3, 2, 4];
        int[] originalReference = nums;
        int val = 2;

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Same(originalReference, nums); // Verifies in-place modification
        Assert.Equal(3, k);
    }

    [Fact]
    public void RemoveElement_WithLargeArray_ReturnsCorrectCount()
    {
        // Arrange - testing with larger array near constraint limit
        int[] nums = new int[100];
        for (int i = 0; i < 100; i++)
        {
            nums[i] = i % 10; // Values 0-9 repeating
        }
        int val = 5;
        int expectedCount = 90; // 100 elements - 10 occurrences of 5

        // Act
        int k = new Solution().RemoveElement(nums, val);

        // Assert
        Assert.Equal(expectedCount, k);
        // Verify none of the first k elements equal val
        for (int i = 0; i < k; i++)
        {
            Assert.NotEqual(val, nums[i]);
        }
    }
}
