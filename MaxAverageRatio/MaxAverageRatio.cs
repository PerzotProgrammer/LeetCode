namespace MaxAverageRatio;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/maximum-average-pass-ratio/solutions/6147543/priority-queue-o-m-n-log-n-solution-100-beats/?envType=daily-question&envId=2024-12-15
        // Example 1:
        //
        // Input: classes = [[1,2],[3,5],[2,2]], extraStudents = 2
        // Output: 0.78333
        // Explanation: You can assign the two extra students to the first class. The average pass ratio will be equal to (3/4 + 3/5 + 2/2) / 3 = 0.78333.

        // Example 2:
        //
        // Input: classes = [[2,4],[3,9],[4,5],[2,10]], extraStudents = 4
        // Output: 0.53485


        Solution solution = new();

        Console.WriteLine(solution.MaxAverageRatio([[1, 2], [3, 5], [2, 2]], 2));
        Console.WriteLine(solution.MaxAverageRatio([[2, 4], [3, 9], [4, 5], [2, 10]], 4));
    }

    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        PriorityQueue<(double gain, int pass, int total), double> maxHeap =
            new(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        double sum = 0.0;

        foreach (int[] cls in classes)
        {
            int pass = cls[0];
            int total = cls[1];
            sum += (double)pass / total;
            maxHeap.Enqueue((Gain(pass, total), pass, total), Gain(pass, total));
        }

        for (int i = 0; i < extraStudents; i++)
        {
            (double gain, int pass, int total) top = maxHeap.Dequeue();
            int pass = top.pass, total = top.total;
            sum -= (double)pass / total;
            pass++;
            total++;
            sum += (double)pass / total;
            maxHeap.Enqueue((Gain(pass, total), pass, total), Gain(pass, total));
        }

        return double.Round(sum / classes.Length, 5);
    }

    private double Gain(int pass, int total)
    {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
}