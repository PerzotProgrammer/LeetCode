namespace MinimumTime;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/minimum-time-to-visit-a-cell-in-a-grid/solutions/6093432/c-solution-for-minimum-time-to-visit-a-cell-in-a-grid-problem/?envType=daily-question&envId=2024-11-29
        // Example 1:
        //
        // Input: grid = [[0,1,3,2],[5,1,2,5],[4,3,8,6]]
        // Output: 7
        // Explanation: One of the paths that we can take is the following:
        // - at t = 0, we are on the cell (0,0).
        // - at t = 1, we move to the cell (0,1). It is possible because grid[0][1] <= 1.
        // - at t = 2, we move to the cell (1,1). It is possible because grid[1][1] <= 2.
        // - at t = 3, we move to the cell (1,2). It is possible because grid[1][2] <= 3.
        // - at t = 4, we move to the cell (1,1). It is possible because grid[1][1] <= 4.
        // - at t = 5, we move to the cell (1,2). It is possible because grid[1][2] <= 5.
        // - at t = 6, we move to the cell (1,3). It is possible because grid[1][3] <= 6.
        // - at t = 7, we move to the cell (2,3). It is possible because grid[2][3] <= 7.
        // The final time is 7. It can be shown that it is the minimum time possible.

        // Example 2:
        //
        // Input: grid = [[0,2,4],[3,2,1],[1,0,4]]
        // Output: -1
        // Explanation: There is no path from the top left to the bottom-right cell.


        Solution solution = new();

        Console.WriteLine(solution.MinimumTime([[0, 1, 3, 2], [5, 1, 2, 5], [4, 3, 8, 6]]));
        Console.WriteLine(solution.MinimumTime([[0, 2, 4], [3, 2, 1], [1, 0, 4]]));
    }

    public int MinimumTime(int[][] grid)
    {
        if (grid[0][1] > 1 && grid[1][0] > 1) return -1;

        PriorityQueue<(int time, int row, int col), int> pq = new();
        pq.Enqueue((0, 0, 0), 0);

        bool[,] visited = new bool[grid.Length, grid[0].Length];
        int[][] directions = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 },
            new[] { 0, -1 },
            new[] { -1, 0 }
        };

        while (pq.Count > 0)
        {
            (int time, int row, int col) = pq.Dequeue();
            if (row == grid.Length - 1 && col == grid[0].Length - 1) return time;

            if (visited[row, col]) continue;
            visited[row, col] = true;

            foreach (int[] dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid[0].Length)
                {
                    int nextTime = time + 1;
                    int requiredTime = grid[newRow][newCol];

                    if (nextTime < requiredTime)
                    {
                        int wait = (requiredTime - nextTime) % 2 == 0 ? 0 : 1;
                        nextTime = requiredTime + wait;
                    }

                    if (!visited[newRow, newCol]) pq.Enqueue((nextTime, newRow, newCol), nextTime);
                }
            }
        }

        return -1;
    }
}