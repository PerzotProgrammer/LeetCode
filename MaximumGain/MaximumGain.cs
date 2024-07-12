namespace MaximumGain;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "cdbcbbaaabab", x = 4, y = 5
        // Output: 19
        // Explanation:
        // - Remove the "ba" underlined in "cdbcbbaaabab". Now, s = "cdbcbbaaab" and 5 points are added to the score.
        // - Remove the "ab" underlined in "cdbcbbaaab". Now, s = "cdbcbbaa" and 4 points are added to the score.
        // - Remove the "ba" underlined in "cdbcbbaa". Now, s = "cdbcba" and 5 points are added to the score.
        // - Remove the "ba" underlined in "cdbcba". Now, s = "cdbc" and 5 points are added to the score.
        // Total score = 5 + 4 + 5 + 5 = 19.

        // Example 2:
        //
        // Input: s = "aabbaaxybbaabb", x = 5, y = 4
        // Output: 20


        Solution solution = new();

        Console.WriteLine(solution.MaximumGain("cdbcbbaaabab", 4, 5));
        Console.WriteLine(solution.MaximumGain("aabbaaxybbaabb", 5, 4));
    }

    public int MaximumGain(string s, int x, int y)
    {
        char a = 'a';
        char b = 'b';
        if (y > x)
        {
            (a, b) = (b, a);
            (x, y) = (y, x);
        }

        int score = 0;
        Stack<char> forwardStack = new();
        foreach (char ch in s)
            if (forwardStack.Count != 0 && ch == b && forwardStack.Peek() == a)
            {
                score += x;
                forwardStack.Pop();
            }
            else forwardStack.Push(ch);

        Stack<char> reverseStack = new();
        while (forwardStack.Count != 0)
            if (reverseStack.Count != 0 && reverseStack.Peek() == a && forwardStack.Peek() == b)
            {
                score += y;
                forwardStack.Pop();
                reverseStack.Pop();
            }
            else reverseStack.Push(forwardStack.Pop());

        return score;
    }
}