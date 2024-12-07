namespace MinimumSize;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [9], maxOperations = 2
        // Output: 3
        // Explanation: 
        // - Divide the bag with 9 balls into two bags of sizes 6 and 3. [9] -> [6,3].
        // - Divide the bag with 6 balls into two bags of sizes 3 and 3. [6,3] -> [3,3,3].
        //     The bag with the most number of balls has 3 balls, so your penalty is 3 and you should return 3.

        // Example 2:
        //
        // Input: nums = [2,4,8,2], maxOperations = 4
        // Output: 2
        // Explanation:
        // - Divide the bag with 8 balls into two bags of sizes 4 and 4. [2,4,8,2] -> [2,4,4,4,2].
        // - Divide the bag with 4 balls into two bags of sizes 2 and 2. [2,4,4,4,2] -> [2,2,2,4,4,2].
        // - Divide the bag with 4 balls into two bags of sizes 2 and 2. [2,2,2,4,4,2] -> [2,2,2,2,2,4,2].
        // - Divide the bag with 4 balls into two bags of sizes 2 and 2. [2,2,2,2,2,4,2] -> [2,2,2,2,2,2,2,2].
        // The bag with the most number of balls has 2 balls, so your penalty is 2, and you should return 2.


        Solution solution = new();

        Console.WriteLine(solution.MinimumSize([9], 2));
        Console.WriteLine(solution.MinimumSize([2, 4, 8, 2], 4));
    }

    public int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1;
        int right = nums.Max();
        int result = right;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (CanAchievePenalty(nums, mid, maxOperations))
            {
                result = mid;
                right = mid - 1;
            }
            else left = mid + 1;
        }

        return result;
    }

    private bool CanAchievePenalty(int[] nums, int penalty, int maxOperations)
    {
        int operations = 0;

        foreach (int num in nums)
        {
            operations += (num - 1) / penalty;

            if (operations > maxOperations) return false;
        }

        return true;
    }
}