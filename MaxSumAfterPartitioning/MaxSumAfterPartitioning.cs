namespace MaxSumAfterPartitioning;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [1,15,7,9,2,5,10], k = 3
        // Output: 84
        // Explanation: arr becomes [15,15,15,9,10,10,10]
        
        // Example 2:
        //
        // Input: arr = [1,4,1,5,7,3,6,1,9,9,3], k = 4
        // Output: 83
        
        // Example 3:
        //
        // Input: arr = [1], k = 1
        // Output: 1

        Solution solution = new();

        Console.WriteLine(solution.MaxSumAfterPartitioning([1,15,7,9,2,5,10], 3));
        Console.WriteLine(solution.MaxSumAfterPartitioning([1,4,1,5,7,3,6,1,9,9,3], 4));
        Console.WriteLine(solution.MaxSumAfterPartitioning([1], 1));
    }

    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        int length = arr.Length;

        int[] dp = new int[length + 1];

        for (int i = 1; i <= length; i++)
        {
            int max = 0;

            for (int j = 1; j <= k && i - j >= 0; j++)
            {
                max = Math.Max(max, arr[i - j]);
                dp[i] = Math.Max(dp[i], dp[i - j] + max * j);
            }
        }

        return dp[length];
    }
}