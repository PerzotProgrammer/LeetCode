namespace StrangePrinter;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "aaabbb"
        // Output: 2
        // Explanation: Print "aaa" first and then print "bbb".

        // Example 2:
        //
        // Input: s = "aba"
        // Output: 2
        // Explanation: Print "aaa" first and then print "b" from the second place of the string, which will cover the existing character 'a'.


        Solution solution = new();

        Console.WriteLine(solution.StrangePrinter("aaabbb"));
        Console.WriteLine(solution.StrangePrinter("aba"));
    }

    public int StrangePrinter(string s)
    {
        int[,] memo = new int[s.Length, s.Length];
        return MinTurns(s, 0, s.Length - 1, memo);
    }

    private int MinTurns(string s, int i, int j, int[,] memo)
    {
        if (i > j) return 0;
        if (memo[i, j] != 0) return memo[i, j];

        int minTurns = MinTurns(s, i, j - 1, memo) + 1;

        for (int k = i; k < j; k++)
        {
            if (s[k] == s[j])
            {
                int turns = MinTurns(s, i, k, memo) + MinTurns(s, k + 1, j - 1, memo);
                minTurns = Math.Min(minTurns, turns);
            }
        }

        memo[i, j] = minTurns;
        return minTurns;
    }
}