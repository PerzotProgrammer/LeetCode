namespace RotateString;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "abcde", goal = "cdeab"
        // Output: true

        // Example 2:
        //
        // Input: s = "abcde", goal = "abced"
        // Output: false

        Solution solution = new();

        Console.WriteLine(solution.RotateString("abcde", "cdeab"));
        Console.WriteLine(solution.RotateString("abcde", "abced"));
    }

    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length) return false;
        return (s + s).Contains(goal);
    }
}