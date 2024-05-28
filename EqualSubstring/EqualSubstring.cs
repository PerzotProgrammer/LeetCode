namespace EqualSubstring;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "abcd", t = "bcdf", maxCost = 3
        // Output: 3
        // Explanation: "abc" of s can change to "bcd".
        // That costs 3, so the maximum length is 3.

        // Example 2:
        //
        // Input: s = "abcd", t = "cdef", maxCost = 3
        // Output: 1
        // Explanation: Each character in s costs 2 to change to character in t,  so the maximum length is 1.

        // Example 3:
        //
        // Input: s = "abcd", t = "acde", maxCost = 0
        // Output: 1
        // Explanation: You cannot make any change, so the maximum length is 1.


        Solution solution = new();

        Console.WriteLine(solution.EqualSubstring("abcd", "bcdf", 3));
        Console.WriteLine(solution.EqualSubstring("abcd", "cdef", 3));
        Console.WriteLine(solution.EqualSubstring("abcd", "acde", 0));
    }

    public int EqualSubstring(string s, string t, int maxCost)
    {
        int maxLength = 0;
        int start = 0;
        int currentCost = 0;

        for (int i = 0; i < s.Length; i++)
        {
            currentCost += Math.Abs(s[i] - t[i]);
            while (currentCost > maxCost)
            {
                currentCost -= Math.Abs(s[start] - t[start]);
                start++;
            }

            maxLength = Math.Max(maxLength, i - start + 1);
        }

        return maxLength;
    }
}