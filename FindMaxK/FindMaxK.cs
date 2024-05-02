namespace FindMaxK;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [-1,2,-3,3]
        // Output: 3
        // Explanation: 3 is the only valid k we can find in the array.

        // Example 2:
        //
        // Input: nums = [-1,10,6,7,-7,1]
        // Output: 7
        // Explanation: Both 1 and 7 have their corresponding negative values in the array. 7 has a larger value.

        // Example 3:
        //
        // Input: nums = [-10,8,6,7,-2,-3]
        // Output: -1
        // Explanation: There is no a single valid k, we return -1.

        Solution solution = new();

        Console.WriteLine(solution.FindMaxK([-1, 2, -3, 3]));
        Console.WriteLine(solution.FindMaxK([-1, 10, 6, 7, -7, 1]));
        Console.WriteLine(solution.FindMaxK([-10, 8, 6, 7, -2, -3]));
    }

    public int FindMaxK(int[] nums)
    {
        Array.Sort(nums);
        int low = 0;
        int high = nums.Length - 1;

        while (low < high)
        {
            if (-nums[low] == nums[high]) return nums[high];

            if (-nums[low] > nums[high]) low++;
            else high--;
        }

        return -1;
    }
}