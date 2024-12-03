using System.Text;

namespace AddSpaces;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "LeetcodeHelpsMeLearn", spaces = [8,13,15]
        // Output: "Leetcode Helps Me Learn"
        // Explanation: 
        // The indices 8, 13, and 15 correspond to the underlined characters in "LeetcodeHelpsMeLearn".
        // We then place spaces before those characters.

        // Example 2:
        //
        // Input: s = "icodeinpython", spaces = [1,5,7,9]
        // Output: "i code in py thon"
        // Explanation:
        // The indices 1, 5, 7, and 9 correspond to the underlined characters in "icodeinpython".
        // We then place spaces before those characters.

        // Example 3:
        //
        // Input: s = "spacing", spaces = [0,1,2,3,4,5,6]
        // Output: " s p a c i n g"
        // Explanation:
        // We are also able to place spaces before the first character of the string.


        Solution solution = new();

        Console.WriteLine(solution.AddSpaces("LeetcodeHelpsMeLearn", [8, 13, 15]));
        Console.WriteLine(solution.AddSpaces("icodeinpython", [1, 5, 7, 9]));
        Console.WriteLine(solution.AddSpaces("spacing", [0, 1, 2, 3, 4, 5, 6]));
    }

    public string AddSpaces(string s, int[] spaces)
    {
        StringBuilder result = new();
        int spaceIndex = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex])
            {
                result.Append(' ');
                spaceIndex++;
            }

            result.Append(s[i]);
        }

        return result.ToString();
    }
}