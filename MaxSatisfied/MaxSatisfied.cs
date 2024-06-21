namespace MaxSatisfied;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: customers = [1,0,1,2,1,1,7,5], grumpy = [0,1,0,1,0,1,0,1], minutes = 3
        // Output: 16
        // Explanation: The bookstore owner keeps themselves not grumpy for the last 3 minutes. 
        // The maximum number of customers that can be satisfied = 1 + 1 + 1 + 1 + 7 + 5 = 16.

        // Example 2:
        //
        // Input: customers = [1], grumpy = [0], minutes = 1
        // Output: 1


        Solution solution = new();

        Console.WriteLine(solution.MaxSatisfied([1, 0, 1, 2, 1, 1, 7, 5], [0, 1, 0, 1, 0, 1, 0, 1], 3));
        Console.WriteLine(solution.MaxSatisfied([1], [0], 1));
    }

    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int satisfiedCustomers = 0;

        for (int i = 0; i < customers.Length; i++)
        {
            if (grumpy[i] == 0) satisfiedCustomers += customers[i];
        }

        int[] grumpyPrefixSum = new int[customers.Length + 1];
        for (int i = 0; i < customers.Length; i++)
        {
            grumpyPrefixSum[i + 1] = grumpyPrefixSum[i];
            if (grumpy[i] == 1) grumpyPrefixSum[i + 1] += customers[i];
        }

        int maxAdditionalSatisfied = 0;
        for (int i = 0; i <= customers.Length - minutes; i++)
        {
            int end = i + minutes;
            int additionalSatisfied = grumpyPrefixSum[end] - grumpyPrefixSum[i];
            maxAdditionalSatisfied = Math.Max(maxAdditionalSatisfied, additionalSatisfied);
        }

        return satisfiedCustomers + maxAdditionalSatisfied;
    }
}