namespace MaximumHappinessSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: happiness = [1,2,3], k = 2
        // Output: 4
        // Explanation: We can pick 2 children in the following way:
        // - Pick the child with the happiness value == 3. The happiness value of the remaining children becomes [0,1].
        // - Pick the child with the happiness value == 1. The happiness value of the remaining child becomes [0]. Note that the happiness value cannot become less than 0.
        // The sum of the happiness values of the selected children is 3 + 1 = 4.

        // Example 2:
        //
        // Input: happiness = [1,1,1,1], k = 2
        // Output: 1
        // Explanation: We can pick 2 children in the following way:
        // - Pick any child with the happiness value == 1. The happiness value of the remaining children becomes [0,0,0].
        // - Pick the child with the happiness value == 0. The happiness value of the remaining child becomes [0,0].
        // The sum of the happiness values of the selected children is 1 + 0 = 1.

        // Example 3:
        //
        // Input: happiness = [2,3,4,5], k = 1
        // Output: 5
        // Explanation: We can pick 1 child in the following way:
        // - Pick the child with the happiness value == 5. The happiness value of the remaining children becomes [1,2,3].
        // The sum of the happiness values of the selected children is 5.

        Solution solution = new();

        Console.WriteLine(solution.MaximumHappinessSum([1, 2, 3], 2));
        Console.WriteLine(solution.MaximumHappinessSum([1, 1, 1, 1], 2));
        Console.WriteLine(solution.MaximumHappinessSum([2, 3, 4, 5], 1));
    }

    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness);
        Array.Reverse(happiness);

        long output = 0;
        int turns = 0;

        for (int i = 0; i < k; i++)
        {
            output += Math.Max(happiness[i] - turns, 0);
            turns++;
        }

        return output;
    }
}