namespace FindChampion;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = 3, edges = [[0,1],[1,2]]
        // Output: 0
        // Explanation: Team 1 is weaker than team 0. Team 2 is weaker than team 1. So the champion is team 0.

        // Example 2:
        //
        // Input: n = 4, edges = [[0,2],[1,3],[1,2]]
        // Output: -1
        // Explanation: Team 2 is weaker than team 0 and team 1. Team 3 is weaker than team 1. But team 1 and team 0 are not weaker than any other teams. So the answer is -1.


        Solution solution = new();

        Console.WriteLine(solution.FindChampion(3, [[0, 1], [1, 2]]));
        Console.WriteLine(solution.FindChampion(4, [[0, 2], [1, 3], [1, 2]]));
    }

    public int FindChampion(int n, int[][] edges)
    {
        int[] indegree = new int[n];

        foreach (int[] edge in edges) indegree[edge[1]]++;

        int champ = -1;
        int champCount = 0;

        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                champCount++;
                champ = i;
            }
        }

        return champCount > 1 ? -1 : champ;
    }
}