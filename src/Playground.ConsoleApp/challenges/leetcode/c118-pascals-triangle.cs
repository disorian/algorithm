public class C118PascalsTriangle
{
    public IList<IList<int>> Generate(int numRows)
    {
        if (numRows <= 0)
            return [];

        int[][] result = new int[numRows][];

        result[0] = [1];

        for (int i = 1; i < numRows; i++)
        {
            result[i] = new int[i + 1];

            int[] previousRow = result[i - 1];
            int[] row = new int[i + 1];
            row[0] = 1;
            row[^1] = 1;

            for (int j = 1; j < row.Length - 1; j++)
            {
                row[j] = previousRow[j] + previousRow[j - 1];
            }
            result[i] = row;
        }

        return result;
    }
}
