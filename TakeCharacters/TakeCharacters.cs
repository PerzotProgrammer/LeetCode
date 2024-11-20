namespace TakeCharacters;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "aabaaaacaabc", k = 2
        // Output: 8
        // Explanation: 
        // Take three characters from the left of s. You now have two 'a' characters, and one 'b' character.
        // Take five characters from the right of s. You now have four 'a' characters, two 'b' characters, and two 'c' characters.
        // A total of 3 + 5 = 8 minutes is needed.
        // It can be proven that 8 is the minimum number of minutes needed.

        // Example 2:
        //
        // Input: s = "a", k = 1
        // Output: -1
        // Explanation: It is not possible to take one 'b' or 'c' so return -1.


        Solution solution = new();

        Console.WriteLine(solution.TakeCharacters("aabaaaacaabc", 2));
        Console.WriteLine(solution.TakeCharacters("a", 1));
    }

    public int TakeCharacters(string s, int k)
    {
        int[] count = new int[3];
        foreach (char c in s) count[c - 'a']++;

        if (count[0] < k || count[1] < k || count[2] < k) return -1;

        int requiredA = count[0] - k;
        int requiredB = count[1] - k;
        int requiredC = count[2] - k;

        int[] windowCount = new int[3];
        int left = 0, maxMiddleLength = 0;
        for (int right = 0; right < s.Length; right++)
        {
            windowCount[s[right] - 'a']++;

            while (windowCount[0] > requiredA || windowCount[1] > requiredB || windowCount[2] > requiredC)
            {
                windowCount[s[left] - 'a']--;
                left++;
            }

            maxMiddleLength = Math.Max(maxMiddleLength, right - left + 1);
        }

        return s.Length - maxMiddleLength;
    }
}