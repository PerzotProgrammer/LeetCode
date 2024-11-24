namespace MaxMatrixSum;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: matrix = [[1,-1],[-1,1]]
        // Output: 4
        // Explanation: We can follow the following steps to reach sum equals 4:
        // - Multiply the 2 elements in the first row by -1.
        // - Multiply the 2 elements in the first column by -1.

        // Example 2:
        //
        // Input: matrix = [[1,2,3],[-1,-2,-3],[1,2,3]]
        // Output: 16
        // Explanation: We can follow the following step to reach sum equals 16:
        // - Multiply the 2 last elements in the second row by -1.


        Solution solution = new();

        Console.WriteLine(solution.MaxMatrixSum([[1, -1], [-1, 1]]));
        Console.WriteLine(solution.MaxMatrixSum([[1, 2, 3], [-1, -2, -3], [1, 2, 3]]));
    }

    public long MaxMatrixSum(int[][] matrix)
    {
        long totalSum = 0;
        int minAbsValue = int.MaxValue;
        bool hasOddNegatives = false;

        foreach (int[] row in matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int value = row[i];
                int absValue = Math.Abs(value);
                totalSum += absValue;

                if (absValue < minAbsValue) minAbsValue = absValue;
                if (value < 0) hasOddNegatives = !hasOddNegatives;
            }
        }

        if (hasOddNegatives) totalSum -= 2 * minAbsValue;

        return totalSum;
    }
}