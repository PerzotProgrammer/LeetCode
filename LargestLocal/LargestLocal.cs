namespace LargestLocal;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[9,9,8,1],[5,6,2,6],[8,2,6,4],[6,2,2,2]]
        // Output: [[9,9],[8,6]]
        // Explanation: The diagram above shows the original matrix and the generated matrix.
        // Notice that each value in the generated matrix corresponds to the largest value of a contiguous 3 x 3 matrix in grid.

        // Example 2:
        //
        // Input: grid = [[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]]
        // Output: [[2,2,2],[2,2,2],[2,2,2]]
        // Explanation: Notice that the 2 is contained within every contiguous 3 x 3 matrix in grid.

        Solution solution = new();

        PrintMatrix(solution.LargestLocal([[9, 9, 8, 1], [5, 6, 2, 6], [8, 2, 6, 4], [6, 2, 2, 2]]));
        PrintMatrix(solution.LargestLocal([
            [1, 1, 1, 1, 1], [1, 1, 1, 1, 1], [1, 1, 2, 1, 1], [1, 1, 1, 1, 1], [1, 1, 1, 1, 1]
        ]));
    }

    public int[][] LargestLocal(int[][] grid)
    {
        int[][] maxLocal = new int[grid.Length - 2][];

        for (int i = 0; i < grid.Length - 2; i++)
        {
            maxLocal[i] = new int[grid.Length - 2];
            for (int j = 0; j < grid.Length - 2; j++) maxLocal[i][j] = FindMaxInSubmatrix(grid, i, j);
        }

        return maxLocal;
    }

    private int FindMaxInSubmatrix(int[][] grid, int row, int col)
    {
        int max = int.MinValue;
        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++) max = Math.Max(max, grid[i][j]);
        }

        return max;
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