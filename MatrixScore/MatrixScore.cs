namespace MatrixScore;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: grid = [[0,0,1,1],[1,0,1,0],[1,1,0,0]]
        // Output: 39
        // Explanation: 0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39

        // Example 2:
        //
        // Input: grid = [[0]]
        // Output: 1

        Solution solution = new();

        Console.WriteLine(solution.MatrixScore([[0, 0, 1, 1], [1, 0, 1, 0], [1, 1, 0, 0]]));
        Console.WriteLine(solution.MatrixScore([[0]]));
    }

    public int MatrixScore(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            if (grid[i][0] == 0)
            {
                for (int j = 0; j < grid[0].Length; j++) grid[i][j] = 1 - grid[i][j];
            }
        }

        for (int j = 1; j < grid[0].Length; j++)
        {
            int countZero = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i][j] == 0) countZero++;
            }

            if (countZero > grid.Length - countZero)
            {
                for (int i = 0; i < grid.Length; i++) grid[i][j] = 1 - grid[i][j];
            }
        }

        int output = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                int columnScore = grid[i][j] << (grid[0].Length - j - 1);
                output += columnScore;
            }
        }

        return output;
    }
}