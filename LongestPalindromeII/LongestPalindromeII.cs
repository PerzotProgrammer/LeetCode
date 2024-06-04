namespace LongestPalindromeII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "abccccdd"
        // Output: 7
        // Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
        
        // Example 2:
        //
        // Input: s = "a"
        // Output: 1
        // Explanation: The longest palindrome that can be built is "a", whose length is 1.


        Solution solution = new();

        Console.WriteLine(solution.LongestPalindrome("abccccdd"));
        Console.WriteLine(solution.LongestPalindrome("a"));
    }

    public int LongestPalindrome(string s)
    {
        int[] charCount = new int[128];

        foreach (char c in s) charCount[c]++;

        int length = 0;
        bool hasOddCount = false;

        foreach (int count in charCount)
        {
            if (count % 2 == 0) length += count;
            else
            {
                length += count - 1;
                hasOddCount = true;
            }
        }

        if (hasOddCount) length += 1;

        return length;
    }
}