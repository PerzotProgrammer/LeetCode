namespace FindFarmland;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: land = [[1,0,0],[0,1,1],[0,1,1]]
        // Output: [[0,0,0,0],[1,1,2,2]]
        // Explanation:
        // The first group has a top left corner at land[0][0] and a bottom right corner at land[0][0].
        //The second group has a top left corner at land[1][1] and a bottom right corner at land[2][2].

        // Example 2:
        //
        // Input: land = [[1,1],[1,1]]
        // Output: [[0,0,1,1]]
        // Explanation:
        // The first group has a top left corner at land[0][0] and a bottom right corner at land[1][1].

        // Example 3:
        //
        // Input: land = [[0]]
        // Output: []
        // Explanation:
        // There are no groups of farmland.

        Solution solution = new();

        PrintMatrix(solution.FindFarmland([[1, 0, 0], [0, 1, 1], [0, 1, 1]]));
        PrintMatrix(solution.FindFarmland([[1, 1], [1, 1]]));
        PrintMatrix(solution.FindFarmland([[0]]));
    }

    public int[][] FindFarmland(int[][] land)
    {
        List<int[]> output = new();

        for (int row = 0; row < land.Length; row++)
        {
            for (int col = 0; col < land[0].Length; col++)
            {
                if (land[row][col] == 1)
                {
                    int x;
                    int y = col;
                    for (x = row; x < land.Length && land[x][col] == 1; x++)
                    {
                        for (y = col; y < land[0].Length && land[x][y] == 1; y++) land[x][y] = 0;
                    }

                    int[] arr = { row, col, x - 1, y - 1 };
                    output.Add(arr);
                }
            }
        }

        return output.ToArray();
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