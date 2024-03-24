namespace FindDuplicate;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,3,4,2,2]
        // Output: 2

        // Example 2:
        //
        // Input: nums = [3,1,3,4,2]
        // Output: 3

        // Example 3:
        //
        // Input: nums = [3,3,3,3,3]
        // Output: 3

        Solution solution = new();

        Console.WriteLine(solution.FindDuplicate([1, 3, 4, 2, 2]));
        Console.WriteLine(solution.FindDuplicate([3, 1, 3, 4, 2]));
        Console.WriteLine(solution.FindDuplicate([3, 3, 3, 3, 3]));
    }

    public int FindDuplicate(int[] nums)
    {
        Dictionary<int, int> used = new();

        foreach (int num in nums)
        {
            if (!used.TryAdd(num, 0)) return num;
        }

        return -1;
    }
}