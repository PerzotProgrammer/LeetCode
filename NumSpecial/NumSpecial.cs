namespace NumSpecial;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: mat = [[1,0,0],[0,0,1],[1,0,0]]
        // Output: 1
        // Explanation: (1, 2) is a special position because mat[1][2] == 1 and all other elements in row 1 and column 2 are 0.
        //     Example 2:
        //
        //
        // Input: mat = [[1,0,0],[0,1,0],[0,0,1]]
        // Output: 3
        // Explanation: (0, 0), (1, 1) and (2, 2) are special positions.

        int[][] mat1 = { new int[] { 1, 0, 0 }, new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 } };
        int[][] mat2 = { new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 } };

        Solution solution = new();

        Console.WriteLine(solution.NumSpecial(mat1));
        Console.WriteLine(solution.NumSpecial(mat2));
    }

    public int NumSpecial(int[][] mat)
    {
        int xDim = mat.Length;
        int yDim = mat[0].Length;
        int specials = 0;
        for (int i = 0; i < xDim; i++)
        {
            for (int j = 0; j < yDim; j++)
            {
                bool isSpecial = true;
                if (mat[i][j] == 1)
                {
                    for (int k = 0; k < xDim; k++)
                    {
                        if (mat[k][j] == 1 && i != k)
                        {
                            isSpecial = false;
                            break;
                        }
                    }

                    for (int k = 0; k < yDim; k++)
                    {
                        if (mat[i][k] == 1 && j != k)
                        {
                            isSpecial = false;
                            break;
                        }
                    }

                    if (isSpecial) specials++;
                }
            }
        }

        return specials;
    }
}