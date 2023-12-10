namespace TransposeMatrix;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
        // Output: [[1,4,7],[2,5,8],[3,6,9]]
        // Example 2:
        //
        // Input: matrix = [[1,2,3],[4,5,6]]
        // Output: [[1,4],[2,5],[3,6]]

        int[][] m1 = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
        int[][] m2 = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };

        Solution solution = new();

        int[][] m1Out = solution.Transpose(m1);
        int[][] m2Out = solution.Transpose(m2);

        PrintMatrix(m1Out);
        PrintMatrix(m2Out);
    }

    public int[][] Transpose(int[][] matrix)
    {
        int xDim = matrix.Length;
        int yDim = matrix[0].Length;
        int[][] matrixOut = new int[yDim][];
        
        for (int i = 0; i < yDim; i++) matrixOut[i] = new int[xDim];

        for (int i = 0; i < xDim; i++)
        {
            for (int j = 0; j < yDim; j++)
            {
                matrixOut[j][i] = matrix[i][j];
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