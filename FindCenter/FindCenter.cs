namespace FindCenter;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: edges = [[1,2],[2,3],[4,2]]
        // Output: 2
        // Explanation: As shown in the figure above, node 2 is connected to every other node, so 2 is the center.

        // Example 2:
        //
        // Input: edges = [[1,2],[5,1],[1,3],[1,4]]
        // Output: 1


        Solution solution = new();

        Console.WriteLine(solution.FindCenter([[1, 2], [2, 3], [4, 2]]));
        Console.WriteLine(solution.FindCenter([[1, 2], [5, 1], [1, 3], [1, 4]]));
    }

    public int FindCenter(int[][] edges)
    {
        Dictionary<int, int> nodeCount = new();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];

            if (!nodeCount.TryAdd(u, 1)) nodeCount[u]++;
            if (!nodeCount.TryAdd(v, 1)) nodeCount[v]++;
        }

        foreach (KeyValuePair<int, int> pair in nodeCount)
        {
            if (pair.Value == edges.Length) return pair.Key;
        }

        return -1;
    }
}