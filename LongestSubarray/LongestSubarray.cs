namespace LongestSubarray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [8,2,4,7], limit = 4
        // Output: 2 
        // Explanation: All subarrays are: 
        // [8] with maximum absolute diff |8-8| = 0 <= 4.
        // [8,2] with maximum absolute diff |8-2| = 6 > 4. 
        // [8,2,4] with maximum absolute diff |8-2| = 6 > 4.
        // [8,2,4,7] with maximum absolute diff |8-2| = 6 > 4.
        // [2] with maximum absolute diff |2-2| = 0 <= 4.
        // [2,4] with maximum absolute diff |2-4| = 2 <= 4.
        // [2,4,7] with maximum absolute diff |2-7| = 5 > 4.
        // [4] with maximum absolute diff |4-4| = 0 <= 4.
        // [4,7] with maximum absolute diff |4-7| = 3 <= 4.
        // [7] with maximum absolute diff |7-7| = 0 <= 4. 
        // Therefore, the size of the longest subarray is 2.

        // Example 2:
        //
        // Input: nums = [10,1,2,4,7,2], limit = 5
        // Output: 4 
        // Explanation: The subarray [2,4,7,2] is the longest since the maximum absolute diff is |2-7| = 5 <= 5.

        // Example 3:
        //
        // Input: nums = [4,2,2,2,4,4,2,2], limit = 0
        // Output: 3


        Solution solution = new();

        Console.WriteLine(solution.LongestSubarray([8, 2, 4, 7], 4));
        Console.WriteLine(solution.LongestSubarray([10, 1, 2, 4, 7, 2], 5));
        Console.WriteLine(solution.LongestSubarray([4, 2, 2, 2, 4, 4, 2, 2], 0));
    }

    public int LongestSubarray(int[] nums, int limit)
    {
        LinkedList<int> decQ = new();
        LinkedList<int> incQ = new();
        int ans = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; ++right)
        {
            int num = nums[right];

            while (decQ.Count > 0 && num > decQ.Last!.Value) decQ.RemoveLast();

            decQ.AddLast(num);

            while (incQ.Count > 0 && num < incQ.Last!.Value) incQ.RemoveLast();

            incQ.AddLast(num);

            while (decQ.First!.Value - incQ.First!.Value > limit)
            {
                if (decQ.First.Value == nums[left]) decQ.RemoveFirst();

                if (incQ.First.Value == nums[left]) incQ.RemoveFirst();

                ++left;
            }

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}