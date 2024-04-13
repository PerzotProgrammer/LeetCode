namespace MaximalRectangle;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/maximal-rectangle/solutions/5014792/c-solution-for-maximal-rectangle-problem/?envType=daily-question&envId=2024-04-13
        // Example 1:
        //
        // Input: matrix = [['1','0','1','0','0'],['1','0','1','1','1'],['1','1','1','1','1'],['1','0','0','1','0']]
        // Output: 6
        // Explanation: The maximal rectangle is shown in the above picture.

        // Example 2:
        //
        // Input: matrix = [['0']]
        // Output: 0

        // Example 3:
        //
        // Input: matrix = [['1']]
        // Output: 1

        Solution solution = new();
        Console.WriteLine(solution.MaximalRectangle([
            ['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']
        ]));
        Console.WriteLine(solution.MaximalRectangle([['0']]));
        Console.WriteLine(solution.MaximalRectangle([['1']]));
    }

    public int MaximalRectangle(char[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;

        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int maxArea = 0;
        int[] heights = new int[cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }

        return maxArea;
    }

    private int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new();
        int maxArea = 0;
        int i = 0;

        while (i < heights.Length)
        {
            if (stack.Count == 0 || heights[stack.Peek()] <= heights[i]) stack.Push(i++);
            else
            {
                int top = stack.Pop();
                int area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
                maxArea = Math.Max(maxArea, area);
            }
        }

        while (stack.Count > 0)
        {
            int top = stack.Pop();
            int area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}