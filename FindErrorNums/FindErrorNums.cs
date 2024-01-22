namespace FindErrorNums;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,2,4]
        // Output: [2,3]

        // Example 2:
        //
        // Input: nums = [1,1]
        // Output: [1,2]

        Solution solution = new();

        PrintArray(solution.FindErrorNums([1, 2, 2, 4]));
        PrintArray(solution.FindErrorNums([1, 1]));
    }

    public int[] FindErrorNums(int[] nums)
    {
        int first = 0;
        int second = 0;

        int[] count = new int[nums.Length + 1];
        count[nums[0]] += 1;

        for (int i = 1; i < nums.Length; i++) count[nums[i]] += 1;

        for (int j = 1; j < count.Length; j++)
        {
            if (count[j] > 1) first = j;
            if (count[j] == 0) second = j;
        }

        return [first, second];
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i},");
        Console.WriteLine();
    }
}