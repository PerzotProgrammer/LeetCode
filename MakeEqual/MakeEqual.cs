namespace MakeEqual;

public class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: words = ["abc","aabc","bc"]
        // Output: true
        // Explanation: Move the first 'a' in words[1] to the front of words[2],
        // to make words[1] = "abc" and words[2] = "abc".
        // All the strings are now equal to "abc", so return true.

        // Example 2:
        //
        // Input: words = ["ab","a"]
        // Output: false
        // Explanation: It is impossible to make all the strings equal using the operation.

        string[] w1 = { "abc", "aabc", "bc" };
        string[] w2 = { "ab", "a" };

        Solution solution = new();

        Console.WriteLine(solution.MakeEqual(w1));
        Console.WriteLine(solution.MakeEqual(w2));
    }

    public bool MakeEqual(string[] words)
    {
        Dictionary<char, int> charCount = new();
        foreach (string word in words)
        {
            foreach (char c in word)
            {
                charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
            }
        }

        foreach (int charCountValue in charCount.Values)
        {
            if (charCountValue % words.Length != 0)
            {
                return false;
            }
        }

        return true;
    }
}