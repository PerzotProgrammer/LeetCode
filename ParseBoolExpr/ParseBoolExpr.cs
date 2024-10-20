namespace ParseBoolExpr;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: expression = "&(|(f))"
        // Output: false
        // Explanation: 
        // First, evaluate |(f) --> f. The expression is now "&(f)".
        // Then, evaluate &(f) --> f. The expression is now "f".
        // Finally, return false.

        // Example 2:
        //
        // Input: expression = "|(f,f,f,t)"
        // Output: true
        // Explanation: The evaluation of (false OR false OR false OR true) is true.

        // Example 3:
        //
        // Input: expression = "!(&(f,t))"
        // Output: true
        // Explanation: 
        // First, evaluate &(f,t) --> (false AND true) --> false --> f. The expression is now "!(f)".
        // Then, evaluate !(f) --> NOT false --> true. We return true.


        Solution solution = new();

        Console.WriteLine(solution.ParseBoolExpr("&(|(f))"));
        Console.WriteLine(solution.ParseBoolExpr("|(f,f,f,t)"));
        Console.WriteLine(solution.ParseBoolExpr("!(&(f,t))"));
    }

    public bool ParseBoolExpr(string expression)
    {
        Stack<char> stack = new();

        foreach (char c in expression)
        {
            if (c == ',') continue;
            if (c != ')') stack.Push(c);
            else
            {
                List<char> subExpr = new();

                while (stack.Peek() != '(')
                {
                    subExpr.Add(stack.Pop());
                }

                stack.Pop();
                char op = stack.Pop();
                bool result = false;

                if (op == '!') result = subExpr[0] == 'f';
                else if (op == '&') result = !subExpr.Contains('f');
                else if (op == '|') result = subExpr.Contains('t');

                stack.Push(result ? 't' : 'f');
            }
        }

        return stack.Pop() == 't';
    }
}