namespace LongestCommonSubsequence;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: text1 = "abcde", text2 = "ace" 
        // Output: 3  
        // Explanation: The longest common subsequence is "ace" and its length is 3.
        
        // Example 2:
        //
        // Input: text1 = "abc", text2 = "abc"
        // Output: 3
        // Explanation: The longest common subsequence is "abc" and its length is 3.
        
        // Example 3:
        //
        // Input: text1 = "abc", text2 = "def"
        // Output: 0
        // Explanation: There is no such common subsequence, so the result is 0.

        Solution solution = new();

        Console.WriteLine(solution.LongestCommonSubsequence("abcde", "ace"));
        Console.WriteLine(solution.LongestCommonSubsequence("abc", "abc"));        
        Console.WriteLine(solution.LongestCommonSubsequence("abc", "def"));

    }

    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (text1[i] == text2[j])
                {
                    dp[i + 1, j + 1] = 1 + dp[i, j];
                }
                else
                {
                    dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }
        }

        return dp[m, n];
    }
}