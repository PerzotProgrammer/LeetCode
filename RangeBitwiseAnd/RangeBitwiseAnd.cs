namespace RangeBitwiseAnd;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: left = 5, right = 7
        // Output: 4

        // Example 2:
        //
        // Input: left = 0, right = 0
        // Output: 0

        // Example 3:
        //
        // Input: left = 1, right = 2147483647
        // Output: 0

        Solution solution = new();

        Console.WriteLine(solution.RangeBitwiseAnd(5, 7));
        Console.WriteLine(solution.RangeBitwiseAnd(0, 0));
        Console.WriteLine(solution.RangeBitwiseAnd(1, 2147483647));
    }

    public int RangeBitwiseAnd(int left, int right)
    {
        while (left < right) right &= right - 1;
        return left & right;
    }
}