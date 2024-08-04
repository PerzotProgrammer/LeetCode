namespace RangeSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,4], n = 4, left = 1, right = 5
        // Output: 13 
        // Explanation: All subarray sums are 1, 3, 6, 10, 2, 5, 9, 3, 7, 4. After sorting them in non-decreasing order we have the new array [1, 2, 3, 3, 4, 5, 6, 7, 9, 10]. The sum of the numbers from index le = 1 to ri = 5 is 1 + 2 + 3 + 3 + 4 = 13. 

        // Example 2:
        //
        // Input: nums = [1,2,3,4], n = 4, left = 3, right = 4
        // Output: 6
        // Explanation: The given array is the same as example 1. We have the new array [1, 2, 3, 3, 4, 5, 6, 7, 9, 10]. The sum of the numbers from index le = 3 to ri = 4 is 3 + 3 = 6.

        // Example 3:
        //
        // Input: nums = [1,2,3,4], n = 4, left = 1, right = 10
        // Output: 50


        Solution solution = new();

        Console.WriteLine(solution.RangeSum([1, 2, 3, 4], 4, 1, 5));
        Console.WriteLine(solution.RangeSum([1, 2, 3, 4], 4, 3, 4));
        Console.WriteLine(solution.RangeSum([1, 2, 3, 4], 4, 1, 10));
    }

    public int RangeSum(int[] nums, int n, int left, int right)
    {
        List<int> storeSubarray = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int sum = 0;
            for (int j = i; j < nums.Length; j++)
            {
                sum += nums[j];
                storeSubarray.Add(sum);
            }
        }

        storeSubarray.Sort();
        int rangeSum = 0;
        int mod = 1_000_000_000 + 7;
        for (int i = left - 1; i <= right - 1; i++)
        {
            rangeSum = (rangeSum + storeSubarray[i]) % mod;
        }

        return rangeSum;
    }
}