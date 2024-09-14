namespace LongestSubarrayII;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,3,2,2]
        // Output: 2
        // Explanation:
        // The maximum possible bitwise AND of a subarray is 3.
        // The longest subarray with that value is [3,3], so we return 2.

        // Example 2:
        //
        // Input: nums = [1,2,3,4]
        // Output: 1
        // Explanation:
        // The maximum possible bitwise AND of a subarray is 4.
        // The longest subarray with that value is [4], so we return 1.


        Solution solution = new();

        Console.WriteLine(solution.LongestSubarray([1, 2, 3, 3, 2, 2]));
        Console.WriteLine(solution.LongestSubarray([1, 2, 3, 4]));
    }

    public int LongestSubarray(int[] nums)
    {
        int maxVal = 0;
        int ans = 0;
        int currentStreak = 0;

        foreach (int num in nums)
        {
            if (maxVal < num)
            {
                maxVal = num;
                ans = currentStreak = 0;
            }

            if (maxVal == num) currentStreak++;
            else currentStreak = 0;

            ans = Math.Max(ans, currentStreak);
        }

        return ans;
    }
}