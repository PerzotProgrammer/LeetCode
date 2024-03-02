namespace SortedSquares;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [-4,-1,0,3,10]
        // Output: [0,1,9,16,100]
        // Explanation: After squaring, the array becomes [16,1,0,9,100].
        // After sorting, it becomes [0,1,9,16,100].

        // Example 2:
        //
        // Input: nums = [-7,-3,2,3,11]
        // Output: [4,9,9,49,121]

        Solution solution = new();

        int[] a1 = solution.SortedSquares([-4,-1,0,3,10]);
        int[] a2 = solution.SortedSquares([-7,-3,2,3,11]);
        
        PrintArray(a1);
        PrintArray(a2);
    }

    public int[] SortedSquares(int[] nums)
    {
        int[] output = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) output[i] = nums[i] * nums[i];
        Array.Sort(output);
        return output;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}