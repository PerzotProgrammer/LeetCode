namespace IslandPerimeter;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
        // Output: 16
        // Explanation: The perimeter is the 16 yellow stripes in the image above.

        //Example 2:
        //
        // Input: grid = [[1]]
        // Output: 4

        // Example 3:
        //
        // Input: grid = [[1,0]]
        // Output: 4

        Solution solution = new();

        Console.WriteLine(solution.IslandPerimeter([[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]]));
        Console.WriteLine(solution.IslandPerimeter([[1]]));
        Console.WriteLine(solution.IslandPerimeter([[1, 0]]));
    }

    public int IslandPerimeter(int[][] grid)
    {
        int output = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    output += 4;

                    if (i > 0 && grid[i - 1][j] == 1) output -= 2;
                    if (j > 0 && grid[i][j - 1] == 1) output -= 2;
                }
            }
        }

        return output;
    }
}