namespace FindMatrix;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,4,1,2,3,1]
        // Output: [[1,3,4,2],[1,3],[1]]
        // Explanation: We can create a 2D array that contains the following rows:
        // - 1,3,4,2
        // - 1,3
        // - 1
        // All elements of nums were used, and each row of the 2D array contains distinct integers, so it is a valid answer.
        // It can be shown that we cannot have less than 3 rows in a valid array.

        // Example 2:
        //
        // Input: nums = [1,2,3,4]
        // Output: [[4,3,2,1]]
        // Explanation: All elements of the array are distinct, so we can keep all of them in the first row of the 2D array.

        int[] n1 = { 1, 3, 4, 1, 2, 3, 1 };
        int[] n2 = { 1, 2, 3, 4 };

        Solution solution = new();

        PrintMatrix(solution.FindMatrix(n1));
        PrintMatrix(solution.FindMatrix(n2));
    }

    public IList<IList<int>> FindMatrix(int[] nums)
    {
        int[] Freq = new int[nums.Length + 1];
        IList<IList<int>> Matrix = new List<IList<int>>();

        foreach (int num in nums)
        {
            if (Freq[num] >= Matrix.Count)
            {
                Matrix.Add(new List<int>());
            }

            Matrix.ElementAt(Freq[num]).Add(num);
            Freq[num]++;
        }

        return Matrix;
    }

    static void PrintMatrix(IList<IList<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write($"{matrix[i][j]},");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}