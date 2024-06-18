namespace MaxProfitAssignment;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: difficulty = [2,4,6,8,10], profit = [10,20,30,40,50], worker = [4,5,6,7]
        // Output: 100
        // Explanation: Workers are assigned jobs of difficulty [4,4,6,6] and they get a profit of [20,20,30,30] separately.

        // Example 2:
        //
        // Input: difficulty = [85,47,57], profit = [24,66,99], worker = [40,25,25]
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.MaxProfitAssignment([2, 4, 6, 8, 10], [10, 20, 30, 40, 50], [4, 5, 6, 7]));
        Console.WriteLine(solution.MaxProfitAssignment([85, 47, 57], [24, 66, 99], [40, 25, 25]));
    }

    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        List<int[]> jobs = new();
        for (int i = 0; i < difficulty.Length; i++) jobs.Add([difficulty[i], profit[i]]);

        jobs.Sort((a, b) => a[0].CompareTo(b[0]));

        Dictionary<int, int> maxProfitMap = new();
        int maxProfit = 0;
        foreach (int[] job in jobs)
        {
            maxProfit = Math.Max(maxProfit, job[1]);
            if (!maxProfitMap.ContainsKey(job[0])) maxProfitMap[job[0]] = maxProfit;
            else maxProfitMap[job[0]] = Math.Max(maxProfitMap[job[0]], maxProfit);
        }

        Array.Sort(worker);

        int totalProfit = 0;
        int currentMaxProfit = 0;
        int jobIndex = 0;

        foreach (int ability in worker)
        {
            while (jobIndex < jobs.Count && jobs[jobIndex][0] <= ability)
            {
                currentMaxProfit = Math.Max(currentMaxProfit, jobs[jobIndex][1]);
                jobIndex++;
            }

            totalProfit += currentMaxProfit;
        }

        return totalProfit;
    }
}