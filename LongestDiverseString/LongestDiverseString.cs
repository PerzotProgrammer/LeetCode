namespace LongestDiverseString;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: a = 1, b = 1, c = 7
        // Output: "ccaccbcc"
        // Explanation: "ccbccacc" would also be a correct answer.

        // Example 2:
        //
        // Input: a = 7, b = 1, c = 0
        // Output: "aabaa"
        // Explanation: It is the only correct answer in this case.


        Solution solution = new();

        Console.WriteLine(solution.LongestDiverseString(1, 1, 7));
        Console.WriteLine(solution.LongestDiverseString(7, 1, 0));
    }

    public string LongestDiverseString(int a, int b, int c)
    {
        PriorityQueue<(int count, char ch), int> maxHeap = new();

        if (a > 0) maxHeap.Enqueue((a, 'a'), -a);
        if (b > 0) maxHeap.Enqueue((b, 'b'), -b);
        if (c > 0) maxHeap.Enqueue((c, 'c'), -c);

        string result = "";

        while (maxHeap.Count > 0)
        {
            (int count1, char ch1) = maxHeap.Dequeue();
            if (result.Length >= 2 && result[^1] == ch1 && result[^2] == ch1)
            {
                if (maxHeap.Count == 0) break;

                (int count2, char ch2) = maxHeap.Dequeue();
                result += ch2;
                count2--;
                if (count2 > 0) maxHeap.Enqueue((count2, ch2), -count2);

                maxHeap.Enqueue((count1, ch1), -count1);
            }
            else
            {
                result += ch1;
                count1--;

                if (count1 > 0) maxHeap.Enqueue((count1, ch1), -count1);
            }
        }

        return result;
    }
}