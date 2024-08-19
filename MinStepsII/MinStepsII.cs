namespace MinStepsII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 3
        // Output: 3
        // Explanation: Initially, we have one character 'A'.
        // In step 1, we use Copy All operation.
        // In step 2, we use Paste operation to get 'AA'.
        // In step 3, we use Paste operation to get 'AAA'.

        // Example 2:
        //
        // Input: n = 1
        // Output: 0

        Solution solution = new();

        Console.WriteLine(solution.MinSteps(3));
        Console.WriteLine(solution.MinSteps(1));
    }

    public int MinSteps(int n)
    {
        int ans = 0;
        int d = 2;
        while (n > 1)
        {
            while (n % d == 0)
            {
                ans += d;
                n /= d;
            }

            d++;
        }

        return ans;
    }
}