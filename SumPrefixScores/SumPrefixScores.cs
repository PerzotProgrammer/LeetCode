namespace SumPrefixScores;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/sum-of-prefix-scores-of-strings/solutions/5830244/c-solution-for-sum-of-prefix-scores-of-strings-problem/?envType=daily-question&envId=2024-09-25
        // Example 1:
        //
        // Input: words = ["abc","ab","bc","b"]
        // Output: [5,4,3,2]
        // Explanation: The answer for each string is the following:
        // - "abc" has 3 prefixes: "a", "ab", and "abc".
        // - There are 2 strings with the prefix "a", 2 strings with the prefix "ab", and 1 string with the prefix "abc".
        // The total is answer[0] = 2 + 2 + 1 = 5.
        // - "ab" has 2 prefixes: "a" and "ab".
        // - There are 2 strings with the prefix "a", and 2 strings with the prefix "ab".
        // The total is answer[1] = 2 + 2 = 4.
        // - "bc" has 2 prefixes: "b" and "bc".
        // - There are 2 strings with the prefix "b", and 1 string with the prefix "bc".
        // The total is answer[2] = 2 + 1 = 3.
        // - "b" has 1 prefix: "b".
        // - There are 2 strings with the prefix "b".
        // The total is answer[3] = 2.

        // Example 2:
        //
        // Input: words = ["abcd"]
        // Output: [4]
        // Explanation:
        // "abcd" has 4 prefixes: "a", "ab", "abc", and "abcd".
        // Each prefix has a score of one, so the total is answer[0] = 1 + 1 + 1 + 1 = 4.


        Solution solution = new();

        PrintArray(solution.SumPrefixScores(["abc", "ab", "bc", "b"]));
        PrintArray(solution.SumPrefixScores(["abcd"]));
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public int Count;

        public TrieNode()
        {
            Children = new();
            Count = 0;
        }
    }

    private void Insert(TrieNode root, string word)
    {
        TrieNode currentNode = root;
        foreach (char c in word)
        {
            if (!currentNode.Children.ContainsKey(c))
            {
                currentNode.Children[c] = new();
            }

            currentNode = currentNode.Children[c];
            currentNode.Count++;
        }
    }

    private int GetScore(TrieNode root, string word)
    {
        TrieNode currentNode = root;
        int score = 0;
        foreach (char c in word)
        {
            currentNode = currentNode.Children[c];
            score += currentNode.Count;
        }

        return score;
    }

    public int[] SumPrefixScores(string[] words)
    {
        TrieNode root = new();

        foreach (string word in words) Insert(root, word);

        int[] result = new int[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            result[i] = GetScore(root, words[i]);
        }

        return result;
    }

    static void PrintArray(int[] array)
    {
        foreach (int i in array) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}