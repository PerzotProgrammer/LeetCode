namespace MinDifficulty;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: jobDifficulty = [6,5,4,3,2,1], d = 2
        // Output: 7
        // Explanation: First day you can finish the first 5 jobs, total difficulty = 6.
        // Second day you can finish the last job, total difficulty = 1.
        // The difficulty of the schedule = 6 + 1 = 7 


        // Example 2:
        //
        // Input: jobDifficulty = [9,9,9], d = 4
        // Output: -1
        // Explanation: If you finish a job per day you will still have a free day. you cannot find a schedule for the given jobs.


        // Example 3:
        //
        // Input: jobDifficulty = [1,1,1], d = 3
        // Output: 3
        // Explanation: The schedule is one job per day. total difficulty will be 3.

        int[] j1 = { 6, 5, 4, 3, 2, 1 };
        int[] j2 = { 9, 9, 9 };
        int[] j3 = { 1, 1, 1 };

        Solution solution = new();

        Console.WriteLine(solution.MinDifficulty(j1, 2));
        Console.WriteLine(solution.MinDifficulty(j2, 4));
        Console.WriteLine(solution.MinDifficulty(j3, 3));
    }

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        int jobsLength = jobDifficulty.Length;

        if (d > jobsLength)
        {
            return -1;
        }

        int[,] dp = new int[d, jobsLength];

        dp[0, 0] = jobDifficulty[0];

        for (int i = 1; i < jobsLength; i++)
        {
            dp[0, i] = Math.Max(dp[0, i - 1], jobDifficulty[i]);
        }

        for (int curDay = 1; curDay < d; curDay++)
        {
            for (int jobLim = curDay; jobLim < jobsLength; jobLim++)
            {
                dp[curDay, jobLim] = int.MaxValue;

                int maxDifficulty = 0;

                for (int jobInd = jobLim; jobInd >= curDay; jobInd--)
                {
                    maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[jobInd]);

                    dp[curDay, jobLim] = Math.Min(dp[curDay, jobLim], dp[curDay - 1, jobInd - 1] + maxDifficulty);
                }
            }
        }

        return dp[d - 1, jobsLength - 1];
    }
}