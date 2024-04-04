namespace MaxDepth;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "(1+(2*3)+((8)/4))+1"
        // Output: 3
        // Explanation: Digit 8 is inside of 3 nested parentheses in the string.
        //     Example 2:
        //
        // Input: s = "(1)+((2))+(((3)))"
        // Output: 3

        Solution solution = new();

        Console.WriteLine(solution.MaxDepth("(1+(2*3)+((8)/4))+1"));
        Console.WriteLine(solution.MaxDepth("(1)+((2))+(((3)))"));
    }

    public int MaxDepth(string s)
    {
        int maxDepth = 0;
        int currentDepth = 0;
        Stack<char> stack = new();

        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
                currentDepth = stack.Count;
                maxDepth = Math.Max(maxDepth, currentDepth);
            }
            else if (c == ')') stack.Pop();
        }

        return maxDepth;
    }
}