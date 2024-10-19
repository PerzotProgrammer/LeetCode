namespace FindKthBit;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = 3, k = 1
        // Output: "0"
        // Explanation: S3 is "0111001".
        // The 1st bit is "0".

        // Example 2:
        //
        // Input: n = 4, k = 11
        // Output: "1"
        // Explanation: S4 is "011100110110001".
        // The 11th bit is "1".


        Solution solution = new();

        Console.WriteLine(solution.FindKthBit(3, 1));
        Console.WriteLine(solution.FindKthBit(4, 11));
    }

    public char FindKthBit(int n, int k)
    {
        while (n > 1)
        {
            int length = (1 << n) - 1;
            int mid = length / 2 + 1;
            if (k == mid) return '1';

            if (k > mid)
            {
                k = length - k + 1;
                return FindKthBit(n - 1, k) == '0' ? '1' : '0';
            }

            n--;
        }

        return '0';
    }
}