﻿namespace FindComplement;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: num = 5
        // Output: 2
        // Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.

        // Example 2:
        //
        // Input: num = 1
        // Output: 0
        // Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.


        Solution solution = new();

        Console.WriteLine(solution.FindComplement(5));
        Console.WriteLine(solution.FindComplement(1));
    }

    public int FindComplement(int num)
    {
        int mask = 1;

        while (mask < num) mask = (mask << 1) | 1;

        return num ^ mask;
    }
}