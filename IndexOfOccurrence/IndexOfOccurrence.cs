namespace IndexOfOccurrence;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: haystack = "sadbutsad", needle = "sad"
        // Output: 0
        // Explanation: "sad" occurs at index 0 and 6.
        //     The first occurrence is at index 0, so we return 0.
        //     Example 2:
        //
        // Input: haystack = "leetcode", needle = "leeto"
        // Output: -1
        // Explanation: "leeto" did not occur in "leetcode", so we return -1.

        string s1a = "sadbutsad";
        string s1b = "sad";
        string s2a = "leetcode";
        string s2b = "leeto";

        Solution solution = new();
        
        Console.WriteLine(solution.StrStr(s1a, s1b));
        Console.WriteLine(solution.StrStr(s2a, s2b));
    }

    public int StrStr(string haystack, string needle)
    {
        if (!haystack.Contains(needle)) return -1;
        return haystack.IndexOf(needle, StringComparison.Ordinal);
    }
}

