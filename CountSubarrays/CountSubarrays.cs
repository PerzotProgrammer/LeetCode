namespace CountSubarrays;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,2,3,3], k = 2
        // Output: 6
        // Explanation: The subarrays that contain the element 3 at least 2 times are: [1,3,2,3], [1,3,2,3,3], [3,2,3], [3,2,3,3], [2,3,3] and [3,3].

        // Example 2:
        //
        // Input: nums = [1,4,2,1], k = 3
        // Output: 0
        // Explanation: No subarray contains the element 4 at least 3 times.

        Solution solution = new();

        Console.WriteLine(solution.CountSubarrays([1, 3, 2, 3, 3], 2));
        Console.WriteLine(solution.CountSubarrays([1, 4, 2, 1], 3));
    }

    public long CountSubarrays(int[] nums, int k)
    {
        int maxItem = nums.Max();
        long output = 0;
        int start = 0;
        int maxItemInWin = 0;

        for (int end = 0; end < nums.Length; end++)
        {
            if (nums[end] == maxItem) maxItemInWin++;

            while (k == maxItemInWin)
            {
                if (nums[start] == maxItem) maxItemInWin--;
                start++;
            }

            output += start;
        }

        return output;
    }
}