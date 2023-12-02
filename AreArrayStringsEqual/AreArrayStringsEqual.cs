namespace AreArrayStringsEqual;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: word1 = ["ab", "c"], word2 = ["a", "bc"]
        // Output: true
        // Explanation:
        // word1 represents string "ab" + "c" -> "abc"
        // word2 represents string "a" + "bc" -> "abc"
        // The strings are the same, so return true.
        //     Example 2:
        //
        // Input: word1 = ["a", "cb"], word2 = ["ab", "c"]
        // Output: false
        // Example 3:
        //
        // Input: word1  = ["abc", "d", "defg"], word2 = ["abcddefg"]
        // Output: true

        string[] w1a = { "ab", "c" };
        string[] w1b = { "a", "bc" };
        string[] w2a = { "a", "cb" };
        string[] w2b = { "ab", "c" };
        string[] w3a = { "abc", "d", "defg" };
        string[] w3b = { "abcddefg" };

        Solution solution = new();

        Console.WriteLine(solution.ArrayStringsAreEqual(w1a, w1b));
        Console.WriteLine(solution.ArrayStringsAreEqual(w2a, w2b));
        Console.WriteLine(solution.ArrayStringsAreEqual(w3a, w3b));
    }

    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        string w1Str = "";
        string w2Str = "";

        for (int i = 0; i < word1.Length; i++) w1Str += word1[i];
        for (int i = 0; i < word2.Length; i++) w2Str += word2[i];

        if (w1Str == w2Str) return true;
        return false;
    }
}