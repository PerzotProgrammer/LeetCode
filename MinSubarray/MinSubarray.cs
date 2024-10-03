namespace MinSubarray;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [3,1,4,2], p = 6
        // Output: 1
        // Explanation: The sum of the elements in nums is 10, which is not divisible by 6. We can remove the subarray [4], and the sum of the remaining elements is 6, which is divisible by 6.

        // Example 2:
        //
        // Input: nums = [6,3,5,2], p = 9
        // Output: 2
        // Explanation: We cannot remove a single element to get a sum divisible by 9. The best way is to remove the subarray [5,2], leaving us with [6,3] with sum 9.

        // Example 3:
        //
        // Input: nums = [1,2,3], p = 3
        // Output: 0
        // Explanation: Here the sum is 6. which is already divisible by 3. Thus we do not need to remove anything.


        Solution solution = new();

        Console.WriteLine(solution.MinSubarray([3, 1, 4, 2], 6));
        Console.WriteLine(solution.MinSubarray([6, 3, 5, 2], 9));
        Console.WriteLine(solution.MinSubarray([1, 2, 3], 3));
    }

    public int MinSubarray(int[] nums, int p)
    {
        long totalSum = 0;
        foreach (int num in nums) totalSum += num;

        long remainder = totalSum % p;
        if (remainder == 0) return 0;

        Dictionary<long, int> prefixMap = new();
        prefixMap[0] = -1;

        long prefixSum = 0;
        int minLength = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];
            long currentMod = prefixSum % p;
            long targetMod = (currentMod - remainder + p) % p;


            if (prefixMap.TryGetValue(targetMod, out int mod))
            {
                minLength = Math.Min(minLength, i - mod);
            }

            prefixMap[currentMod] = i;
        }

        if (minLength != nums.Length) return minLength;
        return -1;
    }
}