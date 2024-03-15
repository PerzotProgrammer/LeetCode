namespace ProductExceptSelf;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,4]
        // Output: [24,12,8,6]

        // Example 2:
        //
        // Input: nums = [-1,1,0,-3,3]
        // Output: [0,0,9,0,0]

        Solution solution = new();

        PrintArray(solution.ProductExceptSelf([1, 2, 3, 4]));
        PrintArray(solution.ProductExceptSelf([-1,1,0,-3,3]));
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] answer = new int[n];

        int left = 1;
        for (int i = 0; i < n; i++)
        {
            answer[i] = left;
            left *= nums[i];
        }

        int right = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            answer[i] *= right;
            right *= nums[i];
        }

        return answer;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}