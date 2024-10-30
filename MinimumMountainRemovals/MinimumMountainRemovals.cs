namespace MinimumMountainRemovals;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [1,3,1]
        // Output: 0
        // Explanation: The array itself is a mountain array so we do not need to remove any elements.

        // Example 2:
        //
        // Input: nums = [2,1,1,5,6,2,3,1]
        // Output: 3
        // Explanation: One solution is to remove the elements at indices 0, 1, and 5, making the array nums = [1,5,6,3,1].


        Solution solution = new();

        Console.WriteLine(solution.MinimumMountainRemovals([1, 3, 1]));
        Console.WriteLine(solution.MinimumMountainRemovals([2, 1, 1, 5, 6, 2, 3, 1]));
    }

    public int MinimumMountainRemovals(int[] nums)
    {
        int[] lisLength = new int[nums.Length];
        int[] ldsLength = new int[nums.Length];

        Array.Fill(lisLength, 1);
        Array.Fill(ldsLength, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (nums[i] > nums[j]) lisLength[i] = Math.Max(lisLength[i], lisLength[j] + 1);
            }
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] > nums[j]) ldsLength[i] = Math.Max(ldsLength[i], ldsLength[j] + 1);
            }
        }

        int minRemovals = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (lisLength[i] > 1 && ldsLength[i] > 1)
            {
                minRemovals = Math.Min(minRemovals, nums.Length - lisLength[i] - ldsLength[i] + 1);
            }
        }

        return minRemovals;
    }
}