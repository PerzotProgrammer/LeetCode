namespace KInversePairs;

class Solution
{
    static void Main()
    {
        // Internet znowu pomógł :)
        // https://leetcode.com/problems/k-inverse-pairs-array/solutions/4632683/beats-100-py-java-c-c-c-js-go-rust/?envType=daily-question&envId=2024-01-27
        
        // Example 1:
        //
        // Input: n = 3, k = 0
        // Output: 1
        // Explanation: Only the array [1,2,3] which consists of numbers from 1 to 3 has exactly 0 inverse pairs.

        // Example 2:
        //
        // Input: n = 3, k = 1
        // Output: 2
        // Explanation: The array [1,3,2] and [2,1,3] have exactly 1 inverse pair.

        Solution solution = new();

        Console.WriteLine(solution.KInversePairs(3, 0));
        Console.WriteLine(solution.KInversePairs(3, 1));
    }

    public int KInversePairs(int n, int k)
    {
        int mod = 1000000007;
        int[] dp = new int[k + 1];
        dp[0] = 1;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                dp[j] = (dp[j] + dp[j - 1]) % mod;
            }

            for (int j = k; j >= i; j--)
            {
                dp[j] = (dp[j] - dp[j - i] + mod) % mod;
            }
        }

        return dp[k];
    }
}