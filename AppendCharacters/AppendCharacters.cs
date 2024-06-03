namespace AppendCharacters;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "coaching", t = "coding"
        // Output: 4
        // Explanation: Append the characters "ding" to the end of s so that s = "coachingding".
        // Now, t is a subsequence of s ("coachingding").
        // It can be shown that appending any 3 characters to the end of s will never make t a subsequence.

        // Example 2:
        //
        // Input: s = "abcde", t = "a"
        // Output: 0
        // Explanation: t is already a subsequence of s ("abcde").

        // Example 3:
        //
        // Input: s = "z", t = "abcde"
        // Output: 5
        // Explanation: Append the characters "abcde" to the end of s so that s = "zabcde".
        // Now, t is a subsequence of s ("zabcde").
        // It can be shown that appending any 4 characters to the end of s will never make t a subsequence.


        Solution solution = new();

        Console.WriteLine(solution.AppendCharacters("coaching", "coding"));
        Console.WriteLine(solution.AppendCharacters("abcde", "a"));
        Console.WriteLine(solution.AppendCharacters("z", "abcde"));
    }

    public int AppendCharacters(string s, string t)
    {
        int first = 0;
        int longestPrefix = 0;

        while (first < s.Length && longestPrefix < t.Length)
        {
            if (s[first] == t[longestPrefix]) longestPrefix++;
            first++;
        }

        return t.Length - longestPrefix;
    }
}