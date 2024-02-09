namespace LargestDivisibleSubset;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3]
        // Output: [1,2]
        // Explanation: [1,3] is also accepted.

        // Example 2:
        //
        // Input: nums = [1,2,4,8]
        // Output: [1,2,4,8]

        Solution solution = new();

        PrintList(solution.LargestDivisibleSubset([1, 2, 3]));
        PrintList(solution.LargestDivisibleSubset([1, 2, 4, 8]));
    }

    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        if (nums == null || nums.Length == 0) return new List<int>();

        Array.Sort(nums);
        int n = nums.Length;

        int[] dp = new int[n];
        int[] prev = new int[n];

        int maxIndex = 0;
        int maxSize = 1;

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            prev[i] = -1;

            for (int j = i - 1; j >= 0; j--)
            {
                if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;

                    if (dp[i] > maxSize)
                    {
                        maxSize = dp[i];
                        maxIndex = i;
                    }
                }
            }
        }

        IList<int> result = new List<int>();

        while (maxIndex != -1)
        {
            result.Add(nums[maxIndex]);
            maxIndex = prev[maxIndex];
        }

        result = result.Reverse().ToList();
        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}