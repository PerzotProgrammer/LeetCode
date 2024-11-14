namespace MinimizedMaximum;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = 6, quantities = [11,6]
        // Output: 3
        // Explanation: One optimal way is:
        // - The 11 products of type 0 are distributed to the first four stores in these amounts: 2, 3, 3, 3
        // - The 6 products of type 1 are distributed to the other two stores in these amounts: 3, 3
        // The maximum number of products given to any store is max(2, 3, 3, 3, 3, 3) = 3.

        // Example 2:
        //
        // Input: n = 7, quantities = [15,10,10]
        // Output: 5
        // Explanation: One optimal way is:
        // - The 15 products of type 0 are distributed to the first three stores in these amounts: 5, 5, 5
        // - The 10 products of type 1 are distributed to the next two stores in these amounts: 5, 5
        // - The 10 products of type 2 are distributed to the last two stores in these amounts: 5, 5
        // The maximum number of products given to any store is max(5, 5, 5, 5, 5, 5, 5) = 5.

        // Example 3:
        //
        // Input: n = 1, quantities = [100000]
        // Output: 100000
        // Explanation: The only optimal way is:
        // - The 100000 products of type 0 are distributed to the only store.
        // The maximum number of products given to any store is max(100000) = 100000.


        Solution solution = new();

        Console.WriteLine(solution.MinimizedMaximum(6, [11, 6]));
        Console.WriteLine(solution.MinimizedMaximum(7, [15, 10, 10]));
        Console.WriteLine(solution.MinimizedMaximum(1, [100000]));
    }

    public int MinimizedMaximum(int n, int[] quantities)
    {
        int left = 1;
        int right = GetMaxQuantity(quantities);

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanDistribute(n, quantities, mid)) right = mid;
            else left = mid + 1;
        }

        return left;
    }

    private int GetMaxQuantity(int[] quantities)
    {
        int maxQuantity = 0;
        foreach (int quantity in quantities) maxQuantity = Math.Max(maxQuantity, quantity);

        return maxQuantity;
    }

    private bool CanDistribute(int n, int[] quantities, int maxProductsPerStore)
    {
        int requiredStores = 0;
        foreach (int quantity in quantities)
        {
            requiredStores += (quantity + maxProductsPerStore - 1) / maxProductsPerStore;
            if (requiredStores > n) return false;
        }

        return requiredStores <= n;
    }
}