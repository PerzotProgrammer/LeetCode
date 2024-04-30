namespace WonderfulSubstrings;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: word = "aba"
        // Output: 4
        // Explanation: The four wonderful substrings are underlined below:
        // - "aba" -> "a"
        // - "aba" -> "b"
        // - "aba" -> "a"
        // - "aba" -> "aba"
        // Example 2:
        //
        // Input: word = "aabb"
        // Output: 9
        // Explanation: The nine wonderful substrings are underlined below:
        // - "aabb" -> "a"
        // - "aabb" -> "aa"
        // - "aabb" -> "aab"
        // - "aabb" -> "aabb"
        // - "aabb" -> "a"
        // - "aabb" -> "abb"
        // - "aabb" -> "b"
        // - "aabb" -> "bb"
        // - "aabb" -> "b"
        // Example 3:
        //
        // Input: word = "he"
        // Output: 2
        // Explanation: The two wonderful substrings are underlined below:
        // - "he" -> "h"
        // - "he" -> "e"

        Solution solution = new();

        Console.WriteLine(solution.WonderfulSubstrings("aba"));
        Console.WriteLine(solution.WonderfulSubstrings("aabb"));
        Console.WriteLine(solution.WonderfulSubstrings("he"));
    }

    public long WonderfulSubstrings(string word)
    {
        Dictionary<int, int> maskFreq = new();
        int bitMask = 0;
        long output = 0;
        maskFreq[bitMask] = 1;
        foreach (char ch in word)
        {
            bitMask ^= 1 << (ch - 'a');
            for (int i = 0; i < 10; i++)
            {
                if (maskFreq.TryGetValue(bitMask ^ (1 << i), out int oneBitDiffFreq)) output += oneBitDiffFreq;
            }

            if (maskFreq.TryGetValue(bitMask, out int freq))
            {
                output += freq;
                maskFreq[bitMask]++;
            }
            else maskFreq[bitMask] = 1;
        }

        return output;
    }
}