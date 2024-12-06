namespace MaxCount;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: banned = [1,6,5], n = 5, maxSum = 6
        // Output: 2
        // Explanation: You can choose the integers 2 and 4.
        // 2 and 4 are from the range [1, 5], both did not appear in banned, and their sum is 6, which did not exceed maxSum.

        // Example 2:
        //
        // Input: banned = [1,2,3,4,5,6,7], n = 8, maxSum = 1
        // Output: 0
        // Explanation: You cannot choose any integer while following the mentioned conditions.

        // Example 3:
        //
        // Input: banned = [11], n = 7, maxSum = 50
        // Output: 7
        // Explanation: You can choose the integers 1, 2, 3, 4, 5, 6, and 7.
        // They are from the range [1, 7], all did not appear in banned, and their sum is 28, which did not exceed maxSum.


        Solution solution = new();

        Console.WriteLine(solution.MaxCount([1, 6, 5], 5, 6));
        Console.WriteLine(solution.MaxCount([1, 2, 3, 4, 5, 6, 7], 8, 1));
        Console.WriteLine(solution.MaxCount([11], 7, 50));
    }

    public int MaxCount(int[] banned, int n, int maxSum)
    {
        Array.Sort(banned);
        int currentSum = 0;
        int currentCount = 0;
        for (int i = 1; i <= n; i++)
        {
            if (currentSum + i > maxSum) break;
            if (!banned.Contains(i))
            {
                currentSum += i;
                currentCount++;
            }
        }

        return currentCount;
    }
}