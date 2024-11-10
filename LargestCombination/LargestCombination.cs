﻿namespace LargestCombination;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: candidates = [16,17,71,62,12,24,14]
        // Output: 4
        // Explanation: The combination [16,17,62,24] has a bitwise AND of 16 & 17 & 62 & 24 = 16 > 0.
        // The size of the combination is 4.
        // It can be shown that no combination with a size greater than 4 has a bitwise AND greater than 0.
        // Note that more than one combination may have the largest size.
        // For example, the combination [62,12,24,14] has a bitwise AND of 62 & 12 & 24 & 14 = 8 > 0.

        // Example 2:
        //
        // Input: candidates = [8,8]
        // Output: 2
        // Explanation: The largest combination [8,8] has a bitwise AND of 8 & 8 = 8 > 0.
        // The size of the combination is 2, so we return 2.


        Solution solution = new();

        Console.WriteLine(solution.LargestCombination([16, 17, 71, 62, 12, 24, 14]));
        Console.WriteLine(solution.LargestCombination([8, 8]));
    }

    public int LargestCombination(int[] candidates)
    {
        int[] bitCount = new int[24];
        for (int i = 0; i < 24; i++)
        {
            foreach (int num in candidates)
            {
                if ((num & (1 << i)) != 0) bitCount[i]++;
            }
        }

        int max = 0;
        foreach (int count in bitCount)
        {
            if (count > max) max = count;
        }

        return max;
    }
}