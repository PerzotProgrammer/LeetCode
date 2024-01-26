namespace FindPaths;

class Solution
{
    static void Main()
    {
        // Pomoc z wątku: https://leetcode.com/problems/out-of-boundary-paths/solutions/4628048/c-solution-for-out-of-boundary-paths-problem/?envType=daily-question&envId=2024-01-26

        // Example 1:
        //     
        // Input: m = 2, n = 2, maxMove = 2, startRow = 0, startColumn = 0
        // Output: 6
        //     
        // Example 2:
        //     
        // Input: m = 1, n = 3, maxMove = 3, startRow = 0, startColumn = 1
        // Output: 12

        Solution solution = new();

        Console.WriteLine(solution.FindPaths(2, 2, 2, 0, 0));
        Console.WriteLine(solution.FindPaths(1, 3, 3, 0, 1));
    }

    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        int MOD = 1000000007;
        int[,] dp = new int[m, n];
        int count = 0;

        dp[startRow, startColumn] = 1;

        for (int moves = 1; moves <= maxMove; moves++)
        {
            int[,] temp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == m - 1) count = (count + dp[i, j]) % MOD;
                    if (j == n - 1) count = (count + dp[i, j]) % MOD;
                    if (i == 0) count = (count + dp[i, j]) % MOD;
                    if (j == 0) count = (count + dp[i, j]) % MOD;

                    temp[i, j] = (
                        ((i > 0 ? dp[i - 1, j] : 0) + (i < m - 1 ? dp[i + 1, j] : 0)) % MOD +
                        ((j > 0 ? dp[i, j - 1] : 0) + (j < n - 1 ? dp[i, j + 1] : 0)) % MOD
                    ) % MOD;
                }
            }

            dp = temp;
        }

        return count;
    }
}