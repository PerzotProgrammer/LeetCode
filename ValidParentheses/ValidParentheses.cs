namespace ValidParentheses;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: s = "()"
        // Output: true
        // Example 2:

        // Input: s = "()[]{}"
        // Output: true
        // Example 3:

        // Input: s = "(]"
        // Output: false

        string inp1 = "()";
        string inp2 = "()[]{}";
        string inp3 = "(]";
        string inp4 = "{[]}";
        string inp5 = "([)]";

        Solution solution = new();
        Console.WriteLine(solution.IsValid(inp1));
        Console.WriteLine(solution.IsValid(inp2));
        Console.WriteLine(solution.IsValid(inp3));
        Console.WriteLine(solution.IsValid(inp4));
        Console.WriteLine(solution.IsValid(inp5));
    }

    public bool IsValid(string s)
    {
        while (s.Contains("()") || s.Contains("{}") || s.Contains("[]"))
        {
            s = s.Replace("()", "");
            s = s.Replace("{}", "");
            s = s.Replace("[]", "");
        }

        return s.Length == 0;
    }
}