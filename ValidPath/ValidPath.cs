namespace ValidPath;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
        // Output: true
        // Explanation: There are two paths from vertex 0 to vertex 2:
        // - 0 → 1 → 2
        // - 0 → 2

        // Example 2:
        //
        // Input: n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
        // Output: false
        // Explanation: There is no path from vertex 0 to vertex 5.

        Solution solution = new();

        Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
        Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));
    }

    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        Dictionary<int, List<int>> graph = new();

        foreach (int[] edge in edges)
        {
            if (!graph.TryAdd(edge[0], new() { edge[1] })) graph[edge[0]].Add(edge[1]);
            if (!graph.TryAdd(edge[1], new() { edge[0] })) graph[edge[1]].Add(edge[0]);
        }

        Stack<int> stack = new();
        List<int> visited = new();
        stack.Push(source);

        while (stack.Count > 0)
        {
            int current = stack.Pop();
            if (current == destination) return true;
            if (!visited.Contains(current))
            {
                visited.Add(current);
                foreach (int i in graph[current]) stack.Push(i);
            }
        }

        return false;
    }
}