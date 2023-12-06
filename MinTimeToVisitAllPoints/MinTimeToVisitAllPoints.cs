namespace MinTimeToVisitAllPoints;

class Solution
{
    static void Main()
    {
        // Input: points = [[1,1],[3,4],[-1,0]]
        // Output: 7
        // Explanation: One optimal path is [1,1] -> [2,2] -> [3,3] -> [3,4] -> [2,3] -> [1,2] -> [0,1] -> [-1,0]   
        // Time from [1,1] to [3,4] = 3 seconds 
        //     Time from [3,4] to [-1,0] = 4 seconds
        // Total time = 7 seconds
        //     Example 2:
        //
        // Input: points = [[3,2],[-2,2]]
        // Output: 5

        int[][] T1 = { new[] { 1, 1 }, new[] { 3, 4 }, new[] { -1, 0 } };
        int[][] T2 = { new[] { 3, 2 }, new[] { - 2, 2 } };

        Solution solution = new();

        Console.WriteLine(solution.MinTimeToVisitAllPoints(T1));
        Console.WriteLine(solution.MinTimeToVisitAllPoints(T2));
    }

    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int moves = 0;
    
        for (int i = 0; i < points.Length - 1; i++)
        {
            int currX = points[i][0];
            int currY = points[i][1];
            int nextX = points[i + 1][0];
            int nextY = points[i + 1][1];
            moves += Math.Max(Math.Abs(nextX - currX), Math.Abs(nextY - currY));
        }
        
        return moves;
    }
}