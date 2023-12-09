namespace LongestPalindrome;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "babad"
        // Output: "bab"
        // Explanation: "aba" is also a valid answer.
        //     Example 2:
        //
        // Input: s = "cbbd"
        // Output: "bb"

        string s1 = "babad";
        string s2 = "cbbd";

        Solution solution = new();

        Console.WriteLine(solution.LongestPalindrome(s1));
        Console.WriteLine(solution.LongestPalindrome(s2));
    }

    public string LongestPalindrome(string s)
    {
        if (IsPalindrome(s)) return s;
        
        List<string> palindromes = new();

        for (int i = 0; i < s.Length; i++)
        {
            string check = "";
            for (int j = i; j < s.Length; j++)
            {
                check += s[j];
                if (IsPalindrome(check)) palindromes.Add(check);
            }
        }

        string longest = "";
        int longestLength = 0;
        foreach (string palindrome in palindromes)
        {
            if (palindrome.Length > longestLength)
            {
                longest = palindrome;
                longestLength = palindrome.Length;
            }
        }

        return longest;
    }
    
    static bool IsPalindrome(string check)
    {
        int length = check.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (check[i] != check[length - i - 1]) return false;
        }

        return true;
    }
}