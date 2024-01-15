namespace FindWinners;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
        // Output: [[1,2,10],[4,5,7,8]]
        // Explanation:
        // Players 1, 2, and 10 have not lost any matches.
        //     Players 4, 5, 7, and 8 each have lost one match.
        //     Players 3, 6, and 9 each have lost two matches.
        //     Thus, answer[0] = [1,2,10] and answer[1] = [4,5,7,8].

        // Example 2:
        //
        // Input: matches = [[2,3],[1,3],[5,4],[6,4]]
        // Output: [[1,2,5,6],[]]
        // Explanation:
        // Players 1, 2, 5, and 6 have not lost any matches.
        //     Players 3 and 4 each have lost two matches.
        //     Thus, answer[0] = [1,2,5,6] and answer[1] = [].

        Solution solution = new Solution();

        PrintMatrix(solution.FindWinners([
            [1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9]
        ]));
        PrintMatrix(solution.FindWinners([[2, 3], [1, 3], [5, 4], [6, 4]]));
    }

    public IList<IList<int>> FindWinners(int[][] matches)
    {
        HashSet<int> zeroLoss = new();
        HashSet<int> oneLoss = new();
        HashSet<int> moreLoss = new();

        foreach (int[] match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            if (!oneLoss.Contains(winner) && !moreLoss.Contains(winner))
            {
                zeroLoss.Add(winner);
            }

            if (zeroLoss.Contains(loser))
            {
                zeroLoss.Remove(loser);
                oneLoss.Add(loser);
            }
            else if (oneLoss.Contains(loser))
            {
                oneLoss.Remove(loser);
                moreLoss.Add(loser);
            }
            else if (moreLoss.Contains(loser))
            {
                continue;
            }
            else
            {
                oneLoss.Add(loser);
            }
        }

        IList<IList<int>> answer = new List<IList<int>>();
        int[] zeroLossArr = zeroLoss.ToArray();
        int[] oneLossArr = oneLoss.ToArray();
        Array.Sort(zeroLossArr);
        Array.Sort(oneLossArr);
        
        answer.Add(zeroLossArr);
        answer.Add(oneLossArr);

        return answer;
    }

    static void PrintMatrix(IList<IList<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write($"{matrix[i][j]},");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}