namespace PivotInteger;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 8
        // Output: 6
        // Explanation: 6 is the pivot integer since: 1 + 2 + 3 + 4 + 5 + 6 = 6 + 7 + 8 = 21.
        
        // Example 2:
        //
        // Input: n = 1
        // Output: 1
        // Explanation: 1 is the pivot integer since: 1 = 1.
        
        // Example 3:
        //
        // Input: n = 4
        // Output: -1
        // Explanation: It can be proved that no such integer exist.

        Solution solution = new();

        Console.WriteLine(solution.PivotInteger(8));
        Console.WriteLine(solution.PivotInteger(1));
        Console.WriteLine(solution.PivotInteger(4));
    }

    public int PivotInteger(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            int left = 0;
            int right = 0;

            for (int j = 1; j <= i; j++) left += j;
            for (int j = i; j <= n; j++) right += j;

            if (left == right) return i;
        }

        return -1;
    }
}