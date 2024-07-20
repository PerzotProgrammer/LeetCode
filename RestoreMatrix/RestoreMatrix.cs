namespace RestoreMatrix;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: rowSum = [3,8], colSum = [4,7]
        // Output: [[3,0],
        // [1,7]]
        // Explanation: 
        // 0th row: 3 + 0 = 3 == rowSum[0]
        // 1st row: 1 + 7 = 8 == rowSum[1]
        // 0th column: 3 + 1 = 4 == colSum[0]
        // 1st column: 0 + 7 = 7 == colSum[1]
        // The row and column sums match, and all matrix elements are non-negative.
        // Another possible matrix is: [[1,2],
        // [3,5]]

        // Example 2:
        //
        // Input: rowSum = [5,7,10], colSum = [8,6,8]
        // Output: [[0,5,0],
        // [6,1,0],
        // [2,0,8]]


        Solution solution = new();

        PrintMatrix(solution.RestoreMatrix([3, 8], [4, 7]));
        PrintMatrix(solution.RestoreMatrix([5, 7, 10], [8, 6, 8]));
    }

    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        int[][] matrix = new int[rowSum.Length][];

        for (int i = 0; i < rowSum.Length; i++) matrix[i] = new int[colSum.Length];

        for (int i = 0; i < rowSum.Length; i++)
        {
            for (int j = 0; j < colSum.Length; j++)
            {
                int value = Math.Min(rowSum[i], colSum[j]);
                matrix[i][j] = value;
                rowSum[i] -= value;
                colSum[j] -= value;
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] ints in matrix)
        {
            foreach (int i in ints) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}