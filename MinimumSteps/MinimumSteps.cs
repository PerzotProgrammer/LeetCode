namespace MinimumSteps;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "101"
        // Output: 1
        // Explanation: We can group all the black balls to the right in the following way:
        // - Swap s[0] and s[1], s = "011".
        // Initially, 1s are not grouped together, requiring at least 1 step to group them to the right.

        // Example 2:
        //
        // Input: s = "100"
        // Output: 2
        // Explanation: We can group all the black balls to the right in the following way:
        // - Swap s[0] and s[1], s = "010".
        // - Swap s[1] and s[2], s = "001".
        // It can be proven that the minimum number of steps needed is 2.

        // Example 3:
        //
        // Input: s = "0111"
        // Output: 0
        // Explanation: All the black balls are already grouped to the right.


        Solution solution = new();

        Console.WriteLine(solution.MinimumSteps("101"));
        Console.WriteLine(solution.MinimumSteps("100"));
        Console.WriteLine(solution.MinimumSteps("0111"));
    }

    public long MinimumSteps(string s)
    {
        int whitePosition = 0;
        long totalSwaps = 0;

        for (int currentPos = 0; currentPos < s.Length; currentPos++)
        {
            if (s[currentPos] == '0')
            {
                totalSwaps += currentPos - whitePosition;
                whitePosition++;
            }
        }

        return totalSwaps;
    }
}