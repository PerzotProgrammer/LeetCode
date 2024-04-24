namespace Tribonacci;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 4
        // Output: 4
        // Explanation:
        // T_3 = 0 + 1 + 1 = 2
        // T_4 = 1 + 1 + 2 = 4

        // Example 2:
        //
        // Input: n = 25
        // Output: 1389537

        Solution solution = new();

        Console.WriteLine(solution.Tribonacci(4));
        Console.WriteLine(solution.Tribonacci(25));
    }

    public int Tribonacci(int n)
    {
        if (n == 0) return 0;
        if (n < 3) return 1;

        int n1;
        int n2 = 1;
        int n3 = 1;
        int n4 = n2 + n3;

        for (int i = 4; i <= n; i++)
        {
            n1 = n2;
            n2 = n3;
            n3 = n4;
            n4 = n1 + n2 + n3;
        }

        return n4;
    }
}