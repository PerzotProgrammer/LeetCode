namespace SmallestDistancePair;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,1], k = 1
        // Output: 0
        // Explanation: Here are all the pairs:
        // (1,3) -> 2
        // (1,1) -> 0
        // (3,1) -> 2
        // Then the 1st smallest distance pair is (1,1), and its distance is 0.

        // Example 2:
        //
        // Input: nums = [1,1,1], k = 2
        // Output: 0

        // Example 3:
        //
        // Input: nums = [1,6,1], k = 3
        // Output: 5


        Solution solution = new();

        Console.WriteLine(solution.SmallestDistancePair([1, 3, 1], 1));
        Console.WriteLine(solution.SmallestDistancePair([1, 1, 1], 2));
        Console.WriteLine(solution.SmallestDistancePair([1, 6, 1], 3));
    }

    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);
        int low = 0;
        int high = nums[^1] - nums[0];

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (CountPairs(nums, mid) >= k) high = mid;
            else low = mid + 1;
        }

        return low;
    }

    private int CountPairs(int[] nums, int mid)
    {
        int count = 0;
        int j = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length && nums[j] - nums[i] <= mid) j++;
            count += j - i - 1;
        }

        return count;
    }
}