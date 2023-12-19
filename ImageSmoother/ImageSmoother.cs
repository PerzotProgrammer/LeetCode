namespace ImageSmoother;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: img = [[1,1,1],[1,0,1],[1,1,1]]
        // Output: [[0,0,0],[0,0,0],[0,0,0]]
        // Explanation:
        // For the points (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
        // For the points (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
        // For the point (1,1): floor(8/9) = floor(0.88888889) = 0

        // Example 2:
        //
        //
        // Input: img = [[100,200,100],[200,50,200],[100,200,100]]
        // Output: [[137,141,137],[141,138,141],[137,141,137]]
        // Explanation:
        // For the points (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137.5) = 137
        // For the points (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) = floor(141.666667) = 141
        // For the point (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.888889) = 138

        int[][] i1 = { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
        int[][] i2 = { new int[] { 100, 200, 100 }, new int[] { 200, 50, 200 }, new[] { 100, 200, 100 } };

        Solution solution = new();

        PrintMatrix(solution.ImageSmoother(i1));
        PrintMatrix(solution.ImageSmoother(i2));
    }

    public int[][] ImageSmoother(int[][] img)
    {
        int yDim = img.Length;
        int xDim = img[0].Length;

        int[][] imgOut = new int[yDim][];
        for (int i = 0; i < yDim; i++) imgOut[i] = new int[xDim];

        for (int i = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++)
            {
                int sum = 0;
                int count = 0;

                for (int x = i - 1; x <= i + 1; x++)
                {
                    for (int y = j - 1; y <= j + 1; y++)
                    {
                        if (0 <= x && x < yDim && 0 <= y && y < xDim)
                        {
                            sum += img[x][y];
                            count++;
                        }
                    }
                }

                imgOut[i][j] = sum / count;
            }
        }

        return imgOut;
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