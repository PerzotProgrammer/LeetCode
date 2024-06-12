namespace SortColors;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [2,0,2,1,1,0]
        // Output: [0,0,1,1,2,2]

        // Example 2:
        //
        // Input: nums = [2,0,1]
        // Output: [0,1,2]


        Solution solution = new();

        int[] a = [2, 0, 2, 1, 1, 0];
        int[] b = [2, 0, 1];
        
        solution.SortColors(a);
        solution.SortColors(b);
        
        PrintArray(a);
        PrintArray(b);
    }

    public void SortColors(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length - i - 1; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                }
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}