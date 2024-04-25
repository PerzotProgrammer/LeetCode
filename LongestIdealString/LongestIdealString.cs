namespace LongestIdealString;

class Solution
{
    static void Main()
    {
        // Lekka pomoc leetcode z memoizacją
        // Example 1:
        //
        // Input: s = "acfgbd", k = 2
        // Output: 4
        // Explanation: The longest ideal string is "acbd". The length of this string is 4, so 4 is returned.
        // Note that "acfgbd" is not ideal because 'c' and 'f' have a difference of 3 in alphabet order.

        // Example 2:
        //
        // Input: s = "abcd", k = 3
        // Output: 4
        // Explanation: The longest ideal string is "abcd". The length of this string is 4, so 4 is returned.

        Solution solution = new();

        Console.WriteLine(solution.LongestIdealString("acfgbd", 2));
        Console.WriteLine(solution.LongestIdealString("abcd", 3));
    }

    public int LongestIdealString(string s, int k)
    {
        int n = s.Length;
        int[] dp = new int[26];
        int maxLen = 0;

        for (int i = 0; i < n; i++)
        {
            char curr = s[i];
            int idx = curr - 'a';
            int best = 0;

            for (int prev = 0; prev < 26; prev++)
            {
                if (Math.Abs(curr - 'a' - prev) <= k) best = Math.Max(best, dp[prev]);
            }

            dp[idx] = best + 1;
            maxLen = Math.Max(maxLen, dp[idx]);
        }

        return maxLen;
    }
}