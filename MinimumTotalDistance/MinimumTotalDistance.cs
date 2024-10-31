namespace MinimumTotalDistance;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/minimum-total-distance-traveled/editorial/?envType=daily-question&envId=2024-10-31
        // Example 1:
        //
        // Input: robot = [0,4,6], factory = [[2,2],[6,2]]
        // Output: 4
        // Explanation: As shown in the figure:
        // - The first robot at position 0 moves in the positive direction. It will be repaired at the first factory.
        // - The second robot at position 4 moves in the negative direction. It will be repaired at the first factory.
        // - The third robot at position 6 will be repaired at the second factory. It does not need to move.
        // The limit of the first factory is 2, and it fixed 2 robots.
        // The limit of the second factory is 2, and it fixed 1 robot.
        // The total distance is |2 - 0| + |2 - 4| + |6 - 6| = 4. It can be shown that we cannot achieve a better total distance than 4.

        // Example 2:
        //
        // Input: robot = [1,-1], factory = [[-2,1],[2,1]]
        // Output: 2
        // Explanation: As shown in the figure:
        // - The first robot at position 1 moves in the positive direction. It will be repaired at the second factory.
        // - The second robot at position -1 moves in the negative direction. It will be repaired at the first factory.
        // The limit of the first factory is 1, and it fixed 1 robot.
        // The limit of the second factory is 1, and it fixed 1 robot.
        // The total distance is |2 - 1| + |(-2) - (-1)| = 2. It can be shown that we cannot achieve a better total distance than 2.


        Solution solution = new();

        Console.WriteLine(solution.MinimumTotalDistance([0, 4, 6], [[2, 2,], [6, 2]]));
        Console.WriteLine(solution.MinimumTotalDistance([1, -1], [[-2, 1], [2, 1]]));
    }

    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        int[] sortedRobot = robot.OrderBy(x => x).ToArray();
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));


        long[,] dp = new long[sortedRobot.Length + 1, factory.Length + 1];
        for (int i = 0; i <= sortedRobot.Length; i++)
        {
            for (int j = 0; j <= factory.Length; j++) dp[i, j] = long.MaxValue;
        }

        dp[sortedRobot.Length, factory.Length] = 0;

        for (int j = factory.Length - 1; j >= 0; j--)
        {
            long prefixSum = 0;
            LinkedList<(int, long)> deque = new();
            deque.AddLast((sortedRobot.Length, 0));

            for (int i = sortedRobot.Length - 1; i >= 0; i--)
            {
                prefixSum += Math.Abs(sortedRobot[i] - factory[j][0]);

                if (deque.Count > 0 && deque.First.Value.Item1 > i + factory[j][1]) deque.RemoveFirst();

                long currentValue = dp[i, j + 1] - prefixSum;
                while (deque.Count > 0 && deque.Last.Value.Item2 >= currentValue) deque.RemoveLast();

                deque.AddLast((i, currentValue));
                dp[i, j] = deque.First.Value.Item2 + prefixSum;
            }
        }

        return dp[0, 0];
    }
}