namespace SumOfDistancesInTree;

class Solution
{
    static void Main()
    {
        // Pomoc LeetCode: https://leetcode.com/problems/sum-of-distances-in-tree/solutions/5082504/c-solution-for-sum-of-distances-in-tree-problem/?envType=daily-question&envId=2024-04-28
        // Example 1:
        //
        // Input: n = 6, edges = [[0,1],[0,2],[2,3],[2,4],[2,5]]
        // Output: [8,12,6,10,10,10]
        // Explanation: The tree is shown above.
        // We can see that dist(0,1) + dist(0,2) + dist(0,3) + dist(0,4) + dist(0,5)
        // equals 1 + 1 + 2 + 2 + 2 = 8.
        // Hence, answer[0] = 8, and so on.

        // Example 2:
        //
        // Input: n = 1, edges = []
        // Output: [0]

        // Example 3:
        //
        // Input: n = 2, edges = [[1,0]]
        // Output: [1,1]

        Solution solution = new();

        PrintArray(solution.SumOfDistancesInTree(6, [[0, 1], [0, 2], [2, 3], [2, 4], [2, 5]]));
        PrintArray(solution.SumOfDistancesInTree(1, []));
        PrintArray(solution.SumOfDistancesInTree(2, [[1, 0]]));
    }

    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new();

        foreach (int[] edge in edges)
        {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        int[] count = new int[n];
        int[] ans = new int[n];

        DFS(0, -1, graph, count, ans);

        CountDfs(0, -1, graph, count, ans);

        return ans;
    }

    private void DFS(int node, int parent, List<int>[] graph, int[] count, int[] ans)
    {
        count[node] = 1;
        foreach (int child in graph[node])
        {
            if (child != parent)
            {
                DFS(child, node, graph, count, ans);
                count[node] += count[child];
                ans[node] += ans[child] + count[child];
            }
        }
    }

    private void CountDfs(int node, int parent, List<int>[] graph, int[] count, int[] ans)
    {
        foreach (int child in graph[node])
        {
            if (child != parent)
            {
                ans[child] = ans[node] - count[child] + count.Length - count[child];
                CountDfs(child, node, graph, count, ans);
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}