namespace CountSubstrings;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "abc"
        // Output: 3
        // Explanation: Three palindromic strings: "a", "b", "c".
        
        // Example 2:
        //
        // Input: s = "aaa"
        // Output: 6
        // Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

        Solution solution = new();

        Console.WriteLine(solution.CountSubstrings("abc"));
        Console.WriteLine(solution.CountSubstrings("aaa"));
    }

    public int CountSubstrings(string s)
    {
        int n = s.Length;
        int count = 0;
        bool[,] dp = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            dp[i, i] = true;
            count++;
        }

        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                count++;
            }
        }

        for (int len = 3; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    count++;
                }
            }
        }

        return count;
    }
}