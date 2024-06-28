namespace MaximumImportance;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 5, roads = [[0,1],[1,2],[2,3],[0,2],[1,3],[2,4]]
        // Output: 43
        // Explanation: The figure above shows the country and the assigned values of [2,4,5,3,1].
        // - The road (0,1) has an importance of 2 + 4 = 6.
        // - The road (1,2) has an importance of 4 + 5 = 9.
        // - The road (2,3) has an importance of 5 + 3 = 8.
        // - The road (0,2) has an importance of 2 + 5 = 7.
        // - The road (1,3) has an importance of 4 + 3 = 7.
        // - The road (2,4) has an importance of 5 + 1 = 6.
        // The total importance of all roads is 6 + 9 + 8 + 7 + 7 + 6 = 43.
        // It can be shown that we cannot obtain a greater total importance than 43.

        // Example 2:
        //
        // Input: n = 5, roads = [[0,3],[2,4],[1,3]]
        // Output: 20
        // Explanation: The figure above shows the country and the assigned values of [4,3,2,5,1].
        // - The road (0,3) has an importance of 4 + 5 = 9.
        // - The road (2,4) has an importance of 2 + 1 = 3.
        // - The road (1,3) has an importance of 3 + 5 = 8.
        // The total importance of all roads is 9 + 3 + 8 = 20.
        // It can be shown that we cannot obtain a greater total importance than 20.


        Solution solution = new();

        Console.WriteLine(solution.MaximumImportance(5, [[0, 1], [1, 2], [2, 3], [0, 2], [1, 3], [2, 4]]));
        Console.WriteLine(solution.MaximumImportance(5, [[0, 3], [2, 4], [1, 3]]));
    }

    public long MaximumImportance(int n, int[][] roads)
    {
        int[] degree = new int[n];
        foreach (int[] road in roads)
        {
            degree[road[0]]++;
            degree[road[1]]++;
        }

        int[] cityIndices = Enumerable.Range(0, n).ToArray();
        Array.Sort(cityIndices, (a, b) => degree[b].CompareTo(degree[a]));

        int[] cityValues = new int[n];
        for (int i = 0; i < n; i++)
        {
            cityValues[cityIndices[i]] = n - i;
        }

        long totalImportance = 0;
        foreach (int[] road in roads)
        {
            totalImportance += cityValues[road[0]] + cityValues[road[1]];
        }

        return totalImportance;
    }
}