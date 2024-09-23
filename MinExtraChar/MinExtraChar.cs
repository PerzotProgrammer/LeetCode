namespace MinExtraChar;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/extra-characters-in-a-string/solutions/5825271/optimal-solution/?envType=daily-question&envId=2024-09-23
        // Example 1:
        //
        // Input: s = "leetscode", dictionary = ["leet","code","leetcode"]
        // Output: 1
        // Explanation: We can break s in two substrings: "leet" from index 0 to 3 and "code" from index 5 to 8. There is only 1 unused character (at index 4), so we return 1.

        // Example 2:
        //
        // Input: s = "sayhelloworld", dictionary = ["hello","world"]
        // Output: 3
        // Explanation: We can break s in two substrings: "hello" from index 3 to 7 and "world" from index 8 to 12. The characters at indices 0, 1, 2 are not used in any substring and thus are considered as extra characters. Hence, we return 3.


        Solution solution = new();

        Console.WriteLine(solution.MinExtraChar("leetscode", ["leet", "code", "leetcode"]));
        Console.WriteLine(solution.MinExtraChar("sayhelloworld", ["hello", "world"]));
    }

    public int MinExtraChar(string s, string[] dictionary)
    {
        int[] dp = new int[s.Length + 1];

        for (int i = 0; i <= s.Length; i++) dp[i] = i;

        HashSet<string> dictSet = new(dictionary);

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                string substring = s.Substring(j, i - j);
                if (dictSet.Contains(substring)) dp[i] = Math.Min(dp[i], dp[j]);
            }

            dp[i] = Math.Min(dp[i], dp[i - 1] + 1);
        }

        return dp[s.Length];
    }
}