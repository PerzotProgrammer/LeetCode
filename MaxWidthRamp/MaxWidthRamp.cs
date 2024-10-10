namespace MaxWidthRamp;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [6,0,8,2,1,5]
        // Output: 4
        // Explanation: The maximum width ramp is achieved at (i, j) = (1, 5): nums[1] = 0 and nums[5] = 5.

        // Example 2:
        //
        // Input: nums = [9,8,1,0,1,9,4,0,4,1]
        // Output: 7
        // Explanation: The maximum width ramp is achieved at (i, j) = (2, 9): nums[2] = 1 and nums[9] = 1.


        Solution solution = new();

        Console.WriteLine(solution.MaxWidthRamp([6, 0, 8, 2, 1, 5]));
        Console.WriteLine(solution.MaxWidthRamp([9, 8, 1, 0, 1, 9, 4, 0, 4, 1]));
    }

    public int MaxWidthRamp(int[] nums)
    {
        List<int> list = new();

        for (int i = 0; i < nums.Length; i++) list.Add(i);

        list.Sort((i, j) => nums[i] == nums[j] ? i.CompareTo(j) : nums[i].CompareTo(nums[j]));

        int maxWidth = 0;
        int minIndex = int.MaxValue;

        foreach (int i in list)
        {
            minIndex = Math.Min(minIndex, i);
            maxWidth = Math.Max(maxWidth, i - minIndex);
        }

        return maxWidth;
    }
}