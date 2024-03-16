namespace FindMaxLength;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [0,1]
        // Output: 2
        // Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.

        // Example 2:
        //
        // Input: nums = [0,1,0]
        // Output: 2
        // Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

        Solution solution = new();
        Console.WriteLine(solution.FindMaxLength([0, 1]));
        Console.WriteLine(solution.FindMaxLength([0, 1, 0]));
    }

    public int FindMaxLength(int[] nums)
    {
        Dictionary<int, int> map = new() { { 0, -1 } };
        int maxLength = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) count++;
            else count--;
            if (!map.TryAdd(count, i)) maxLength = Math.Max(maxLength, i - map[count]);
        }

        return maxLength;
    }
}