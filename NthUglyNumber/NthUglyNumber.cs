namespace NthUglyNumber;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 10
        // Output: 12
        // Explanation: [1, 2, 3, 4, 5, 6, 8, 9, 10, 12] is the sequence of the first 10 ugly numbers.

        // Example 2:
        //
        // Input: n = 1
        // Output: 1
        // Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.


        Solution solution = new();

        Console.WriteLine(solution.NthUglyNumber(10));
        Console.WriteLine(solution.NthUglyNumber(1));
    }

    public int NthUglyNumber(int n)
    {
        HashSet<long> seen = new();
        PriorityQueue<long, long> heap = new();

        heap.Enqueue(1, 1);
        seen.Add(1);

        long[] primes = { 2, 3, 5 };
        long output = 1;

        for (int i = 0; i < n; i++)
        {
            output = heap.Dequeue();
            foreach (long prime in primes)
            {
                long newUgly = output * prime;
                if (seen.Add(newUgly)) heap.Enqueue(newUgly, newUgly);
            }
        }

        return (int)output;
    }
}