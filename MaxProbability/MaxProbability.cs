namespace MaxProbability;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE:https://leetcode.com/problems/path-with-maximum-probability/solutions/5696030/100-00-easy-solution-with-explanation/?envType=daily-question&envId=2024-08-27
        // Example 1:
        //
        // Input: n = 3, edges = [[0,1],[1,2],[0,2]], succProb = [0.5,0.5,0.2], start = 0, end = 2
        // Output: 0.25000
        // Explanation: There are two paths from start to end, one having a probability of success = 0.2 and the other has 0.5 * 0.5 = 0.25.

        // Example 2:
        //
        // Input: n = 3, edges = [[0,1],[1,2],[0,2]], succProb = [0.5,0.5,0.3], start = 0, end = 2
        // Output: 0.30000

        // Example 3:
        //
        // Input: n = 3, edges = [[0,1]], succProb = [0.5], start = 0, end = 2
        // Output: 0.00000
        // Explanation: There is no path between 0 and 2.


        Solution solution = new();

        Console.WriteLine(solution.MaxProbability(3, [[0, 1], [1, 2], [0, 2]], [0.5, 0.5, 0.2], 0, 2));
        Console.WriteLine(solution.MaxProbability(3, [[0, 1], [1, 2], [0, 2]], [0.5, 0.5, 0.3], 0, 2));
        Console.WriteLine(solution.MaxProbability(3, [[0, 1]], [0.5], 0, 2));
    }

    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {
        double[] maxProb = new double[n];
        maxProb[start_node] = 1.0;

        for (int i = 0; i < n - 1; i++)
        {
            bool updated = false;
            for (int j = 0; j < edges.Length; j++)
            {
                int u = edges[j][0];
                int v = edges[j][1];
                double prob = succProb[j];

                if (maxProb[u] * prob > maxProb[v])
                {
                    maxProb[v] = maxProb[u] * prob;
                    updated = true;
                }

                if (maxProb[v] * prob > maxProb[u])
                {
                    maxProb[u] = maxProb[v] * prob;
                    updated = true;
                }
            }

            if (!updated) break;
        }

        return maxProb[end_node];
    }
}