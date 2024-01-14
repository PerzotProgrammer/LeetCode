namespace CloseStrings;

class Solution
{
    static void Main()
    {
        //     Example 1:
        //
        //     Input: word1 = "abc", word2 = "bca"
        //     Output: true
        //     Explanation: You can attain word2 from word1 in 2 operations.
        //         Apply Operation 1: "abc" -> "acb"
        //     Apply Operation 1: "acb" -> "bca"


        //     Example 2:
        //
        //     Input: word1 = "a", word2 = "aa"
        //     Output: false
        //     Explanation: It is impossible to attain word2 from word1, or vice versa, in any number of operations.


        //     Example 3:
        //
        //     Input: word1 = "cabbba", word2 = "abbccc"
        //     Output: true
        //     Explanation: You can attain word2 from word1 in 3 operations.
        //         Apply Operation 1: "cabbba" -> "caabbb"
        //     Apply Operation 2: "caabbb" -> "baaccc"
        //     Apply Operation 2: "baaccc" -> "abbccc"

        Solution solution = new();

        Console.WriteLine(solution.CloseStrings("abc", "bca"));
        Console.WriteLine(solution.CloseStrings("a", "aa"));
        Console.WriteLine(solution.CloseStrings("cabbba", "abbccc"));
    }

    public bool CloseStrings(string word1, string word2)
    {
        int length = word1.Length;
        if (length != word2.Length) return false;

        int[] chars1 = new int[26];
        int[] chars2 = new int[26];
        int[] values1 = new int[length + 1];
        int[] values2 = new int[length + 1];

        foreach (char c in word1)
        {
            chars1[c - 'a']++;
            values1[chars1[c - 'a']]++;
        }

        foreach (char c in word2)
        {
            chars2[c - 'a']++;
            values2[chars2[c - 'a']]++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (chars1[i] > 0 && chars2[i] == 0) return false;
        }

        for (int i = 0; i < length; i++)
        {
            if (values1[i] != values2[i]) return false;
        }

        return true;
    }
}