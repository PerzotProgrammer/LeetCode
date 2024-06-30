namespace MaxNumEdgesToRemove;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/remove-max-number-of-edges-to-keep-graph-fully-traversable/solutions/5392845/c-solution-for-remove-max-number-of-edges-to-keep-graph-fully-traversable-problem/?envType=daily-question&envId=2024-06-29
        // Example 1:
        //
        // Input: n = 4, edges = [[3,1,2],[3,2,3],[1,1,3],[1,2,4],[1,1,2],[2,3,4]]
        // Output: 2
        // Explanation: If we remove the 2 edges [1,1,2] and [1,1,3]. The graph will still be fully traversable by Alice and Bob. Removing any additional edge will not make it so. So the maximum number of edges we can remove is 2.

        // Example 2:
        //
        // Input: n = 4, edges = [[3,1,2],[3,2,3],[1,1,4],[2,1,4]]
        // Output: 0
        // Explanation: Notice that removing any edge will not make the graph fully traversable by Alice and Bob.

        // Example 3:
        //
        // Input: n = 4, edges = [[3,2,3],[1,1,2],[2,3,4]]
        // Output: -1
        // Explanation: In the current graph, Alice cannot reach node 4 from the other nodes. Likewise, Bob cannot reach 1. Therefore it's impossible to make the graph fully traversable.


        Solution solution = new();

        Console.WriteLine(solution.MaxNumEdgesToRemove(4, [[3,1,2],[3,2,3],[1,1,3],[1,2,4],[1,1,2],[2,3,4]]));
        Console.WriteLine(solution.MaxNumEdgesToRemove(4, [[3,1,2],[3,2,3],[1,1,4],[2,1,4]]));
        Console.WriteLine(solution.MaxNumEdgesToRemove(4, [[3,2,3],[1,1,2],[2,3,4]]));
    }

    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        UnionFind ufA = new(n + 1);
        UnionFind ufB = new(n + 1);
        UnionFind ufCommon = new(n + 1);
        int usedEdges = 0;

        foreach (int[] edge in edges)
        {
            if (edge[0] == 3)
            {
                if (ufCommon.Union(edge[1], edge[2]))
                {
                    ufA.Union(edge[1], edge[2]);
                    ufB.Union(edge[1], edge[2]);
                    usedEdges++;
                }
            }
        }

        foreach (int[] edge in edges)
        {
            if (edge[0] == 1)
                if (ufA.Union(edge[1], edge[2]))
                    usedEdges++;
        }

        foreach (int[] edge in edges)
        {
            if (edge[0] == 2)
            {
                if (ufB.Union(edge[1], edge[2])) usedEdges++;
            }
        }

        if (!AllConnected(ufA, n) || !AllConnected(ufB, n)) return -1;

        return edges.Length - usedEdges;
    }

    private bool AllConnected(UnionFind uf, int n)
    {
        int root = uf.Find(1);
        for (int i = 2; i <= n; i++)
        {
            if (uf.Find(i) != root) return false;
        }

        return true;
    }
}

class UnionFind
{
    private int[] Parent;
    private int[] Rank;

    public UnionFind(int n)
    {
        Parent = new int[n];
        Rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            Parent[i] = i;
            Rank[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (Parent[x] != x) Parent[x] = Find(Parent[x]);
        return Parent[x];
    }

    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX != rootY)
        {
            if (Rank[rootX] > Rank[rootY]) Parent[rootY] = rootX;
            else if (Rank[rootX] < Rank[rootY]) Parent[rootX] = rootY;
            else
            {
                Parent[rootY] = rootX;
                Rank[rootX]++;
            }

            return true;
        }

        return false;
    }
}