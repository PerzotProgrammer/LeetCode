namespace CountSquares;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: matrix =
        // [
        //     [0,1,1,1],
        //     [1,1,1,1],
        //     [0,1,1,1]
        // ]
        // Output: 15
        // Explanation: 
        // There are 10 squares of side 1.
        // There are 4 squares of side 2.
        // There is  1 square of side 3.
        // Total number of squares = 10 + 4 + 1 = 15.

        // Example 2:
        //
        // Input: matrix = 
        // [
        //     [1,0,1],
        //     [1,1,0],
        //     [1,1,0]
        // ]
        // Output: 7
        // Explanation: 
        // There are 6 squares of side 1.  
        // There is 1 square of side 2. 
        // Total number of squares = 6 + 1 = 7.


        Solution solution = new();

        Console.WriteLine(solution.CountSquares([[0, 1, 1, 1], [1, 1, 1, 1], [0, 1, 1, 1]]));
        Console.WriteLine(solution.CountSquares([[1, 0, 1], [1, 1, 0], [1, 1, 0]]));
    }

    public int CountSquares(int[][] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 1)
                {
                    int maxSize = Math.Min(matrix.Length - i, matrix[0].Length - j);
                    for (int size = 1; size <= maxSize; size++)
                    {
                        bool isSquare = true;
                        for (int x = 0; x < size && isSquare; x++)
                        {
                            if (matrix[i + x][j + size - 1] == 0 || matrix[i + size - 1][j + x] == 0) isSquare = false;
                        }

                        if (isSquare) count++;
                        else break;
                    }
                }
            }
        }

        return count;
    }
}