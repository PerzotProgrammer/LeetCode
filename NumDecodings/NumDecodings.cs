namespace NumDecodings;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "12"
        // Output: 2
        // Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).
        
        // Example 2:
        //
        // Input: s = "226"
        // Output: 3
        // Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
        
        // Example 3:
        //
        // Input: s = "06"
        // Output: 0
        // Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").

        string s1 = "12";
        string s2 = "226";
        string s3 = "06";

        Solution solution = new();

        Console.WriteLine(solution.NumDecodings(s1));
        Console.WriteLine(solution.NumDecodings(s2));
        Console.WriteLine(solution.NumDecodings(s3));
    }
    
    public int NumDecodings(string s)
    {
        if (s == "" || s[0] == '0') return 0;
        int[] arr = new int[s.Length + 1];

        arr[0] = 1;
        arr[1] = 1;

        for (int i = 2; i <= s.Length; i++)
        {
            int one = s[i - 1] - '0';
            int two = int.Parse(s.Substring(i - 2, 2));
            if (one != 0) arr[i] += arr[i - 1];
            if (10 <= two && two <= 26) arr[i] += arr[i - 2];
        }

        return arr[s.Length];
    }
}