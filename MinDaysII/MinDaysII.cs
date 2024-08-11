namespace MinDaysII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[0,1,1,0],[0,1,1,0],[0,0,0,0]]
        // Output: 2
        // Explanation: We need at least 2 days to get a disconnected grid.
        // Change land grid[1][1] and grid[0][2] to water and get 2 disconnected island.

        // Example 2:
        //
        // Input: grid = [[1,1]]
        // Output: 2
        // Explanation: Grid of full water is also disconnected ([[1,1]] -> [[0,0]]), 0 islands.


        Solution solution = new();

        Console.WriteLine(solution.MinDays([[0, 1, 1, 0], [0, 1, 1, 0], [0, 0, 0, 0]]));
        Console.WriteLine(solution.MinDays([[1, 1]]));
    }

    public int MinDays(int[][] grid)
    {
        if (CountIslands(grid) != 1) return 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    if (CountIslands(grid) != 1) return 1;
                    grid[i][j] = 1;
                }
            }
        }

        return 2;
    }

    private int CountIslands(int[][] grid)
    {
        bool[,] visited = new bool[grid.Length, grid[0].Length];
        int islandCount = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1 && !visited[i, j])
                {
                    islandCount++;
                    Dfs(grid, visited, i, j);
                }
            }
        }

        return islandCount;
    }

    private void Dfs(int[][] grid, bool[,] visited, int i, int j)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        visited[i, j] = true;

        for (int k = 0; k < 4; k++)
        {
            int newX = i + dx[k];
            int newY = j + dy[k];

            if (newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid[0].Length &&
                grid[newX][newY] == 1 && !visited[newX, newY])
            {
                Dfs(grid, visited, newX, newY);
            }
        }
    }
}