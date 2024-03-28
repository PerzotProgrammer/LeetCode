namespace MaxSubarrayLength;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,1,2,3,1,2], k = 2
        // Output: 6
        // Explanation: The longest possible good subarray is [1,2,3,1,2,3] since the values 1, 2, and 3 occur at most twice in this subarray. Note that the subarrays [2,3,1,2,3,1] and [3,1,2,3,1,2] are also good.
        // It can be shown that there are no good subarrays with length more than 6.

        // Example 2:
        //
        // Input: nums = [1,2,1,2,1,2,1,2], k = 1
        // Output: 2
        // Explanation: The longest possible good subarray is [1,2] since the values 1 and 2 occur at most once in this subarray. Note that the subarray [2,1] is also good.
        // It can be shown that there are no good subarrays with length more than 2.

        // Example 3:
        //
        // Input: nums = [5,5,5,5,5,5,5], k = 4
        // Output: 4
        // Explanation: The longest possible good subarray is [5,5,5,5] since the value 5 occurs 4 times in this subarray.
        // It can be shown that there are no good subarrays with length more than 4.

        Solution solution = new();

        Console.WriteLine(solution.MaxSubarrayLength([1, 2, 3, 1, 2, 3, 1, 2], 2));
        Console.WriteLine(solution.MaxSubarrayLength([1, 2, 1, 2, 1, 2, 1, 2], 1));
        Console.WriteLine(solution.MaxSubarrayLength([5, 5, 5, 5, 5, 5, 5], 4));
        Console.WriteLine(solution.MaxSubarrayLength([1, 4, 4, 3], 1));
    }

    public int MaxSubarrayLength(int[] nums, int k)
    {
        int output = 0;
        int start = 0;
        Dictionary<int, int> freq = new();

        for (int end = 0; end < nums.Length; end++)
        {
            int num = nums[end];
            if (!freq.TryAdd(num, 1)) freq[num]++;

            while (freq.ContainsKey(num) && freq[num] > k)
            {
                int leftNum = nums[start];
                freq[leftNum]--;
                if (freq[leftNum] == 0) freq.Remove(leftNum);
                start++;
            }

            output = Math.Max(output, end - start + 1);
        }

        return output;
    }
}