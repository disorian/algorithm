public class C121BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length == 0)
            return 0;

        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (var curentPrice in prices)
        {
            if (curentPrice < minPrice)
            {
                minPrice = curentPrice;
                continue;
            }

            int profit = curentPrice - minPrice;
            if (profit > maxProfit)
                maxProfit = profit;
        }

        return maxProfit;
    }
    public int MaxProfit_Bad(int[] prices)
    {
        if (prices.Length == 0)
            return 0;

        int minIndex = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > 0 && prices[i] < prices[minIndex])
                minIndex = i;
        }

        if (minIndex == prices.Length - 1)
            return 0;

        int maxIndex = minIndex;
        for (int j = minIndex + 1; j < prices.Length; j++)
        {
            if (prices[j] > prices[maxIndex])
                maxIndex = j;
        }

        return prices[maxIndex] - prices[minIndex];
    }
}

// [7,1,5,3,6,4]
// [7,6,4,3,1]

///
/// max index = min
