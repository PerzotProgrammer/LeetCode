namespace MinBitFlips;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: start = 10, goal = 7
        // Output: 3
        // Explanation: The binary representation of 10 and 7 are 1010 and 0111 respectively. We can convert 10 to 7 in 3 steps:
        // - Flip the first bit from the right: 1010 -> 1011.
        // - Flip the third bit from the right: 1011 -> 1111.
        // - Flip the fourth bit from the right: 1111 -> 0111.
        // It can be shown we cannot convert 10 to 7 in less than 3 steps. Hence, we return 3.

        // Example 2:
        //
        // Input: start = 3, goal = 4
        // Output: 3
        // Explanation: The binary representation of 3 and 4 are 011 and 100 respectively. We can convert 3 to 4 in 3 steps:
        // - Flip the first bit from the right: 011 -> 010.
        // - Flip the second bit from the right: 010 -> 000.
        // - Flip the third bit from the right: 000 -> 100.
        // It can be shown we cannot convert 3 to 4 in less than 3 steps. Hence, we return 3.


        Solution solution = new();

        Console.WriteLine(solution.MinBitFlips(10, 7));
        Console.WriteLine(solution.MinBitFlips(3, 4));
    }

    public int MinBitFlips(int start, int goal)
    {
        int count = 0;
        while (start > 0 || goal > 0)
        {
            if ((start & 1) != (goal & 1)) count++;

            start >>= 1;
            goal >>= 1;
        }

        return count;
    }
}