namespace ValidArrangement;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: pairs = [[5,1],[4,5],[11,9],[9,4]]
        // Output: [[11,9],[9,4],[4,5],[5,1]]
        // Explanation:
        // This is a valid arrangement since endi-1 always equals starti.
        // end0 = 9 == 9 = start1 
        // end1 = 4 == 4 = start2
        // end2 = 5 == 5 = start3

        // Example 2:
        //
        // Input: pairs = [[1,3],[3,2],[2,1]]
        // Output: [[1,3],[3,2],[2,1]]
        // Explanation:
        // This is a valid arrangement since endi-1 always equals starti.
        // end0 = 3 == 3 = start1
        // end1 = 2 == 2 = start2
        // The arrangements [[2,1],[1,3],[3,2]] and [[3,2],[2,1],[1,3]] are also valid.

        // Example 3:
        //
        // Input: pairs = [[1,2],[1,3],[2,1]]
        // Output: [[1,2],[2,1],[1,3]]
        // Explanation:
        // This is a valid arrangement since endi-1 always equals starti.
        // end0 = 2 == 2 = start1
        // end1 = 1 == 1 = start2


        Solution solution = new();

        PrintMatrix(solution.ValidArrangement([[5, 1], [4, 5], [11, 9], [9, 4]]));
        PrintMatrix(solution.ValidArrangement([[1, 3], [3, 2], [2, 1]]));
        PrintMatrix(solution.ValidArrangement([[1, 2], [1, 3], [2, 1]]));
    }

    public int[][] ValidArrangement(int[][] pairs)
    {
        Dictionary<int, Stack<int>> graph = new();
        Dictionary<int, int> inDegree = new();
        Dictionary<int, int> outDegree = new();

        foreach (int[] pair in pairs)
        {
            int start = pair[0];
            int end = pair[1];

            if (!graph.ContainsKey(start)) graph[start] = new();

            graph[start].Push(end);

            outDegree[start] = outDegree.GetValueOrDefault(start, 0) + 1;
            inDegree[end] = inDegree.GetValueOrDefault(end, 0) + 1;
        }

        int startNode = pairs[0][0];
        foreach (int node in graph.Keys)
        {
            if (outDegree.GetValueOrDefault(node, 0) > inDegree.GetValueOrDefault(node, 0))
            {
                startNode = node;
                break;
            }
        }

        List<int[]> result = new();
        Stack<int> stack = new();
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            int node = stack.Peek();
            if (graph.ContainsKey(node) && graph[node].Count > 0) stack.Push(graph[node].Pop());
            else
            {
                stack.Pop();
                if (stack.Count > 0) result.Add(new[] { stack.Peek(), node });
            }
        }

        result.Reverse();
        return result.ToArray();
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] row in matrix)
        {
            foreach (int i in row) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}