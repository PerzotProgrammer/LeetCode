namespace CheckValidString;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "()"
        // Output: true

        // Example 2:
        //
        // Input: s = "(*)"
        // Output: true

        // Example 3:
        //
        // Input: s = "(*))"
        // Output: true

        Solution solution = new();

        Console.WriteLine(solution.CheckValidString("()"));
        Console.WriteLine(solution.CheckValidString("(*)"));
        Console.WriteLine(solution.CheckValidString("(*))"));
    }

    public bool CheckValidString(string s)
    {
        int leftMin = 0;
        int leftMax = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                leftMin++;
                leftMax++;
            }
            else if (c == ')')
            {
                leftMin--;
                leftMax--;
            }
            else
            {
                leftMin--;
                leftMax++;
            }

            if (leftMax < 0) return false;
            if (leftMin < 0) leftMin = 0;
        }

        return leftMin == 0;
    }
}