namespace GroupAnagrams;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: strs = ["eat","tea","tan","ate","nat","bat"]
        // Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

        // Example 2:
        //
        // Input: strs = [""]
        // Output: [[""]]

        // Example 3:
        //
        // Input: strs = ["a"]
        // Output: [["a"]]

        Solution solution = new();

        IList<IList<string>> a1 = solution.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
        IList<IList<string>> a2 = solution.GroupAnagrams([""]);
        IList<IList<string>> a3 = solution.GroupAnagrams(["a"]);

        PrintMatrix(a1);
        PrintMatrix(a2);
        PrintMatrix(a3);
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();
        foreach (string str in strs)
        {
            string sortedStr = string.Concat(str.OrderBy(c => c));
            if (!groups.ContainsKey(sortedStr)) groups[sortedStr] = new List<string>();
            groups[sortedStr].Add(str);
        }

        return groups.Values.ToList();
    }

    static void PrintMatrix(IList<IList<string>> matrix)
    {
        foreach (IList<string> list in matrix)
        {
            foreach (string str in list) Console.Write($"{str}, ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}