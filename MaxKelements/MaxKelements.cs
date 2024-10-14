namespace MaxKelements;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [10,10,10,10,10], k = 5
        // Output: 50
        // Explanation: Apply the operation to each array element exactly once. The final score is 10 + 10 + 10 + 10 + 10 = 50.

        // Example 2:
        //
        // Input: nums = [1,10,3,3,3], k = 3
        // Output: 17
        // Explanation: You can do the following operations:
        // Operation 1: Select i = 1, so nums becomes [1,4,3,3,3]. Your score increases by 10.
        // Operation 2: Select i = 1, so nums becomes [1,2,3,3,3]. Your score increases by 4.
        // Operation 3: Select i = 2, so nums becomes [1,1,1,3,3]. Your score increases by 3.
        // The final score is 10 + 4 + 3 = 17.


        Solution solution = new();

        Console.WriteLine(solution.MaxKelements([10, 10, 10, 10, 10], 5));
        Console.WriteLine(solution.MaxKelements([1, 10, 3, 3, 3], 3));
    }

    public long MaxKelements(int[] nums, int k)
    {
        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (int num in nums) maxHeap.Enqueue(num, num);
        long score = 0;

        for (int i = 0; i < k; i++)
        {
            int maxElement = maxHeap.Dequeue();
            score += maxElement;
            int newElement = (int)Math.Ceiling(maxElement / 3.0);
            maxHeap.Enqueue(newElement, newElement);
        }

        return score;
    }
}