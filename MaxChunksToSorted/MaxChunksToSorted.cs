namespace MaxChunksToSorted;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [4,3,2,1,0]
        // Output: 1
        // Explanation:
        // Splitting into two or more chunks will not return the required result.
        // For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1, 2], which isn't sorted.

        // Example 2:
        //
        // Input: arr = [1,0,2,3,4]
        // Output: 4
        // Explanation:
        // We can split into two chunks, such as [1, 0], [2, 3, 4].
        // However, splitting into [1, 0], [2], [3], [4] is the highest number of chunks possible.


        Solution solution = new();

        Console.WriteLine(solution.MaxChunksToSorted([3, 2, 0, 1, 4]));
        Console.WriteLine(solution.MaxChunksToSorted([1, 0, 2, 3, 4]));
    }

    public int MaxChunksToSorted(int[] arr)
    {
        int chunks = 0;
        int maxElement = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            maxElement = Math.Max(maxElement, arr[i]);
            if (maxElement == i) chunks++;
        }

        return chunks;
    }
}