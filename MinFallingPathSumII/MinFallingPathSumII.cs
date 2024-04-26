namespace MinFallingPathSumII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[1,2,3],[4,5,6],[7,8,9]]
        // Output: 13
        // Explanation: 
        // The possible falling paths are:
        // [1,5,9], [1,5,7], [1,6,7], [1,6,8],
        // [2,4,8], [2,4,9], [2,6,7], [2,6,8],
        // [3,4,8], [3,4,9], [3,5,7], [3,5,9]
        // The falling path with the smallest sum is [1,5,7], so the answer is 13.

        // Example 2:
        //
        // Input: grid = [[7]]
        // Output: 7

        Solution solution = new();

        Console.WriteLine(solution.MinFallingPathSum([[1, 2, 3], [4, 5, 6], [7, 8, 9]]));
        Console.WriteLine(solution.MinFallingPathSum([[7]]));
    }

    public int MinFallingPathSum(int[][] grid)
    {
        int nextMin1C = -1;
        int nextMin1 = -1;
        int nextMin2 = -1;

        for (int col = 0; col < grid.Length; col++)
        {
            if (nextMin1 == -1 || grid[^1][col] <= nextMin1)
            {
                nextMin2 = nextMin1;
                nextMin1 = grid[^1][col];
                nextMin1C = col;
            }
            else if (nextMin2 == -1 || grid[^1][col] <= nextMin2) nextMin2 = grid[^1][col];
        }

        for (int row = grid.Length - 2; row >= 0; row--)
        {
            int min1C = -1;
            int min1 = -1;
            int min2 = -1;

            for (int col = 0; col < grid.Length; col++)
            {
                int value;
                if (col != nextMin1C) value = grid[row][col] + nextMin1;
                else value = grid[row][col] + nextMin2;

                if (min1 == -1 || value <= min1)
                {
                    min2 = min1;
                    min1 = value;
                    min1C = col;
                }
                else if (min2 == -1 || value <= min2) min2 = value;
            }

            nextMin1C = min1C;
            nextMin1 = min1;
            nextMin2 = min2;
        }

        return nextMin1;
    }
}