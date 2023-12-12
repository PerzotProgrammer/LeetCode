namespace MaxProduct;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [3,4,5,2]
        // Output: 12 
        // Explanation: If you choose the indices i=1 and j=2 (indexed from 0), you will get the maximum value, that is, (nums[1]-1)*(nums[2]-1) = (4-1)*(5-1) = 3*4 = 12. 

        // Example 2:
        //
        // Input: nums = [1,5,4,5]
        // Output: 16
        // Explanation: Choosing the indices i=1 and j=3 (indexed from 0), you will get the maximum value of (5-1)*(5-1) = 16.

        // Example 3:
        //
        // Input: nums = [3,7]
        // Output: 12 

        int[] n1 = { 3, 4, 5, 2 };
        int[] n2 = { 1, 5, 4, 5 };
        int[] n3 = { 3, 7 };

        Solution solution = new();

        Console.WriteLine(solution.MaxProduct(n1));
        Console.WriteLine(solution.MaxProduct(n2));
        Console.WriteLine(solution.MaxProduct(n3));
    }

    public int MaxProduct(int[] nums)
    {
        int max = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                int checkMax;
                
                if (i != j)
                {
                    checkMax = (nums[i] - 1) * (nums[j] - 1);

                    if (checkMax > max)
                    {
                        max = checkMax;
                    }
                }
            }
        }

        return max;
    }
}