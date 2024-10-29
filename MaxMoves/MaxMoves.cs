namespace MaxMoves;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: grid = [[2,4,3,5],[5,4,9,3],[3,4,2,11],[10,9,13,15]]
        // Output: 3
        // Explanation: We can start at the cell (0, 0) and make the following moves:
        // - (0, 0) -> (0, 1).
        // - (0, 1) -> (1, 2).
        // - (1, 2) -> (2, 3).
        // It can be shown that it is the maximum number of moves that can be made.

        // Example 2:
        //
        // Input: grid = [[3,2,4],[2,1,9],[1,1,7]]
        // Output: 0
        // Explanation: Starting from any cell in the first column we cannot perform any moves.


        Solution solution = new();

        Console.WriteLine(solution.MaxMoves([[2, 4, 3, 5], [5, 4, 9, 3], [3, 4, 2, 11], [10, 9, 13, 15]]));
        Console.WriteLine(solution.MaxMoves([[3, 2, 4], [2, 1, 9], [1, 1, 7]]));
    }

    public int MaxMoves(int[][] grid)
    {
        int[] dirs = { -1, 0, 1 };
        Queue<int[]> queue = new();
        bool[][] visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++) visited[i] = new bool[grid[0].Length];

        for (int i = 0; i < grid.Length; i++)
        {
            visited[i][0] = true;
            queue.Enqueue([i, 0, 0]);
        }

        int maxMoves = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;

            while (size-- > 0)
            {
                int[] check = queue.Dequeue();

                int row = check[0];
                int col = check[1];
                int count = check[2];

                maxMoves = Math.Max(maxMoves, count);

                foreach (int dir in dirs)
                {
                    int newRow = row + dir, newCol = col + 1;

                    if (
                        newRow >= 0 &&
                        newCol >= 0 &&
                        newRow < grid.Length &&
                        newCol < grid[0].Length &&
                        !visited[newRow][newCol] &&
                        grid[row][col] < grid[newRow][newCol]
                    )
                    {
                        visited[newRow][newCol] = true;
                        queue.Enqueue([newRow, newCol, count + 1]);
                    }
                }
            }
        }

        return maxMoves;
    }
}