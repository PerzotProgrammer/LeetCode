namespace MinEnd;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = 3, x = 4
        // Output: 6
        // Explanation:
        // nums can be [4,5,6] and its last element is 6.

        //Example 2:
        //
        // Input: n = 2, x = 7
        // Output: 15
        // Explanation:
        // nums can be [7,15] and its last element is 15.


        Solution solution = new();

        Console.WriteLine(solution.MinEnd(3, 4));
        Console.WriteLine(solution.MinEnd(2, 7));
    }

    public long MinEnd(int n, int x)
    {
        long result = x;
        while (--n > 0) result = (result + 1) | (uint)x;
        return result;
    }
}