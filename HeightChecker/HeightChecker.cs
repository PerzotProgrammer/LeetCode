namespace HeightChecker;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: heights = [1,1,4,2,1,3]
        // Output: 3
        // Explanation: 
        // heights:  [1,1,4,2,1,3]
        // expected: [1,1,1,2,3,4]
        // Indices 2, 4, and 5 do not match.

        // Example 2:
        //
        // Input: heights = [5,1,2,3,4]
        // Output: 5
        // Explanation:
        // heights:  [5,1,2,3,4]
        // expected: [1,2,3,4,5]
        // All indices do not match.

        // Example 3:
        //
        // Input: heights = [1,2,3,4,5]
        // Output: 0
        // Explanation:
        // heights:  [1,2,3,4,5]
        // expected: [1,2,3,4,5]
        // All indices match.


        Solution solution = new();

        Console.WriteLine(solution.HeightChecker([1, 1, 4, 2, 1, 3]));
        Console.WriteLine(solution.HeightChecker([5, 1, 2, 3, 4]));
        Console.WriteLine(solution.HeightChecker([1, 2, 3, 4, 5]));
    }

    public int HeightChecker(int[] heights)
    {
        int[] count = new int[101];

        foreach (int height in heights) count[height]++;

        int index = 0;
        int result = 0;

        for (int i = 1; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                if (heights[index] != i) result++;
                index++;
                count[i]--;
            }
        }

        return result;
    }
}