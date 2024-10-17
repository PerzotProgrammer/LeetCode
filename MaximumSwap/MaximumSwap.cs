namespace MaximumSwap;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: num = 2736
        // Output: 7236
        // Explanation: Swap the number 2 and the number 7.

        // Example 2:
        //
        // Input: num = 9973
        // Output: 9973
        // Explanation: No swap.

        Solution solution = new();

        Console.WriteLine(solution.MaximumSwap(2736));
        Console.WriteLine(solution.MaximumSwap(9973));
    }

    public int MaximumSwap(int num)
    {
        char[] digits = num.ToString().ToCharArray();

        int maxPos = digits.Length - 1;
        int x = -1;
        int y = -1;

        for (int i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] < digits[maxPos])
            {
                x = i;
                y = maxPos;
            }
            else if (digits[i] > digits[maxPos]) maxPos = i;
        }

        if (x != -1 && y != -1)
        {
            (digits[x], digits[y]) = (digits[y], digits[x]);
            return int.Parse(new string(digits));
        }

        return num;
    }
}