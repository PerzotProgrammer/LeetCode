namespace TimeRequiredToBuy;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: tickets = [2,3,2], k = 2
        // Output: 6
        // Explanation: 
        // - In the first pass, everyone in the line buys a ticket and the line becomes [1, 2, 1].
        // - In the second pass, everyone in the line buys a ticket and the line becomes [0, 1, 0].
        // The person at position 2 has successfully bought 2 tickets and it took 3 + 3 = 6 seconds.

        // Example 2:
        //
        // Input: tickets = [5,1,1,1], k = 0
        // Output: 8
        // Explanation:
        // - In the first pass, everyone in the line buys a ticket and the line becomes [4, 0, 0, 0].
        // - In the next 4 passes, only the person in position 0 is buying tickets.
        // The person at position 0 has successfully bought 5 tickets and it took 4 + 1 + 1 + 1 + 1 = 8 seconds.

        Solution solution = new();

        Console.WriteLine(solution.TimeRequiredToBuy([2, 3, 2], 2));
        Console.WriteLine(solution.TimeRequiredToBuy([5, 1, 1, 1], 0));
    }

    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        Queue<int> queue = new();
        for (int i = 0; i < tickets.Length; i++) queue.Enqueue(i);

        int time = 0;
        while (tickets[k] > 0)
        {
            int person = queue.Dequeue();
            if (tickets[person] > 0)
            {
                tickets[person]--;
                time++;
                queue.Enqueue(person);
            }
        }

        return time;
    }
}