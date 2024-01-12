namespace HalvesAreAlike;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "book"
        // Output: true
        // Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        
        // Example 2:
        //
        // Input: s = "textbook"
        // Output: false
        // Explanation: a = "text" and b = "book". a has 1 vowel whereas b has 2. Therefore, they are not alike.
        //     Notice that the vowel o is counted twice.

        string s1 = "book";
        string s2 = "textbook";

        Solution solution = new();

        Console.WriteLine(solution.HalvesAreAlike(s1));
        Console.WriteLine(solution.HalvesAreAlike(s2));
    }
    
    public bool HalvesAreAlike(string s)
    {
        string vowels = "aeiou";

        int aVow = 0;
        int bVow = 0;
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (vowels.Contains(char.ToLower(s[i]))) aVow++;
        }

        for (int i = s.Length / 2; i < s.Length; i++)
        {
            if (vowels.Contains(char.ToLower(s[i]))) bVow++;
        }

        return aVow == bVow;
    }
}