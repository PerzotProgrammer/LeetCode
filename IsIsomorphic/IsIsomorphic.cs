namespace IsIsomorphic;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "egg", t = "add"
        // Output: true

        // Example 2:
        //
        // Input: s = "foo", t = "bar"
        // Output: false

        // Example 3:
        //
        // Input: s = "paper", t = "title"
        // Output: true

        Solution solution = new();

        Console.WriteLine(solution.IsIsomorphic("egg", "add"));
        Console.WriteLine(solution.IsIsomorphic("foo", "bar"));
        Console.WriteLine(solution.IsIsomorphic("paper", "title"));
        Console.WriteLine(solution.IsIsomorphic("badc", "baba"));
    }

    public bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> pair1 = new();
        Dictionary<char, char> pair2 = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (!pair1.TryAdd(s[i], t[i]))
            {
                if (pair1[s[i]] != t[i]) return false;
            }

            if (!pair2.TryAdd(t[i], s[i]))
            {
                if (pair2[t[i]] != s[i]) return false;
            }
        }

        return true;
    }
}