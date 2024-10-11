namespace SmallestChair;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: times = [[1,4],[2,3],[4,6]], targetFriend = 1
        // Output: 1
        // Explanation: 
        // - Friend 0 arrives at time 1 and sits on chair 0.
        // - Friend 1 arrives at time 2 and sits on chair 1.
        // - Friend 1 leaves at time 3 and chair 1 becomes empty.
        // - Friend 0 leaves at time 4 and chair 0 becomes empty.
        // - Friend 2 arrives at time 4 and sits on chair 0.
        // Since friend 1 sat on chair 1, we return 1.

        // Example 2:
        //
        // Input: times = [[3,10],[1,5],[2,6]], targetFriend = 0
        // Output: 2
        // Explanation: 
        // - Friend 1 arrives at time 1 and sits on chair 0.
        // - Friend 2 arrives at time 2 and sits on chair 1.
        // - Friend 0 arrives at time 3 and sits on chair 2.
        // - Friend 1 leaves at time 5 and chair 0 becomes empty.
        // - Friend 2 leaves at time 6 and chair 1 becomes empty.
        // - Friend 0 leaves at time 10 and chair 2 becomes empty.
        // Since friend 0 sat on chair 2, we return 2.


        Solution solution = new();

        Console.WriteLine(solution.SmallestChair([[1, 4], [2, 3], [4, 6]], 1));
        Console.WriteLine(solution.SmallestChair([[3, 10], [1, 5], [2, 6]], 0));
    }

    public int SmallestChair(int[][] times, int targetFriend)
    {
        int[][] timesWithIndex = new int[times.Length][];
        for (int i = 0; i < times.Length; i++) timesWithIndex[i] = [times[i][0], times[i][1], i];

        Array.Sort(timesWithIndex, (a, b) => a[0].CompareTo(b[0]));

        bool[] occupied = new bool[times.Length];
        int[] chairAssignment = new int[times.Length];
        List<Tuple<int, int>> leavingList = new();

        for (int i = 0; i < times.Length; i++)
        {
            int arrivalTime = timesWithIndex[i][0];
            int leavingTime = timesWithIndex[i][1];
            int friendIndex = timesWithIndex[i][2];
            leavingList.RemoveAll(l =>
            {
                if (l.Item1 <= arrivalTime)
                {
                    occupied[l.Item2] = false;
                    return true;
                }

                return false;
            });
            int assignedChair = -1;
            for (int j = 0; j < times.Length; j++)
            {
                if (!occupied[j])
                {
                    assignedChair = j;
                    occupied[j] = true;
                    break;
                }
            }

            chairAssignment[friendIndex] = assignedChair;
            if (friendIndex == targetFriend) return assignedChair;
            leavingList.Add(Tuple.Create(leavingTime, assignedChair));
        }

        return -1;
    }
}