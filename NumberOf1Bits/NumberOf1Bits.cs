namespace NumberOf1Bits;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 00000000000000000000000000001011
        // Output: 3
        // Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.
        //     Example 2:
        //
        // Input: n = 00000000000000000000000010000000
        // Output: 1
        // Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.
        //     Example 3:
        //
        // Input: n = 11111111111111111111111111111101
        // Output: 31
        // Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.

        uint n1 = 0b00000000000000000000000000001011;
        uint n2 = 0b00000000000000000000000010000000;
        uint n3 = 0b11111111111111111111111111111101;

        Solution solution = new();

        Console.WriteLine(solution.HammingWeight(n1));
        Console.WriteLine(solution.HammingWeight(n2));
        Console.WriteLine(solution.HammingWeight(n3));
    }

    public int HammingWeight(uint n)
    {
        string nStr = Convert.ToString(n, 2);
        int howManyOnes = 0;

        foreach (char c in nStr)
        {
            if (c == '1') howManyOnes++;
        }

        return howManyOnes;
    }
}