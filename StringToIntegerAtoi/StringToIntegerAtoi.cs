namespace StringToIntegerAtoi;

class Solution
{
    static void Main()
    {
        // Tu było dużo walk...
        // W końcu się udało.
        
        // Example 1:
        //
        // Input: s = "42"
        // Output: 42
        // Explanation: The underlined characters are what is read in, the caret is the current reader position.
        //     Step 1: "42" (no characters read because there is no leading whitespace)
        //     ^
        //     Step 2: "42" (no characters read because there is neither a '-' nor '+')
        //     ^
        //     Step 3: "42" ("42" is read in)
        //     ^
        //     The parsed integer is 42.
        //     Since 42 is in the range [-231, 231 - 1], the final result is 42.
        //     Example 2:
        //
        // Input: s = "   -42"
        // Output: -42
        // Explanation:
        // Step 1: "   -42" (leading whitespace is read and ignored)
        //     ^
        //     Step 2: "   -42" ('-' is read, so the result should be negative)
        //     ^
        //     Step 3: "   -42" ("42" is read in)
        //     ^
        //     The parsed integer is -42.
        //     Since -42 is in the range [-231, 231 - 1], the final result is -42.
        //     Example 3:
        //
        // Input: s = "4193 with words"
        // Output: 4193
        // Explanation:
        // Step 1: "4193 with words" (no characters read because there is no leading whitespace)
        //     ^
        //     Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
        //     ^
        //     Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
        // ^
        //     The parsed integer is 4193.
        //     Since 4193 is in the range [-231, 231 - 1], the final result is 4193.

        string s1 = "42";
        string s2 = "   -42";
        string s3 = "4193 with words";
        string s4 = "words and 987";
        string s5 = "3.14159";
        string s6 = "+-12";
        string s7 = "   +0 123";
        string s8 = "20000000000000000000";
        string s9 = "-91283472332";
        string s10 = "00000-42a1234";
        string s11 = ".1";

        Solution solution = new();

        Console.WriteLine(solution.MyAtoi(s1));
        Console.WriteLine(solution.MyAtoi(s2));
        Console.WriteLine(solution.MyAtoi(s3));
        Console.WriteLine(solution.MyAtoi(s4));
        Console.WriteLine(solution.MyAtoi(s5));
        Console.WriteLine(solution.MyAtoi(s6));
        Console.WriteLine(solution.MyAtoi(s7));
        Console.WriteLine(solution.MyAtoi(s8));
        Console.WriteLine(solution.MyAtoi(s9));
        Console.WriteLine(solution.MyAtoi(s10));
        Console.WriteLine(solution.MyAtoi(s11));
    }

    public int MyAtoi(string s)
    {
        if (s == "") return 0;
        bool spaceFlag = false;
        foreach (char c in s)
        {
            if (c == ' ')
            {
                spaceFlag = true;
            }
            else
            {
                spaceFlag = false;
                break;
            }
        }

        if (spaceFlag) return 0;
        
        string stack = "";

        int i = 0;

        while (i < s.Length && s[i] == ' ') i++;

        bool isNegative = false;

        if (s[i] == '-')
        {
            isNegative = true;
            stack += '-';
            i++;
        }
        else if (s[i] == '+') i++;

        while (i < s.Length && char.IsDigit(s[i]))
        {
            stack += s[i];
            i++;
        }

        try
        {
            return int.Parse(stack);
        }
        catch (OverflowException)
        {
            if (isNegative) return Int32.MinValue;
            return Int32.MaxValue;
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}