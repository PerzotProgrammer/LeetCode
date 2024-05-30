namespace CountTriplets;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [2,3,1,6,7]
        // Output: 4
        // Explanation: The triplets are (0,1,2), (0,2,2), (2,3,4) and (2,4,4)

        // Example 2:
        //
        // Input: arr = [1,1,1,1,1]
        // Output: 10

        Solution solution = new();

        Console.WriteLine(solution.CountTriplets([2, 3, 1, 6, 7]));
        Console.WriteLine(solution.CountTriplets([1, 1, 1, 1, 1]));
    }

    public int CountTriplets(int[] arr)
    {
        int count = 0;
        for (int start = 0; start < arr.Length - 1; ++start)
        {
            int xorA = 0;

            for (int mid = start + 1; mid < arr.Length; ++mid)
            {
                xorA ^= arr[mid - 1];
                int xorB = 0;
                for (int end = mid; end < arr.Length; ++end)
                {
                    xorB ^= arr[end];
                    if (xorA == xorB) ++count;
                }
            }
        }

        return count;
    }
}