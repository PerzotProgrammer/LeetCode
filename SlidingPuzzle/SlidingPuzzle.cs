namespace SlidingPuzzle;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: board = [[1,2,3],[4,0,5]]
        // Output: 1
        // Explanation: Swap the 0 and the 5 in one move.

        // Example 2:
        //
        // Input: board = [[1,2,3],[5,4,0]]
        // Output: -1
        // Explanation: No number of moves will make the board solved.

        // Example 3:
        //
        // Input: board = [[4,1,2],[5,0,3]]
        // Output: 5
        // Explanation: 5 is the smallest number of moves that solves the board.
        // An example path:
        // After move 0: [[4,1,2],[5,0,3]]
        // After move 1: [[4,1,2],[0,5,3]]
        // After move 2: [[0,1,2],[4,5,3]]
        // After move 3: [[1,0,2],[4,5,3]]
        // After move 4: [[1,2,0],[4,5,3]]
        // After move 5: [[1,2,3],[4,5,0]]


        Solution solution = new();

        Console.WriteLine(solution.SlidingPuzzle([[1, 2, 3], [4, 0, 5]]));
        Console.WriteLine(solution.SlidingPuzzle([[1, 2, 3], [5, 4, 0]]));
        Console.WriteLine(solution.SlidingPuzzle([[4, 1, 2], [5, 0, 3]]));
    }

    public int SlidingPuzzle(int[][] board)
    {
        string target = "123450";
        string start = string.Join("", board[0]) + string.Join("", board[1]);
        if (start == target) return 0;
        int[][] directions =
        [
            [1, 3],
            [0, 2, 4],
            [1, 5],
            [0, 4],
            [1, 3, 5],
            [2, 4]
        ];

        Queue<string> queue = new();
        HashSet<string> visited = new();

        queue.Enqueue(start);
        visited.Add(start);
        int steps = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                string current = queue.Dequeue();
                if (current == target) return steps;

                int zeroPos = current.IndexOf('0');
                foreach (int nextPos in directions[zeroPos])
                {
                    char[] newConfig = current.ToCharArray();
                    newConfig[zeroPos] = newConfig[nextPos];
                    newConfig[nextPos] = '0';
                    string newConfigStr = new string(newConfig);

                    if (visited.Add(newConfigStr)) queue.Enqueue(newConfigStr);
                }
            }

            steps++;
        }

        return -1;
    }
}