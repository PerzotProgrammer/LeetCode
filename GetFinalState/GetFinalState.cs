namespace GetFinalState;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [2,1,3,5,6], k = 5, multiplier = 2
        // Output: [8,4,6,5,6]
        // Explanation:
        // Operation	Result
        // After operation 1	[2, 2, 3, 5, 6]
        // After operation 2	[4, 2, 3, 5, 6]
        // After operation 3	[4, 4, 3, 5, 6]
        // After operation 4	[4, 4, 6, 5, 6]
        // After operation 5	[8, 4, 6, 5, 6]

        // Example 2:
        //
        // Input: nums = [1,2], k = 3, multiplier = 4
        // Output: [16,8]
        // Explanation:
        // Operation	Result
        // After operation 1	[4, 2]
        // After operation 2	[4, 8]
        // After operation 3	[16, 8]


        Solution solution = new();

        PrintArray(solution.GetFinalState([2, 1, 3, 5, 6], 5, 2));
        PrintArray(solution.GetFinalState([1, 2], 3, 4));
    }

    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        for (int j = 0; j < k; j++)
        {
            int minIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < nums[minIndex]) minIndex = i;
            }

            nums[minIndex] *= multiplier;
        }

        return nums;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}