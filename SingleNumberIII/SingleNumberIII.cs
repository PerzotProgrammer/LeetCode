namespace SingleNumberIII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,1,3,2,5]
        // Output: [3,5]
        // Explanation:  [5, 3] is also a valid answer.

        // Example 2:
        //
        // Input: nums = [-1,0]
        // Output: [-1,0]

        // Example 3:
        //
        // Input: nums = [0,1]
        // Output: [1,0]


        Solution solution = new();

        PrintArray(solution.SingleNumber([1, 2, 1, 3, 2, 5]));
        PrintArray(solution.SingleNumber([-1, 0]));
        PrintArray(solution.SingleNumber([0, 1]));
    }

    public int[] SingleNumber(int[] nums)
    {
        Dictionary<int, int> freq = new();

        foreach (int num in nums)
        {
            if (!freq.TryAdd(num, 1)) freq[num]++;
        }

        List<int> output = new();
        foreach (KeyValuePair<int, int> pair in freq)
        {
            if (pair.Value == 1) output.Add(pair.Key);
        }

        return output.ToArray();
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i},");
        Console.WriteLine();
    }
}