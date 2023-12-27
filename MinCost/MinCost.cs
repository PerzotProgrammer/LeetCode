namespace MinCost;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: colors = "abaac", neededTime = [1,2,3,4,5]
        // Output: 3
        // Explanation: In the above image, 'a' is blue, 'b' is red, and 'c' is green.
        // Bob can remove the blue balloon at index 2. This takes 3 seconds.
        // There are no longer two consecutive balloons of the same color. Total time = 3.


        // Example 2:
        //
        //
        // Input: colors = "abc", neededTime = [1,2,3]
        // Output: 0
        // Explanation: The rope is already colorful. Bob does not need to remove any balloons from the rope.


        // Example 3:
        //
        //
        // Input: colors = "aabaa", neededTime = [1,2,3,4,1]
        // Output: 2
        // Explanation: Bob will remove the ballons at indices 0 and 4. Each ballon takes 1 second to remove.
        // There are no longer two consecutive balloons of the same color. Total time = 1 + 1 = 2.

        string c1 = "abaac";
        int[] t1 = { 1, 2, 3, 4, 5 };

        string c2 = "abc";
        int[] t2 = { 1, 2, 3 };

        string c3 = "aabaa";
        int[] t3 = { 1, 2, 3, 4, 1 };

        Solution solution = new();

        Console.WriteLine(solution.MinCost(c1, t1));
        Console.WriteLine(solution.MinCost(c2, t2));
        Console.WriteLine(solution.MinCost(c3, t3));
    }

    public int MinCost(string colors, int[] neededTime)
    {
        int sum = 0;

        for (int i = 1; i < colors.Length; i++)
        {
            if (colors[i - 1] == colors[i])
            {
                sum += Math.Min(neededTime[i], neededTime[i - 1]);
                neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
            }
        }

        return sum;
    }
}