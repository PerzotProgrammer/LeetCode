namespace JobScheduling;

class Solution
{
    static void Main()
    {
        // Wykonano z pomocą Internetu, głownie podejście klasowe Job.
        // Wątek z którego korzystałem: https://leetcode.com/problems/maximum-profit-in-job-scheduling/solutions/4517067/f/?envType=daily-question&envId=2024-01-06
        
        
        // Example 1:
        // Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
        // Output: 120
        // Explanation: The subset chosen is the first and fourth job. 
        // Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.


        // Example 2:
        // Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,60]
        // Output: 150
        // Explanation: The subset chosen is the first, fourth and fifth job. 
        //     Profit obtained 150 = 20 + 70 + 60.


        // Example 3:
        // Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
        // Output: 6

        Solution solution = new();

        Console.WriteLine(solution.JobScheduling([1, 2, 3, 3], [3, 4, 5, 6], [50, 10, 40, 70]));
        Console.WriteLine(solution.JobScheduling([1, 2, 3, 4, 6], [3, 5, 10, 6, 9], [20, 20, 100, 70, 60]));
        Console.WriteLine(solution.JobScheduling([1, 1, 1], [2, 3, 4], [5, 6, 4]));
    }

    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;
        List<Job> jobs = new();

        for (int i = 0; i < n; i++)
        {
            jobs.Add(new Job(startTime[i], endTime[i], profit[i]));
        }

        jobs.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));

        int[] dp = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], jobs[i - 1].Profit);
            for (int j = i - 1; j > 0; j--)
            {
                if (jobs[i - 1].StartTime >= jobs[j - 1].EndTime)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + jobs[i - 1].Profit);
                    break;
                }
            }
        }

        return dp[n];
    }
}

class Job
{
    public int StartTime;
    public int EndTime;
    public int Profit;

    public Job(int start, int end, int prof)
    {
        StartTime = start;
        EndTime = end;
        Profit = prof;
    }
}