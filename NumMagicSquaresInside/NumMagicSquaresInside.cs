namespace NumMagicSquaresInside;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[4,3,8,4],[9,5,1,9],[2,7,6,2]]
        // Output: 1
        // Explanation: 
        // The following subgrid is a 3 x 3 magic square:
        // ...
        // while this one is not:
        // ...
        // In total, there is only one magic square inside the given grid.

        // Example 2:
        //
        // Input: grid = [[8]]
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.NumMagicSquaresInside([[4, 3, 8, 4], [9, 5, 1, 9], [2, 7, 6, 2]]));
        Console.WriteLine(solution.NumMagicSquaresInside([[8]]));
    }

    public int NumMagicSquaresInside(int[][] grid)
    {
        int output = 0;
        for (int row = 0; row + 2 < grid.Length; row++)
        {
            for (int col = 0; col + 2 < grid[0].Length; col++)
            {
                if (IsMagicSquare(grid, row, col)) output++;
            }
        }

        return output;
    }

    private bool IsMagicSquare(int[][] grid, int row, int col)
    {
        bool[] seen = new bool[10];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int num = grid[row + i][col + j];
                if (num < 1 || num > 9) return false;
                if (seen[num]) return false;
                seen[num] = true;
            }
        }

        int diagonal1 =
            grid[row][col] + grid[row + 1][col + 1] + grid[row + 2][col + 2];
        int diagonal2 =
            grid[row + 2][col] + grid[row + 1][col + 1] + grid[row][col + 2];

        if (diagonal1 != diagonal2) return false;

        int row1 = grid[row][col] + grid[row][col + 1] + grid[row][col + 2];
        int row2 =
            grid[row + 1][col] +
            grid[row + 1][col + 1] +
            grid[row + 1][col + 2];
        int row3 =
            grid[row + 2][col] +
            grid[row + 2][col + 1] +
            grid[row + 2][col + 2];

        if (!(row1 == diagonal1 && row2 == diagonal1 && row3 == diagonal1)) return false;

        int col1 = grid[row][col] + grid[row + 1][col] + grid[row + 2][col];
        int col2 =
            grid[row][col + 1] +
            grid[row + 1][col + 1] +
            grid[row + 2][col + 1];
        int col3 =
            grid[row][col + 2] +
            grid[row + 1][col + 2] +
            grid[row + 2][col + 2];

        if (!(col1 == diagonal1 && col2 == diagonal1 && col3 == diagonal2)) return false;
        return true;
    }
}