namespace RobotSim;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: commands = [4,-1,3], obstacles = []
        // Output: 25
        // Explanation: The robot starts at (0, 0):
        // 1. Move north 4 units to (0, 4).
        // 2. Turn right.
        // 3. Move east 3 units to (3, 4).
        // The furthest point the robot ever gets from the origin is (3, 4), which squared is 32 + 42 = 25 units away.

        // Example 2:
        //
        // Input: commands = [4,-1,4,-2,4], obstacles = [[2,4]]
        // Output: 65
        // Explanation: The robot starts at (0, 0):
        // 1. Move north 4 units to (0, 4).
        // 2. Turn right.
        // 3. Move east 1 unit and get blocked by the obstacle at (2, 4), robot is at (1, 4).
        // 4. Turn left.
        // 5. Move north 4 units to (1, 8).
        // The furthest point the robot ever gets from the origin is (1, 8), which squared is 12 + 82 = 65 units away.

        // Example 3:
        //
        // Input: commands = [6,-1,-1,6], obstacles = []
        // Output: 36
        // Explanation: The robot starts at (0, 0):
        // 1. Move north 6 units to (0, 6).
        // 2. Turn right.
        // 3. Turn right.
        // 4. Move south 6 units to (0, 0).
        //     The furthest point the robot ever gets from the origin is (0, 6), which squared is 62 = 36 units away.


        Solution solution = new();

        Console.WriteLine(solution.RobotSim([4, -1, 3], []));
        Console.WriteLine(solution.RobotSim([4, -1, 4, -2, 4], [[2, 4]]));
        Console.WriteLine(solution.RobotSim([6, -1, -1, 6], []));
    }

    public int RobotSim(int[] commands, int[][] obstacles)
    {
        int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        Dictionary<(int, int), bool> obstacleMap = new();
        foreach (int[] obstacle in obstacles) obstacleMap[(obstacle[0], obstacle[1])] = true;

        int x = 0;
        int y = 0;
        int directionIndex = 0;
        int maxDistance = 0;

        foreach (int command in commands)
        {
            if (command == -1) directionIndex = (directionIndex + 1) % 4;
            else if (command == -2) directionIndex = (directionIndex + 3) % 4;
            else
            {
                for (int i = 0; i < command; i++)
                {
                    int nextX = x + directions[directionIndex, 0];
                    int nextY = y + directions[directionIndex, 1];

                    if (!obstacleMap.ContainsKey((nextX, nextY)))
                    {
                        x = nextX;
                        y = nextY;
                        maxDistance = Math.Max(maxDistance, x * x + y * y);
                    }
                    else break;
                }
            }
        }

        return maxDistance;
    }
}