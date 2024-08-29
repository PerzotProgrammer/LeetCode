namespace RemoveStones;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]
        // Output: 5
        // Explanation: One way to remove 5 stones is as follows:
        // 1. Remove stone [2,2] because it shares the same row as [2,1].
        // 2. Remove stone [2,1] because it shares the same column as [0,1].
        // 3. Remove stone [1,2] because it shares the same row as [1,0].
        // 4. Remove stone [1,0] because it shares the same column as [0,0].
        // 5. Remove stone [0,1] because it shares the same row as [0,0].
        // Stone [0,0] cannot be removed since it does not share a row/column with another stone still on the plane.

        // Example 2:
        //
        // Input: stones = [[0,0],[0,2],[1,1],[2,0],[2,2]]
        // Output: 3
        // Explanation: One way to make 3 moves is as follows:
        // 1. Remove stone [2,2] because it shares the same row as [2,0].
        // 2. Remove stone [2,0] because it shares the same column as [0,0].
        // 3. Remove stone [0,2] because it shares the same row as [0,0].
        // Stones [0,0] and [1,1] cannot be removed since they do not share a row/column with another stone still on the plane.

        // Example 3:
        //
        // Input: stones = [[0,0]]
        // Output: 0
        // Explanation: [0,0] is the only stone on the plane, so you cannot remove it.


        Solution solution = new();

        Console.WriteLine(solution.RemoveStones([[0, 0], [0, 1], [1, 0], [1, 2], [2, 1], [2, 2]]));
        Console.WriteLine(solution.RemoveStones([[0, 0], [0, 2], [1, 1], [2, 0], [2, 2]]));
        Console.WriteLine(solution.RemoveStones([[0, 0]]));
    }

    public int RemoveStones(int[][] stones)
    {
        HashSet<(int, int)> visited = new();
        Dictionary<int, List<int>> graph = new();

        for (int i = 0; i < stones.Length; i++)
        {
            for (int j = 0; j < stones.Length; j++)
            {
                if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
                {
                    if (!graph.ContainsKey(i)) graph[i] = new List<int>();
                    graph[i].Add(j);
                }
            }
        }

        int components = 0;
        for (int i = 0; i < stones.Length; i++)
        {
            if (!visited.Contains((stones[i][0], stones[i][1])))
            {
                Dfs(i, visited, graph, stones);
                components++;
            }
        }

        return stones.Length - components;
    }

    private void Dfs(int node, HashSet<(int, int)> visited, Dictionary<int, List<int>> graph, int[][] stones)
    {
        visited.Add((stones[node][0], stones[node][1]));

        foreach (int neighbor in graph[node])
        {
            if (!visited.Contains((stones[neighbor][0], stones[neighbor][1])))
            {
                Dfs(neighbor, visited, graph, stones);
            }
        }
    }
}