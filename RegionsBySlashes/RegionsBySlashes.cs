namespace RegionsBySlashes;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [" /","/ "]
        // Output: 2

        // Example 2:
        //
        // Input: grid = [" /","  "]
        // Output: 1

        // Example 3:
        //
        // Input: grid = ["/\\","\\/"]
        // Output: 5
        // Explanation: Recall that because \ characters are escaped, "\\/" refers to \/, and "/\\" refers to /\.


        Solution solution = new();

        Console.WriteLine(solution.RegionsBySlashes([" /", "/ "]));
        Console.WriteLine(solution.RegionsBySlashes([" /", "  "]));
        Console.WriteLine(solution.RegionsBySlashes(["/\\", "\\/"]));
    }

    public int RegionsBySlashes(string[] grid)
    {
        int size = grid.Length * 3;
        int[,] expandedGrid = new int[size, size];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid.Length; j++)
            {
                char c = grid[i][j];
                int r = i * 3;
                int c1 = j * 3;
                if (c == '/')
                {
                    expandedGrid[r, c1 + 2] = 1;
                    expandedGrid[r + 1, c1 + 1] = 1;
                    expandedGrid[r + 2, c1] = 1;
                }
                else if (c == '\\')
                {
                    expandedGrid[r, c1] = 1;
                    expandedGrid[r + 1, c1 + 1] = 1;
                    expandedGrid[r + 2, c1 + 2] = 1;
                }
            }
        }

        int regions = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (expandedGrid[i, j] == 0)
                {
                    regions++;
                    Dfs(expandedGrid, i, j, size);
                }
            }
        }

        return regions;
    }

    private void Dfs(int[,] grid, int r, int c, int size)
    {
        if (r < 0 || r >= size || c < 0 || c >= size || grid[r, c] != 0) return;

        grid[r, c] = 1;

        Dfs(grid, r - 1, c, size);
        Dfs(grid, r + 1, c, size);
        Dfs(grid, r, c - 1, size);
        Dfs(grid, r, c + 1, size);
    }
}