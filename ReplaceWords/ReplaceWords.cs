namespace ReplaceWords;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by the battery"
        // Output: "the cat was rat by the bat"

        // Example 2:
        //
        // Input: dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
        // Output: "a a b c"


        Solution solution = new();

        Console.WriteLine(solution.ReplaceWords(["cat", "bat", "rat"], "the cattle was rattled by the battery"));
        Console.WriteLine(solution.ReplaceWords(["a", "b", "c"], "aadsfasf absbs bbab cadsfafs"));
    }

    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            foreach (string word in dictionary)
            {
                if (words[i].StartsWith(word)) words[i] = word;
            }
        }

        string output = "";

        for (int i = 0; i < words.Length - 1; i++) output += words[i] + " ";

        output += words[^1];
        return output;
    }
}