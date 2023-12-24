namespace MinOperations;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "0100"
        // Output: 1
        // Explanation: If you change the last character to '1', s will be "0101", which is alternating.

        // Example 2:
        //
        // Input: s = "10"
        // Output: 0
        // Explanation: s is already alternating.

        // Example 3:
        //
        // Input: s = "1111"
        // Output: 2
        // Explanation: You need two operations to reach "0101" or "1010".

        string s1 = "0100";
        string s2 = "10";
        string s3 = "1111";

        Solution solution = new();

        Console.WriteLine(solution.MinOperations(s1));
        Console.WriteLine(solution.MinOperations(s2));
        Console.WriteLine(solution.MinOperations(s3));
    }

    public int MinOperations(string s)
    {
        int ops0 = 0;
        int ops1 = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (s[i] == '0') ops1++;
                else ops0++;
            }
            else
            {
                if (s[i] == '1') ops1++;
                else ops0++;
            }
        }


        return Math.Min(ops0, ops1);
    }
}