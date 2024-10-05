namespace CheckInclusion;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s1 = "ab", s2 = "eidbaooo"
        // Output: true
        // Explanation: s2 contains one permutation of s1 ("ba").
        
        // Example 2:
        //
        // Input: s1 = "ab", s2 = "eidboaoo"
        // Output: false

        Solution solution = new();

        Console.WriteLine(solution.CheckInclusion("ab", "eidbaooo"));
        Console.WriteLine(solution.CheckInclusion("ab", "eidboaoo"));
    }

    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        int[] s1Count = new int[26];
        int[] s2Count = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        int matches = 0;
        for (int i = 0; i < 26; i++)
        {
            if (s1Count[i] == s2Count[i]) matches++;
        }

        for (int i = 0; i < s2.Length - s1.Length; i++)
        {
            if (matches == 26) return true;

            int right = s2[i + s1.Length] - 'a';
            int left = s2[i] - 'a';

            s2Count[right]++;
            if (s2Count[right] == s1Count[right]) matches++;
            else if (s2Count[right] == s1Count[right] + 1) matches--;
            s2Count[left]--;
            if (s2Count[left] == s1Count[left]) matches++;
            else if (s2Count[left] == s1Count[left] - 1) matches--;
        }

        return matches == 26;
    }
}