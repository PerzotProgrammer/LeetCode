namespace JudgeSquareSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: c = 5
        // Output: true
        // Explanation: 1 * 1 + 2 * 2 = 5
        
        // Example 2:
        //
        // Input: c = 3
        // Output: false

        
        Solution solution = new();

        Console.WriteLine(solution.JudgeSquareSum(5));
        Console.WriteLine(solution.JudgeSquareSum(3));
    }

    public bool JudgeSquareSum(int c)
    {
        for (long a = 0; a * a <= c; a++)
        {
            double b = Math.Sqrt(c - a * a);
            if (Math.Abs(b - (int)b) < 0.00001) return true;
        }

        return false;
    }
}