namespace MaxUniqueSplit;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "ababccc"
        // Output: 5
        // Explanation: One way to split maximally is ['a', 'b', 'ab', 'c', 'cc']. Splitting like ['a', 'b', 'a', 'b', 'c', 'cc'] is not valid as you have 'a' and 'b' multiple times.
        // Example 2:
        //
        // Input: s = "aba"
        // Output: 2
        // Explanation: One way to split maximally is ['a', 'ba'].

        // Example 3:
        //
        // Input: s = "aa"
        // Output: 1
        // Explanation: It is impossible to split the string any further.


        Solution solution = new();

        Console.WriteLine(solution.MaxUniqueSplit("ababccc"));
        Console.WriteLine(solution.MaxUniqueSplit("aba"));
        Console.WriteLine(solution.MaxUniqueSplit("aa"));
    }

    public int MaxUniqueSplit(string s)
    {
        HashSet<string> uniqueSubstrings = new();
        return Dfs(s, 0, uniqueSubstrings);
    }

    private int Dfs(string s, int start, HashSet<string> uniqueSubstrings)
    {
        if (start == s.Length) return 0;
        int maxSplits = 0;

        for (int i = start + 1; i <= s.Length; i++)
        {
            string currentSubstring = s.Substring(start, i - start);

            if (uniqueSubstrings.Add(currentSubstring))
            {
                maxSplits = Math.Max(maxSplits, 1 + Dfs(s, i, uniqueSubstrings));
                uniqueSubstrings.Remove(currentSubstring);
            }
        }

        return maxSplits;
    }
}