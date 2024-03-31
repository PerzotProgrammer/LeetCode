namespace CountSubarraysK;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
        // Output: 2
        // Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].

        // Example 2:
        //
        // Input: nums = [1,1,1,1], minK = 1, maxK = 1
        // Output: 10
        // Explanation: Every subarray of nums is a fixed-bound subarray. There are 10 possible subarrays.

        Solution solution = new();

        Console.WriteLine(solution.CountSubarrays([1, 3, 5, 2, 7, 5], 1, 5));
        Console.WriteLine(solution.CountSubarrays([1, 1, 1, 1], 1, 1));
    }

    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long output = 0;
        int badIndex = -1;
        int leftIndex = -1;
        int rightIndex = -1;

        for (int i = 0; i < nums.Length; ++i)
        {
            if (!(minK <= nums[i] && nums[i] <= maxK)) badIndex = i;
            if (nums[i] == minK) leftIndex = i;
            if (nums[i] == maxK) rightIndex = i;
            output += Math.Max(0, Math.Min(leftIndex, rightIndex) - badIndex);
        }

        return output;
    }
}