namespace SortArray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [5,2,3,1]
        // Output: [1,2,3,5]
        // Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).

        // Example 2:
        //
        // Input: nums = [5,1,1,2,0,0]
        // Output: [0,0,1,1,2,5]
        // Explanation: Note that the values of nums are not necessairly unique.


        Solution solution = new();

        PrintArray(solution.SortArray([5, 2, 3, 1]));
        PrintArray(solution.SortArray([5, 1, 1, 2, 0, 0]));
    }

    public int[] SortArray(int[] nums)
    {
        int start = nums.Length / 2;
        int end = nums.Length;

        while (end > 1)
        {
            if (start > 0) --start;
            else
            {
                --end;
                (nums[0], nums[end]) = (nums[end], nums[0]);
            }

            int root = start;

            while (root * 2 + 1 < end)
            {
                int child = root * 2 + 1;
                if (child + 1 < end && nums[child] < nums[child + 1]) ++child;
                if (nums[root] < nums[child])
                {
                    (nums[child], nums[root]) = (nums[root], nums[child]);
                    root = child;
                }
                else break;
            }
        }

        return nums;
    }

    static void PrintArray(int[] array)
    {
        foreach (int i in array) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}