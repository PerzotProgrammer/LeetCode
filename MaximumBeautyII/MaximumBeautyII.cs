namespace MaximumBeautyII;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [4,6,1,2], k = 2
        // Output: 3
        // Explanation: In this example, we apply the following operations:
        // - Choose index 1, replace it with 4 (from range [4,8]), nums = [4,4,1,2].
        // - Choose index 3, replace it with 4 (from range [0,4]), nums = [4,4,1,4].
        // After the applied operations, the beauty of the array nums is 3 (subsequence consisting of indices 0, 1, and 3).
        // It can be proven that 3 is the maximum possible length we can achieve.

        // Example 2:
        //
        // Input: nums = [1,1,1,1], k = 10
        // Output: 4
        // Explanation: In this example we don't have to apply any operations.
        // The beauty of the array nums is 4 (whole array).


        Solution solution = new();

        Console.WriteLine(solution.MaximumBeauty([4, 6, 1, 2], 2));
        Console.WriteLine(solution.MaximumBeauty([1, 1, 1, 1], 10));
    }

    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);
        int right = 0;
        int maxBeauty = 0;

        for (int left = 0; left < nums.Length; left++)
        {
            while (right < nums.Length && nums[right] - nums[left] <= 2 * k) right++;

            maxBeauty = Math.Max(maxBeauty, right - left);
        }

        return maxBeauty;
    }
}