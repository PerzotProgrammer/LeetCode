namespace MaxTwoEvents;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: events = [[1,3,2],[4,5,2],[2,4,3]]
        // Output: 4
        // Explanation: Choose the green events, 0 and 1 for a sum of 2 + 2 = 4.

        // Example 2:
        //
        // Example 1 Diagram
        // Input: events = [[1,3,2],[4,5,2],[1,5,5]]
        // Output: 5
        // Explanation: Choose event 2 for a sum of 5.

        // Example 3:
        //
        // Input: events = [[1,5,3],[1,5,1],[6,6,5]]
        // Output: 8
        // Explanation: Choose events 0 and 2 for a sum of 3 + 5 = 8.


        Solution solution = new();

        Console.WriteLine(solution.MaxTwoEvents([[1, 3, 2], [4, 5, 2], [2, 4, 3]]));
        Console.WriteLine(solution.MaxTwoEvents([[1, 3, 2], [4, 5, 2], [1, 5, 5]]));
        Console.WriteLine(solution.MaxTwoEvents([[1, 5, 3], [1, 5, 1], [6, 6, 5]]));
    }

    public int MaxTwoEvents(int[][] events)
    {
        Array.Sort(events, (a, b) => a[0] - b[0]);

        int[] suffix = new int[events.Length];
        suffix[events.Length - 1] = events[^1][2];

        for (int i = events.Length - 2; i >= 0; i--)
        {
            suffix[i] = Math.Max(suffix[i + 1], events[i][2]);
        }

        int value = 0;

        for (int i = 0; i < events.Length; i++)
        {
            int current = events[i][2];
            value = Math.Max(value, current);
            int low = i + 1;
            int high = events.Length - 1;
            int nextEvent = -1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (events[mid][0] > events[i][1])
                {
                    nextEvent = mid;
                    high = mid - 1;
                }
                else low = mid + 1;
            }

            if (nextEvent != -1) value = Math.Max(value, current + suffix[nextEvent]);
        }

        return value;
    }
}