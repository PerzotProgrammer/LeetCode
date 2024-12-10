namespace MaximumLength;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "aaaa"
        // Output: 2
        // Explanation: The longest special substring which occurs thrice is "aa": substrings "aaaa", "aaaa", and "aaaa".
        // It can be shown that the maximum length achievable is 2.

        // Example 2:
        //
        // Input: s = "abcdef"
        // Output: -1
        // Explanation: There exists no special substring which occurs at least thrice. Hence return -1.

        // Example 3:
        //
        // Input: s = "abcaba"
        // Output: 1
        // Explanation: The longest special substring which occurs thrice is "a": substrings "abcaba", "abcaba", and "abcaba".
        // It can be shown that the maximum length achievable is 1.


        Solution solution = new();

        Console.WriteLine(solution.MaximumLength("aaaa"));
        Console.WriteLine(solution.MaximumLength("abcdef"));
        Console.WriteLine(solution.MaximumLength("abcaba"));
    }

    public int MaximumLength(string s)
    {
        HashSet<string> subStrs = new();
        Dictionary<string, int> dict = new();

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 1; j < s.Length - i + 1; j++)
            {
                string sub = s.Substring(i, j);
                if (s[i] != sub[^1])
                    break;
                subStrs.Add(sub);
            }
        }

        foreach (string subStr in subStrs)
        {
            for (int i = 0; i < s.Length - subStr.Length + 1; i++)
            {
                string sub = s.Substring(i, subStr.Length);
                if (subStr == sub)
                {
                    dict.TryAdd(subStr, 0);
                    dict[subStr]++;
                }
            }
        }

        int res = -1;
        foreach (KeyValuePair<string, int> item in dict)
        {
            if (item.Value >= 3) res = Math.Max(res, item.Key.Length);
        }

        return res;
    }
}