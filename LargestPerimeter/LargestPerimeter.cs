namespace LargestPerimeter;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [5,5,5]
        // Output: 15
        // Explanation: The only possible polygon that can be made from nums has 3 sides: 5, 5, and 5. The perimeter is 5 + 5 + 5 = 15.

        // Example 2:
        //
        // Input: nums = [1,12,1,2,5,50,3]
        // Output: 12
        // Explanation: The polygon with the largest perimeter which can be made from nums has 5 sides: 1, 1, 2, 3, and 5. The perimeter is 1 + 1 + 2 + 3 + 5 = 12.
        // We cannot have a polygon with either 12 or 50 as the longest side because it is not possible to include 2 or more smaller sides that have a greater sum than either of them.
        // It can be shown that the largest possible perimeter is 12.

        // Example 3:
        //
        // Input: nums = [5,5,50]
        // Output: -1
        // Explanation: There is no possible way to form a polygon from nums, as a polygon has at least 3 sides and 50 > 5 + 5.

        Solution solution = new();

        Console.WriteLine(solution.LargestPerimeter([5, 5, 5]));
        Console.WriteLine(solution.LargestPerimeter([1, 12, 1, 2, 5, 50, 3]));
        Console.WriteLine(solution.LargestPerimeter([5, 5, 50]));
    }

    public long LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        long prev = 0;
        long ans = -1;

        foreach (int num in nums)
        {
            if (num < prev) ans = Math.Max(ans, prev + num);
            prev += num;
        }

        return ans;
    }
}