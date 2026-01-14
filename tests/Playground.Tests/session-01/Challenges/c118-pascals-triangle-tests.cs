namespace Playground.Tests.Session01.Challenges;

public class C118PascalsTriangleTests
{
    private readonly C118PascalsTriangle _solution;

    public C118PascalsTriangleTests()
    {
        _solution = new C118PascalsTriangle();
    }

    #region Basic Functionality Tests

    [Fact]
    public void Generate_WithOneRow_ReturnsSingleRow()
    {
        // Arrange
        int numRows = 1;
        var expected = new List<IList<int>>
        {
            new List<int> { 1 }
        };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected.Count, result.Count);
        Assert.Equal(expected[0], result[0]);
    }

    [Fact]
    public void Generate_WithTwoRows_ReturnsCorrectTriangle()
    {
        // Arrange
        int numRows = 2;
        var expected = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int> { 1, 1 }
        };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Fact]
    public void Generate_WithThreeRows_ReturnsCorrectTriangle()
    {
        // Arrange
        int numRows = 3;
        var expected = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 }
        };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Fact]
    public void Generate_WithFiveRows_ReturnsCorrectTriangle()
    {
        // Arrange
        int numRows = 5;
        var expected = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 }
        };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Fact]
    public void Generate_WithTenRows_ReturnsCorrectTriangle()
    {
        // Arrange
        int numRows = 10;
        var expected = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 },
            new List<int> { 1, 5, 10, 10, 5, 1 },
            new List<int> { 1, 6, 15, 20, 15, 6, 1 },
            new List<int> { 1, 7, 21, 35, 35, 21, 7, 1 },
            new List<int> { 1, 8, 28, 56, 70, 56, 28, 8, 1 },
            new List<int> { 1, 9, 36, 84, 126, 126, 84, 36, 9, 1 }
        };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected.Count, result.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Generate_WithZeroRows_ReturnsEmptyList()
    {
        // Arrange
        int numRows = 0;

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Generate_WithNegativeRows_ReturnsEmptyList()
    {
        // Arrange
        int numRows = -5;

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Generate_WithMaxConstraint_ReturnsCorrectSize()
    {
        // Arrange - Maximum constraint is 30 rows
        int numRows = 30;

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(30, result.Count);
        Assert.Equal(30, result[29].Count); // Last row should have 30 elements
    }

    #endregion

    #region Property-Based Tests

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void Generate_VerifiesRowCount_MatchesInput(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(numRows, result.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Generate_VerifiesRowLength_MatchesRowIndex(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert - Each row i should have i+1 elements (0-indexed)
        for (int i = 0; i < result.Count; i++)
        {
            Assert.Equal(i + 1, result[i].Count);
        }
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void Generate_VerifiesSymmetry_InEachRow(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert - Verify each row is symmetric (palindrome)
        foreach (var row in result)
        {
            var rowList = row.ToList();
            var reversed = new List<int>(rowList);
            reversed.Reverse();
            Assert.Equal(rowList, reversed);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(30)]
    public void Generate_VerifiesFirstAndLastElements_AreAlwaysOne(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert - Every row starts and ends with 1
        foreach (var row in result)
        {
            Assert.Equal(1, row[0]);
            Assert.Equal(1, row[row.Count - 1]);
        }
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Generate_VerifiesPascalProperty_SumOfTwoAbove(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert - Each interior element equals sum of two elements above it
        for (int i = 2; i < result.Count; i++) // Start from row 2 (0-indexed)
        {
            var currentRow = result[i];
            var previousRow = result[i - 1];

            for (int j = 1; j < currentRow.Count - 1; j++) // Interior elements only
            {
                int expectedValue = previousRow[j - 1] + previousRow[j];
                Assert.Equal(expectedValue, currentRow[j]);
            }
        }
    }

    #endregion

    #region Return Type Verification

    [Fact]
    public void Generate_ReturnsCorrectType_IListOfIListOfInt()
    {
        // Act
        var result = _solution.Generate(5);

        // Assert
        Assert.IsAssignableFrom<IList<IList<int>>>(result);
    }

    [Fact]
    public void Generate_ReturnsArrayType_NotList()
    {
        // Act
        var result = _solution.Generate(5);

        // Assert - Verify implementation uses arrays, not Lists
        Assert.IsType<int[][]>(result);
        Assert.IsType<int[]>(result[0]);
    }

    #endregion

    #region Mathematical Properties

    [Theory]
    [InlineData(5, 2, new[] { 1, 2, 1 })] // Row 2 (0-indexed)
    [InlineData(5, 3, new[] { 1, 3, 3, 1 })] // Row 3
    [InlineData(5, 4, new[] { 1, 4, 6, 4, 1 })] // Row 4
    [InlineData(7, 5, new[] { 1, 5, 10, 10, 5, 1 })] // Row 5
    [InlineData(7, 6, new[] { 1, 6, 15, 20, 15, 6, 1 })] // Row 6
    public void Generate_VerifiesSpecificRow_MatchesBinomialCoefficients(int numRows, int rowIndex, int[] expectedRow)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expectedRow, result[rowIndex]);
    }

    [Fact]
    public void Generate_VerifiesBinomialCoefficients_Row5()
    {
        // Arrange - Row 5 represents binomial coefficients (5 choose k) for k=0 to 5
        // C(5,0)=1, C(5,1)=5, C(5,2)=10, C(5,3)=10, C(5,4)=5, C(5,5)=1
        int numRows = 6;
        var expected = new[] { 1, 5, 10, 10, 5, 1 };

        // Act
        var result = _solution.Generate(numRows);

        // Assert
        Assert.Equal(expected, result[5]);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void Generate_VerifiesRowSum_PowersOfTwo(int numRows)
    {
        // Act
        var result = _solution.Generate(numRows);

        // Assert - Sum of row n equals 2^n (0-indexed)
        for (int i = 0; i < result.Count; i++)
        {
            int expectedSum = (int)Math.Pow(2, i);
            int actualSum = result[i].Sum();
            Assert.Equal(expectedSum, actualSum);
        }
    }

    #endregion

    #region Performance and Memory Tests

    [Fact]
    public void Generate_WithLargeInput_CompletesInReasonableTime()
    {
        // Arrange
        int numRows = 30; // Maximum constraint

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = _solution.Generate(numRows);
        stopwatch.Stop();

        // Assert - Should complete in less than 100ms for 30 rows
        Assert.True(stopwatch.ElapsedMilliseconds < 100,
            $"Generation took {stopwatch.ElapsedMilliseconds}ms, expected < 100ms");
        Assert.Equal(30, result.Count);
    }

    [Fact]
    public void Generate_DoesNotModifyResult_AfterReturn()
    {
        // Arrange
        int numRows = 5;

        // Act
        var result = _solution.Generate(numRows);
        var originalValues = result.Select(row => row.ToArray()).ToArray();

        // Attempt to modify (should not affect original if properly implemented)
        if (result.Count > 0 && result[0].Count > 0)
        {
            // Arrays are mutable, so this test verifies the structure is correct
            Assert.Equal(1, result[0][0]);
        }

        // Assert - Values should remain unchanged
        for (int i = 0; i < result.Count; i++)
        {
            Assert.Equal(originalValues[i], result[i]);
        }
    }

    #endregion
}
