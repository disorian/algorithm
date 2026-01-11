namespace Playground.Tests.Arrays;

using Playground.Basics;

/// <summary>
/// Tests for Array Rotation - Rotate an array to the right by k steps.
/// </summary>
public class ArrayRotationTests
{
    [Fact]
    public void Rotate_BasicCase_RotatesCorrectly()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act
        ArrayRotation.Rotate(numbers, 2);

        // Assert
        Assert.Equal([4, 5, 1, 2, 3], numbers);
    }

    [Fact]
    public void Rotate_NegativeNumbers_RotatesCorrectly()
    {
        // Arrange
        int[] numbers = [-1, -100, 3, 99];

        // Act
        ArrayRotation.Rotate(numbers, 3);

        // Assert
        Assert.Equal([-100, 3, 99, -1], numbers);
    }

    [Fact]
    public void Rotate_ByZero_NoChange()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];
        int[] expected = [1, 2, 3, 4, 5];

        // Act
        ArrayRotation.Rotate(numbers, 0);

        // Assert
        Assert.Equal(expected, numbers);
    }

    [Fact]
    public void Rotate_ByArrayLength_NoChange()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];
        int[] expected = [1, 2, 3, 4, 5];

        // Act
        ArrayRotation.Rotate(numbers, 5);

        // Assert
        Assert.Equal(expected, numbers);
    }

    [Fact]
    public void Rotate_ByGreaterThanLength_WrapsAround()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act - rotating by 7 should be same as rotating by 2 (7 % 5 = 2)
        ArrayRotation.Rotate(numbers, 7);

        // Assert
        Assert.Equal([4, 5, 1, 2, 3], numbers);
    }

    [Fact]
    public void Rotate_SingleElement_NoChange()
    {
        // Arrange
        int[] numbers = [42];

        // Act
        ArrayRotation.Rotate(numbers, 1);

        // Assert
        Assert.Equal([42], numbers);
    }

    [Fact]
    public void Rotate_TwoElements_Swaps()
    {
        // Arrange
        int[] numbers = [1, 2];

        // Act
        ArrayRotation.Rotate(numbers, 1);

        // Assert
        Assert.Equal([2, 1], numbers);
    }

    [Fact]
    public void Rotate_EmptyArray_NoChange()
    {
        // Arrange
        int[] numbers = [];

        // Act
        ArrayRotation.Rotate(numbers, 5);

        // Assert
        Assert.Empty(numbers);
    }

    [Fact]
    public void Rotate_ByOne_RotatesCorrectly()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act
        ArrayRotation.Rotate(numbers, 1);

        // Assert
        Assert.Equal([5, 1, 2, 3, 4], numbers);
    }

    [Fact]
    public void Rotate_ByLengthMinusOne_RotatesCorrectly()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act
        ArrayRotation.Rotate(numbers, 4);

        // Assert
        Assert.Equal([2, 3, 4, 5, 1], numbers);
    }

    [Fact]
    public void Rotate_LargeArray_RotatesEfficiently()
    {
        // Arrange
        int[] numbers = [.. Enumerable.Range(1, 1000)];
        int[] expected = [.. Enumerable.Range(501, 500), .. Enumerable.Range(1, 500)];

        // Act
        ArrayRotation.Rotate(numbers, 500);

        // Assert
        Assert.Equal(expected, numbers);
    }

    [Fact]
    public void Rotate_MultipleOfLength_NoChange()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];
        int[] expected = [1, 2, 3, 4, 5];

        // Act - 15 % 5 = 0, so no rotation
        ArrayRotation.Rotate(numbers, 15);

        // Assert
        Assert.Equal(expected, numbers);
    }

    [Fact]
    public void Rotate_VeryLargeK_HandlesCorrectly()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];

        // Act - 1000002 % 5 = 2
        ArrayRotation.Rotate(numbers, 1000002);

        // Assert
        Assert.Equal([4, 5, 1, 2, 3], numbers);
    }

    [Fact]
    public void Rotate_AllSameElements_RemainsUnchanged()
    {
        // Arrange
        int[] numbers = [7, 7, 7, 7, 7];
        int[] expected = [7, 7, 7, 7, 7];

        // Act
        ArrayRotation.Rotate(numbers, 3);

        // Assert
        Assert.Equal(expected, numbers);
    }

    [Fact]
    public void Rotate_ThreeElements_RotatesByOne()
    {
        // Arrange
        int[] numbers = [1, 2, 3];

        // Act
        ArrayRotation.Rotate(numbers, 1);

        // Assert
        Assert.Equal([3, 1, 2], numbers);
    }

    [Fact]
    public void Rotate_ThreeElements_RotatesByTwo()
    {
        // Arrange
        int[] numbers = [1, 2, 3];

        // Act
        ArrayRotation.Rotate(numbers, 2);

        // Assert
        Assert.Equal([2, 3, 1], numbers);
    }

    [Fact]
    public void Rotate_MixedPositiveNegativeZero_RotatesCorrectly()
    {
        // Arrange
        int[] numbers = [-5, 0, 3, -2, 7];

        // Act
        ArrayRotation.Rotate(numbers, 2);

        // Assert
        Assert.Equal([-2, 7, -5, 0, 3], numbers);
    }
}