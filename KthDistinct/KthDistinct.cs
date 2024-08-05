namespace KthDistinct;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = ["d","b","c","b","c","a"], k = 2
        // Output: "a"
        // Explanation:
        // The only distinct strings in arr are "d" and "a".
        // "d" appears 1st, so it is the 1st distinct string.
        // "a" appears 2nd, so it is the 2nd distinct string.
        // Since k == 2, "a" is returned. 

        // Example 2:
        //
        // Input: arr = ["aaa","aa","a"], k = 1
        // Output: "aaa"
        // Explanation:
        // All strings in arr are distinct, so the 1st string "aaa" is returned.

        // Example 3:
        //
        // Input: arr = ["a","b","a"], k = 3
        // Output: ""
        // Explanation:
        // The only distinct string is "b". Since there are fewer than 3 distinct strings, we return an empty string "".


        Solution solution = new();

        Console.WriteLine(solution.KthDistinct(["d", "b", "c", "b", "c", "a"], 2));
        Console.WriteLine(solution.KthDistinct(["aaa", "aa", "a"], 1));
        Console.WriteLine(solution.KthDistinct(["a", "b", "a"], 3));
    }

    public string KthDistinct(string[] arr, int k)
    {
        Dictionary<string, int> freq = new();
        foreach (string s in arr)
        {
            if (!freq.TryAdd(s, 1)) freq[s]++;
        }

        int ithStr = 0;
        foreach (KeyValuePair<string, int> pair in freq)
        {
            if (pair.Value == 1)
            {
                ithStr++;
                if (ithStr == k) return pair.Key;
            }
        }

        return "";
    }
}