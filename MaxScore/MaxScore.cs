namespace MaxScore;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "011101"
        // Output: 5 
        // Explanation: 
        // All possible ways of splitting s into two non-empty substrings are:
        // left = "0" and right = "11101", score = 1 + 4 = 5 
        // left = "01" and right = "1101", score = 1 + 3 = 4 
        // left = "011" and right = "101", score = 1 + 2 = 3 
        // left = "0111" and right = "01", score = 1 + 1 = 2 
        // left = "01110" and right = "1", score = 2 + 1 = 3
        // Example 2:
        //
        // Input: s = "00111"
        // Output: 5
        // Explanation: When left = "00" and right = "111", we get the maximum score = 2 + 3 = 5
        // Example 3:
        //
        // Input: s = "1111"
        // Output: 3

        string s1 = "011101";
        string s2 = "00111";
        string s3 = "1111";

        Solution solution = new();

        Console.WriteLine(solution.MaxScore(s1));
        Console.WriteLine(solution.MaxScore(s2));
        Console.WriteLine(solution.MaxScore(s3));
    }

    public int MaxScore(string s)
    {
        int best = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            string sLeft = "";
            string sRight = "";

            for (int j = 0; j < i + 1; j++) sLeft += s[j];
            for (int j = i + 1; j < s.Length; j++) sRight += s[j];
            
            // Console.WriteLine($"Left: {sLeft}");
            // Console.WriteLine($"Right: {sRight}");
            // Console.WriteLine();

            int lefts = 0;
            int rights = 0;
            
            foreach (char c in sLeft)
            {
                if (c == '0') lefts++;
            }

            foreach (char c in sRight)
            {
                if (c == '1') rights++;
            }

            if (lefts + rights > best) best = lefts + rights;
        }

        return best;
    }
}