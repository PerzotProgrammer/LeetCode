namespace FindCheapestPrice;

class Solution
{
    static void Main()
    {
        // Pomoc internetu: https://leetcode.com/problems/cheapest-flights-within-k-stops/solutions/3101971/intuitive-bfs-dictionary/?envType=daily-question&envId=2024-02-23
        
        // Example 1:
        //
        // Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1
        // Output: 700
        // Explanation:
        // The graph is shown above.
        // The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
        // Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.

        // Example 2:
        //
        // Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1
        // Output: 200
        // Explanation:
        // The graph is shown above.
        // The optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.

        // Example 3:
        //
        // Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0
        // Output: 500
        // Explanation:
        // The graph is shown above.
        // The optimal path with no stops from city 0 to 2 is marked in red and has cost 500.

        Solution solution = new();

        int[][] a1 = [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]];
        int[][] a2 = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];
        int[][] a3 = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];

        Console.WriteLine(solution.FindCheapestPrice(4, a1, 0, 3, 1));
        Console.WriteLine(solution.FindCheapestPrice(3, a2, 0, 2, 1));
        Console.WriteLine(solution.FindCheapestPrice(3, a3, 0, 2, 0));
    }

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        IDictionary<int, IList<(int, int)>> adj = BuildGraph(flights);

        Dictionary<int, int> dist = new();

        Queue<(int, int)> q = new();
        q.Enqueue((src, 0));

        int stops = 0;

        while (stops <= k && q.Count > 0)
        {
            int size = q.Count;

            while (size > 0)
            {
                size--;
                var (node, distance) = q.Dequeue();

                if (!adj.ContainsKey(node))
                {
                    continue;
                }

                foreach (var (neighbor, price) in adj[node])
                {
                    if (dist.ContainsKey(neighbor) && price + distance >= dist[neighbor])
                    {
                        continue;
                    }

                    dist[neighbor] = price + distance;
                    q.Enqueue((neighbor, dist[neighbor]));
                }
            }

            stops++;
        }

        return dist.TryGetValue(dst, out var value) ? value : -1;
    }

    private IDictionary<int, IList<(int, int)>> BuildGraph(int[][] flights)
    {
        var graph = new Dictionary<int, IList<(int, int)>>();

        foreach (int[] flight in flights)
        {
            if (!graph.ContainsKey(flight[0]))
            {
                graph[flight[0]] = new List<(int, int)>();
            }

            graph[flight[0]].Add((flight[1], flight[2]));
        }

        return graph;
    }
}