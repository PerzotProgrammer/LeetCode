namespace MyPow;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: x = 2.00000, n = 10
        // Output: 1024.00000

        // Example 2:
        //
        // Input: x = 2.10000, n = 3
        // Output: 9.26100

        // Example 3:
        //
        // Input: x = 2.00000, n = -2
        // Output: 0.25000
        // Explanation: 2-2 = 1/22 = 1/4 = 0.25

        Solution solution = new();

        Console.WriteLine(solution.MyPow(2, 10));
        Console.WriteLine(solution.MyPow(2.1, 3));
        Console.WriteLine(solution.MyPow(2, -2));
    }

    public double MyPow(double x, int n)
    {
        if (n == 1) return x;
        if (n == -1) return 1 / x;
        if (n == 0) return 1;

        if (n % 2 == 0) return MyPow(x * x, n / 2);
        return x * MyPow(x, n - 1);
    }
}