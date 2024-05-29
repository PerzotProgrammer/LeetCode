namespace NumSteps;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "1101"
        // Output: 6
        // Explanation: "1101" corressponds to number 13 in their decimal representation.
        // Step 1) 13 is odd, add 1 and obtain 14. 
        // Step 2) 14 is even, divide by 2 and obtain 7.
        // Step 3) 7 is odd, add 1 and obtain 8.
        // Step 4) 8 is even, divide by 2 and obtain 4.  
        // Step 5) 4 is even, divide by 2 and obtain 2. 
        // Step 6) 2 is even, divide by 2 and obtain 1.  

        // Example 2:
        //
        // Input: s = "10"
        // Output: 1
        // Explanation: "10" corressponds to number 2 in their decimal representation.
        // Step 1) 2 is even, divide by 2 and obtain 1.  

        // Example 3:
        //
        // Input: s = "1"
        // Output: 0

        Solution solution = new();
        Console.WriteLine(solution.NumSteps("1101"));
        Console.WriteLine(solution.NumSteps("10"));
        Console.WriteLine(solution.NumSteps("1"));
    }

    public int NumSteps(string s)
    {
        int steps = 0;
        int carry = 0;
        for (int i = s.Length - 1; i > 0; i--)
        {
            int digit = int.Parse(s[i].ToString()) + carry;

            if (digit % 2 == 0) steps++;
            else
            {
                steps += 2;
                carry = 1;
            }
        }

        return steps + carry;
    }
}