namespace SingleNumber;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [2,2,1]
        // Output: 1

        // Example 2:
        //
        // Input: nums = [4,1,2,1,2]
        // Output: 4

        // Example 3:
        //
        // Input: nums = [1]
        // Output: 1

        Solution solution = new();

        Console.WriteLine(solution.SingleNumber([2, 2, 1]));
        Console.WriteLine(solution.SingleNumber([4, 1, 2, 1, 2]));
        Console.WriteLine(solution.SingleNumber([1]));
    }

    public int SingleNumber(int[] nums)
    {
        Dictionary<int, int> freq = new();
        foreach (int num in nums) if (!freq.TryAdd(num, 1)) freq[num]++;
        foreach (KeyValuePair<int, int> pair in freq) if (pair.Value == 1) return pair.Key;
        return -1;
    }
}