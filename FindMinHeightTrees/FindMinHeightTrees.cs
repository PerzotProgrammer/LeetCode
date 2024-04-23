namespace FindMinHeightTrees;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 4, edges = [[1,0],[1,2],[1,3]]
        // Output: [1]
        // Explanation: As shown, the height of the tree is 1 when the root is the node with label 1 which is the only MHT.

        // Example 2:
        //
        // Input: n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
        // Output: [3,4]

        Solution solution = new();

        PrintList(solution.FindMinHeightTrees(4, [[1, 0], [1, 2], [1, 3]]));
        PrintList(solution.FindMinHeightTrees(6, [[3, 0], [3, 1], [3, 2], [3, 4], [5, 4]]));
    }

    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (n == 1) return new List<int> { 0 };

        List<HashSet<int>> adj = new(n);
        for (int i = 0; i < n; i++) adj.Add(new HashSet<int>());

        foreach (int[] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int[] indegree = new int[n];
        Queue<int> queue = new();

        for (int i = 0; i < n; i++)
        {
            indegree[i] = adj[i].Count;
            if (indegree[i] == 1) queue.Enqueue(i);
        }

        while (n > 2)
        {
            int size = queue.Count;
            n -= size;
            for (int i = 0; i < size; i++)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in adj[node])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 1) queue.Enqueue(neighbor);
                }
            }
        }

        List<int> result = new();
        while (queue.Count > 0) result.Add(queue.Dequeue());

        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}