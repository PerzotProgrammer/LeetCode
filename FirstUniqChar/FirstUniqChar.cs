namespace FirstUniqChar;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "leetcode"
        // Output: 0
        
        // Example 2:
        //
        // Input: s = "loveleetcode"
        // Output: 2
        
        // Example 3:
        //
        // Input: s = "aabb"
        // Output: -1

        Solution solution = new();

        Console.WriteLine(solution.FirstUniqChar("leetcode"));
        Console.WriteLine(solution.FirstUniqChar("loveleetcode"));
        Console.WriteLine(solution.FirstUniqChar("aabb"));
    }
    
    public int FirstUniqChar(string s)
    {

        foreach (char c in s) if (s.IndexOf(c) == s.LastIndexOf(c)) return s.IndexOf(c);
        
        return -1;
    }
}