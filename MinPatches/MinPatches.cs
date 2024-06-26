﻿namespace MinPatches;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3], n = 6
        // Output: 1
        // Explanation:
        // Combinations of nums are [1], [3], [1,3], which form possible sums of: 1, 3, 4.
        // Now if we add/patch 2 to nums, the combinations are: [1], [2], [3], [1,3], [2,3], [1,2,3].
        // Possible sums are 1, 2, 3, 4, 5, 6, which now covers the range [1, 6].
        // So we only need 1 patch.

        // Example 2:
        //
        // Input: nums = [1,5,10], n = 20
        // Output: 2
        // Explanation: The two patches can be [2, 4].

        // Example 3:
        //
        // Input: nums = [1,2,2], n = 5
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.MinPatches([1, 3], 6));
        Console.WriteLine(solution.MinPatches([1, 5, 10], 20));
        Console.WriteLine(solution.MinPatches([1, 2, 2], 5));
    }

    public int MinPatches(int[] nums, int n)
    {
        int patches = 0;
        long maxSumCovered = 0;
        int i = 0;

        while (maxSumCovered < n)
        {
            if (i < nums.Length && nums[i] <= maxSumCovered + 1)
            {
                maxSumCovered += nums[i];
                i++;
            }
            else
            {
                maxSumCovered += maxSumCovered + 1;
                patches++;
            }
        }

        return patches;
    }
}