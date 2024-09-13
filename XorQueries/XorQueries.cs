namespace XorQueries;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [1,3,4,8], queries = [[0,1],[1,2],[0,3],[3,3]]
        // Output: [2,7,14,8] 
        // Explanation: 
        // The binary representation of the elements in the array are:
        // 1 = 0001 
        // 3 = 0011 
        // 4 = 0100 
        // 8 = 1000 
        // The XOR values for queries are:
        // [0,1] = 1 xor 3 = 2 
        // [1,2] = 3 xor 4 = 7 
        // [0,3] = 1 xor 3 xor 4 xor 8 = 14 
        // [3,3] = 8

        // Example 2:
        //
        // Input: arr = [4,8,2,10], queries = [[2,3],[1,3],[0,0],[0,3]]
        // Output: [8,0,4,4]


        Solution solution = new();

        PrintArray(solution.XorQueries([1, 3, 4, 8], [[0, 1], [1, 2], [0, 3], [3, 3]]));
        PrintArray(solution.XorQueries([4, 8, 2, 10], [[2, 3], [1, 3], [0, 0], [0, 3]]));
    }

    public int[] XorQueries(int[] arr, int[][] queries)
    {
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int xorSum = 0;
            for (int j = queries[i][0]; j <= queries[i][1]; j++) xorSum ^= arr[j];
            result[i] = xorSum;
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}