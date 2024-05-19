namespace MaximumValueSum;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/find-the-maximum-sum-of-node-values/solutions/5180588/c-solution-for-find-the-maximum-sum-of-node-values-problem/?envType=daily-question&envId=2024-05-19

        // Example 1:
        //
        // Input: nums = [1,2,1], k = 3, edges = [[0,1],[0,2]]
        // Output: 6
        // Explanation: Alice can achieve the maximum sum of 6 using a single operation:
        // - Choose the edge [0,2]. nums[0] and nums[2] become: 1 XOR 3 = 2, and the array nums becomes: [1,2,1] -> [2,2,2].
        // The total sum of values is 2 + 2 + 2 = 6.
        // It can be shown that 6 is the maximum achievable sum of values.

        //     Example 2:
        //
        // Input: nums = [2,3], k = 7, edges = [[0,1]]
        // Output: 9
        // Explanation: Alice can achieve the maximum sum of 9 using a single operation:
        // - Choose the edge [0,1]. nums[0] becomes: 2 XOR 7 = 5 and nums[1] become: 3 XOR 7 = 4, and the array nums becomes: [2,3] -> [5,4].
        // The total sum of values is 5 + 4 = 9.
        // It can be shown that 9 is the maximum achievable sum of values.

        // Example 3:
        //
        // Input: nums = [7,7,7,7,7,7], k = 3, edges = [[0,1],[0,2],[0,3],[0,4],[0,5]]
        // Output: 42
        // Explanation: The maximum achievable sum is 42 which can be achieved by Alice performing no operations.


        Solution solution = new();

        Console.WriteLine(solution.MaximumValueSum([1, 2, 1], 3, [[0, 1], [0, 2]]));
        Console.WriteLine(solution.MaximumValueSum([2, 3], 7, [[0, 1]]));
        Console.WriteLine(solution.MaximumValueSum([7, 7, 7, 7, 7, 7], 3, [[0, 1], [0, 2], [0, 3], [0, 4], [0, 5]]));
    }

    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long[,] dp = new long[nums.Length + 1, 2];

        dp[nums.Length, 1] = 0;
        dp[nums.Length, 0] = long.MinValue;

        for (int index = nums.Length - 1; index >= 0; index--)
        {
            for (int isEven = 0; isEven <= 1; isEven++)
            {
                long dontPerformOperation = dp[index + 1, isEven] + nums[index];
                long performOperation = dp[index + 1, isEven ^ 1] + (nums[index] ^ k);

                dp[index, isEven] = Math.Max(dontPerformOperation, performOperation);
            }
        }

        return dp[0, 1];
    }
}