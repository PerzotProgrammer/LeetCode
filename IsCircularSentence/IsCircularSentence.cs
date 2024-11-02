namespace IsCircularSentence;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: sentence = "leetcode exercises sound delightful"
        // Output: true
        // Explanation: The words in sentence are ["leetcode", "exercises", "sound", "delightful"].
        // - leetcode's last character is equal to exercises's first character.
        // - exercises's last character is equal to sound's first character.
        // - sound's last character is equal to delightful's first character.
        // - delightful's last character is equal to leetcode's first character.
        // The sentence is circular.
        
        // Example 2:
        //
        // Input: sentence = "eetcode"
        // Output: true
        // Explanation: The words in sentence are ["eetcode"].
        // - eetcode's last character is equal to eetcode's first character.
        // The sentence is circular.


        Solution solution = new();

        Console.WriteLine(solution.IsCircularSentence("leetcode exercises sound delightful"));
        Console.WriteLine(solution.IsCircularSentence("eetcode"));
    }

    public bool IsCircularSentence(string sentence)
    {
        string[] words = sentence.Split(" ");
        char last = words[^1][words[^1].Length - 1];
        foreach (string word in words)
        {
            if (word[0] != last) return false;
            last = word[^1];
        }

        return true;
    }
}