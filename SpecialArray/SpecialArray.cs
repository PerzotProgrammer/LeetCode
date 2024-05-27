namespace SpecialArray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [3,5]
        // Output: 2
        // Explanation: There are 2 values (3 and 5) that are greater than or equal to 2.

        // Example 2:
        //
        // Input: nums = [0,0]
        // Output: -1
        // Explanation: No numbers fit the criteria for x.
        // If x = 0, there should be 0 numbers >= x, but there are 2.
        // If x = 1, there should be 1 number >= x, but there are 0.
        // If x = 2, there should be 2 numbers >= x, but there are 0.
        // x cannot be greater since there are only 2 numbers in nums.

        // Example 3:
        //
        // Input: nums = [0,4,3,0,4]
        // Output: 3
        // Explanation: There are 3 values that are greater than or equal to 3.


        Solution solution = new();

        Console.WriteLine(solution.SpecialArray([3, 5]));
        Console.WriteLine(solution.SpecialArray([0, 0]));
        Console.WriteLine(solution.SpecialArray([0, 4, 3, 0, 4]));
    }

    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);

        for (int i = 1; i <= nums.Length; i++)
        {
            int k = BinarySearch(nums, i);
            if (nums.Length - k == i) return i;
        }

        return -1;
    }

    private int BinarySearch(int[] nums, int val)
    {
        int low = 0;
        int high = nums.Length - 1;
        int index = nums.Length;

        while (low <= high)
        {
            int mid = (high + low) / 2;
            if (nums[mid] >= val)
            {
                index = mid;
                high = mid - 1;
            }
            else low = mid + 1;
        }

        return index;
    }
}