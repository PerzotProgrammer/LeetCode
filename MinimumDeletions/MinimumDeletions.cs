namespace MinimumDeletions;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "aababbab"
        // Output: 2
        // Explanation: You can either:
        // Delete the characters at 0-indexed positions 2 and 6 ("aababbab" -> "aaabbb"), or
        // Delete the characters at 0-indexed positions 3 and 6 ("aababbab" -> "aabbbb").

        // Example 2:
        //
        // Input: s = "bbaaaaabb"
        // Output: 2
        // Explanation: The only solution is to delete the first two characters.


        Solution solution = new();

        Console.WriteLine(solution.MinimumDeletions("aababbab"));
        Console.WriteLine(solution.MinimumDeletions("bbaaaaabb"));
    }

    public int MinimumDeletions(string s)
    {
        int[] left = new int[s.Length];
        int[] right = new int[s.Length];

        left[0] = s[0] == 'b' ? 1 : 0;
        right[s.Length - 1] = s[^1] == 'a' ? 1 : 0;

        for (int i = 1; i < s.Length; i++)
        {
            left[i] = left[i - 1] + (s[i] == 'b' ? 1 : 0);
        }

        for (int i = s.Length - 2; i >= 0; i--)
        {
            right[i] = right[i + 1] + (s[i] == 'a' ? 1 : 0);
        }

        int minDeletions = Math.Min(left[s.Length - 1], right[0]);
        for (int i = 0; i < s.Length - 1; i++)
        {
            minDeletions = Math.Min(minDeletions, left[i] + right[i + 1]);
        }

        return minDeletions;
    }
}