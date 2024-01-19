namespace MinFallingPathSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
        // Output: 13
        // Explanation: There are two falling paths with a minimum sum as shown.
        
        // Example 2:
        //
        // Input: matrix = [[-19,57],[-40,-5]]
        // Output: -59
        // Explanation: The falling path with a minimum sum is shown.

        Solution solution = new();

        Console.WriteLine(solution.MinFallingPathSum([[2,1,3],[6,5,4],[7,8,9]]));
        Console.WriteLine(solution.MinFallingPathSum([[-19,57],[-40,-5]]));
    }

    public int MinFallingPathSum(int[][] matrix)
    {
        int n = matrix.Length;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] += Math.Min(matrix[i - 1][j],
                    Math.Min((j > 0) ? matrix[i - 1][j - 1] : int.MaxValue,
                        (j < n - 1) ? matrix[i - 1][j + 1] : int.MaxValue));
            }
        }

        return matrix[n - 1].Min();
    }
}