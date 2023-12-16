namespace IsAnagram;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: s = "anagram", t = "nagaram"
        // Output: true

        // Example 2:

        // Input: s = "rat", t = "car"
        // Output: false

        string s1 = "anagram";
        string t1 = "nagaram";

        string s2 = "rat";
        string t2 = "car";

        string s3 = "abcd";
        string t3 = "aabcd";

        Solution solution = new();

        Console.WriteLine(solution.IsAnagram(s1, t1));
        Console.WriteLine(solution.IsAnagram(s2, t2));
        Console.WriteLine(solution.IsAnagram(s3, t3));
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        
        char[] sChars = s.ToCharArray();
        char[] tChars = t.ToCharArray();

        Array.Sort(sChars);
        Array.Sort(tChars);

        string sCheck = new string(sChars);
        string tCheck = new string(tChars);

        if (sCheck == tCheck) return true;
        return false;
    }
}