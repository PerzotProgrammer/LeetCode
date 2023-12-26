namespace NumRollsToTarget;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 1, k = 6, target = 3
        // Output: 1
        // Explanation: You throw one die with 6 faces.
        // There is only one way to get a sum of 3.

        // Example 2:
        //
        // Input: n = 2, k = 6, target = 7
        // Output: 6
        // Explanation: You throw two dice, each with 6 faces.
        // There are 6 ways to get a sum of 7: 1+6, 2+5, 3+4, 4+3, 5+2, 6+1.

        // Example 3:
        //
        // Input: n = 30, k = 30, target = 500
        // Output: 222616187
        // Explanation: The answer must be returned modulo 109 + 7.

        Solution solution = new();

        Console.WriteLine(solution.NumRollsToTarget(1, 6, 3));
        Console.WriteLine(solution.NumRollsToTarget(2, 6, 7));
        Console.WriteLine(solution.NumRollsToTarget(30, 30, 500));
    }

    public int NumRollsToTarget(int n, int k, int target)
    {
        int[] dp = new int[target + 1];
        dp[0] = 1;

        for (int i = 1; i <= n; i++)
        {
            int[] temp = new int[dp.Length];

            for (int j = 1; j <= target; j++)
            {
                if (j > i * k) continue;

                for (int l = 1; l <= k && l <= j; l++)
                {
                    temp[j] = (temp[j] + dp[j - l]) % 1000000007;
                }
            }

            dp = temp;
        }

        return dp[target];
    }
}