namespace LuckyNumbers;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
        // Output: [15]
        // Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column.

        // Example 2:
        //
        // Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
        // Output: [12]
        // Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.

        // Example 3:
        //
        // Input: matrix = [[7,8],[1,2]]
        // Output: [7]
        // Explanation: 7 is the only lucky number since it is the minimum in its row and the maximum in its column.


        Solution solution = new();

        PrintIList(solution.LuckyNumbers([[3, 7, 8], [9, 11, 13], [15, 16, 17]]));
        PrintIList(solution.LuckyNumbers([[1, 10, 4, 2], [9, 3, 8, 7], [15, 16, 17, 12]]));
        PrintIList(solution.LuckyNumbers([[7, 8], [1, 2]]));
    }

    public IList<int> LuckyNumbers(int[][] matrix)
    {
        HashSet<int> minRowValues = new();
        HashSet<int> maxColValues = new();


        for (int i = 0; i < matrix.Length; i++)
        {
            int minValue = matrix[i][0];
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] < minValue) minValue = matrix[i][j];
            }

            minRowValues.Add(minValue);
        }

        for (int j = 0; j < matrix[0].Length; j++)
        {
            int maxValue = matrix[0][j];
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][j] > maxValue) maxValue = matrix[i][j];
            }

            maxColValues.Add(maxValue);
        }

        List<int> luckyNumbers = new();
        foreach (int value in minRowValues)
        {
            if (maxColValues.Contains(value)) luckyNumbers.Add(value);
        }

        return luckyNumbers;
    }

    static void PrintIList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}