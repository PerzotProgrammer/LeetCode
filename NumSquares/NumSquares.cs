namespace NumSquares;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 12
        // Output: 3
        // Explanation: 12 = 4 + 4 + 4.

        // Example 2:
        //
        // Input: n = 13
        // Output: 2
        // Explanation: 13 = 4 + 9.

        Solution solution = new();

        Console.WriteLine(solution.NumSquares(12));
        Console.WriteLine(solution.NumSquares(13));
    }

    public int NumSquares(int n)
    {
        Dictionary<int, int> dp = new() { [0] = 0 };

        for (int i = 1; i <= n; i++)
        {
            dp[i] = int.MaxValue;
            int j = 1;
            while (j * j <= i)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                j++;
            }
        }

        return dp[n];
    }
}