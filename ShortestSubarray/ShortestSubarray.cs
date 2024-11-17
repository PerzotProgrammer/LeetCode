namespace ShortestSubarray;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/solutions/6054823/c-solution-for-shortest-subarray-with-sum-at-least-k-problem/?envType=daily-question&envId=2024-11-17
        // Example 1:
        //
        // Input: nums = [1], k = 1
        // Output: 1

        // Example 2:
        //
        // Input: nums = [1,2], k = 4
        // Output: -1

        // Example 3:
        //
        // Input: nums = [2,-1,2], k = 3
        // Output: 3


        Solution solution = new();

        Console.WriteLine(solution.ShortestSubarray([1], 1));
        Console.WriteLine(solution.ShortestSubarray([1, 2], 4));
        Console.WriteLine(solution.ShortestSubarray([2, -1, 2], 3));
    }

    public int ShortestSubarray(int[] nums, int k)
    {
        long[] prefixSum = new long[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) prefixSum[i + 1] = prefixSum[i] + nums[i];

        LinkedList<int> deque = new();
        int minLength = int.MaxValue;

        for (int i = 0; i <= nums.Length; i++)
        {
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First!.Value] >= k)
            {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last!.Value]) deque.RemoveLast();
            deque.AddLast(i);
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}