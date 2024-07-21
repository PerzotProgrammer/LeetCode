namespace BuildMatrix;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: k = 3, rowConditions = [[1,2],[3,2]], colConditions = [[2,1],[3,2]]
        // Output: [[3,0,0],[0,0,1],[0,2,0]]
        // Explanation: The diagram above shows a valid example of a matrix that satisfies all the conditions.
        // The row conditions are the following:
        // - Number 1 is in row 1, and number 2 is in row 2, so 1 is above 2 in the matrix.
        // - Number 3 is in row 0, and number 2 is in row 2, so 3 is above 2 in the matrix.
        // The column conditions are the following:
        // - Number 2 is in column 1, and number 1 is in column 2, so 2 is left of 1 in the matrix.
        // - Number 3 is in column 0, and number 2 is in column 1, so 3 is left of 2 in the matrix.
        // Note that there may be multiple correct answers.

        // Example 2:
        //
        // Input: k = 3, rowConditions = [[1,2],[2,3],[3,1],[2,3]], colConditions = [[2,1]]
        // Output: []
        // Explanation: From the first two conditions, 3 has to be below 1 but the third conditions needs 3 to be above 1 to be satisfied.
        // No matrix can satisfy all the conditions, so we return the empty matrix.


        Solution solution = new();

        PrintMatrix(solution.BuildMatrix(3, [[1, 2], [3, 2]], [[2, 1], [3, 2]]));
        PrintMatrix(solution.BuildMatrix(3, [[1, 2], [2, 3], [3, 1], [2, 3]], [[2, 1]]));
    }

    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
    {
        (int top, List<int> bot)[] rowGraph = new (int top, List<int> bot)[k];
        for (int i = 0; i < k; i++) rowGraph[i] = (0, []);

        for (int i = 0; i < rowConditions.Length; i++)
        {
            int topCond = rowConditions[i][0] - 1;
            int botCond = rowConditions[i][1] - 1;

            rowGraph[topCond].bot.Add(botCond);
            rowGraph[botCond].top++;
        }

        Stack<int> empty = new();
        for (int i = 0; i < rowGraph.Length; i++)
        {
            if (rowGraph[i].top == 0) empty.Push(i);
        }

        int[] rowOrder = new int[k];
        int rowInd = 0;

        while (empty.Count > 0)
        {
            int node = empty.Pop();
            rowOrder[rowInd++] = node;

            foreach (int other in rowGraph[node].bot)
            {
                rowGraph[other].top--;
                if (rowGraph[other].top == 0) empty.Push(other);
            }
        }

        if (rowInd != k) return [];

        (int left, List<int> right)[] colGraph = new (int left, List<int> right)[k];
        for (int i = 0; i < k; i++) colGraph[i] = (0, []);

        for (int i = 0; i < colConditions.Length; i++)
        {
            int leftCond = colConditions[i][0] - 1;
            int rightCond = colConditions[i][1] - 1;

            colGraph[leftCond].right.Add(rightCond);
            colGraph[rightCond].left++;
        }

        for (int i = 0; i < colGraph.Length; i++)
        {
            if (colGraph[i].left == 0) empty.Push(i);
        }

        int[] colOrder = new int[k];
        int colInd = 0;

        while (empty.Count > 0)
        {
            int node = empty.Pop();
            colOrder[node] = colInd++;

            foreach (int other in colGraph[node].right)
            {
                colGraph[other].left--;
                if (colGraph[other].left == 0) empty.Push(other);
            }
        }

        if (colInd != k) return [];

        int[][] result = new int[k][];
        for (int i = 0; i < k; i++) result[i] = new int[k];

        for (int i = 0; i < k; i++)
        {
            int ni = i;
            int nj = colOrder[rowOrder[i]];
            result[ni][nj] = rowOrder[i] + 1;
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