namespace FindMinArrowShots;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: points = [[10,16],[2,8],[1,6],[7,12]]
        // Output: 2
        // Explanation: The balloons can be burst by 2 arrows:
        // - Shoot an arrow at x = 6, bursting the balloons [2,8] and [1,6].
        // - Shoot an arrow at x = 11, bursting the balloons [10,16] and [7,12].

        // Example 2:
        //
        // Input: points = [[1,2],[3,4],[5,6],[7,8]]
        // Output: 4
        // Explanation: One arrow needs to be shot for each balloon for a total of 4 arrows.

        // Example 3:
        //
        // Input: points = [[1,2],[2,3],[3,4],[4,5]]
        // Output: 2
        // Explanation: The balloons can be burst by 2 arrows:
        // - Shoot an arrow at x = 2, bursting the balloons [1,2] and [2,3].
        // - Shoot an arrow at x = 4, bursting the balloons [3,4] and [4,5].

        Solution solution = new();

        Console.WriteLine(solution.FindMinArrowShots([[10, 16], [2, 8], [1, 6], [7, 12]]));
        Console.WriteLine(solution.FindMinArrowShots([[1, 2], [3, 4], [5, 6], [7, 8]]));
        Console.WriteLine(solution.FindMinArrowShots([[1, 2], [2, 3], [3, 4], [4, 5]]));
    }

    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
        int arrows = 1;
        int end = points[0][1];

        foreach (int[] balloon in points)
        {
            int start = balloon[0];
            int finish = balloon[1];

            if (start > end)
            {
                arrows++;
                end = finish;
            }
            else end = Math.Min(end, finish);
        }

        return arrows;
    }
}