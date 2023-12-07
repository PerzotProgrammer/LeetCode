namespace LargestOddNumber;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: num = "52"
        // Output: "5"
        // Explanation: The only non-empty substrings are "5", "2", and "52". "5" is the only odd number.
            // Example 2:

        // Input: num = "4206"
        // Output: ""
        // Explanation: There are no odd numbers in "4206".
            // Example 3:

        // Input: num = "35427"
        // Output: "35427"
        // Explanation: "35427" is already an odd number.

        string n1 = "52";
        string n2 = "4206";
        string n3 = "35427";

        Solution solution = new();

        Console.WriteLine(solution.LargestOddNumber(n1));
        Console.WriteLine(solution.LargestOddNumber(n2));
        Console.WriteLine(solution.LargestOddNumber(n3));
    }

    public string LargestOddNumber(string num)
    {
        for (int i = num.Length - 1; i >= 0; i--)
        {
            if (Convert.ToInt32(num[i]) % 2 != 0)
            {
                return num.Substring(0, i + 1);
            }
        }

        return "";
    }
}

