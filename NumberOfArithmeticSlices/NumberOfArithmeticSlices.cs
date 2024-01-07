namespace NumberOfArithmeticSlices;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [2,4,6,8,10]
        // Output: 7
        // Explanation: All arithmetic subsequence slices are:
        // [2,4,6]
        // [4,6,8]
        // [6,8,10]
        // [2,4,6,8]
        // [4,6,8,10]
        // [2,4,6,8,10]
        // [2,6,10]
        // Example 2:
        //
        // Input: nums = [7,7,7,7,7]
        // Output: 16
        // Explanation: Any subsequence of this array is arithmetic.

        Solution solution = new();

        Console.WriteLine(solution.NumberOfArithmeticSlices([2,4,6,8,10]));
        Console.WriteLine(solution.NumberOfArithmeticSlices([7,7,7,7,7]));
    }

    public int NumberOfArithmeticSlices(int[] nums)
    {
        int n = nums.Length;
        long output = 0;
        Dictionary<int, int>[] count = new Dictionary<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            count[i] = new Dictionary<int, int>(i);
            for (int j = 0; j < i; j++)
            {
                long delta = (long)nums[i] - (long)nums[j];
                if (delta < int.MinValue || delta > int.MaxValue) continue;

                int diff = (int)delta;
                int sum = count[j].GetValueOrDefault(diff, 0);
                int origin = count[i].GetValueOrDefault(diff, 0);
                count[i][diff] = origin + sum + 1;
                output += sum;
            }
        }

        return (int)output;
    }
}