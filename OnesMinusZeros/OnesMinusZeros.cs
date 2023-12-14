namespace OnesMinusZeros;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: grid = [[0,1,1],[1,0,1],[0,0,1]]
        // Output: [[0,0,4],[0,0,4],[-2,-2,2]]
        // Explanation:
        // - diff[0][0] = onesRow0 + onesCol0 - zerosRow0 - zerosCol0 = 2 + 1 - 1 - 2 = 0 
        // - diff[0][1] = onesRow0 + onesCol1 - zerosRow0 - zerosCol1 = 2 + 1 - 1 - 2 = 0 
        // - diff[0][2] = onesRow0 + onesCol2 - zerosRow0 - zerosCol2 = 2 + 3 - 1 - 0 = 4 
        // - diff[1][0] = onesRow1 + onesCol0 - zerosRow1 - zerosCol0 = 2 + 1 - 1 - 2 = 0 
        // - diff[1][1] = onesRow1 + onesCol1 - zerosRow1 - zerosCol1 = 2 + 1 - 1 - 2 = 0 
        // - diff[1][2] = onesRow1 + onesCol2 - zerosRow1 - zerosCol2 = 2 + 3 - 1 - 0 = 4 
        // - diff[2][0] = onesRow2 + onesCol0 - zerosRow2 - zerosCol0 = 1 + 1 - 2 - 2 = -2
        // - diff[2][1] = onesRow2 + onesCol1 - zerosRow2 - zerosCol1 = 1 + 1 - 2 - 2 = -2
        // - diff[2][2] = onesRow2 + onesCol2 - zerosRow2 - zerosCol2 = 1 + 3 - 2 - 0 = 2

        // Example 2:
        //
        //
        // Input: grid = [[1,1,1],[1,1,1]]
        // Output: [[5,5,5],[5,5,5]]
        // Explanation:
        // - diff[0][0] = onesRow0 + onesCol0 - zerosRow0 - zerosCol0 = 3 + 2 - 0 - 0 = 5
        // - diff[0][1] = onesRow0 + onesCol1 - zerosRow0 - zerosCol1 = 3 + 2 - 0 - 0 = 5
        // - diff[0][2] = onesRow0 + onesCol2 - zerosRow0 - zerosCol2 = 3 + 2 - 0 - 0 = 5
        // - diff[1][0] = onesRow1 + onesCol0 - zerosRow1 - zerosCol0 = 3 + 2 - 0 - 0 = 5
        // - diff[1][1] = onesRow1 + onesCol1 - zerosRow1 - zerosCol1 = 3 + 2 - 0 - 0 = 5
        // - diff[1][2] = onesRow1 + onesCol2 - zerosRow1 - zerosCol2 = 3 + 2 - 0 - 0 = 5

        int[][] g1 = { new int[] { 0, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 0, 0, 1 } };
        int[][] g2 = { new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 }};

        Solution solution = new();
        
        PrintMatrix(solution.OnesMinusZeros(g1));
        PrintMatrix(solution.OnesMinusZeros(g2));
    }

    public int[][] OnesMinusZeros(int[][] grid)
    {
        int yDim = grid.Length;
        int xDim = grid[0].Length;

        int[] colArr = new int[xDim];
        int[] rowArr = new int[yDim];

        for (int i = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++)
            {
                if (grid[i][j] == 1)
                {
                    rowArr[i] += 1;
                    colArr[j] += 1;
                }
                else
                {
                    rowArr[i] -= 1;
                    colArr[j] -= 1;
                }
            }
        }

        int[][] matrixOut = new int[yDim][];

        for (int i = 0; i < yDim; i++)
        {
            matrixOut[i] = new int[xDim];

            for (int j = 0; j < xDim; j++)
            {
                matrixOut[i][j] = colArr[j] + rowArr[i];
            }
        }

        return matrixOut;
    }
    
    static void PrintMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Console.Write($"{matrix[i][j]}, ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}