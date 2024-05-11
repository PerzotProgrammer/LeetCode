namespace MincostToHireWorkers;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: quality = [10,20,5], wage = [70,50,30], k = 2
        // Output: 105.00000
        // Explanation: We pay 70 to 0th worker and 35 to 2nd worker.

        // Example 2:
        //
        // Input: quality = [3,1,10,10,1], wage = [4,8,2,2,7], k = 3
        // Output: 30.66667
        // Explanation: We pay 4 to 0th worker, 13.33333 to 2nd and 3rd workers separately.

        Solution solution = new();

        Console.WriteLine(solution.MincostToHireWorkers([10, 20, 5], [70, 50, 30], 2));
        Console.WriteLine(solution.MincostToHireWorkers([3, 1, 10, 10, 1], [4, 8, 2, 2, 7], 3));
    }


    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        List<(double, int)> rateToQuality = new();
        PriorityQueue<int, int> maxHeap = new();
        double output = double.MaxValue;

        for (int i = 0; i < quality.Length; i++) rateToQuality.Add((wage[i] / (1.0 * quality[i]), quality[i]));

        rateToQuality = rateToQuality.OrderBy(tuple => tuple.Item1).ToList();
        int totalQuality = 0;

        foreach ((double, int) item in rateToQuality)
        {
            totalQuality += item.Item2;
            maxHeap.Enqueue(item.Item2, -item.Item2);

            if (maxHeap.Count > k) totalQuality -= maxHeap.Dequeue();
            if (maxHeap.Count == k) output = Math.Min(output, totalQuality * item.Item1);
        }

        return output;
    }
}