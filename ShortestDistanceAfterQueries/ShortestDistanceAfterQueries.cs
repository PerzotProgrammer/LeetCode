namespace ShortestDistanceAfterQueries;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/shortest-distance-after-road-addition-queries-i/solutions/6087514/c-solution-for-shortest-distance-after-road-addition-queries-i-problem/?envType=daily-question&envId=2024-11-27
        // Example 1:
        //
        // Input: n = 5, queries = [[2,4],[0,2],[0,4]]
        // Output: [3,2,1]
        // Explanation:
        // After the addition of the road from 2 to 4, the length of the shortest path from 0 to 4 is 3.
        // After the addition of the road from 0 to 2, the length of the shortest path from 0 to 4 is 2.
        // After the addition of the road from 0 to 4, the length of the shortest path from 0 to 4 is 1.

        // Example 2:
        //
        // Input: n = 4, queries = [[0,3],[0,2]]
        // Output: [1,1]
        // Explanation:
        // After the addition of the road from 0 to 3, the length of the shortest path from 0 to 3 is 1.
        // After the addition of the road from 0 to 2, the length of the shortest path remains 1.


        Solution solution = new();

        PrintArray(solution.ShortestDistanceAfterQueries(5, [[2, 4], [0, 2], [0, 4]]));
        PrintArray(solution.ShortestDistanceAfterQueries(4, [[0, 3], [0, 2]]));
    }

    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        int[] answer = new int[queries.Length];
        List<List<int>> adjList = new();

        for (int i = 0; i < n; i++) adjList.Add(new());

        for (int i = 0; i < n - 1; i++) adjList[i].Add(i + 1);

        for (int q = 0; q < queries.Length; q++)
        {
            int u = queries[q][0];
            int v = queries[q][1];

            adjList[u].Add(v);

            int[] dp = new int[n];
            Array.Fill(dp, -1);
            answer[q] = FindMinDistance(0, n, adjList, dp);
        }

        return answer;
    }

    private int FindMinDistance(int currentNode, int n, List<List<int>> adjList, int[] dp)
    {
        if (currentNode == n - 1) return 0;

        if (dp[currentNode] != -1) return dp[currentNode];

        int minDistance = n;
        foreach (int neighbor in adjList[currentNode])
        {
            minDistance = Math.Min(minDistance, 1 + FindMinDistance(neighbor, n, adjList, dp));
        }

        dp[currentNode] = minDistance;
        return minDistance;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}