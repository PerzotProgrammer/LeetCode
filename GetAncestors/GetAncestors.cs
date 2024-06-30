namespace GetAncestors;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 8, edgeList = [[0,3],[0,4],[1,3],[2,4],[2,7],[3,5],[3,6],[3,7],[4,6]]
        // Output: [[],[],[],[0,1],[0,2],[0,1,3],[0,1,2,3,4],[0,1,2,3]]
        // Explanation:
        // The above diagram represents the input graph.
        // - Nodes 0, 1, and 2 do not have any ancestors.
        // - Node 3 has two ancestors 0 and 1.
        // - Node 4 has two ancestors 0 and 2.
        // - Node 5 has three ancestors 0, 1, and 3.
        // - Node 6 has five ancestors 0, 1, 2, 3, and 4.
        // - Node 7 has four ancestors 0, 1, 2, and 3.

        // Example 2:
        //
        // Input: n = 5, edgeList = [[0,1],[0,2],[0,3],[0,4],[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
        // Output: [[],[0],[0,1],[0,1,2],[0,1,2,3]]
        // Explanation:
        // The above diagram represents the input graph.
        // - Node 0 does not have any ancestor.
        // - Node 1 has one ancestor 0.
        // - Node 2 has two ancestors 0 and 1.
        // - Node 3 has three ancestors 0, 1, and 2.
        // - Node 4 has four ancestors 0, 1, 2, and 3.


        Solution solution = new();

        PrintMatrix(solution.GetAncestors(8, [[0, 3], [0, 4], [1, 3], [2, 4], [2, 7], [3, 5], [3, 6], [3, 7], [4, 6]]));
        PrintMatrix(solution.GetAncestors(5,
            [[0, 1], [0, 2], [0, 3], [0, 4], [1, 2], [1, 3], [1, 4], [2, 3], [2, 4], [3, 4]]));
    }

    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new();

        int[] inDegree = new int[n];
        foreach (int[] edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        List<HashSet<int>> ancestors = new(new HashSet<int>[n]);
        for (int i = 0; i < n; i++) ancestors[i] = new();

        Queue<int> queue = new();
        for (int i = 0; i < n; i++) if (inDegree[i] == 0) queue.Enqueue(i);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (int neighbor in graph[node])
            {
                ancestors[neighbor].UnionWith(ancestors[node]);
                ancestors[neighbor].Add(node);
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        List<IList<int>> result = new();
        for (int i = 0; i < n; i++)
        {
            List<int> sortedAncestors = new(ancestors[i]);
            sortedAncestors.Sort();
            result.Add(sortedAncestors);
        }

        return result;
    }

    static void PrintMatrix(IList<IList<int>> matrix)
    {
        foreach (IList<int> list in matrix)
        {
            foreach (int i in list) Console.Write($"{i}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}