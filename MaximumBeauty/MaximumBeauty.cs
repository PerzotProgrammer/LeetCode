namespace MaximumBeauty;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: items = [[1,2],[3,2],[2,4],[5,6],[3,5]], queries = [1,2,3,4,5,6]
        // Output: [2,4,5,5,6,6]
        // Explanation:
        // - For queries[0]=1, [1,2] is the only item which has price <= 1. Hence, the answer for this query is 2.
        // - For queries[1]=2, the items which can be considered are [1,2] and [2,4]. 
        // The maximum beauty among them is 4.
        // - For queries[2]=3 and queries[3]=4, the items which can be considered are [1,2], [3,2], [2,4], and [3,5].
        // The maximum beauty among them is 5.
        // - For queries[4]=5 and queries[5]=6, all items can be considered.
        // Hence, the answer for them is the maximum beauty of all items, i.e., 6.

        // Example 2:
        //
        // Input: items = [[1,2],[1,2],[1,3],[1,4]], queries = [1]
        // Output: [4]
        // Explanation: 
        // The price of every item is equal to 1, so we choose the item with the maximum beauty 4. 
        // Note that multiple items can have the same price and/or beauty.  

        // Example 3:
        //
        // Input: items = [[10,1000]], queries = [5]
        // Output: [0]
        // Explanation:
        // No item has a price less than or equal to 5, so no item can be chosen.
        // Hence, the answer to the query is 0.


        Solution solution = new();

        PrintArray(solution.MaximumBeauty([[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]], [1, 2, 3, 4, 5, 6]));
        PrintArray(solution.MaximumBeauty([[1, 2], [1, 2], [1, 3], [1, 4]], [1]));
        PrintArray(solution.MaximumBeauty([[10, 1000]], [5]));
    }

    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        int[] ans = new int[queries.Length];

        Array.Sort(items, (a, b) => a[0] - b[0]);
        int max = items[0][1];
        for (int i = 0; i < items.Length; i++)
        {
            max = Math.Max(max, items[i][1]);
            items[i][1] = max;
        }

        for (int i = 0; i < queries.Length; i++) ans[i] = BinarySearch(items, queries[i]);

        return ans;
    }

    private int BinarySearch(int[][] items, int targetPrice)
    {
        int left = 0;
        int right = items.Length - 1;
        int maxBeauty = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (items[mid][0] > targetPrice) right = mid - 1;
            else
            {
                maxBeauty = Math.Max(maxBeauty, items[mid][1]);
                left = mid + 1;
            }
        }

        return maxBeauty;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}