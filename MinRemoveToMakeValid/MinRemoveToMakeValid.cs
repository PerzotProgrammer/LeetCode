namespace MinRemoveToMakeValid;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "lee(t(c)o)de)"
        // Output: "lee(t(c)o)de"
        // Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.

        // Example 2:
        //
        // Input: s = "a)b(c)d"
        // Output: "ab(c)d"

        // Example 3:
        //
        // Input: s = "))(("
        // Output: ""
        // Explanation: An empty string is also valid.

        Solution solution = new();
        Console.WriteLine(solution.MinRemoveToMakeValid("lee(t(c)o)de)"));
        Console.WriteLine(solution.MinRemoveToMakeValid("a)b(c)d"));
        Console.WriteLine(solution.MinRemoveToMakeValid("))(("));
    }

    public string MinRemoveToMakeValid(string s)
    {
        Stack<int> stack = new();
        char[] chars = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') stack.Push(i);
            else if (s[i] == ')')
            {
                if (stack.Count > 0)
                {
                    int index = stack.Pop();
                    chars[index] = '(';
                    chars[i] = ')';
                }
            }
            else chars[i] = s[i];
        }

        string output = "";
        foreach (char c in chars)
        {
            if (c != '\u0000') output += c;
        }

        return output;
    }
}