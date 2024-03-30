namespace SubarraysWithKDistinct;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,1,2,3], k = 2
        // Output: 7
        // Explanation: Subarrays formed with exactly 2 different integers: [1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,1,2]

        // Example 2:
        //
        // Input: nums = [1,2,1,3,4], k = 3
        // Output: 3
        // Explanation: Subarrays formed with exactly 3 different integers: [1,2,1,3], [2,1,3], [1,3,4].

        Solution solution = new();

        Console.WriteLine(solution.SubarraysWithKDistinct([1, 2, 1, 2, 3], 2));
        Console.WriteLine(solution.SubarraysWithKDistinct([1, 2, 1, 3, 4], 3));
    }

    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        Dictionary<int, int> lastOccur = new();
        int output = 0;
        int u = 0;
        int r = 0;
        int l = -1;

        for (; r < nums.Length; r++)
        {
            lastOccur[nums[r]] = r;

            while (lastOccur[nums[u]] != u) u++;

            if (lastOccur.Count > k)
            {
                l = u++;
                lastOccur.Remove(nums[l]);

                while (lastOccur[nums[u]] != u) u++;
            }

            if (lastOccur.Count == k) output += u - l;
        }

        return output;
    }
}