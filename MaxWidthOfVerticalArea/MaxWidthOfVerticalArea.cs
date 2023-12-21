namespace MaxWidthOfVerticalArea;

class Solution
{
    static void Main()
    {
        // Example 1:
        // Input: points = [[8,7],[9,9],[7,4],[9,7]]
        // Output: 1
        // Explanation: Both the red and the blue area are optimal.
        //
        //     
        //Example 2:     
        // Input: points = [[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]
        // Output: 3

        int[][] p1 = { new int[] { 8, 7 }, new int[] { 9, 9 }, new int[] { 7, 4 }, new int[] { 9, 7 } };
        int[][] p2 = { new int[] { 3, 1 }, new int[] { 9, 0 }, new int[] { 1, 0 }, new int[] { 1, 4 }, new int[] { 5, 3 }, new int[] { 8, 8 } };

        Solution solution = new();

        Console.WriteLine(solution.MaxWidthOfVerticalArea(p1));
        Console.WriteLine(solution.MaxWidthOfVerticalArea(p2));
    }

    public int MaxWidthOfVerticalArea(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0] - b[0]); // stack overflow <3
        // Debug
        // PrintMatrix(points);
        int shortestLen = 0;

        for (int i = 1; i < points.Length; i++)
        {
            int checkLen = points[i][0] - points[i - 1][0];
            if (checkLen > shortestLen) shortestLen = checkLen;
        }

        return shortestLen;
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