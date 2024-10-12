namespace MinGroups;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: intervals = [[5,10],[6,8],[1,5],[2,3],[1,10]]
        // Output: 3
        // Explanation: We can divide the intervals into the following groups:
        // - Group 1: [1, 5], [6, 8].
        // - Group 2: [2, 3], [5, 10].
        // - Group 3: [1, 10].
        // It can be proven that it is not possible to divide the intervals into fewer than 3 groups.

        // Example 2:
        //
        // Input: intervals = [[1,3],[5,6],[8,10],[11,13]]
        // Output: 1
        // Explanation: None of the intervals overlap, so we can put all of them in one group.


        Solution solution = new();

        Console.WriteLine(solution.MinGroups([[5, 10], [6, 8], [1, 5], [2, 3], [1, 10]]));
        Console.WriteLine(solution.MinGroups([[1, 3], [5, 6], [8, 10], [11, 13]]));
    }

    public int MinGroups(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        PriorityQueue<int, int> minHeap = new();

        foreach (int[] interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];

            if (minHeap.Count > 0 && minHeap.Peek() < start) minHeap.Dequeue();
            minHeap.Enqueue(end, end);
        }

        return minHeap.Count;
    }
}