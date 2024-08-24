namespace NearestPalindromic;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = "123"
        // Output: "121"
        // Example 2:
        //
        // Input: n = "1"
        // Output: "0"
        // Explanation: 0 and 2 are the closest palindromes but we return the smallest which is 0.


        Solution solution = new();

        Console.WriteLine(solution.NearestPalindromic("123"));
        Console.WriteLine(solution.NearestPalindromic("1"));
    }
    public string NearestPalindromic(string n)
    {
        int i = n.Length % 2 == 0 ? n.Length / 2 - 1 : n.Length / 2;
        long firstHalf = long.Parse(n.Substring(0, i + 1));
        List<long> possibilities = new();

        possibilities.Add(HalfToPalindrome(firstHalf, n.Length % 2 == 0));
        possibilities.Add(HalfToPalindrome(firstHalf + 1, n.Length % 2 == 0));
        possibilities.Add(HalfToPalindrome(firstHalf - 1, n.Length % 2 == 0));
        possibilities.Add((long)Math.Pow(10, n.Length - 1) - 1);
        possibilities.Add((long)Math.Pow(10, n.Length) + 1);

        long diff = long.MaxValue, res = 0, nl = long.Parse(n);
        foreach (long candidates in possibilities)
        {
            if (candidates == nl) continue;
            if (Math.Abs(candidates - nl) < diff)
            {
                diff = Math.Abs(candidates - nl);
                res = candidates;
            }
            else if (Math.Abs(candidates - nl) == diff)
            {
                res = Math.Min(res, candidates);
            }
        }

        return res.ToString();
    }

    private long HalfToPalindrome(long left, bool even)
    {
        long res = left;
        if (!even) left /= 10;
        while (left > 0)
        {
            res = res * 10 + (left % 10);
            left /= 10;
        }

        return res;
    }
}