using System.Text;

namespace CompressedString;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: word = "abcde"
        // Output: "1a1b1c1d1e"
        // Explanation:
        // Initially, comp = "". Apply the operation 5 times, choosing "a", "b", "c", "d", and "e" as the prefix in each operation.
        // For each prefix, append "1" followed by the character to comp.

        // Example 2:
        //
        // Input: word = "aaaaaaaaaaaaaabb"
        // Output: "9a5a2b"
        // Explanation:
        // Initially, comp = "". Apply the operation 3 times, choosing "aaaaaaaaa", "aaaaa", and "bb" as the prefix in each operation.
        // For prefix "aaaaaaaaa", append "9" followed by "a" to comp.
        // For prefix "aaaaa", append "5" followed by "a" to comp.
        // For prefix "bb", append "2" followed by "b" to comp.


        Solution solution = new();

        Console.WriteLine(solution.CompressedString("abcde"));
        Console.WriteLine(solution.CompressedString("aaaaaaaaaaaaaabb"));
    }

    public string CompressedString(string word)
    {
        StringBuilder comp = new();
        int pos = 0;

        while (pos < word.Length)
        {
            int consecutiveCount = 0;
            char currentChar = word[pos];

            while (
                pos < word.Length &&
                consecutiveCount < 9 &&
                word[pos] == currentChar
            )
            {
                consecutiveCount++;
                pos++;
            }

            comp.Append(consecutiveCount.ToString() + currentChar);
        }

        return comp.ToString();
    }
}