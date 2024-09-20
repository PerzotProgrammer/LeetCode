namespace ShortestPalindrome;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "aacecaaa"
        // Output: "aaacecaaa"

        // Example 2:
        //
        // Input: s = "abcd"
        // Output: "dcbabcd"

        Solution solution = new();

        Console.WriteLine(solution.ShortestPalindrome("aacecaaa"));
        Console.WriteLine(solution.ShortestPalindrome("abcd"));
    }

    public string ShortestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;

        int n = s.Length;
        int end = n - 1;
        int j = 0;

        while (end >= 0)
        {
            if (s[end] == s[j]) j++;
            end--;
        }

        if (j == n) return s;

        string suffix = s.Substring(j);
        char[] charArray = suffix.ToCharArray();
        Array.Reverse(charArray);
        string revSuffix = new string(charArray);
        return revSuffix + ShortestPalindrome(s.Substring(0, j)) + suffix;
    }
}