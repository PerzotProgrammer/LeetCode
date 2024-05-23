namespace BeautifulSubsets;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/the-number-of-beautiful-subsets/solutions/5195504/c-recursion-backtracking/?envType=daily-question&envId=2024-05-22
        // Example 1:
        //
        // Input: nums = [2,4,6], k = 2
        // Output: 4
        // Explanation: The beautiful subsets of the array nums are: [2], [4], [6], [2, 6].
        // It can be proved that there are only 4 beautiful subsets in the array [2,4,6].

        // Example 2:
        //
        // Input: nums = [1], k = 1
        // Output: 1
        // Explanation: The beautiful subset of the array nums is [1].
        // It can be proved that there is only 1 beautiful subset in the array [1].


        Solution solution = new();

        Console.WriteLine(solution.BeautifulSubsets([2, 4, 6], 2));
        Console.WriteLine(solution.BeautifulSubsets([1], 1));
    }

    public int BeautifulSubsets(int[] nums, int k)
    {
        Array.Sort(nums);
        int res = 0;
        Dfs(nums, 0, new(), ref res, k);
        return res;
    }

    public void Dfs(int[] nums, int index, List<int> list, ref int res, int k)
    {
        if (index == nums.Length)
        {
            if (list.Count > 0) res++;
            return;
        }

        Dfs(nums, index + 1, list, ref res, k);
        if (list.Count == 0 || (!list.Contains(nums[index] - k) && !list.Contains(nums[index] + k)))
        {
            list.Add(nums[index]);
            Dfs(nums, index + 1, list, ref res, k);
            list.RemoveAt(list.Count - 1);
        }
    }
}