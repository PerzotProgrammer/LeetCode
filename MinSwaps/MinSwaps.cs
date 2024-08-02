namespace MinSwaps;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [0,1,0,1,1,0,0]
        // Output: 1
        // Explanation: Here are a few of the ways to group all the 1's together:
        // [0,0,1,1,1,0,0] using 1 swap.
        // [0,1,1,1,0,0,0] using 1 swap.
        // [1,1,0,0,0,0,1] using 2 swaps (using the circular property of the array).
        // There is no way to group all 1's together with 0 swaps.
        // Thus, the minimum number of swaps required is 1.

        // Example 2:
        //
        // Input: nums = [0,1,1,1,0,0,1,1,0]
        // Output: 2
        // Explanation: Here are a few of the ways to group all the 1's together:
        // [1,1,1,0,0,0,0,1,1] using 2 swaps (using the circular property of the array).
        // [1,1,1,1,1,0,0,0,0] using 2 swaps.
        // There is no way to group all 1's together with 0 or 1 swaps.
        // Thus, the minimum number of swaps required is 2.

        // Example 3:
        //
        // Input: nums = [1,1,0,0,1]
        // Output: 0
        // Explanation: All the 1's are already grouped together due to the circular property of the array.
        // Thus, the minimum number of swaps required is 0.


        Solution solution = new();

        Console.WriteLine(solution.MinSwaps([0, 1, 0, 1, 1, 0, 0]));
        Console.WriteLine(solution.MinSwaps([0, 1, 1, 1, 0, 0, 1, 1, 0]));
        Console.WriteLine(solution.MinSwaps([1, 1, 0, 0, 1]));
    }

    public int MinSwaps(int[] nums)
    {
        int totalOnes = 0;
        foreach (int num in nums)
        {
            if (num == 1) totalOnes++;
        }

        if (totalOnes <= 1) return 0;

        int[] prefixSum = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) prefixSum[i + 1] = prefixSum[i] + nums[i];

        int minSwaps = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            int end = i + totalOnes - 1;
            int currentOnes;

            if (end < nums.Length) currentOnes = prefixSum[end + 1] - prefixSum[i];
            else currentOnes = (prefixSum[nums.Length] - prefixSum[i]) + (prefixSum[end - nums.Length + 1]);

            minSwaps = Math.Min(minSwaps, totalOnes - currentOnes);
        }

        return minSwaps;
    }
}