namespace FurthestBuilding;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: heights = [4,2,7,6,9,14,12], bricks = 5, ladders = 1
        // Output: 4
        // Explanation: Starting at building 0, you can follow these steps:
        // - Go to building 1 without using ladders nor bricks since 4 >= 2.
        // - Go to building 2 using 5 bricks. You must use either bricks or ladders because 2 < 7.
        // - Go to building 3 without using ladders nor bricks since 7 >= 6.
        // - Go to building 4 using your only ladder. You must use either bricks or ladders because 6 < 9.
        // It is impossible to go beyond building 4 because you do not have any more bricks or ladders.

        // Example 2:
        //
        // Input: heights = [4,12,2,7,3,18,20,3,19], bricks = 10, ladders = 2
        // Output: 7

        // Example 3:
        //
        // Input: heights = [14,3,19,3], bricks = 17, ladders = 0
        // Output: 3

        Solution solution = new();

        Console.WriteLine(solution.FurthestBuilding([4, 2, 7, 6, 9, 14, 12], 5, 1));
        Console.WriteLine(solution.FurthestBuilding([4, 12, 2, 7, 3, 18, 20, 3, 19], 10, 2));
        Console.WriteLine(solution.FurthestBuilding([14, 3, 19, 3], 17, 0));
    }

    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        PriorityQueue<int, int> q = new();
        for (int i = 0; i < heights.Length - 1; i++)
        {
            int diff = heights[i + 1] - heights[i];
            if (diff <= 0) continue;
            bricks -= diff;
            q.Enqueue(diff, -diff);

            if (bricks < 0)
            {
                if (ladders == 0) return i;
                ladders -= 1;
                bricks += q.Dequeue();
            }
        }

        return heights.Length - 1;
    }
}