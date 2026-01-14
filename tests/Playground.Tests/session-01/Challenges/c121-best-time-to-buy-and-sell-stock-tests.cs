namespace Playground.Tests.Session01.Challenges;

public class C121BestTimeToBuyAndSellStockTests
{
    private readonly C121BestTimeToBuyAndSellStock _solution;

    public C121BestTimeToBuyAndSellStockTests()
    {
        _solution = new C121BestTimeToBuyAndSellStock();
    }

    #region Basic Functionality Tests

    [Fact]
    public void MaxProfit_Example1_ReturnsCorrectProfit()
    {
        // Arrange
        int[] prices = [7, 1, 5, 3, 6, 4];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(5, result); // Buy at 1, sell at 6
    }

    [Fact]
    public void MaxProfit_Example2_NoProfit_ReturnsZero()
    {
        // Arrange
        int[] prices = [7, 6, 4, 3, 1];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // Prices always decreasing, no profit possible
    }

    [Fact]
    public void MaxProfit_AlwaysIncreasing_ReturnsDifferenceBetweenFirstAndLast()
    {
        // Arrange
        int[] prices = [1, 2, 3, 4, 5];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(4, result); // Buy at 1, sell at 5
    }

    [Fact]
    public void MaxProfit_BestBuyAtBeginning_ReturnsCorrectProfit()
    {
        // Arrange
        int[] prices = [1, 5, 3, 6, 4];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(5, result); // Buy at 1, sell at 6
    }

    [Fact]
    public void MaxProfit_BestBuyLater_ReturnsCorrectProfit()
    {
        // Arrange
        int[] prices = [7, 1, 5, 3, 6, 4];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(5, result); // Buy at 1, sell at 6
    }

    [Fact]
    public void MaxProfit_MultiplePeaks_ReturnsMaxProfit()
    {
        // Arrange
        int[] prices = [3, 2, 6, 5, 0, 3];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(4, result); // Buy at 2, sell at 6 (not 0 to 3)
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void MaxProfit_SingleDay_ReturnsZero()
    {
        // Arrange
        int[] prices = [5];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // Can't buy and sell on same day
    }

    [Fact]
    public void MaxProfit_TwoDays_Increasing_ReturnsProfit()
    {
        // Arrange
        int[] prices = [1, 5];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void MaxProfit_TwoDays_Decreasing_ReturnsZero()
    {
        // Arrange
        int[] prices = [5, 1];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxProfit_TwoDays_SamePrice_ReturnsZero()
    {
        // Arrange
        int[] prices = [5, 5];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxProfit_EmptyArray_ReturnsZero()
    {
        // Arrange
        int[] prices = [];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void MaxProfit_AllSamePrice_ReturnsZero()
    {
        // Arrange
        int[] prices = [5, 5, 5, 5, 5];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // No profit if all prices are identical
    }

    #endregion

    #region Boundary Value Tests

    [Fact]
    public void MaxProfit_MinimumPrice_ReturnsCorrectProfit()
    {
        // Arrange
        int[] prices = [0, 100]; // Minimum price is 0

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(100, result);
    }

    [Fact]
    public void MaxProfit_MaximumPrice_ReturnsCorrectProfit()
    {
        // Arrange
        int[] prices = [0, 10000]; // Maximum price is 10^4

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(10000, result);
    }

    [Fact]
    public void MaxProfit_MaximumProfit_ReturnsCorrectValue()
    {
        // Arrange
        int[] prices = [0, 10000]; // Maximum possible profit

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(10000, result);
    }

    [Fact]
    public void MaxProfit_LargeArray_CompletesInReasonableTime()
    {
        // Arrange - Create array with 10^5 elements
        int[] prices = new int[100000];
        for (int i = 0; i < prices.Length; i++)
        {
            prices[i] = i % 100; // Pattern: 0,1,2,...,99,0,1,2,...
        }

        // Act
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int result = _solution.MaxProfit(prices);
        stopwatch.Stop();

        // Assert - Should complete in less than 100ms for 10^5 elements
        Assert.True(stopwatch.ElapsedMilliseconds < 100,
            $"Processing took {stopwatch.ElapsedMilliseconds}ms, expected < 100ms");
        Assert.Equal(99, result); // Buy at 0, sell at 99
    }

    #endregion

    #region Property-Based Tests

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 0)]
    [InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 4)]
    [InlineData(new[] { 2, 1, 2, 1, 0, 1, 2 }, 2)]
    public void MaxProfit_VariousInputs_ReturnsExpectedProfit(int[] prices, int expectedProfit)
    {
        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(expectedProfit, result);
    }

    [Theory]
    [InlineData(new[] { 1, 2 })]
    [InlineData(new[] { 1, 5, 3, 6 })]
    [InlineData(new[] { 7, 1, 5, 3, 6, 4 })]
    public void MaxProfit_ValidInputs_ReturnsNonNegativeValue(int[] prices)
    {
        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.True(result >= 0, "Profit should never be negative");
    }

    [Theory]
    [InlineData(new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 10, 9, 8, 7, 6, 5 })]
    [InlineData(new[] { 100, 50, 25, 12, 6 })]
    public void MaxProfit_DecreasingPrices_ReturnsZero(int[] prices)
    {
        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // No profit possible when prices always decrease
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 0, 10, 20, 30, 40 })]
    [InlineData(new[] { 5, 10, 15, 20, 25 })]
    public void MaxProfit_IncreasingPrices_ReturnsDifferenceBetweenFirstAndLast(int[] prices)
    {
        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        int expected = prices[^1] - prices[0];
        Assert.Equal(expected, result);
    }

    #endregion

    #region Real-World Scenarios

    [Fact]
    public void MaxProfit_VolatileMarket_ReturnsMaxProfit()
    {
        // Arrange - Simulates volatile stock market
        int[] prices = [100, 80, 120, 70, 110, 60, 130];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(70, result); // Buy at 60, sell at 130
    }

    [Fact]
    public void MaxProfit_CrashRecovery_ReturnsMaxProfit()
    {
        // Arrange - Market crashes then recovers
        int[] prices = [50, 40, 30, 20, 10, 40, 50];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(40, result); // Buy at 10, sell at 50
    }

    [Fact]
    public void MaxProfit_EarlyPeak_DoesNotMissLaterOpportunity()
    {
        // Arrange - Early peak but better opportunity later
        int[] prices = [10, 50, 5, 100];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(95, result); // Buy at 5, sell at 100 (not 10 to 50)
    }

    [Fact]
    public void MaxProfit_MinAtEnd_ReturnsZeroOrEarlierProfit()
    {
        // Arrange - Minimum price at the end
        int[] prices = [5, 10, 3, 1];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(5, result); // Buy at 5, sell at 10 (can't use the 1 at end)
    }

    #endregion

    #region Algorithm Verification

    [Fact]
    public void MaxProfit_VerifiesBuyBeforeSell_Constraint()
    {
        // Arrange - Best profit would be if we could sell before buy (which is invalid)
        int[] prices = [5, 1]; // Can't sell at 5 and buy at 1

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // Must buy before sell, so no profit
    }

    [Fact]
    public void MaxProfit_TracksPriceHistory_Correctly()
    {
        // Arrange - Tests that algorithm correctly tracks minimum price seen so far
        int[] prices = [10, 7, 5, 8, 11, 9];

        // Act
        int result = _solution.MaxProfit(prices);

        // Assert
        Assert.Equal(6, result); // Buy at 5, sell at 11
    }

    #endregion
}
