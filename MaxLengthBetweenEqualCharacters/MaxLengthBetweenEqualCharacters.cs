namespace MaxLengthBetweenEqualCharacters;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "aa"
        // Output: 0
        // Explanation: The optimal substring here is an empty substring between the two 'a's.

        // Example 2:
        //
        // Input: s = "abca"
        // Output: 2
        // Explanation: The optimal substring here is "bc".

        // Example 3:
        //
        // Input: s = "cbzxy"
        // Output: -1
        // Explanation: There are no characters that appear twice in s.

        string s1 = "aa";
        string s2 = "abca";
        string s3 = "cbzxy";

        Solution solution = new();

        Console.WriteLine(solution.MaxLengthBetweenEqualCharacters(s1));
        Console.WriteLine(solution.MaxLengthBetweenEqualCharacters(s2));
        Console.WriteLine(solution.MaxLengthBetweenEqualCharacters(s3));
    }

    public int MaxLengthBetweenEqualCharacters(string s)
    {
        int output = -1;

        for (int left = 0; left < s.Length; left++)
        {
            for (int right = left + 1; right < s.Length; right++)
            {
                if (s[left] == s[right])
                {
                    output = Math.Max(output, right - left - 1);
                }
            }
        }

        return output;
    }
}