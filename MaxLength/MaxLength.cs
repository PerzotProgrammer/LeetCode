namespace MaxLength;

class Solution
{
    static void Main()
    {
        // Po dłuższym próbowaniu poddałem się.
        // Link do wątku, z którego to zrobiłem: https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/solutions/2738434/shortest-recursive-solution-super-clear/?envType=daily-question&envId=2024-01-23

        // Example 1:
        //
        // Input: arr = ["un","iq","ue"]
        // Output: 4
        // Explanation: All the valid concatenations are:
        // - ""
        //     - "un"
        //     - "iq"
        //     - "ue"
        //     - "uniq" ("un" + "iq")
        //     - "ique" ("iq" + "ue")
        // Maximum length is 4.

        // Example 2:
        //
        // Input: arr = ["cha","r","act","ers"]
        // Output: 6
        // Explanation: Possible longest valid concatenations are "chaers" ("cha" + "ers") and "acters" ("act" + "ers").

        // Example 3:
        //
        // Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
        // Output: 26
        // Explanation: The only string in arr has all 26 characters.

        Solution solution = new();
        Console.WriteLine(solution.MaxLength(["un", "iq", "ue"]));
        Console.WriteLine(solution.MaxLength(["cha", "r", "act", "ers"]));
        Console.WriteLine(solution.MaxLength(["abcdefghijklmnopqrstuvwxyz"]));
        Console.WriteLine(solution.MaxLength(["aa", "bb"]));
        Console.WriteLine(solution.MaxLength(["nytozalihusjd", "mi"]));
        Console.WriteLine(solution.MaxLength(["ab", "cd", "cde", "cdef", "efg", "fgh", "abxyz"]));
    }

    public int MaxLength(IList<string> arr, int i = 0, string s = "")
    {
        if (s.Distinct().Count() < s.Length) return 0;

        if (arr.Count == i) return s.Length;

        return Math.Max(MaxLength(arr, i + 1, s), MaxLength(arr, i + 1, s + arr[i]));
    }
}