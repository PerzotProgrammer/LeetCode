namespace MinAddToMakeValid;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "())"
        // Output: 1

        // Example 2:
        //
        // Input: s = "((("
        // Output: 3

        Solution solution = new();

        Console.WriteLine(solution.MinAddToMakeValid("())"));
        Console.WriteLine(solution.MinAddToMakeValid("((("));
    }

    public int MinAddToMakeValid(string S)
    {
        int open = 0;
        int close = 0;

        foreach (char c in S)
        {
            if (c == '(') open++;
            else if (c == ')')
            {
                if (open > 0) open--;
                else close++;
            }
        }

        return open + close;
    }
}