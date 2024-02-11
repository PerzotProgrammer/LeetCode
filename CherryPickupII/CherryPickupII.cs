namespace CherryPickupII;

class Solution
{
    static void Main()
    {
        // Wzięte z internetu bo za ciężkie :(
        // https://leetcode.com/problems/cherry-pickup-ii/solutions/4712512/c-solution-for-cherry-pickup-ii-problem/?envType=daily-question&envId=2024-02-11
        
        // Example 1:
        //
        // Input: grid = [[3,1,1],[2,5,1],[1,5,5],[2,1,1]]
        // Output: 24
        // Explanation: Path of robot #1 and #2 are described in color green and blue respectively.
        // Cherries taken by Robot #1, (3 + 2 + 5 + 2) = 12.
        // Cherries taken by Robot #2, (1 + 5 + 5 + 1) = 12.
        // Total of cherries: 12 + 12 = 24.

        // Example 2:
        //
        // Input: grid = [[1,0,0,0,0,0,1],[2,0,0,0,0,3,0],[2,0,9,0,0,0,0],[0,3,0,5,4,0,0],[1,0,2,3,0,0,6]]
        // Output: 28
        // Explanation: Path of robot #1 and #2 are described in color green and blue respectively.
        // Cherries taken by Robot #1, (1 + 9 + 5 + 2) = 17.
        // Cherries taken by Robot #2, (1 + 3 + 4 + 3) = 11.
        // Total of cherries: 17 + 11 = 28.

        Solution solution = new();

        Console.WriteLine(solution.CherryPickup([[3,1,1],[2,5,1],[1,5,5],[2,1,1]]));
        Console.WriteLine(solution.CherryPickup([[1,0,0,0,0,0,1],[2,0,0,0,0,3,0],[2,0,9,0,0,0,0],[0,3,0,5,4,0,0],[1,0,2,3,0,0,6]]));
    }

    public int CherryPickup(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[][] dp = new int[cols][];
        for (int i = 0; i < cols; i++)
        {
            dp[i] = new int[cols];
        }

        for (int i = rows - 1; i >= 0; i--)
        {
            int[][] nextDP = new int[cols][];
            for (int j = 0; j < cols; j++)
            {
                nextDP[j] = new int[cols];
            }

            for (int j1 = 0; j1 < cols; j1++)
            {
                for (int j2 = 0; j2 < cols; j2++)
                {
                    int cherries = grid[i][j1] + (j1 != j2 ? grid[i][j2] : 0);
                    int maxNext = 0;

                    for (int k1 = j1 - 1; k1 <= j1 + 1; k1++)
                    {
                        for (int k2 = j2 - 1; k2 <= j2 + 1; k2++)
                        {
                            if (k1 >= 0 && k1 < cols && k2 >= 0 && k2 < cols)
                            {
                                maxNext = Math.Max(maxNext, dp[k1][k2]);
                            }
                        }
                    }

                    nextDP[j1][j2] = cherries + maxNext;
                }
            }

            dp = nextDP;
        }

        return dp[0][cols - 1];
    }
}