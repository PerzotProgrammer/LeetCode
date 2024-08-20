namespace StoneGameII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: piles = [2,7,9,4,4]
        // Output: 10
        // Explanation:  If Alice takes one pile at the beginning, Bob takes two piles, then Alice takes 2 piles again. Alice can get 2 + 4 + 4 = 10 piles in total. If Alice takes two piles at the beginning, then Bob can take all three piles left. In this case, Alice get 2 + 7 = 9 piles in total. So we return 10 since it's larger. 

        // Example 2:
        //
        // Input: piles = [1,2,3,4,5,100]
        // Output: 104


        Solution solution = new();

        Console.WriteLine(solution.StoneGameII([2, 7, 9, 4, 4]));
        Console.WriteLine(solution.StoneGameII([1, 2, 3, 4, 5, 100]));
    }

    public int StoneGameII(int[] piles)
    {
        int[][] dp = new int[piles.Length + 1][];

        for (int i = 0; i < dp.Length; i++) dp[i] = new int[piles.Length + 1];

        int[] suffixSum = new int[piles.Length + 1];

        for (int i = piles.Length - 1; i >= 0; i--) suffixSum[i] = suffixSum[i + 1] + piles[i];

        for (int i = 0; i <= piles.Length; i++) dp[i][piles.Length] = suffixSum[i];

        for (int index = piles.Length - 1; index >= 0; index--)
        {
            for (int oldMax = piles.Length - 1; oldMax >= 1; oldMax--)
            {
                for (int X = 1; X <= 2 * oldMax && index + X <= piles.Length; X++)
                {
                    dp[index][oldMax] = Math.Max(
                        dp[index][oldMax],
                        suffixSum[index] -
                        dp[index + X][Math.Max(oldMax, X)]);
                }
            }
        }

        return dp[0][1];
    }
}