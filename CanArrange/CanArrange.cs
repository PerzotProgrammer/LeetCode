namespace CanArrange;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [1,2,3,4,5,10,6,7,8,9], k = 5
        // Output: true
        // Explanation: Pairs are (1,9),(2,8),(3,7),(4,6) and (5,10).

        // Example 2:
        //
        // Input: arr = [1,2,3,4,5,6], k = 7
        // Output: true
        // Explanation: Pairs are (1,6),(2,5) and(3,4).

        // Example 3:
        //
        // Input: arr = [1,2,3,4,5,6], k = 10
        // Output: false
        // Explanation: You can try all possible pairs to see that there is no way to divide arr into 3 pairs each with sum divisible by 10.


        Solution solution = new();

        Console.WriteLine(solution.CanArrange([1, 2, 3, 4, 5, 10, 6, 7, 8, 9], 5));
        Console.WriteLine(solution.CanArrange([1, 2, 3, 4, 5, 6], 7));
        Console.WriteLine(solution.CanArrange([1, 2, 3, 4, 5, 6], 10));
    }

    public bool CanArrange(int[] arr, int k)
    {
        Dictionary<int, int> remainderCounts = new();

        foreach (int num in arr)
        {
            int rem = num % k;
            if (rem < 0) rem += k;

            int complement = (k - rem) % k;

            if (remainderCounts.ContainsKey(complement) && remainderCounts[complement] > 0)
            {
                remainderCounts[complement]--;
                if (remainderCounts[complement] == 0) remainderCounts.Remove(complement);
            }
            else
            {
                if (!remainderCounts.TryAdd(rem, 1)) remainderCounts[rem]++;
            }
        }


        return remainderCounts.Count == 0;
    }
}