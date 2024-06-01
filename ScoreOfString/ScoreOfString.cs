namespace ScoreOfString;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "hello"
        // Output: 13
        // Explanation: The ASCII values of the characters in s are: 'h' = 104, 'e' = 101, 'l' = 108, 'o' = 111. So, the score of s would be |104 - 101| + |101 - 108| + |108 - 108| + |108 - 111| = 3 + 7 + 0 + 3 = 13.
        //
        // Example 2:
        // Input: s = "zaz"
        // Output: 50
        // Explanation: The ASCII values of the characters in s are: 'z' = 122, 'a' = 97. So, the score of s would be |122 - 97| + |97 - 122| = 25 + 25 = 50.

        Solution solution = new();

        Console.WriteLine(solution.ScoreOfString("hello"));
        Console.WriteLine(solution.ScoreOfString("zaz"));
    }

    public int ScoreOfString(string s)
    {
        int sum = 0;
        int prev = s[0];
        for (int i = 1; i < s.Length; i++)
        {
            sum += Math.Abs(prev - s[i]);
            prev = s[i];
        }

        return sum;
    }
}