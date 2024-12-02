namespace IsPrefixOfWord;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: sentence = "i love eating burger", searchWord = "burg"
        // Output: 4
        // Explanation: "burg" is prefix of "burger" which is the 4th word in the sentence.

        // Example 2:
        //
        // Input: sentence = "this problem is an easy problem", searchWord = "pro"
        // Output: 2
        // Explanation: "pro" is prefix of "problem" which is the 2nd and the 6th word in the sentence, but we return 2 as it's the minimal index.

        // Example 3:
        //
        // Input: sentence = "i am tired", searchWord = "you"
        // Output: -1
        // Explanation: "you" is not a prefix of any word in the sentence.


        Solution solution = new();

        Console.WriteLine(solution.IsPrefixOfWord("i love eating burger", "burg"));
        Console.WriteLine(solution.IsPrefixOfWord("this problem is an easy problem", "pro"));
        Console.WriteLine(solution.IsPrefixOfWord("i am tired", "you"));
    }

    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord)) return i + 1;
        }

        return -1;
    }
}