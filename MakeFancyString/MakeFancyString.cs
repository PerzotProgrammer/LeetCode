using System.Text;

namespace MakeFancyString;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "leeetcode"
        // Output: "leetcode"
        // Explanation:
        // Remove an 'e' from the first group of 'e's to create "leetcode".
        // No three consecutive characters are equal, so return "leetcode".

        // Example 2:
        //
        // Input: s = "aaabaaaa"
        // Output: "aabaa"
        // Explanation:
        // Remove an 'a' from the first group of 'a's to create "aabaaaa".
        // Remove two 'a's from the second group of 'a's to create "aabaa".
        // No three consecutive characters are equal, so return "aabaa".

        // Example 3:
        //
        // Input: s = "aab"
        // Output: "aab"
        // Explanation: No three consecutive characters are equal, so return "aab".


        Solution solution = new();

        Console.WriteLine(solution.MakeFancyString("leeetcode"));
        Console.WriteLine(solution.MakeFancyString("aaabaaaa"));
    }

    public string MakeFancyString(string s)
    {
        StringBuilder result = new();
        foreach (char c in s)
        {
            int len = result.Length;
            if (len >= 2 && result[len - 1] == c && result[len - 2] == c) continue;
            result.Append(c);
        }

        return result.ToString();
    }
}