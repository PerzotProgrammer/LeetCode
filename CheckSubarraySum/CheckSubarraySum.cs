namespace CheckSubarraySum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [23,2,4,6,7], k = 6
        // Output: true
        // Explanation: [2, 4] is a continuous subarray of size 2 whose elements sum up to 6.

        // Example 2:
        //
        // Input: nums = [23,2,6,4,7], k = 6
        // Output: true
        // Explanation: [23, 2, 6, 4, 7] is an continuous subarray of size 5 whose elements sum up to 42.
        // 42 is a multiple of 6 because 42 = 7 * 6 and 7 is an integer.

        // Example 3:
        //
        // Input: nums = [23,2,6,4,7], k = 13
        // Output: false


        Solution solution = new();

        Console.WriteLine(solution.CheckSubarraySum([23, 2, 4, 6, 7], 6));
        Console.WriteLine(solution.CheckSubarraySum([23, 2, 6, 4, 7], 6));
        Console.WriteLine(solution.CheckSubarraySum([23, 2, 6, 4, 7], 13));
    }

    public bool CheckSubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> remainderMap = new() { [0] = -1 };

        int runningSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            runningSum += nums[i];
            int remainder = runningSum % k;

            if (remainder < 0) remainder += k;

            if (!remainderMap.TryAdd(remainder, i))
            {
                if (i - remainderMap[remainder] > 1) return true;
            }
        }

        return false;
    }
}