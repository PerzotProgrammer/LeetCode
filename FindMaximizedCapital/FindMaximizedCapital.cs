namespace FindMaximizedCapital;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/ipo/solutions/3220929/c-using-priority-queue/?envType=daily-question&envId=2024-06-15
        // Example 1:
        //
        // Input: k = 2, w = 0, profits = [1,2,3], capital = [0,1,1]
        // Output: 4
        // Explanation: Since your initial capital is 0, you can only start the project indexed 0.
        // After finishing it you will obtain profit 1 and your capital becomes 1.
        // With capital 1, you can either start the project indexed 1 or the project indexed 2.
        // Since you can choose at most 2 projects, you need to finish the project indexed 2 to get the maximum capital.
        // Therefore, output the final maximized capital, which is 0 + 1 + 3 = 4.

        // Example 2:
        //
        // Input: k = 3, w = 0, profits = [1,2,3], capital = [0,1,2]
        // Output: 6


        Solution solution = new();

        Console.WriteLine(solution.FindMaximizedCapital(2, 0, [1, 2, 3], [0, 1, 1]));
        Console.WriteLine(solution.FindMaximizedCapital(3, 0, [1, 2, 3], [0, 1, 2]));
    }

    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        List<(int capital, int profit)> projects = new();

        for (int i = 0; i < profits.Length; i++) projects.Add((capital[i], profits[i]));
        projects = projects.OrderBy(x => x.capital).ToList();
        PriorityQueue<int, int> queue = new();

        int completedProjects = 0;

        while (k > 0)
        {
            k--;
            while (completedProjects < projects.Count && projects[completedProjects].capital <= w)
            {
                queue.Enqueue(projects[completedProjects].profit, int.MaxValue - projects[completedProjects].profit);
                completedProjects++;
            }

            if (queue.Count == 0) break;
            w += queue.Dequeue();
        }

        return w;
    }
}