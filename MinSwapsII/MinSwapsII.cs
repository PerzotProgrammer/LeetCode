namespace MinSwapsII;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "][]["
        // Output: 1
        // Explanation: You can make the string balanced by swapping index 0 with index 3.
        // The resulting string is "[[]]".

        // Example 2:
        //
        // Input: s = "]]][[["
        // Output: 2
        // Explanation: You can do the following to make the string balanced:
        // - Swap index 0 with index 4. s = "[]][][".
        // - Swap index 1 with index 5. s = "[[][]]".
        // The resulting string is "[[][]]".

        // Example 3:
        //
        // Input: s = "[]"
        // Output: 0
        // Explanation: The string is already balanced.


        Solution solution = new();

        Console.WriteLine(solution.MinSwaps("][]["));
        Console.WriteLine(solution.MinSwaps("]]][[["));
        Console.WriteLine(solution.MinSwaps("[]"));
    }

    public int MinSwaps(string s)
    {
        int balance = 0;
        int swaps = 0;

        foreach (char c in s)
        {
            if (c == '[') balance++;
            else balance--;

            if (balance < 0)
            {
                swaps++;
                balance = 0;
            }
        }

        return (swaps + 1) / 2;
    }
}