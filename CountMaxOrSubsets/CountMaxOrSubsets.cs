namespace CountMaxOrSubsets;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [3,1]
        // Output: 2
        // Explanation: The maximum possible bitwise OR of a subset is 3. There are 2 subsets with a bitwise OR of 3:
        // - [3]
        // - [3,1]

        // Example 2:
        //
        // Input: nums = [2,2,2]
        // Output: 7
        // Explanation: All non-empty subsets of [2,2,2] have a bitwise OR of 2. There are 23 - 1 = 7 total subsets.

        // Example 3:
        //
        // Input: nums = [3,2,1,5]
        // Output: 6
        // Explanation: The maximum possible bitwise OR of a subset is 7. There are 6 subsets with a bitwise OR of 7:
        // - [3,5]
        // - [3,1,5]
        // - [3,2,5]
        // - [3,2,1,5]
        // - [2,5]
        // - [2,1,5]

        Solution solution = new();

        Console.WriteLine(solution.CountMaxOrSubsets([3, 1]));
        Console.WriteLine(solution.CountMaxOrSubsets([2, 2, 2]));
        Console.WriteLine(solution.CountMaxOrSubsets([3, 2, 1, 5]));
    }

    public int CountMaxOrSubsets(int[] nums)
    {
        int maxOr = 0;
        foreach (int num in nums) maxOr |= num;

        int count = 0;
        int totalSubsets = 1 << nums.Length;

        for (int mask = 1; mask < totalSubsets; mask++)
        {
            int currentOr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if ((mask & (1 << i)) != 0) currentOr |= nums[i];
            }

            if (currentOr == maxOr) count++;
        }

        return count;
    }
}