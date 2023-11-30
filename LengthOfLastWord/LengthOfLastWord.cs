namespace LengthOfLastWord;


class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "Hello World"
        // Output: 5
        // Explanation: The last word is "World" with length 5.
        //     Example 2:
        //
        // Input: s = "   fly me   to   the moon  "
        // Output: 4
        // Explanation: The last word is "moon" with length 4.
        //     Example 3:
        //
        // Input: s = "luffy is still joyboy"
        // Output: 6
        // Explanation: The last word is "joyboy" with length 6.

        string s1 = "Hello World";
        string s2 = "   fly me   to   the moon  ";
        string s3 = "luffy is still joyboy";
        string s4 = "a";
        string s5 = "a ";

        Solution solution = new();

        Console.WriteLine(solution.LengthOfLastWord(s1));
        Console.WriteLine(solution.LengthOfLastWord(s2));
        Console.WriteLine(solution.LengthOfLastWord(s3));
        Console.WriteLine(solution.LengthOfLastWord(s4));
        Console.WriteLine(solution.LengthOfLastWord(s5));

    }

    public int LengthOfLastWord(string s)
    {
        int index = s.Length - 1;
        int length = 0;
        
        bool flag = false;
        while (index >= 0)
        {
            if (s[index] != ' ')
            {
                flag = true;
                length++;
                index--;
            }
            else if (s[index] == ' ' && !flag) index--;
            else break;
        }

        return length;
    }
}