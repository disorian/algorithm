namespace Playground.Tests.Session2;

using Playground.Session2;

public class MaxAreaTests
{
    // Helper method to execute the MaxArea algorithm
    private static int MaxArea(int[] height)
    {
        var twoPointers = new TwoPointersOppositeDirection();
        return twoPointers.MaxArea(height);
    }

    #region Basic Functionality Tests

    [Fact]
    public void MaxArea_StandardCase_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(49, result); // Max area between indices 1 and 8: min(8,7) * 7 = 49
    }

    [Fact]
    public void MaxArea_TwoElements_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(1, result); // min(1,1) * 1 = 1
    }

    [Fact]
    public void MaxArea_TwoElementsDifferentHeights_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 4, 3 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(3, result); // min(4,3) * 1 = 3
    }

    [Fact]
    public void MaxArea_AllSameHeight_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 5, 5, 5, 5, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(20, result); // min(5,5) * 4 = 20 (max width)
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void MaxArea_IncreasingHeights_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(6, result); // min(2,5) * 3 = 6 or min(3,5) * 2 = 6
    }

    [Fact]
    public void MaxArea_DecreasingHeights_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 5, 4, 3, 2, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(6, result); // min(5,2) * 3 = 6 or min(5,3) * 2 = 6
    }

    [Fact]
    public void MaxArea_ZeroHeight_ReturnsZero()
    {
        // Arrange
        var height = new[] { 0, 0, 0 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxArea_WithZeroInMiddle_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 5, 0, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(10, result); // min(5,5) * 2 = 10
    }

    #endregion

    #region Boundary Tests

    [Fact]
    public void MaxArea_SingleTallBar_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 100, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(2, result); // min(1,1) * 2 = 2 (width between first and last)
    }

    [Fact]
    public void MaxArea_TallBarsAtEnds_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 10, 1, 1, 1, 10 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(40, result); // min(10,10) * 4 = 40
    }

    [Fact]
    public void MaxArea_TallBarsInMiddle_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 10, 10, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(10, result); // min(10,10) * 1 = 10
    }

    #endregion

    #region Multiple Valid Solutions

    [Fact]
    public void MaxArea_MultipleSolutions_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 2, 3, 4, 5, 18, 17, 6 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(17, result); // Multiple combinations could give max area
    }

    [Fact]
    public void MaxArea_AlternatingHeights_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 3, 2, 5, 25, 24, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(24, result);
    }

    #endregion

    #region Performance and Large Arrays

    [Fact]
    public void MaxArea_LargeArray_ReturnsCorrectArea()
    {
        // Arrange
        var height = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            height[i] = i % 10 + 1; // Pattern of 1-10 repeating
        }

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.True(result > 0);
        Assert.Equal(9900, result); // min(10,10) * 990 = 9900 (indices 9 and 999)
    }

    [Fact]
    public void MaxArea_UniformHeight_ReturnsMaxPossibleArea()
    {
        // Arrange
        var height = new[] { 100, 100, 100, 100 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(300, result); // min(100,100) * 3 = 300
    }

    #endregion

    #region Special Patterns

    [Fact]
    public void MaxArea_MountainShape_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(12, result); // min(3,3) * 4 = 12 (indices 2 and 6)
    }

    [Fact]
    public void MaxArea_ValleyShape_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(40, result); // min(5,5) * 8 = 40
    }

    [Fact]
    public void MaxArea_StepPattern_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 1, 2, 2, 3, 3 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(6, result); // min(2,3) * 3 = 6 (indices 2 and 5)
    }

    #endregion

    #region Realistic Scenarios

    [Fact]
    public void MaxArea_WaterTankScenario_ReturnsCorrectArea()
    {
        // Arrange - Simulating water tank walls of varying heights
        var height = new[] { 7, 1, 2, 3, 9 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(28, result); // min(7,9) * 4 = 28
    }

    [Fact]
    public void MaxArea_ContainerYardScenario_ReturnsCorrectArea()
    {
        // Arrange - Different container stack heights
        var height = new[] { 8, 7, 6, 5, 4, 3, 2, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(16, result); // min(8,2) * 6 = 12 or min(4,4) * 4 = 16
    }

    #endregion

    #region Symmetrical Cases

    [Fact]
    public void MaxArea_PerfectSymmetry_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 2, 3, 2, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(4, result); // min(2,2) * 2 = 4
    }

    [Fact]
    public void MaxArea_MirroredPattern_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 5, 1, 1, 5 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(15, result); // min(5,5) * 3 = 15
    }

    #endregion

    #region Single Maximum Height

    [Fact]
    public void MaxArea_SinglePeakAtStart_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 10, 1, 1, 1, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(4, result); // min(10,1) * 4 = 4
    }

    [Fact]
    public void MaxArea_SinglePeakAtEnd_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 1, 1, 1, 10 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(4, result); // min(1,10) * 4 = 4
    }

    [Fact]
    public void MaxArea_SinglePeakInMiddle_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 2, 2, 10, 2, 2 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(8, result); // min(2,2) * 4 = 8
    }

    #endregion

    #region Adjacent Tall Bars

    [Fact]
    public void MaxArea_TwoTallBarsAdjacent_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 10, 10, 1, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(10, result); // min(10,10) * 1 = 10
    }

    [Fact]
    public void MaxArea_ThreeTallBarsConsecutive_ReturnsCorrectArea()
    {
        // Arrange
        var height = new[] { 1, 8, 8, 8, 1 };

        // Act
        var result = MaxArea(height);

        // Assert
        Assert.Equal(16, result); // min(8,8) * 2 = 16
    }

    #endregion
}
