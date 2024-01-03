﻿namespace NumberOfBeams;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: bank = ["011001","000000","010100","001000"]
        // Output: 8
        // Explanation: Between each of the following device pairs, there is one beam. In total, there are 8 beams:
        // * bank[0][1] -- bank[2][1]
        //     * bank[0][1] -- bank[2][3]
        //     * bank[0][2] -- bank[2][1]
        //     * bank[0][2] -- bank[2][3]
        //     * bank[0][5] -- bank[2][1]
        //     * bank[0][5] -- bank[2][3]
        //     * bank[2][1] -- bank[3][2]
        //     * bank[2][3] -- bank[3][2]
        // Note that there is no beam between any device on the 0th row with any on the 3rd row.
        // This is because the 2nd row contains security devices, which breaks the second condition.


        // Example 2:
        //
        //
        // Input: bank = ["000","111","000"]
        // Output: 0
        // Explanation: There does not exist two devices located on two different rows.

        string[] b1 = { "011001", "000000", "010100", "001000" };
        string[] b2 = { "000", "111", "000" };

        Solution solution = new();

        Console.WriteLine(solution.NumberOfBeams(b1));
        Console.WriteLine(solution.NumberOfBeams(b2));
    }

    public int NumberOfBeams(string[] bank)
    {
        int numOfBeams = 0;
        int prevRow = 0;

        foreach (string rowOfBeams in bank)
        {
            int count = rowOfBeams.Count(n => n == '1');
            if (count > 0)
            {
                numOfBeams += prevRow * count;
                prevRow = count;
            }
        }

        return numOfBeams;
    }
}