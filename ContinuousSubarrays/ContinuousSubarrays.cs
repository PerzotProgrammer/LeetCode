namespace ContinuousSubarrays;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [5,4,2,4]
        // Output: 8
        // Explanation: 
        // Continuous subarray of size 1: [5], [4], [2], [4].
        // Continuous subarray of size 2: [5,4], [4,2], [2,4].
        // Continuous subarray of size 3: [4,2,4].
        // Thereare no subarrys of size 4.
        // Total continuous subarrays = 4 + 3 + 1 = 8.
        // It can be shown that there are no more continuous subarrays.


        // Example 2:
        //
        // Input: nums = [1,2,3]
        // Output: 6
        // Explanation: 
        // Continuous subarray of size 1: [1], [2], [3].
        // Continuous subarray of size 2: [1,2], [2,3].
        // Continuous subarray of size 3: [1,2,3].
        // Total continuous subarrays = 3 + 2 + 1 = 6.


        Solution solution = new();

        Console.WriteLine(solution.ContinuousSubarrays([5, 4, 2, 4]));
        Console.WriteLine(solution.ContinuousSubarrays([1, 2, 3]));
    }

    public long ContinuousSubarrays(int[] nums)
    {
        int start = 0;
        long totalSubarrays = 0;
        int minVal = nums[0];
        int maxVal = nums[0];

        for (int end = 0; end < nums.Length; end++)
        {
            minVal = Math.Min(minVal, nums[end]);
            maxVal = Math.Max(maxVal, nums[end]);

            while (maxVal - minVal > 2)
            {
                start++;
                minVal = nums[start];
                maxVal = nums[start];
                for (int k = start; k <= end; k++)
                {
                    minVal = Math.Min(minVal, nums[k]);
                    maxVal = Math.Max(maxVal, nums[k]);
                }
            }

            totalSubarrays += (end - start + 1);
        }

        return totalSubarrays;
    }
}