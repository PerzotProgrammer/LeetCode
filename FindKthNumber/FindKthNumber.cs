namespace FindKthNumber;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC EDITORIALA
        // Example 1:
        //
        // Input: n = 13, k = 2
        // Output: 10
        // Explanation: The lexicographical order is [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9], so the second smallest number is 10.

        // Example 2:
        //
        // Input: n = 1, k = 1
        // Output: 1

        Solution solution = new();

        Console.WriteLine(solution.FindKthNumber(13, 2));
        Console.WriteLine(solution.FindKthNumber(1, 1));
    }

    public int FindKthNumber(int n, int k)
    {
        int current = 1;
        k--;

        while (k > 0)
        {
            long steps = CountSteps(n, current, current + 1);

            if (steps <= k)
            {
                current++;
                k -= (int)steps;
            }
            else
            {
                current *= 10;
                k--;
            }
        }

        return current;
    }

    private long CountSteps(int n, long current, long next)
    {
        long steps = 0;

        while (current <= n)
        {
            steps += Math.Min(n + 1, next) - current;
            current *= 10;
            next *= 10;
        }

        return steps;
    }
}