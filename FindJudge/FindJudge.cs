namespace FindJudge;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 2, trust = [[1,2]]
        // Output: 2

        // Example 2:
        //
        // Input: n = 3, trust = [[1,3],[2,3]]
        // Output: 3

        // Example 3:
        //
        // Input: n = 3, trust = [[1,3],[2,3],[3,1]]
        // Output: -1

        Solution solution = new();

        Console.WriteLine(solution.FindJudge(2, [[1, 2]]));
        Console.WriteLine(solution.FindJudge(3, [[1, 3], [2, 3]]));
        Console.WriteLine(solution.FindJudge(3, [[1, 3], [2, 3], [3, 1]]));
    }

    public int FindJudge(int n, int[][] trust)
    {
        Dictionary<int, int[]> personTrust = new();

        for (int i = 1; i <= n; i++) personTrust.Add(i, [0, 0]);

        foreach (int[] persons in trust)
        {
            personTrust[persons[0]][1]++;
            personTrust[persons[1]][0]++;
        }

        foreach (KeyValuePair<int, int[]> pair in personTrust)
        {
            if (pair.Value[1] == 0 && pair.Value[0] == n - 1) return pair.Key;
        }

        return -1;
    }
}