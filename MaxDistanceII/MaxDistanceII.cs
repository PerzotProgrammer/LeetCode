namespace MaxDistanceII;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arrays = [[1,2,3],[4,5],[1,2,3]]
        // Output: 4
        // Explanation: One way to reach the maximum distance 4 is to pick 1 in the first or third array and pick 5 in the second array.

        // Example 2:
        //
        // Input: arrays = [[1],[1]]
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.MaxDistance([[1, 2, 3], [4, 5], [1, 2, 3]]));
        Console.WriteLine(solution.MaxDistance([[1], [1]]));
    }

    public int MaxDistance(IList<IList<int>> arrays)
    {
        int minGlobal = int.MaxValue;
        int maxGlobal = int.MinValue;

        int result = 0;

        for (int i = 0; i < arrays.Count; i++)
        {
            int currentMin = arrays[i][0];
            int currentMax = arrays[i][arrays[i].Count - 1];

            if (i > 0)
            {
                result = Math.Max(result, Math.Abs(currentMax - minGlobal));
                result = Math.Max(result, Math.Abs(maxGlobal - currentMin));
            }

            minGlobal = Math.Min(minGlobal, currentMin);
            maxGlobal = Math.Max(maxGlobal, currentMax);
        }

        return result;
    }
}