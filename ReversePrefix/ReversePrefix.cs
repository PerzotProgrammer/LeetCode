namespace ReversePrefix;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: word = "abcdefd", ch = "d"
        // Output: "dcbaefd"
        // Explanation: The first occurrence of "d" is at index 3. 
        // Reverse the part of word from 0 to 3 (inclusive), the resulting string is "dcbaefd".

        // Example 2:
        //
        // Input: word = "xyxzxe", ch = "z"
        // Output: "zxyxxe"
        // Explanation: The first and only occurrence of "z" is at index 3.
        // Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".

        // Example 3:
        //
        // Input: word = "abcd", ch = "z"
        // Output: "abcd"
        // Explanation: "z" does not exist in word.
        // You should not do any reverse operation, the resulting string is "abcd".

        Solution solution = new();

        Console.WriteLine(solution.ReversePrefix("abcdefd", 'd'));
        Console.WriteLine(solution.ReversePrefix("xyxzxe", 'z'));
        Console.WriteLine(solution.ReversePrefix("abcd", 'z'));
    }

    public string ReversePrefix(string word, char ch)
    {
        int index = word.IndexOf(ch);
        if (index == -1) return word;

        char[] chars = word.ToCharArray();
        int start = 0;
        int end = index;

        while (start < end)
        {
            (chars[start], chars[end]) = (chars[end], chars[start]);
            start++;
            end--;
        }

        return new string(chars);
    }
}