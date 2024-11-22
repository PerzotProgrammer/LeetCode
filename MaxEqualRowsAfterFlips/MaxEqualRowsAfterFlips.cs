namespace MaxEqualRowsAfterFlips;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: matrix = [[0,1],[1,1]]
        // Output: 1
        // Explanation: After flipping no values, 1 row has all values equal.

        // Example 2:
        //
        // Input: matrix = [[0,1],[1,0]]
        // Output: 2
        // Explanation: After flipping values in the first column, both rows have equal values.

        // Example 3:
        //
        // Input: matrix = [[0,0,0],[0,0,1],[1,1,0]]
        // Output: 2
        // Explanation: After flipping values in the first two columns, the last two rows have equal values.


        Solution solution = new();

        Console.WriteLine(solution.MaxEqualRowsAfterFlips([[0, 1], [1, 1]]));
        Console.WriteLine(solution.MaxEqualRowsAfterFlips([[0, 1], [1, 0]]));
        Console.WriteLine(solution.MaxEqualRowsAfterFlips([[0, 0, 0], [0, 0, 1], [1, 1, 0]]));
    }

    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        Dictionary<string, int> patternCount = new();

        foreach (int[] row in matrix)
        {
            char[] normalizedPattern = new char[row.Length];
            int firstElement = row[0];

            for (int j = 0; j < row.Length; j++) normalizedPattern[j] = row[j] == firstElement ? '0' : '1';

            string key = new string(normalizedPattern);
            if (!patternCount.TryAdd(key, 1)) patternCount[key]++;
        }

        int maxRows = 0;
        foreach (int count in patternCount.Values) maxRows = Math.Max(maxRows, count);

        return maxRows;
    }
}