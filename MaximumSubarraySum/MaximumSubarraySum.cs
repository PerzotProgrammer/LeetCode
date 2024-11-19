namespace MaximumSubarraySum;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [1,5,4,2,9,9,9], k = 3
        // Output: 15
        // Explanation: The subarrays of nums with length 3 are:
        // - [1,5,4] which meets the requirements and has a sum of 10.
        // - [5,4,2] which meets the requirements and has a sum of 11.
        // - [4,2,9] which meets the requirements and has a sum of 15.
        // - [2,9,9] which does not meet the requirements because the element 9 is repeated.
        // - [9,9,9] which does not meet the requirements because the element 9 is repeated.
        //     We return 15 because it is the maximum subarray sum of all the subarrays that meet the conditions

        // Example 2:
        //
        // Input: nums = [4,4,4], k = 3
        // Output: 0
        // Explanation: The subarrays of nums with length 3 are:
        // - [4,4,4] which does not meet the requirements because the element 4 is repeated.
        // We return 0 because no subarrays meet the conditions.


        Solution solution = new();

        Console.WriteLine(solution.MaximumSubarraySum([1, 5, 4, 2, 9, 9, 9], 3));
        Console.WriteLine(solution.MaximumSubarraySum([4, 4, 4], 3));
    }

    public long MaximumSubarraySum(int[] nums, int k)
    {
        long maxSum = 0, currentSum = 0;
        HashSet<int> window = new();
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            while (window.Contains(nums[right]))
            {
                window.Remove(nums[left]);
                currentSum -= nums[left];
                left++;
            }

            window.Add(nums[right]);
            currentSum += nums[right];

            if (right - left + 1 == k)
            {
                maxSum = Math.Max(maxSum, currentSum);
                window.Remove(nums[left]);
                currentSum -= nums[left];
                left++;
            }
        }

        return maxSum;
    }
}