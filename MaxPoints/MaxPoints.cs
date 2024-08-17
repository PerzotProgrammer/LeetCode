namespace MaxPoints;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: points = [[1,2,3],[1,5,1],[3,1,1]]
        // Output: 9
        // Explanation:
        // The blue cells denote the optimal cells to pick, which have coordinates (0, 2), (1, 1), and (2, 0).
        // You add 3 + 5 + 3 = 11 to your score.
        // However, you must subtract abs(2 - 1) + abs(1 - 0) = 2 from your score.
        // Your final score is 11 - 2 = 9.

        // Example 2:
        //
        // Input: points = [[1,5],[2,3],[4,2]]
        // Output: 11
        // Explanation:
        // The blue cells denote the optimal cells to pick, which have coordinates (0, 1), (1, 1), and (2, 0).
        // You add 5 + 3 + 4 = 12 to your score.
        // However, you must subtract abs(1 - 1) + abs(1 - 0) = 1 from your score.
        // Your final score is 12 - 1 = 11.


        Solution solution = new();

        Console.WriteLine(solution.MaxPoints([[1, 2, 3], [1, 5, 1], [3, 1, 1]]));
        Console.WriteLine(solution.MaxPoints([[1, 5], [2, 3], [4, 2]]));
    }

    public long MaxPoints(int[][] points)
    {
        int m = points.Length;
        int n = points[0].Length;

        long[] dp = new long[n];

        for (int c = 0; c < n; c++) dp[c] = points[0][c];

        for (int r = 1; r < m; r++)
        {
            long[] newDp = new long[n];

            long leftMax = dp[0];
            for (int c = 0; c < n; c++)
            {
                leftMax = Math.Max(leftMax, dp[c] + c);
                newDp[c] = leftMax + points[r][c] - c;
            }

            long rightMax = dp[n - 1] - (n - 1);
            for (int c = n - 1; c >= 0; c--)
            {
                rightMax = Math.Max(rightMax, dp[c] - c);
                newDp[c] = Math.Max(newDp[c], rightMax + points[r][c] + c);
            }

            dp = newDp;
        }

        long maxPoints = 0;
        for (int c = 0; c < n; c++) maxPoints = Math.Max(maxPoints, dp[c]);

        return maxPoints;
    }
}