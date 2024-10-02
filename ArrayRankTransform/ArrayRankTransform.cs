namespace ArrayRankTransform;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [40,10,20,30]
        // Output: [4,1,2,3]
        // Explanation: 40 is the largest element. 10 is the smallest. 20 is the second smallest. 30 is the third smallest.

        // Example 2:
        //
        // Input: arr = [100,100,100]
        // Output: [1,1,1]
        // Explanation: Same elements share the same rank.

        // Example 3:
        //
        // Input: arr = [37,12,28,9,100,56,80,5,12]
        // Output: [5,3,4,2,8,6,7,1,3]

        Solution solution = new();

        PrintArray(solution.ArrayRankTransform([40, 10, 20, 30]));
        PrintArray(solution.ArrayRankTransform([100, 100, 100]));
        PrintArray(solution.ArrayRankTransform([37, 12, 28, 9, 100, 56, 80, 5, 12]));
    }

    public int[] ArrayRankTransform(int[] arr)
    {
        if (arr.Length == 0) return [];

        int[] sortedArr = (int[])arr.Clone();
        Array.Sort(sortedArr);

        Dictionary<int, int> rankMap = new();
        int rank = 1;

        for (int i = 0; i < sortedArr.Length; i++)
        {
            if (!rankMap.ContainsKey(sortedArr[i]))
            {
                rankMap[sortedArr[i]] = rank;
                rank++;
            }
        }

        int[] result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            result[i] = rankMap[arr[i]];
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}