namespace RemoveKdigits;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: num = "1432219", k = 3
        // Output: "1219"
        // Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.

        // Example 2:
        //
        // Input: num = "10200", k = 1
        // Output: "200"
        // Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.

        // Example 3:
        //
        // Input: num = "10", k = 2
        // Output: "0"
        // Explanation: Remove all the digits from the number and it is left with nothing which is 0.

        Solution solution = new();

        Console.WriteLine(solution.RemoveKdigits("1432219", 3));
        Console.WriteLine(solution.RemoveKdigits("10200", 1));
        Console.WriteLine(solution.RemoveKdigits("10", 2));
    }

    public string RemoveKdigits(string num, int k)
    {
        string output = "";
        foreach (char c in num)
        {
            while (output.Length > 0 && output[^1] > c && k > 0)
            {
                k--;
                output = output.Remove(output.Length - 1);
            }

            if (output.Length > 0 || c != '0') output += c;
        }

        while (output.Length > 0 && k > 0)
        {
            k--;
            output = output.Remove(output.Length - 1);
        }

        if (output.Length == 0) return "0";
        return output;
    }
}