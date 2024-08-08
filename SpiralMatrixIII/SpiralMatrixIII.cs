namespace SpiralMatrixIII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: rows = 1, cols = 4, rStart = 0, cStart = 0
        // Output: [[0,0],[0,1],[0,2],[0,3]]

        // Example 2:
        //
        // Input: rows = 5, cols = 6, rStart = 1, cStart = 4
        // Output: [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]]


        Solution solution = new();

        PrintMatrix(solution.SpiralMatrixIII(1, 4, 0, 0));
        PrintMatrix(solution.SpiralMatrixIII(5, 6, 1, 4));
    }

    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        int[][] directions =
        [
            [0, 1],
            [1, 0],
            [0, -1],
            [-1, 0]
        ];

        int totalCells = rows * cols;
        int[][] result = new int[totalCells][];
        int x = rStart;
        int y = cStart;
        int direction = 0;
        int steps = 1;
        int index = 0;

        result[index++] = [x, y];

        while (index < totalCells)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < steps; j++)
                {
                    x += directions[direction][0];
                    y += directions[direction][1];
                    if (x >= 0 && x < rows && y >= 0 && y < cols) result[index++] = [x, y];
                }

                direction = (direction + 1) % 4;
            }

            steps++;
        }

        return result;
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] ints in matrix)
        {
            foreach (int i in ints) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}