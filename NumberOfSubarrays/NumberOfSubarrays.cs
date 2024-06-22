namespace NumberOfSubarrays;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,1,2,1,1], k = 3
        // Output: 2
        // Explanation: The only sub-arrays with 3 odd numbers are [1,1,2,1] and [1,2,1,1].

        // Example 2:
        //
        // Input: nums = [2,4,6], k = 1
        // Output: 0
        // Explanation: There are no odd numbers in the array.

        // Example 3:
        //
        // Input: nums = [2,2,2,1,2,2,1,2,2,2], k = 2
        // Output: 16


        Solution solution = new();

        Console.WriteLine(solution.NumberOfSubarrays([1, 1, 2, 1, 1], 3));
        Console.WriteLine(solution.NumberOfSubarrays([2, 4, 6], 1));
        Console.WriteLine(solution.NumberOfSubarrays([2, 2, 2, 1, 2, 2, 1, 2, 2, 2], 2));
    }

    public int NumberOfSubarrays(int[] nums, int k)
    {
        int subarrays = 0;
        int initialGap = 0;
        int gapSize = 0;
        int start = 0;
        for (int end = 0; end < nums.Length; end++)
        {
            if (nums[end] % 2 == 1) gapSize++;

            if (gapSize == k)
            {
                initialGap = 0;
                while (gapSize == k)
                {
                    gapSize -= nums[start] % 2;
                    initialGap++;
                    start++;
                }
            }

            subarrays += initialGap;
        }

        return subarrays;
    }
}