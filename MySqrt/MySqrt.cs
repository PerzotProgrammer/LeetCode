namespace MySqrt;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: x = 4
        // Output: 2
        // Explanation: The square root of 4 is 2, so we return 2.

        // Example 2:
        //
        // Input: x = 8
        // Output: 2
        // Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.

        Solution solution = new();

        Console.WriteLine(solution.MySqrt(4));
        Console.WriteLine(solution.MySqrt(8));
    }

    public int MySqrt(int x)
    {
        int subCount = 0;
        int subNum = 1;

        while (x > 0)
        {
            x -= subNum;
            subNum += 2;
            subCount++;
        }

        if (x == 0) return subCount;
        return subCount - 1;
    }
}