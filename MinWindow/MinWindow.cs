namespace MinWindow;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "ADOBECODEBANC", t = "ABC"
        // Output: "BANC"
        // Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.

        // Example 2:
        //
        // Input: s = "a", t = "a"
        // Output: "a"
        // Explanation: The entire string s is the minimum window.

        // Example 3:
        //
        // Input: s = "a", t = "aa"
        // Output: ""
        // Explanation: Both 'a's from t must be included in the window.
        // Since the largest window of s only has one 'a', return empty string.

        Solution solution = new();

        Console.WriteLine(solution.MinWindow("ADOBECODEBANC", "ABC"));
        Console.WriteLine(solution.MinWindow("a", "a"));
        Console.WriteLine(solution.MinWindow("a", "aa"));
    }

    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

        int[] targetCount = new int[128];

        foreach (char c in t) targetCount[c]++;

        int left = 0, right = 0;
        int minLen = int.MaxValue;
        int minStart = 0;
        int requiredChars = t.Length;

        while (right < s.Length)
        {
            if (targetCount[s[right++]]-- > 0) requiredChars--;

            while (requiredChars == 0)
            {
                if (right - left < minLen)
                {
                    minLen = right - left;
                    minStart = left;
                }

                if (targetCount[s[left++]]++ == 0) requiredChars++;
            }
        }

        if (minLen == int.MaxValue) return "";
        return s.Substring(minStart, minLen);
    }
}