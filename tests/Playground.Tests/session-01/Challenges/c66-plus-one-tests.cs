using Playground.ConsoleApp.Challenges.Leetcode;

namespace Playground.Tests.Session01.Challenges;

public class C66PlusOneTests
{
    [Fact]
    public void PlusOne_Example1_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C66PlusOne();
        var digits = new[] { 1, 2, 3 };
        var expected = new[] { 1, 2, 4 };

        // Act
        var result = solution.PlusOne(digits);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PlusOne_Example2_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C66PlusOne();
        var digits = new[] { 4, 3, 2, 1 };
        var expected = new[] { 4, 3, 2, 2 };

        // Act
        var result = solution.PlusOne(digits);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PlusOne_Example3_ReturnsCorrectResult()
    {
        // Arrange
        var solution = new C66PlusOne();
        var digits = new[] { 9 };
        var expected = new[] { 1, 0 };

        // Act
        var result = solution.PlusOne(digits);

        // Assert
        Assert.Equal(expected, result);
    }
}
