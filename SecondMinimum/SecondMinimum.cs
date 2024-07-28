namespace SecondMinimum;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/second-minimum-time-to-reach-destination/solutions/5546059/c-solution-for-second-minimum-time-to-reach-destination-problem/?envType=daily-question&envId=2024-07-28
        // Example 1:
        //
        // Input: n = 5, edges = [[1,2],[1,3],[1,4],[3,4],[4,5]], time = 3, change = 5
        // Output: 13
        // Explanation:
        // The figure on the left shows the given graph.
        // The blue path in the figure on the right is the minimum time path.
        // The time taken is:
        // - Start at 1, time elapsed=0
        // - 1 -> 4: 3 minutes, time elapsed=3
        // - 4 -> 5: 3 minutes, time elapsed=6
        // Hence the minimum time needed is 6 minutes.
        // The red path shows the path to get the second minimum time.
        // - Start at 1, time elapsed=0
        // - 1 -> 3: 3 minutes, time elapsed=3
        // - 3 -> 4: 3 minutes, time elapsed=6
        // - Wait at 4 for 4 minutes, time elapsed=10
        // - 4 -> 5: 3 minutes, time elapsed=13
        // Hence the second minimum time is 13 minutes.      

        // Example 2:
        //
        // Input: n = 2, edges = [[1,2]], time = 3, change = 2
        // Output: 11
        // Explanation:
        // The minimum time path is 1 -> 2 with time = 3 minutes.
        // The second minimum time path is 1 -> 2 -> 1 -> 2 with time = 11 minutes.

        Solution solution = new();

        Console.WriteLine(solution.SecondMinimum(5, [[1, 2], [1, 3], [1, 4], [3, 4], [4, 5]], 3, 5));
        Console.WriteLine(solution.SecondMinimum(2, [[1, 2]], 3, 2));
    }

    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        Dictionary<int, List<int>> adj = new();
        for (int i = 1; i <= n; i++) adj[i] = new();

        foreach (int[] edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int[] dist1 = new int[n + 1];
        int[] dist2 = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dist1[i] = -1;
            dist2[i] = -1;
        }

        Queue<int[]> queue = new();
        queue.Enqueue([1, 1]);
        dist1[1] = 0;

        while (queue.Count > 0)
        {
            int[] temp = queue.Dequeue();
            int node = temp[0];
            int freq = temp[1];

            int timeTaken = freq == 1 ? dist1[node] : dist2[node];

            if ((timeTaken / change) % 2 == 1)
            {
                timeTaken = change * (timeTaken / change + 1) + time;
            }
            else timeTaken += time;

            foreach (int neighbor in adj[node])
            {
                if (dist1[neighbor] == -1)
                {
                    dist1[neighbor] = timeTaken;
                    queue.Enqueue([neighbor, 1]);
                }
                else if (dist2[neighbor] == -1 && dist1[neighbor] != timeTaken)
                {
                    if (neighbor == n) return timeTaken;
                    dist2[neighbor] = timeTaken;
                    queue.Enqueue([neighbor, 2]);
                }
            }
        }

        return 0;
    }
}