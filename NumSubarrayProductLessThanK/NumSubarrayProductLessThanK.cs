namespace NumSubarrayProductLessThanK;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [10,5,2,6], k = 100
        // Output: 8
        // Explanation: The 8 subarrays that have product less than 100 are:
        // [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]
        // Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.

        // Example 2:
        //
        // Input: nums = [1,2,3], k = 0
        // Output: 0

        Solution solution = new();

        Console.WriteLine(solution.NumSubarrayProductLessThanK([10, 5, 2, 6], 100));
        Console.WriteLine(solution.NumSubarrayProductLessThanK([1, 2, 3], 0));
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;

        int totalCount = 0;
        int product = 1;

        int left = 0;
        int right = 0;
        for (; right < nums.Length; right++)
        {
            product *= nums[right];
            while (product >= k)
            {
                product /= nums[left];
                left++;
            }

            totalCount += right - left + 1;
        }

        return totalCount;
    }
}