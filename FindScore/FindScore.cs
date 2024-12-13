namespace FindScore;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [2,1,3,4,5,2]
        // Output: 7
        // Explanation: We mark the elements as follows:
        // - 1 is the smallest unmarked element, so we mark it and its two adjacent elements: [2,1,3,4,5,2].
        // - 2 is the smallest unmarked element, so we mark it and its left adjacent element: [2,1,3,4,5,2].
        // - 4 is the only remaining unmarked element, so we mark it: [2,1,3,4,5,2].
        // Our score is 1 + 2 + 4 = 7.

        // Example 2:
        //
        // Input: nums = [2,3,5,1,3,2]
        // Output: 5
        // Explanation: We mark the elements as follows:
        // - 1 is the smallest unmarked element, so we mark it and its two adjacent elements: [2,3,5,1,3,2].
        // - 2 is the smallest unmarked element, since there are two of them, we choose the left-most one, so we mark the one at index 0 and its right adjacent element: [2,3,5,1,3,2].
        // - 2 is the only remaining unmarked element, so we mark it: [2,3,5,1,3,2].
        // Our score is 1 + 2 + 2 = 5.


        Solution solution = new();

        Console.WriteLine(solution.FindScore([2, 1, 3, 4, 5, 2]));
        Console.WriteLine(solution.FindScore([2, 3, 5, 1, 3, 2]));
    }

    public long FindScore(int[] nums)
    {
        bool[] marked = new bool[nums.Length];
        List<(int value, int index)> elements = new();
        for (int i = 0; i < nums.Length; i++)
        {
            elements.Add((nums[i], i));
        }

        elements.Sort((a, b) => a.value == b.value ? a.index.CompareTo(b.index) : a.value.CompareTo(b.value));

        long score = 0;

        foreach ((int value, int index) in elements)
        {
            if (marked[index]) continue;

            score += value;

            marked[index] = true;
            if (index > 0) marked[index - 1] = true;

            if (index < nums.Length - 1) marked[index + 1] = true;
        }

        return score;
    }
}