﻿namespace SubsetXORSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3]
        // Output: 6
        // Explanation: The 4 subsets of [1,3] are:
        // - The empty subset has an XOR total of 0.
        // - [1] has an XOR total of 1.
        // - [3] has an XOR total of 3.
        // - [1,3] has an XOR total of 1 XOR 3 = 2.
        // 0 + 1 + 3 + 2 = 6

        // Example 2:
        //
        // Input: nums = [5,1,6]
        // Output: 28
        // Explanation: The 8 subsets of [5,1,6] are:
        // - The empty subset has an XOR total of 0.
        // - [5] has an XOR total of 5.
        // - [1] has an XOR total of 1.
        // - [6] has an XOR total of 6.
        // - [5,1] has an XOR total of 5 XOR 1 = 4.
        // - [5,6] has an XOR total of 5 XOR 6 = 3.
        // - [1,6] has an XOR total of 1 XOR 6 = 7.
        // - [5,1,6] has an XOR total of 5 XOR 1 XOR 6 = 2.
        // 0 + 5 + 1 + 6 + 4 + 3 + 7 + 2 = 28

        // Example 3:
        //
        // Input: nums = [3,4,5,6,7,8]
        // Output: 480
        // Explanation: The sum of all XOR totals for every subset is 480.


        Solution solution = new();

        Console.WriteLine(solution.SubsetXORSum([1, 3]));
        Console.WriteLine(solution.SubsetXORSum([5, 1, 6]));
        Console.WriteLine(solution.SubsetXORSum([3, 4, 5, 6, 7, 8]));
    }

    public int SubsetXORSum(int[] nums)
    {
        int totalSum = 0;

        for (int i = 0; i < 1 << nums.Length; i++)
        {
            int currentXor = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if ((i & (1 << j)) != 0) currentXor ^= nums[j];
            }

            totalSum += currentXor;
        }

        return totalSum;
    }
}