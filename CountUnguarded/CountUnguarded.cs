namespace CountUnguarded;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: m = 4, n = 6, guards = [[0,0],[1,1],[2,3]], walls = [[0,1],[2,2],[1,4]]
        // Output: 7
        // Explanation: The guarded and unguarded cells are shown in red and green respectively in the above diagram.
        // There are a total of 7 unguarded cells, so we return 7.

        // Example 2:
        //
        // Input: m = 3, n = 3, guards = [[1,1]], walls = [[0,1],[1,0],[2,1],[1,2]]
        // Output: 4
        // Explanation: The unguarded cells are shown in green in the above diagram.
        // There are a total of 4 unguarded cells, so we return 4.


        Solution solution = new();

        Console.WriteLine(solution.CountUnguarded(4, 6, [[0, 0], [1, 1], [2, 3]], [[0, 1], [2, 2], [1, 4]]));
        Console.WriteLine(solution.CountUnguarded(3, 3, [[1, 1]], [[0, 1], [1, 0], [2, 1], [1, 2]]));
    }

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        HashSet<(int, int)> blockedCells = new();
        HashSet<(int, int)> guardedCells = new();

        foreach (int[] wall in walls) blockedCells.Add((wall[0], wall[1]));
        foreach (int[] guard in guards) blockedCells.Add((guard[0], guard[1]));

        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        foreach (int[] guard in guards)
        {
            int x = guard[0];
            int y = guard[1];

            for (int d = 0; d < 4; d++)
            {
                int nx = x;
                int ny = y;

                while (true)
                {
                    nx += dx[d];
                    ny += dy[d];

                    if (nx < 0 || ny < 0 || nx >= m || ny >= n || blockedCells.Contains((nx, ny))) break;

                    guardedCells.Add((nx, ny));
                }
            }
        }

        int unguardedCount = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                (int, int) cell = (i, j);
                if (!blockedCells.Contains(cell) && !guardedCells.Contains(cell)) unguardedCount++;
            }
        }

        return unguardedCount;
    }
}