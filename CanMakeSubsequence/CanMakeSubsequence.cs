namespace CanMakeSubsequence;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: str1 = "abc", str2 = "ad"
        // Output: true
        // Explanation: Select index 2 in str1.
        // Increment str1[2] to become 'd'. 
        // Hence, str1 becomes "abd" and str2 is now a subsequence. Therefore, true is returned.

        // Example 2:
        //
        // Input: str1 = "zc", str2 = "ad"
        // Output: true
        // Explanation: Select indices 0 and 1 in str1. 
        // Increment str1[0] to become 'a'. 
        // Increment str1[1] to become 'd'. 
        // Hence, str1 becomes "ad" and str2 is now a subsequence. Therefore, true is returned.

        // Example 3:
        //
        // Input: str1 = "ab", str2 = "d"
        // Output: false
        // Explanation: In this example, it can be shown that it is impossible to make str2 a subsequence of str1 using the operation at most once. 
        // Therefore, false is returned.


        Solution solution = new();

        Console.WriteLine(solution.CanMakeSubsequence("abc", "ad"));
        Console.WriteLine(solution.CanMakeSubsequence("zc", "ad"));
        Console.WriteLine(solution.CanMakeSubsequence("ab", "d"));
    }

    public bool CanMakeSubsequence(string str1, string str2)
    {
        if (str2.Length > str1.Length) return false;
        int j = 0;

        for (int i = 0; i < str1.Length && j < str2.Length; i++)
        {
            char c1 = str1[i];
            char c2 = str2[j];

            if (c1 == c2 || (c1 + 1 - 'a') % 26 == (c2 - 'a')) j++;
        }

        return j == str2.Length;
    }
}