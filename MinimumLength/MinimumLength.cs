namespace MinimumLength;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "ca"
        // Output: 2
        // Explanation: You can't remove any characters, so the string stays as is.

        // Example 2:
        //
        // Input: s = "cabaabac"
        // Output: 0
        // Explanation: An optimal sequence of operations is:
        // - Take prefix = "c" and suffix = "c" and remove them, s = "abaaba".
        // - Take prefix = "a" and suffix = "a" and remove them, s = "baab".
        // - Take prefix = "b" and suffix = "b" and remove them, s = "aa".
        // - Take prefix = "a" and suffix = "a" and remove them, s = "".

        // Example 3:
        //
        // Input: s = "aabccabba"
        // Output: 3
        // Explanation: An optimal sequence of operations is:
        // - Take prefix = "aa" and suffix = "a" and remove them, s = "bccabb".
        // - Take prefix = "b" and suffix = "bb" and remove them, s = "cca".

        Solution solution = new();

        Console.WriteLine(solution.MinimumLength("ca"));
        Console.WriteLine(solution.MinimumLength("cabaabac"));
        Console.WriteLine(solution.MinimumLength("aabccabba"));
    }

    public int MinimumLength(string s)
    {
        char left = s[0];
        char right = s[^1];
        while (left == right && s.Length > 1)
        {
            s = s.Trim(left);
            if (s.Length > 1)
            {
                left = s[0];
                right = s[^1];
            }
        }

        return s.Length;
    }
}