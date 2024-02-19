namespace IsPowerOfTwo;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 1
        // Output: true
        // Explanation: 2^0 = 1

        // Example 2:
        //
        // Input: n = 16
        // Output: true
        // Explanation: 2^4 = 16

        // Example 3:
        //
        // Input: n = 3
        // Output: false

        Solution solution = new();

        Console.WriteLine(solution.IsPowerOfTwo(1));
        Console.WriteLine(solution.IsPowerOfTwo(16));
        Console.WriteLine(solution.IsPowerOfTwo(3));
        Console.WriteLine(solution.IsPowerOfTwo(8));
    }

    public bool IsPowerOfTwo(int n)
    {
        if (n == 1) return true;
        if (n < 1) return false;

        while (n > 1)
        {
            if (n % 2 != 0) return false;
            n /= 2;
        }

        return true;
    }
}