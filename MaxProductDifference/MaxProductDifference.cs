﻿namespace MaxProductDifference;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [5,6,2,7,4]
        // Output: 34
        // Explanation: We can choose indices 1 and 3 for the first pair (6, 7) and indices 2 and 4 for the second pair (2, 4).
        //     The product difference is (6 * 7) - (2 * 4) = 34.

        //     Example 2:
        //
        // Input: nums = [4,2,5,9,7,4,8]
        // Output: 64
        // Explanation: We can choose indices 3 and 6 for the first pair (9, 8) and indices 1 and 5 for the second pair (2, 4).
        //     The product difference is (9 * 8) - (2 * 4) = 64.

        int[] n1 = { 5, 6, 2, 7, 4 };
        int[] n2 = { 4, 2, 5, 9, 7, 4, 8 };

        Solution solution = new();

        Console.WriteLine(solution.MaxProductDifference(n1));
        Console.WriteLine(solution.MaxProductDifference(n2));
    }

    public int MaxProductDifference(int[] nums)
    {
        Array.Sort(nums);
        return nums[^1] * nums[^2] - nums[0] * nums[1];
    }
}