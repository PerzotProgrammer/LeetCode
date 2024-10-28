namespace LongestSquareStreak;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [4,3,6,16,8,2]
        // Output: 3
        // Explanation: Choose the subsequence [4,16,2]. After sorting it, it becomes [2,4,16].
        // - 4 = 2 * 2.
        // - 16 = 4 * 4.
        // Therefore, [4,16,2] is a square streak.
        // It can be shown that every subsequence of length 4 is not a square streak.

        // Example 2:
        //
        // Input: nums = [2,3,5,6,7]
        // Output: -1
        // Explanation: There is no square streak in nums so return -1.


        Solution solution = new();

        Console.WriteLine(solution.LongestSquareStreak([4, 3, 6, 16, 8, 2]));
        Console.WriteLine(solution.LongestSquareStreak([2, 3, 5, 6, 7]));
    }

    public int LongestSquareStreak(int[] nums)
    {
        int longestStreak = 0;
        HashSet<int> uniqueNumbers = new(nums);

        foreach (int startNumber in nums)
        {
            int currentStreak = 0;
            long current = startNumber;

            while (uniqueNumbers.Contains((int)current))
            {
                currentStreak++;
                current *= current;
                if (current > 100000) break;
            }

            longestStreak = Math.Max(longestStreak, currentStreak);
        }

        return longestStreak < 2 ? -1 : longestStreak;
    }
}