namespace MinimumSubarrayLength;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/shortest-subarray-with-or-at-least-k-ii/solutions/6028715/c-solution-for-shortest-subarray-with-or-at-least-k-ii-problem/?envType=daily-question&envId=2024-11-10
        // Example 1:
        //
        // Input: nums = [1,2,3], k = 2
        // Output: 1
        // Explanation:
        // The subarray [3] has OR value of 3. Hence, we return 1.

        // Example 2:
        //
        // Input: nums = [2,1,8], k = 10
        // Output: 3
        // Explanation:
        // The subarray [2,1,8] has OR value of 11. Hence, we return 3.

        // Example 3:
        //
        // Input: nums = [1,2], k = 0
        // Output: 1
        // Explanation:
        // The subarray [1] has OR value of 1. Hence, we return 1.


        Solution solution = new();

        Console.WriteLine(solution.MinimumSubarrayLength([1, 2, 3], 2));
        Console.WriteLine(solution.MinimumSubarrayLength([2, 1, 8], 10));
        Console.WriteLine(solution.MinimumSubarrayLength([1, 2], 0));
    }

    public int MinimumSubarrayLength(int[] nums, int k)
    {
        int minLength = int.MaxValue;
        int windowStart = 0;
        int windowEnd = 0;
        int[] bitCounts = new int[32];

        while (windowEnd < nums.Length)
        {
            UpdateBitCounts(bitCounts, nums[windowEnd], 1);

            while (windowStart <= windowEnd && ConvertBitCountsToNumber(bitCounts) >= k)
            {
                minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                UpdateBitCounts(bitCounts, nums[windowStart], -1);
                windowStart++;
            }

            windowEnd++;
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }

    private void UpdateBitCounts(int[] bitCounts, int number, int delta)
    {
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            if (((number >> bitPosition) & 1) != 0) bitCounts[bitPosition] += delta;
        }
    }

    private int ConvertBitCountsToNumber(int[] bitCounts)
    {
        int result = 0;
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            if (bitCounts[bitPosition] != 0) result |= 1 << bitPosition;
        }

        return result;
    }
}