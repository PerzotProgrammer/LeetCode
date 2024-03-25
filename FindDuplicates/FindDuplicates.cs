namespace FindDuplicates;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [4,3,2,7,8,2,3,1]
        // Output: [2,3]

        // Example 2:
        //
        // Input: nums = [1,1,2]
        // Output: [1]

        // Example 3:
        //
        // Input: nums = [1]
        // Output: []

        Solution solution = new();

        PrintList(solution.FindDuplicates([4, 3, 2, 7, 8, 2, 3, 1]));
        PrintList(solution.FindDuplicates([1, 1, 2]));
        PrintList(solution.FindDuplicates([1]));
    }

    public IList<int> FindDuplicates(int[] nums)
    {
        IList<int> output = new List<int>();
        Dictionary<int, int> freq = new();

        foreach (int num in nums)
        {
            if (!freq.TryAdd(num, 1)) freq[num]++;
        }

        foreach (KeyValuePair<int, int> pair in freq)
        {
            if (pair.Value >= 2) output.Add(pair.Key);
        }

        return output;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}