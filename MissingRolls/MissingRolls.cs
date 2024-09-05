namespace MissingRolls;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: rolls = [3,2,4,3], mean = 4, n = 2
        // Output: [6,6]
        // Explanation: The mean of all n + m rolls is (3 + 2 + 4 + 3 + 6 + 6) / 6 = 4.

        // Example 2:
        //
        // Input: rolls = [1,5,6], mean = 3, n = 4
        // Output: [2,3,2,2]
        // Explanation: The mean of all n + m rolls is (1 + 5 + 6 + 2 + 3 + 2 + 2) / 7 = 3.

        // Example 3:
        //
        // Input: rolls = [1,2,3,4], mean = 6, n = 4
        // Output: []
        // Explanation: It is impossible for the mean to be 6 no matter what the 4 missing rolls are.


        Solution solution = new();

        PrintArray(solution.MissingRolls([3, 2, 4, 3], 4, 2));
        PrintArray(solution.MissingRolls([1, 5, 6], 3, 4));
        PrintArray(solution.MissingRolls([1, 2, 3, 4], 6, 4));
    }

    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int sum = 0;
        foreach (int roll in rolls) sum += roll;

        int remainingSum = mean * (n + rolls.Length) - sum;
        if (remainingSum > 6 * n || remainingSum < n) return [];

        int distributeMean = remainingSum / n;
        int mod = remainingSum % n;
        int[] nElements = new int[n];
        Array.Fill(nElements, distributeMean);
        for (int i = 0; i < mod; i++) nElements[i]++;

        return nElements;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i} ,");
        Console.WriteLine();
    }
}