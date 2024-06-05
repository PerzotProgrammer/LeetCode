namespace CommonChars;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: words = ["bella","label","roller"]
        // Output: ["e","l","l"]

        // Example 2:
        //
        // Input: words = ["cool","lock","cook"]
        // Output: ["c","o"]


        Solution solution = new();

        PrintList(solution.CommonChars(["bella", "label", "roller"]));
        PrintList(solution.CommonChars(["cool", "lock", "cook"]));
    }

    public IList<string> CommonChars(string[] words)
    {
        List<string> result = new();
        if (words == null || words.Length == 0) return result;

        int[] minFreq = new int[26];
        Array.Fill(minFreq, int.MaxValue);

        foreach (string word in words)
        {
            int[] charCount = new int[26];
            foreach (char c in word) charCount[c - 'a']++;
            for (int i = 0; i < 26; i++) minFreq[i] = Math.Min(minFreq[i], charCount[i]);
        }

        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < minFreq[i]; j++) result.Add(((char)(i + 'a')).ToString());
        }

        return result;
    }

    static void PrintList(IList<string> arr)
    {
        foreach (string s in arr) Console.Write($"{s},");
        Console.WriteLine();
    }
}