namespace CountSubIslands;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: grid1 = [[1,1,1,0,0],[0,1,1,1,1],[0,0,0,0,0],[1,0,0,0,0],[1,1,0,1,1]], grid2 = [[1,1,1,0,0],[0,0,1,1,1],[0,1,0,0,0],[1,0,1,1,0],[0,1,0,1,0]]
        // Output: 3
        // Explanation: In the picture above, the grid on the left is grid1 and the grid on the right is grid2.
        // The 1s colored red in grid2 are those considered to be part of a sub-island. There are three sub-islands.

        // Example 2:
        //
        // Input: grid1 = [[1,0,1,0,1],[1,1,1,1,1],[0,0,0,0,0],[1,1,1,1,1],[1,0,1,0,1]], grid2 = [[0,0,0,0,0],[1,1,1,1,1],[0,1,0,1,0],[0,1,0,1,0],[1,0,0,0,1]]
        // Output: 2 
        // Explanation: In the picture above, the grid on the left is grid1 and the grid on the right is grid2.
        //vThe 1s colored red in grid2 are those considered to be part of a sub-island. There are two sub-islands.


        Solution solution = new();

        Console.WriteLine(solution.CountSubIslands(
            [[1, 1, 1, 0, 0], [0, 1, 1, 1, 1], [0, 0, 0, 0, 0], [1, 0, 0, 0, 0], [1, 1, 0, 1, 1]],
            [[1, 1, 1, 0, 0], [0, 0, 1, 1, 1], [0, 1, 0, 0, 0], [1, 0, 1, 1, 0], [0, 1, 0, 1, 0]]));
        Console.WriteLine(solution.CountSubIslands(
            [[1, 0, 1, 0, 1], [1, 1, 1, 1, 1], [0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [1, 0, 1, 0, 1]],
            [[0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [0, 1, 0, 1, 0], [0, 1, 0, 1, 0], [1, 0, 0, 0, 1]]));
    }

    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int subIslandsCount = 0;

        int[][] directions =
        {
            [0, 1],
            [1, 0],
            [0, -1],
            [-1, 0]
        };

        for (int i = 0; i < grid2.Length; i++)
        {
            for (int j = 0; j < grid2[0].Length; j++)
            {
                if (grid2[i][j] == 1)
                {
                    if (Bfs(grid1, grid2, i, j, directions)) subIslandsCount++;
                }
            }
        }

        return subIslandsCount;
    }

    private bool Bfs(int[][] grid1, int[][] grid2, int startX, int startY, int[][] directions)
    {
        Queue<int[]> queue = new();
        queue.Enqueue([startX, startY]);

        bool isSubIsland = true;

        grid2[startX][startY] = 0;

        while (queue.Count > 0)
        {
            int[] cell = queue.Dequeue();
            int x = cell[0];
            int y = cell[1];

            if (grid1[x][y] == 0) isSubIsland = false;

            foreach (int[] dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];

                if (newX >= 0 && newX < grid2.Length && newY >= 0 && newY < grid2[0].Length && grid2[newX][newY] == 1)
                {
                    queue.Enqueue([newX, newY]);
                    grid2[newX][newY] = 0;
                }
            }
        }

        return isSubIsland;
    }
}