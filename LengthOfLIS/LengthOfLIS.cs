namespace LengthOfLIS;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [10,9,2,5,3,7,101,18]
        // Output: 4
        // Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
        
        
        // Example 2:
        //
        // Input: nums = [0,1,0,3,2,3]
        // Output: 4
        
        
        // Example 3:
        //
        // Input: nums = [7,7,7,7,7,7,7]
        // Output: 1

        Solution solution = new();

        Console.WriteLine(solution.LengthOfLIS([10,9,2,5,3,7,101,18]));
        Console.WriteLine(solution.LengthOfLIS([0,1,0,3,2,3]));
        Console.WriteLine(solution.LengthOfLIS([7,7,7,7,7,7,7]));
    }

    public int LengthOfLIS(int[] nums)
    {
        int[] arr = new int[nums.Length];
        Array.Fill(arr, 1);

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    arr[i] = Math.Max(arr[i], arr[j] + 1);
                }
            }
        }

        return arr.Max();
    }
}