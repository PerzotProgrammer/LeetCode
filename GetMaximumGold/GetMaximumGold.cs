namespace GetMaximumGold;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[0,6,0],[5,8,7],[0,9,0]]
        // Output: 24
        // Explanation:
        // [[0,6,0],
        // [5,8,7],
        // [0,9,0]]
        // Path to get the maximum gold, 9 -> 8 -> 7.

        // Example 2:
        //
        // Input: grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]]
        // Output: 28
        // Explanation:
        // [[1,0,7],
        // [2,0,6],
        // [3,4,5],
        // [0,3,0],
        // [9,0,20]]
        // Path to get the maximum gold, 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7.

        Solution solution = new();

        Console.WriteLine(solution.GetMaximumGold([[0, 6, 0], [5, 8, 7], [0, 9, 0]]));
        Console.WriteLine(solution.GetMaximumGold([[1, 0, 7], [2, 0, 6], [3, 4, 5], [0, 3, 0], [9, 0, 20]]));
    }

    public int GetMaximumGold(int[][] grid)
    {
        int max = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] != 0)
                {
                    max = Math.Max(max, Dfs(grid, i, j));
                }
            }
        }

        return max;
    }

    private int Dfs(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0) return 0;

        int temp = grid[i][j];
        grid[i][j] = 0;
        int maxOutput = 0;

        maxOutput = Math.Max(maxOutput, temp + Dfs(grid, i + 1, j));
        maxOutput = Math.Max(maxOutput, temp + Dfs(grid, i - 1, j));
        maxOutput = Math.Max(maxOutput, temp + Dfs(grid, i, j + 1));
        maxOutput = Math.Max(maxOutput, temp + Dfs(grid, i, j - 1));

        grid[i][j] = temp;

        return maxOutput;
    }
}