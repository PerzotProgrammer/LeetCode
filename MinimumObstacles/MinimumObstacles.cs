namespace MinimumObstacles;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: grid = [[0,1,1],[1,1,0],[1,1,0]]
        // Output: 2
        // Explanation: We can remove the obstacles at (0, 1) and (0, 2) to create a path from (0, 0) to (2, 2).
        // It can be shown that we need to remove at least 2 obstacles, so we return 2.
        // Note that there may be other ways to remove 2 obstacles to create a path.

        // Example 2:
        //
        // Input: grid = [[0,1,0,0,0],[0,1,0,1,0],[0,0,0,1,0]]
        // Output: 0
        // Explanation: We can move from (0, 0) to (2, 4) without removing any obstacles, so we return 0.


        Solution solution = new();

        Console.WriteLine(solution.MinimumObstacles([[0, 1, 1], [1, 1, 0], [1, 1, 0]]));
        Console.WriteLine(solution.MinimumObstacles([[0, 1, 0, 0, 0], [0, 1, 0, 1, 0], [0, 0, 0, 1, 0]]));
    }

    public int MinimumObstacles(int[][] grid)
    {
        int[][] directions = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 },
            new[] { 0, -1 },
            new[] { -1, 0 }
        };
        LinkedList<int[]> deque = new();
        deque.AddFirst([0, 0, 0]);
        int[,] visited = new int[grid.Length, grid[0].Length];
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++) visited[i, j] = int.MaxValue;
        }

        visited[0, 0] = 0;

        while (deque.Count > 0)
        {
            int[] current = deque.First!.Value;
            deque.RemoveFirst();
            int x = current[0];
            int y = current[1];
            int obstaclesRemoved = current[2];

            if (x == grid.Length - 1 && y == grid[0].Length - 1) return obstaclesRemoved;

            foreach (int[] dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];
                if (newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid[0].Length)
                {
                    int newObstaclesRemoved = obstaclesRemoved + grid[newX][newY];

                    if (newObstaclesRemoved < visited[newX, newY])
                    {
                        visited[newX, newY] = newObstaclesRemoved;

                        if (grid[newX][newY] == 0) deque.AddFirst([newX, newY, newObstaclesRemoved]);
                        else deque.AddLast([newX, newY, newObstaclesRemoved]);
                    }
                }
            }
        }

        return -1;
    }
}