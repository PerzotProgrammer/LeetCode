namespace CountFairPairs;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [0,1,7,4,4,5], lower = 3, upper = 6
        // Output: 6
        // Explanation: There are 6 fair pairs: (0,3), (0,4), (0,5), (1,3), (1,4), and (1,5).

        // Example 2:
        //
        // Input: nums = [1,7,9,2,5], lower = 11, upper = 11
        // Output: 1
        // Explanation: There is a single fair pair: (2,3).


        Solution solution = new();

        Console.WriteLine(solution.CountFairPairs([0, 1, 7, 4, 4, 5], 3, 6));
        Console.WriteLine(solution.CountFairPairs([1, 7, 9, 2, 5], 11, 11));
    }

    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);
        long count = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            int left = i + 1;
            int right = nums.Length - 1;
            int lowIndex = BinarySearch(nums, left, right, lower - nums[i], true);
            int highIndex = BinarySearch(nums, left, right, upper - nums[i], false);
            if (lowIndex != -1 && highIndex != -1 && lowIndex <= highIndex) count += highIndex - lowIndex + 1;
        }

        return count;
    }

    private int BinarySearch(int[] nums, int left, int right, int target, bool findLower)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < target) left = mid + 1;
            else if (nums[mid] > target) right = mid - 1;
            else
            {
                if (findLower) right = mid - 1;
                else left = mid + 1;
            }
        }

        return findLower ? left : right;
    }
}