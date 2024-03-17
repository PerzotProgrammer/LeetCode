namespace Insert;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
        // Output: [[1,5],[6,9]]

        // Example 2:
        //
        // Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
        // Output: [[1,2],[3,10],[12,16]]
        // Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

        Solution solution = new();

        PrintMatrix(solution.Insert([[1, 3], [6, 9]], [2, 5]));
        PrintMatrix(solution.Insert([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8]));
    }

    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int n = intervals.Length;
        int i = 0;
        List<int[]> res = new();

        while (i < n && intervals[i][1] < newInterval[0])
        {
            res.Add(intervals[i]);
            i++;
        }

        while (i < n && newInterval[1] >= intervals[i][0])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        res.Add(newInterval);

        while (i < n)
        {
            res.Add(intervals[i]);
            i++;
        }

        return res.ToArray();
    }

    static void PrintMatrix(int[][] matrix)
    {
        foreach (int[] ints in matrix)
        {
            foreach (int i in ints)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}