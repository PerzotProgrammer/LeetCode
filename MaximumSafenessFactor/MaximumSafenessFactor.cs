namespace MaximumSafenessFactor;

class Solution
{
    static void Main()
    {
        // LEKKA POMOC LEETCODE
        // Example 1:
        //
        // Input: grid = [[1,0,0],[0,0,0],[0,0,1]]
        // Output: 0
        // Explanation: All paths from (0, 0) to (n - 1, n - 1) go through the thieves in cells (0, 0) and (n - 1, n - 1).

        // Example 2:
        //
        // Input: grid = [[0,0,1],[0,0,0],[0,0,0]]
        // Output: 2
        // Explanation: The path depicted in the picture above has a safeness factor of 2 since:
        // - The closest cell of the path to the thief at cell (0, 2) is cell (0, 0). The distance between them is | 0 - 0 | + | 0 - 2 | = 2.
        // It can be shown that there are no other paths with a higher safeness factor.

        // Example 3:
        //
        // Input: grid = [[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]
        // Output: 2
        // Explanation: The path depicted in the picture above has a safeness factor of 2 since:
        // - The closest cell of the path to the thief at cell (0, 3) is cell (1, 2). The distance between them is | 0 - 1 | + | 3 - 2 | = 2.
        // - The closest cell of the path to the thief at cell (3, 0) is cell (3, 2). The distance between them is | 3 - 3 | + | 0 - 2 | = 2.
        // It can be shown that there are no other paths with a higher safeness factor.


        Solution solution = new();

        Console.WriteLine(solution.MaximumSafenessFactor([[1, 0, 0], [0, 0, 0], [0, 0, 1]]));
        Console.WriteLine(solution.MaximumSafenessFactor([[0, 0, 1], [0, 0, 0], [0, 0, 0]]));
        Console.WriteLine(solution.MaximumSafenessFactor([[0, 0, 0, 1], [0, 0, 0, 0], [0, 0, 0, 0], [1, 0, 0, 0]]));
    }

    private int[][] Dir = { [0, 1], [0, -1], [1, 0], [-1, 0] };

    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int[,] mat = new int[grid.Count, grid.Count];
        Queue<int[]> multiSourceQueue = new();

        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid.Count; j++)
            {
                if (grid[i][j] == 1)
                {
                    multiSourceQueue.Enqueue([i, j]);
                    mat[i, j] = 0;
                }
                else mat[i, j] = -1;
            }
        }

        while (multiSourceQueue.Count > 0)
        {
            int size = multiSourceQueue.Count;
            while (size > 0)
            {
                size--;
                int[] curr = multiSourceQueue.Dequeue();
                foreach (int[] d in Dir)
                {
                    int di = curr[0] + d[0];
                    int dj = curr[1] + d[1];
                    int val = mat[curr[0], curr[1]];
                    if (IsValidCell(mat, di, dj) && mat[di, dj] == -1)
                    {
                        mat[di, dj] = val + 1;
                        multiSourceQueue.Enqueue([di, dj]);
                    }
                }
            }
        }

        int start = 0;
        int end = 0;
        int res = -1;
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid.Count; j++) end = Math.Max(end, mat[i, j]);
        }

        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            if (IsValidSafeness(mat, mid))
            {
                res = mid;
                start = mid + 1;
            }
            else end = mid - 1;
        }

        return res;
    }

    private bool IsValidSafeness(int[,] grid, int minSafeness)
    {
        int n = grid.GetLength(0);

        if (grid[0, 0] < minSafeness || grid[n - 1, n - 1] < minSafeness) return false;

        Queue<int[]> traversalQueue = new();
        traversalQueue.Enqueue([0, 0]);
        bool[,] visited = new bool[n, n];
        visited[0, 0] = true;

        while (traversalQueue.Count > 0)
        {
            int[] curr = traversalQueue.Dequeue();
            if (curr[0] == n - 1 && curr[1] == n - 1) return true;

            foreach (int[] d in Dir)
            {
                int di = curr[0] + d[0];
                int dj = curr[1] + d[1];
                if (IsValidCell(grid, di, dj) && !visited[di, dj] && grid[di, dj] >= minSafeness)
                {
                    visited[di, dj] = true;
                    traversalQueue.Enqueue([di, dj]);
                }
            }
        }

        return false;
    }

    private bool IsValidCell(int[,] mat, int i, int j)
    {
        int n = mat.GetLength(0);
        return i >= 0 && j >= 0 && i < n && j < n;
    }
}