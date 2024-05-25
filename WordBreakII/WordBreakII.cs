namespace WordBreakII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "catsanddog", wordDict = ["cat","cats","and","sand","dog"]
        // Output: ["cats and dog","cat sand dog"]

        // Example 2:
        //
        // Input: s = "pineapplepenapple", wordDict = ["apple","pen","applepen","pine","pineapple"]
        // Output: ["pine apple pen apple","pineapple pen apple","pine applepen apple"]
        // Explanation: Note that you are allowed to reuse a dictionary word.

        // Example 3:
        //
        // Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
        // Output: []


        Solution solution = new();

        PrintList(solution.WordBreak("catsanddog", ["cat", "cats", "and", "sand", "dog"]));
        PrintList(solution.WordBreak("pineapplepenapple", ["apple", "pen", "applepen", "pine", "pineapple"]));
        PrintList(solution.WordBreak("catsandog", ["cats","dog","sand","and","cat"]));
    }

    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        Dictionary<int, List<string>> dict = new();

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                string subStr = s.Substring(j, i - j + 1);
                if (wordDict.Contains(subStr))
                {
                    if (!dict.ContainsKey(i)) dict.Add(i, new());

                    if (j == 0) dict[i].Add(subStr);
                    else if (dict.ContainsKey(j - 1))
                    {
                        foreach (string word in dict[j - 1]) dict[i].Add(word + " " + subStr);
                    }
                }
            }
        }

        if (dict.ContainsKey(s.Length - 1)) return dict[s.Length - 1];
        return new List<string>();
    }

    static void PrintList(IList<string> list)
    {
        foreach (string s in list) Console.Write($"{s},");
        Console.WriteLine();
    }
}