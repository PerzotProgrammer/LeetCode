namespace MinChanges;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "1001"
        // Output: 2
        // Explanation: We change s[1] to 1 and s[3] to 0 to get string "1100".
        // It can be seen that the string "1100" is beautiful because we can partition it into "11|00".
        // It can be proven that 2 is the minimum number of changes needed to make the string beautiful.

        // Example 2:
        //
        // Input: s = "10"
        // Output: 1
        // Explanation: We change s[1] to 1 to get string "11".
        // It can be seen that the string "11" is beautiful because we can partition it into "11".
        // It can be proven that 1 is the minimum number of changes needed to make the string beautiful.

        // Example 3:
        //
        // Input: s = "0000"
        // Output: 0
        // Explanation: We don't need to make any changes as the string "0000" is beautiful already.


        Solution solution = new();

        Console.WriteLine(solution.MinChanges("1001"));
        Console.WriteLine(solution.MinChanges("10"));
        Console.WriteLine(solution.MinChanges("0000"));
    }

    public int MinChanges(string s)
    {
        char currentChar = s[0];

        int consecutiveCount = 0;
        int minChangesRequired = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == currentChar)
            {
                consecutiveCount++;
                continue;
            }

            if (consecutiveCount % 2 == 0) consecutiveCount = 1;
            else
            {
                consecutiveCount = 0;
                minChangesRequired++;
            }

            currentChar = s[i];
        }

        return minChangesRequired;
    }
}