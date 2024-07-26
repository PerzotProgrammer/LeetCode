namespace FindTheCity;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 4, edges = [[0,1,3],[1,2,1],[1,3,4],[2,3,1]], distanceThreshold = 4
        // Output: 3
        // Explanation: The figure above describes the graph. 
        //     The neighboring cities at a distanceThreshold = 4 for each city are:
        // City 0 -> [City 1, City 2] 
        // City 1 -> [City 0, City 2, City 3] 
        // City 2 -> [City 0, City 1, City 3] 
        // City 3 -> [City 1, City 2] 
        // Cities 0 and 3 have 2 neighboring cities at a distanceThreshold = 4, but we have to return city 3 since it has the greatest number.

        // Example 2:
        //
        // Input: n = 5, edges = [[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]], distanceThreshold = 2
        // Output: 0
        // Explanation: The figure above describes the graph. 
        // The neighboring cities at a distanceThreshold = 2 for each city are:
        // City 0 -> [City 1] 
        // City 1 -> [City 0, City 4] 
        // City 2 -> [City 3, City 4] 
        // City 3 -> [City 2, City 4]
        // City 4 -> [City 1, City 2, City 3] 
        // The city 0 has 1 neighboring city at a distanceThreshold = 2.


        Solution solution = new();

        Console.WriteLine(solution.FindTheCity(4, [[0, 1, 3], [1, 2, 1], [1, 3, 4], [2, 3, 1]], 4));
        Console.WriteLine(
            solution.FindTheCity(5, [[0, 1, 2], [0, 4, 8], [1, 2, 3], [1, 4, 2], [2, 3, 1], [3, 4, 1]], 2));
    }

    public int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        int[,] dist = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) dist[i, j] = 0;
                else dist[i, j] = 10001;
            }
        }

        foreach (int[] edge in edges)
        {
            int from = edge[0];
            int to = edge[1];
            int weight = edge[2];
            dist[from, to] = weight;
            dist[to, from] = weight;
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        int minReachableCities = int.MaxValue;
        int city = -1;

        for (int i = 0; i < n; i++)
        {
            int reachableCities = 0;
            for (int j = 0; j < n; j++)
            {
                if (dist[i, j] <= distanceThreshold) reachableCities++;
            }

            if (reachableCities <= minReachableCities)
            {
                minReachableCities = reachableCities;
                city = i;
            }
        }

        return city;
    }
}