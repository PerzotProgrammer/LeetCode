using System.Text;

namespace RepeatLimitedString;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "cczazcc", repeatLimit = 3
        // Output: "zzcccac"
        // Explanation: We use all of the characters from s to construct the repeatLimitedString "zzcccac".
        // The letter 'a' appears at most 1 time in a row.
        // The letter 'c' appears at most 3 times in a row.
        // The letter 'z' appears at most 2 times in a row.
        // Hence, no letter appears more than repeatLimit times in a row and the string is a valid repeatLimitedString.
        // The string is the lexicographically largest repeatLimitedString possible so we return "zzcccac".
        // Note that the string "zzcccca" is lexicographically larger but the letter 'c' appears more than 3 times in a row, so it is not a valid repeatLimitedString.

        // Example 2:
        //
        // Input: s = "aababab", repeatLimit = 2
        // Output: "bbabaa"
        // Explanation: We use only some of the characters from s to construct the repeatLimitedString "bbabaa". 
        // The letter 'a' appears at most 2 times in a row.
        // The letter 'b' appears at most 2 times in a row.
        // Hence, no letter appears more than repeatLimit times in a row and the string is a valid repeatLimitedString.
        // The string is the lexicographically largest repeatLimitedString possible so we return "bbabaa".
        // Note that the string "bbabaaa" is lexicographically larger but the letter 'a' appears more than 2 times in a row, so it is not a valid repeatLimitedString.


        Solution solution = new();

        Console.WriteLine(solution.RepeatLimitedString("cczazcc", 3));
        Console.WriteLine(solution.RepeatLimitedString("aababab", 2));
    }

    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] freq = new int[26];
        foreach (char c in s) freq[c - 'a']++;

        StringBuilder result = new();
        int currentCharIndex = 25;
        while (currentCharIndex >= 0)
        {
            if (freq[currentCharIndex] == 0)
            {
                currentCharIndex--;
                continue;
            }

            int use = Math.Min(freq[currentCharIndex], repeatLimit);
            for (int k = 0; k < use; k++) result.Append((char)('a' + currentCharIndex));

            freq[currentCharIndex] -= use;

            if (freq[currentCharIndex] > 0)
            {
                int smallerCharIndex = currentCharIndex - 1;
                while (smallerCharIndex >= 0 && freq[smallerCharIndex] == 0) smallerCharIndex--;

                if (smallerCharIndex < 0) break;

                result.Append((char)('a' + smallerCharIndex));
                freq[smallerCharIndex]--;
            }
        }

        return result.ToString();
    }
}