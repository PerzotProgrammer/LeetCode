namespace NumSubarraysWithSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,0,1,0,1], goal = 2
        // Output: 4
        // Explanation: The 4 subarrays are bolded and underlined below:
        // [1,0,1,0,1]
        // [1,0,1,0,1]
        // [1,0,1,0,1]
        // [1,0,1,0,1]

        // Example 2:
        //
        // Input: nums = [0,0,0,0,0], goal = 0
        // Output: 15

        Solution solution = new();

        Console.WriteLine(solution.NumSubarraysWithSum([1, 0, 1, 0, 1], 2));
        Console.WriteLine(solution.NumSubarraysWithSum([0, 0, 0, 0, 0], 0));
    }

    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        Dictionary<int, int> freq = new();
        int sum = 0;
        int output = 0;
        foreach (int num in nums)
        {
            sum += num;
            freq.TryAdd(sum, 0);
            if (sum == goal) output++;
            if (sum >= goal)
            {
                if (freq.ContainsKey(sum - goal)) output += freq[sum - goal];
            }

            freq[sum]++;
        }

        return output;
    }
}