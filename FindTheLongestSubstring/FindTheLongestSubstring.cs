namespace FindTheLongestSubstring;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "eleetminicoworoep"
        // Output: 13
        // Explanation: The longest substring is "leetminicowor" which contains two each of the vowels: e, i and o and zero of the vowels: a and u.

        // Example 2:
        //
        // Input: s = "leetcodeisgreat"
        // Output: 5
        // Explanation: The longest substring is "leetc" which contains two e's.

        // Example 3:
        //
        // Input: s = "bcbcbc"
        // Output: 6
        // Explanation: In this case, the given string "bcbcbc" is the longest because all vowels: a, e, i, o and u appear zero times.


        Solution solution = new();

        Console.WriteLine(solution.FindTheLongestSubstring("eleetminicoworoep"));
        Console.WriteLine(solution.FindTheLongestSubstring("leetcodeisgreat"));
        Console.WriteLine(solution.FindTheLongestSubstring("bcbcbc"));
    }

    public int FindTheLongestSubstring(string s)
    {
        Dictionary<int, int> map = new();
        map[0] = -1;

        int maxLength = 0;
        int currentMask = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (ch == 'a') currentMask ^= (1 << 0);
            else if (ch == 'e') currentMask ^= (1 << 1);
            else if (ch == 'i') currentMask ^= (1 << 2);
            else if (ch == 'o') currentMask ^= (1 << 3);
            else if (ch == 'u') currentMask ^= (1 << 4);

            if (map.TryGetValue(currentMask, out int mask)) maxLength = Math.Max(maxLength, i - mask);
            else map[currentMask] = i;
        }

        return maxLength;
    }
}