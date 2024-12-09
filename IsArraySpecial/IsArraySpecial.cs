namespace IsArraySpecial;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [3,4,1,2,6], queries = [[0,4]]
        // Output: [false]
        // Explanation:
        // The subarray is [3,4,1,2,6]. 2 and 6 are both even.

        // Example 2:
        //
        // Input: nums = [4,3,1,6], queries = [[0,2],[2,3]]
        // Output: [false,true]
        // Explanation:
        // The subarray is [4,3,1]. 3 and 1 are both odd. So the answer to this query is false.
        // The subarray is [1,6]. There is only one pair: (1,6) and it contains numbers with different parity. So the answer to this query is true.


        Solution solution = new();

        PrintArray(solution.IsArraySpecial([3, 4, 1, 2, 6], [[0, 4]]));
        PrintArray(solution.IsArraySpecial([4, 3, 1, 6], [[0, 2], [2, 3]]));
    }

    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        int[] maxReach = new int[nums.Length];
        int end = 0;
        for (int start = 0; start < nums.Length; start++)
        {
            end = Math.Max(end, start);
            while (end < nums.Length - 1 && (nums[end] % 2 != nums[end + 1] % 2)) end++;

            maxReach[start] = end;
        }

        bool[] result = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int from = queries[i][0];
            int to = queries[i][1];
            result[i] = to <= maxReach[from];
        }

        return result;
    }

    static void PrintArray(bool[] arr)
    {
        foreach (bool b in arr) Console.Write($"{b}, ");
        Console.WriteLine();
    }
}