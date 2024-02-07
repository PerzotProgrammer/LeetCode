namespace FrequencySort;

class Solution
{
    static void Main()
    {
        
        // Example 1:
        //
        // Input: s = "tree"
        // Output: "eert"
        // Explanation: 'e' appears twice while 'r' and 't' both appear once.
        // So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
        
        // Example 2:
        //
        // Input: s = "cccaaa"
        // Output: "aaaccc"
        // Explanation: Both 'c' and 'a' appear three times, so both "cccaaa" and "aaaccc" are valid answers.
        // Note that "cacaca" is incorrect, as the same characters must be together.
        
        // Example 3:
        //
        // Input: s = "Aabb"
        // Output: "bbAa"
        // Explanation: "bbaA" is also a valid answer, but "Aabb" is incorrect.
        // Note that 'A' and 'a' are treated as two different characters.

        Solution solution = new();

        Console.WriteLine(solution.FrequencySort("tree"));
        Console.WriteLine(solution.FrequencySort("cccaaa"));
        Console.WriteLine(solution.FrequencySort("Aabb"));
    }

    public string FrequencySort(string s)
    {
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
        foreach (char c in s)
        {
            frequencyMap[c] = frequencyMap.GetValueOrDefault(c, 0) + 1;
        }

        List<char> sortedCharacters = new List<char>(frequencyMap.Keys);
        sortedCharacters.Sort((a, b) => frequencyMap[b].CompareTo(frequencyMap[a]));

        string result = "";
        foreach (char currentChar in sortedCharacters)
        {
            int frequency = frequencyMap[currentChar];
            for (int i = 0; i < frequency; i++) result += currentChar;
        }

        return result;
    }
}