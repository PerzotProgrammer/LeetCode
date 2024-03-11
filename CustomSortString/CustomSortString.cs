namespace CustomSortString;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input:  order = "cba", s = "abcd" 
        // Output:  "cbad" 
        // Explanation: "a", "b", "c" appear in order, so the order of "a", "b", "c" should be "c", "b", and "a".
        // Since "d" does not appear in order, it can be at any position in the returned string. "dcba", "cdba", "cbda" are also valid outputs.
        //
        // Example 2:
        //
        // Input:  order = "bcafg", s = "abcd" 
        // Output:  "bcad" 
        // Explanation: The characters "b", "c", and "a" from order dictate the order for the characters in s. The character "d" in s does not appear in order, so its position is flexible.
        // Following the order of appearance in order, "b", "c", and "a" from s should be arranged as "b", "c", "a". "d" can be placed at any position since it's not in order. The output "bcad" correctly follows this rule. Other arrangements like "bacd" or "bcda" would also be valid, as long as "b", "c", "a" maintain their order.

        Solution solution = new();

        Console.WriteLine(solution.CustomSortString("cba", "abcd"));
        Console.WriteLine(solution.CustomSortString("bcafg", "abcd"));
        Console.WriteLine(solution.CustomSortString("kqep", "pekeq"));
    }

    public string CustomSortString(string order, string s)
    {
        string output = "";
        Dictionary<char, int> freq = new();
        foreach (char c in s)
        {
            if (!freq.TryAdd(c, 1)) freq[c]++;
        }

        foreach (char c in order)
        {
            try
            {
                while (freq[c] > 0)
                {
                    output += c;
                    freq[c]--;
                }
            }
            catch (KeyNotFoundException)
            {
                continue;
            }
        }

        foreach (KeyValuePair<char, int> pair in freq)
        {
            for (int i = pair.Value; i > 0; i--) output += pair.Key;
        }

        return output;
    }
}