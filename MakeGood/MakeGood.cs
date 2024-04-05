namespace MakeGood;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "leEeetcode"
        // Output: "leetcode"
        // Explanation: In the first step, either you choose i = 1 or i = 2, both will result "leEeetcode" to be reduced to "leetcode".

        // Example 2:
        //
        // Input: s = "abBAcC"
        // Output: ""
        // Explanation: We have many possible scenarios, and all lead to the same answer. For example:
        // "abBAcC" --> "aAcC" --> "cC" --> ""
        // "abBAcC" --> "abBA" --> "aA" --> ""

        // Example 3:
        //
        // Input: s = "s"
        // Output: "s"

        Solution solution = new();

        Console.WriteLine(solution.MakeGood("leEeetcode"));
        Console.WriteLine(solution.MakeGood("abBAcC"));
        Console.WriteLine(solution.MakeGood("s"));
    }

    public string MakeGood(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            char first = s[i];
            char second = s[i + 1];
            if (Math.Abs(first - second) == 32)
            {
                s = s.Remove(i, 2);
                if (i - 2 >= -1) i -= 2;
                else i = -1;
            }
        }

        return s;
    }
}