﻿namespace Construct2DArray;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: original = [1,2,3,4], m = 2, n = 2
        // Output: [[1,2],[3,4]]
        // Explanation: The constructed 2D array should contain 2 rows and 2 columns.
        // The first group of n=2 elements in original, [1,2], becomes the first row in the constructed 2D array.
        // The second group of n=2 elements in original, [3,4], becomes the second row in the constructed 2D array.

        // Example 2:
        //
        // Input: original = [1,2,3], m = 1, n = 3
        // Output: [[1,2,3]]
        // Explanation: The constructed 2D array should contain 1 row and 3 columns.
        // Put all three elements in original into the first row of the constructed 2D array.

        // Example 3:
        //
        // Input: original = [1,2], m = 1, n = 1
        // Output: []
        // Explanation: There are 2 elements in original.
        // It is impossible to fit 2 elements in a 1x1 2D array, so return an empty 2D array.


        Solution solution = new();

        PrintMatrix(solution.Construct2DArray([1, 2, 3, 4], 2, 2));
        PrintMatrix(solution.Construct2DArray([1, 2, 3], 1, 3));
        PrintMatrix(solution.Construct2DArray([1, 2], 1, 1));
    }

    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (m * n != original.Length)
        {
            return [];
        }

        int[][] result = new int[m][];
        for (int i = 0; i < m; i++) result[i] = new int[n];

        for (int i = 0; i < original.Length; i++) result[i / n][i % n] = original[i];

        return result;
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] ints in matrix)
        {
            foreach (int i in ints) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}