namespace FindRelativeRanks;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: score = [5,4,3,2,1]
        // Output: ["Gold Medal","Silver Medal","Bronze Medal","4","5"]
        // Explanation: The placements are [1st, 2nd, 3rd, 4th, 5th].

        // Example 2:
        //
        // Input: score = [10,3,8,9,4]
        // Output: ["Gold Medal","5","Bronze Medal","Silver Medal","4"]
        // Explanation: The placements are [1st, 5th, 3rd, 2nd, 4th].

        Solution solution = new();

        PrintArray(solution.FindRelativeRanks([5, 4, 3, 2, 1]));
        PrintArray(solution.FindRelativeRanks([10, 3, 8, 9, 4]));
    }

    public string[] FindRelativeRanks(int[] score)
    {
        int[] scoreCopy = new int[score.Length];
        Array.Copy(score, scoreCopy, score.Length);

        Dictionary<int, int> scoreIndex = new();

        for (int i = 0; i < score.Length; i++) scoreIndex.Add(scoreCopy[i], i);

        Array.Sort(scoreCopy);

        string[] output = new string[score.Length];

        for (int i = 0; i < score.Length; i++)
        {
            if (i == 0) output[scoreIndex[scoreCopy[score.Length - i - 1]]] = "Gold Medal";
            else if (i == 1) output[scoreIndex[scoreCopy[score.Length - i - 1]]] = "Silver Medal";
            else if (i == 2) output[scoreIndex[scoreCopy[score.Length - i - 1]]] = "Bronze Medal";
            else output[scoreIndex[scoreCopy[score.Length - i - 1]]] = (i + 1).ToString();
        }

        return output;
    }

    static void PrintArray(string[] strings)
    {
        foreach (string s in strings) Console.Write($"{s}, ");
        Console.WriteLine();
    }
}