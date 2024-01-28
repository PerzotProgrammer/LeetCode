namespace NumSubmatrixSumTarget;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: matrix = [[0,1,0],[1,1,1],[0,1,0]], target = 0
        // Output: 4
        // Explanation: The four 1x1 submatrices that only contain 0.

        // Example 2:
        //
        // Input: matrix = [[1,-1],[-1,1]], target = 0
        // Output: 5
        // Explanation: The two 1x2 submatrices, plus the two 2x1 submatrices, plus the 2x2 submatrix.

        // Example 3:
        //
        // Input: matrix = [[904]], target = 0
        // Output: 0

        Solution solution = new();

        Console.WriteLine(solution.NumSubmatrixSumTarget([[0, 1, 0], [1, 1, 1], [0, 1, 0]], 0));
        Console.WriteLine(solution.NumSubmatrixSumTarget([[1, -1], [-1, 1]], 0));
        Console.WriteLine(solution.NumSubmatrixSumTarget([[904]], 0));
    }

    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        for (int row = 0; row < m; row++)
        {
            for (int col = 1; col < n; col++)
            {
                matrix[row][col] += matrix[row][col - 1];
            }
        }

        int count = 0;

        for (int c1 = 0; c1 < n; c1++)
        {
            for (int c2 = c1; c2 < n; c2++)
            {
                Dictionary<int, int> map = new() { [0] = 1 };
                int sum = 0;

                for (int row = 0; row < m; row++)
                {
                    sum += matrix[row][c2] - (c1 > 0 ? matrix[row][c1 - 1] : 0);
                    count += map.GetValueOrDefault(sum - target, 0);
                    map[sum] = map.GetValueOrDefault(sum, 0) + 1;
                }
            }
        }

        return count;
    }
}