namespace CountConsistentStrings;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        // Output: 2
        // Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'.

        // Example 2:
        //
        // Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        // Output: 7
        // Explanation: All strings are consistent.

        // Example 3:
        //
        // Input: allowed = "cad", words = ["cc","acd","b","ba","bac","bad","ac","d"]
        // Output: 4
        // Explanation: Strings "cc", "acd", "ac", and "d" are consistent.


        Solution solution = new();

        Console.WriteLine(solution.CountConsistentStrings("ab", ["ad", "bd", "aaab", "baa", "badab"]));
        Console.WriteLine(solution.CountConsistentStrings("abc", ["a", "b", "c", "ab", "ac", "bc", "abc"]));
        Console.WriteLine(solution.CountConsistentStrings("cad", ["cc", "acd", "b", "ba", "bac", "bad", "ac", "d"]));
    }

    public int CountConsistentStrings(string allowed, string[] words)
    {
        int consistentCount = 0;

        foreach (string word in words)
        {
            bool isWordConsistent = true;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                bool isCharAllowed = false;

                for (int j = 0; j < allowed.Length; j++)
                {
                    if (allowed[j] == currentChar)
                    {
                        isCharAllowed = true;
                        break;
                    }
                }

                if (!isCharAllowed)
                {
                    isWordConsistent = false;
                    break;
                }
            }

            if (isWordConsistent) consistentCount++;
        }

        return consistentCount;
    }
}