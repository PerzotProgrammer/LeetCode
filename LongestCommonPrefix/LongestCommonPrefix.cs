namespace LongestCommonPrefix;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: strs = ["flower","flow","flight"]
        // Output: "fl"

        // Example 2:

        // Input: strs = ["dog","racecar","car"]
        // Output: ""
        // Explanation: There is no common prefix among the input strings.
        string[] T1 = { "flower", "flow", "flight" };
        string[] T2 = { "dog", "racecar", "car" };
        string[] T3 = { "a" };
        
        Solution solution = new();

        Console.WriteLine(solution.LongestCommonPrefix(T1));
        Console.WriteLine(solution.LongestCommonPrefix(T2));
        Console.WriteLine(solution.LongestCommonPrefix(T3));
    }

    public string LongestCommonPrefix(string[] strs)
    {
        int strsLength = strs.Length;
        int shortestStrLength = strs[0].Length;
        int commonLength = 0;
        
        foreach (string str in strs)
        {
            if (shortestStrLength > str.Length) shortestStrLength = str.Length;
        }

        bool flag = false;
        
        for (int i = 0; i < shortestStrLength; i++)
        {
            char scope = strs[0][i];
            for (int j = 0; j < strsLength; j++)
            {
                if (strs[j][i] != scope) flag = true;
            }

            if (flag) break;
            commonLength++;
        }

        string output = "";
        for (int i = 0; i < commonLength; i++) output += strs[0][i];
        return output;
    }
}