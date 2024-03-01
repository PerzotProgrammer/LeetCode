namespace MaximumOddBinaryNumber;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "010"
        // Output: "001"
        // Explanation: Because there is just one '1', it must be in the last position. So the answer is "001".

        // Example 2:
        //
        // Input: s = "0101"
        // Output: "1001"
        // Explanation: One of the '1's must be in the last position. The maximum number that can be made with the remaining digits is "100". So the answer is "1001".

        Solution solution = new();

        Console.WriteLine(solution.MaximumOddBinaryNumber("010"));
        Console.WriteLine(solution.MaximumOddBinaryNumber("0101"));
    }

    public string MaximumOddBinaryNumber(string s)
    {
        int numOfOnes = 0;
        foreach (char c in s)
        {
            if (c == '1') numOfOnes++;
        }

        string output = "";
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (numOfOnes > 1)
            {
                output += '1';
                numOfOnes--;
            }
            else output += '0';
        }

        output += '1';
        return output;
    }
}