namespace UncommonFromSentences;

public class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s1 = "this apple is sweet", s2 = "this apple is sour"
        // Output: ["sweet","sour"]
        // Explanation:
        // The word "sweet" appears only in s1, while the word "sour" appears only in s2.
        //
        // Example 2:
        //
        // Input: s1 = "apple apple", s2 = "banana"
        // Output: ["banana"]

        Solution solution = new();

        PrintArray(solution.UncommonFromSentences("this apple is sweet", "this apple is sour"));
        PrintArray(solution.UncommonFromSentences("apple apple", "banana"));
    }

    public string[] UncommonFromSentences(string s1, string s2)
    {
        Dictionary<string, int> freq = new();

        List<string> words = new();
        foreach (string s in s1.Trim().Split(" ")) words.Add(s);
        foreach (string s in s2.Trim().Split(" ")) words.Add(s);

        foreach (string s in words)
            if (!freq.TryAdd(s, 1))
                freq[s]++;


        List<string> result = new();
        foreach (KeyValuePair<string, int> pair in freq)
        {
            if (pair.Value == 1) result.Add(pair.Key);
        }

        return result.ToArray();
    }

    static void PrintArray(string[] arr)
    {
        foreach (string s in arr) Console.Write($"{s}, ");
        Console.WriteLine();
    }
}