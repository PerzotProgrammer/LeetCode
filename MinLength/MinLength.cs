namespace MinLength;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "ABFCACDB"
        // Output: 2
        // Explanation: We can do the following operations:
        // - Remove the substring "ABFCACDB", so s = "FCACDB".
        // - Remove the substring "FCACDB", so s = "FCAB".
        // - Remove the substring "FCAB", so s = "FC".
        // So the resulting length of the string is 2.
        // It can be shown that it is the minimum length that we can obtain.
        
        // Example 2:
        //
        // Input: s = "ACBBD"
        // Output: 5
        // Explanation: We cannot do any operations on the string so the length remains the same.


        Solution solution = new();

        Console.WriteLine(solution.MinLength("ABFCACDB"));
        Console.WriteLine(solution.MinLength("ACBBD"));
    }
    public int MinLength(string s)
    {
        while (s.Contains("AB") || s.Contains("CD"))
        {
            if (s.Contains("AB")) s = s.Replace("AB", "");
            else if (s.Contains("CD")) s = s.Replace("CD", "");
        }

        return s.Length;
    }
}