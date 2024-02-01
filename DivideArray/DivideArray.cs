namespace DivideArray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,4,8,7,9,3,5,1], k = 2
        // Output: [[1,1,3],[3,4,5],[7,8,9]]
        // Explanation: We can divide the array into the following arrays: [1,1,3], [3,4,5] and [7,8,9].
        // The difference between any two elements in each array is less than or equal to 2.
        // Note that the order of elements is not important.

        // Example 2:
        //
        // Input: nums = [1,3,3,2,7,3], k = 3
        // Output: []
        // Explanation: It is not possible to divide the array satisfying all the conditions.

        Solution solution = new();

        int[][] a1 = solution.DivideArray([1, 3, 4, 8, 7, 9, 3, 5, 1], 2);
        int[][] a2 = solution.DivideArray([1,3,3,2,7,3], 3);
        
        PrintMatrix(a1);
        Console.WriteLine();
        PrintMatrix(a2);
    }

    public int[][] DivideArray(int[] nums, int k)
    {
        int[][] output = new int[nums.Length / 3][];

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i += 3)
        {
            int n1 = nums[i];
            int n2 = nums[i + 1];
            int n3 = nums[i + 2];

            bool divisible = n3 - n1 <= k;

            if (!divisible) return [];

            output[i / 3] = [n1, n2, n3];
        }

        return output;
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] array in matrix)
        {
            foreach (int element in array)
            {
                Console.Write($"{element}; ");
            }

            Console.WriteLine();
        }
    }
}