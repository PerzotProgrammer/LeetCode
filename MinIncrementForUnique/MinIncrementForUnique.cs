namespace MinIncrementForUnique;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,2]
        // Output: 1
        // Explanation: After 1 move, the array could be [1, 2, 3].

        // Example 2:
        //
        // Input: nums = [3,2,1,2,1,7]
        // Output: 6
        // Explanation: After 6 moves, the array could be [3, 4, 1, 2, 5, 7].
        // It can be shown with 5 or less moves that it is impossible for the array to have all unique values.


        Solution solution = new();

        Console.WriteLine(solution.MinIncrementForUnique([1, 2, 2]));
        Console.WriteLine(solution.MinIncrementForUnique([3, 2, 1, 2, 1, 7]));
    }

    public int MinIncrementForUnique(int[] nums)
    {
        Array.Sort(nums);

        int moves = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                int increment = nums[i - 1] - nums[i] + 1;
                nums[i] += increment;
                moves += increment;
            }
        }

        return moves;
    }
}