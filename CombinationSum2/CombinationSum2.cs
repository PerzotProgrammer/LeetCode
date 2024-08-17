namespace CombinationSum2;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: candidates = [10,1,2,7,6,1,5], target = 8
        // Output: 
        // [
        // [1,1,6],
        // [1,2,5],
        // [1,7],
        // [2,6]
        //     ]

        // Example 2:
        //
        // Input: candidates = [2,5,2,1,2], target = 5
        // Output: 
        // [
        // [1,2,2],
        // [5]
        //     ]

        Solution solution = new();

        PrintIList(solution.CombinationSum2([10, 1, 2, 7, 6, 1, 5], 8));
        PrintIList(solution.CombinationSum2([2,5,2,1,2], 5));
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        List<IList<int>>[] dp = new List<IList<int>>[target + 1];

        for (int i = 0; i <= target; i++) dp[i] = new();
        dp[0].Add(new List<int>());

        foreach (int candidate in candidates)
        {
            for (int i = target; i >= candidate; i--)
            {
                foreach (IList<int> comb in dp[i - candidate])
                {
                    List<int> newComb = new(comb) { candidate };
                    if (!dp[i].Any(x => x.SequenceEqual(newComb))) dp[i].Add(newComb);
                }
            }
        }

        return dp[target];
    }

    static void PrintIList(IList<IList<int>> list)
    {
        foreach (IList<int> ints in list)
        {
            foreach (int i in ints) Console.Write($"{i},");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}