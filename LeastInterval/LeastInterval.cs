namespace LeastInterval;

class Solution
{
    static void Main()
    {
        // Example 1:
        // Input:
        // tasks = ["A", "A", "A", "B", "B", "B"], n = 2
        // Output:8
        // Explanation: A possible sequence is : A->B->idle->A->B->idle->A->B.After completing task A, you must wait two cycles before
        // doing A again.The same applies to task B.In the 3rd interval, neither A nor B can be done, so you idle.By
        // the 4th cycle, you can do A again as 2 intervals have passed.
        //
        // Example 2:
        // Input:
        // tasks = ["A", "C", "A", "B", "D", "B"], n = 1
        // Output: 6
        // Explanation: A possible sequence is : A->B->C->D->A->B.

        Solution solution = new();

        Console.WriteLine(solution.LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 2));
        Console.WriteLine(solution.LeastInterval(['A', 'C', 'A', 'B', 'D', 'B'], 1));
    }

    public int LeastInterval(char[] tasks, int n)
    {
        int[] frequencies = new int[26];
        foreach (char task in tasks) frequencies[task - 'A']++;

        Array.Sort(frequencies);

        int maxFrequency = frequencies[25] - 1;
        int idleSlots = maxFrequency * n;

        for (int i = 24; i >= 0 && frequencies[i] > 0; i--) idleSlots -= Math.Min(frequencies[i], maxFrequency);

        return Math.Max(idleSlots, 0) + tasks.Length;
    }
}