namespace MinSteps;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "bab", t = "aba"
        // Output: 1
        // Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.
        
        // Example 2:
        //
        // Input: s = "leetcode", t = "practice"
        // Output: 5
        // Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters to make t anagram of s.
        
        // Example 3:
        //
        // Input: s = "anagram", t = "mangaar"
        // Output: 0
        // Explanation: "anagram" and "mangaar" are anagrams. 

        Solution solution = new();

        Console.WriteLine(solution.MinSteps("bab", "aba"));
        Console.WriteLine(solution.MinSteps("leetcode", "practice"));
        Console.WriteLine(solution.MinSteps("anagram", "mangaar"));
    }

    public int MinSteps(string s, string t)
    {
        int[] countOfChars = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            countOfChars[t[i] - 'a']++;
            countOfChars[s[i] - 'a']--;
        }

        int output = 0;

        for (int i = 0; i < 26; i++)
        {
            output += Math.Max(0, countOfChars[i]);
        }

        return output;
    }
}