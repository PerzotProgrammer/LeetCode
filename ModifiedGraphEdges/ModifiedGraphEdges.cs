namespace ModifiedGraphEdges;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/modify-graph-edge-weights/solutions/5709476/c-solution-for-modify-graph-edge-weights-problem/?envType=daily-question&envId=2024-08-30
        // Example 1:
        //
        // Input: n = 5, edges = [[4,1,-1],[2,0,-1],[0,3,-1],[4,3,-1]], source = 0, destination = 1, target = 5
        // Output: [[4,1,1],[2,0,1],[0,3,3],[4,3,1]]
        // Explanation: The graph above shows a possible modification to the edges, making the distance from 0 to 1 equal to 5.

        // Example 2:
        //
        // Input: n = 3, edges = [[0,1,-1],[0,2,5]], source = 0, destination = 2, target = 6
        // Output: []
        // Explanation: The graph above contains the initial edges. It is not possible to make the distance from 0 to 2 equal to 6 by modifying the edge with weight -1. So, an empty array is returned.

        // Example 3:
        //
        // Input: n = 4, edges = [[1,0,4],[1,2,3],[2,3,5],[0,3,-1]], source = 0, destination = 2, target = 6
        // Output: [[1,0,4],[1,2,3],[2,3,5],[0,3,1]]
        // Explanation: The graph above shows a modified graph having the shortest distance from 0 to 2 as 6.


        Solution solution = new();

        PrintMatrix(solution.ModifiedGraphEdges(5, [[4, 1, -1], [2, 0, -1], [0, 3, -1], [4, 3, -1]], 0, 1, 5));
        PrintMatrix(solution.ModifiedGraphEdges(3, [[0, 1, -1], [0, 2, 5]], 0, 2, 6));
        PrintMatrix(solution.ModifiedGraphEdges(4, [[1, 0, 4], [1, 2, 3], [2, 3, 5], [0, 3, -1]], 0, 2, 6));
    }

    private List<int[]>[] Graph = null!;
    private static readonly int Inf = (int)2e9;

    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
    {
        Graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            Graph[i] = new();
        }

        foreach (int[] edge in edges)
        {
            if (edge[2] != -1)
            {
                Graph[edge[0]].Add([edge[1], edge[2]]);
                Graph[edge[1]].Add([edge[0], edge[2]]);
            }
        }

        int currentShortestDistance = RunDijkstra(n, source, destination);
        if (currentShortestDistance < target)
        {
            return [];
        }

        bool matchesTarget = (currentShortestDistance == target);

        foreach (int[] edge in edges)
        {
            if (edge[2] != -1) continue;

            edge[2] = matchesTarget ? Inf : 1;
            Graph[edge[0]].Add([edge[1], edge[2]]);
            Graph[edge[1]].Add([edge[0], edge[2]]);

            if (!matchesTarget)
            {
                int newDistance = RunDijkstra(n, source, destination);
                if (newDistance <= target)
                {
                    matchesTarget = true;
                    edge[2] += target - newDistance;
                }
            }
        }

        return matchesTarget ? edges : [];
    }

    private int RunDijkstra(int n, int source, int destination)
    {
        int[] minDistance = new int[n];
        bool[] visited = new bool[n];
        PriorityQueue<int[], int> minHeap = new();

        Array.Fill(minDistance, Inf);
        minDistance[source] = 0;
        minHeap.Enqueue([source, 0], 0);

        while (minHeap.Count > 0)
        {
            int[] curr = minHeap.Dequeue();
            int u = curr[0];
            int d = curr[1];

            if (d > minDistance[u]) continue;

            foreach (int[] neighbor in Graph[u])
            {
                int v = neighbor[0];
                int weight = neighbor[1];

                if (d + weight < minDistance[v])
                {
                    minDistance[v] = d + weight;
                    minHeap.Enqueue([v, minDistance[v]], minDistance[v]);
                }
            }
        }

        return minDistance[destination];
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