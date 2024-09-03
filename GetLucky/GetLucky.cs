namespace GetLucky;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: s = "iiii", k = 1
        // Output: 36
        // Explanation: The operations are as follows:
        // - Convert: "iiii" ➝ "(9)(9)(9)(9)" ➝ "9999" ➝ 9999
        // - Transform #1: 9999 ➝ 9 + 9 + 9 + 9 ➝ 36
        // Thus the resulting integer is 36.

        // Example 2:
        //
        // Input: s = "leetcode", k = 2
        // Output: 6
        // Explanation: The operations are as follows:
        // - Convert: "leetcode" ➝ "(12)(5)(5)(20)(3)(15)(4)(5)" ➝ "12552031545" ➝ 12552031545
        // - Transform #1: 12552031545 ➝ 1 + 2 + 5 + 5 + 2 + 0 + 3 + 1 + 5 + 4 + 5 ➝ 33
        // - Transform #2: 33 ➝ 3 + 3 ➝ 6
        // Thus the resulting integer is 6.

        // Example 3:
        //
        // Input: s = "zbax", k = 2
        // Output: 8


        Solution solution = new();

        Console.WriteLine(solution.GetLucky("iiii", 1));
        Console.WriteLine(solution.GetLucky("leetcode", 2));
        Console.WriteLine(solution.GetLucky("zbax", 2));
    }

    public int GetLucky(string s, int k)
    {
        string numericString = "";
        foreach (char ch in s)
        {
            numericString += (ch - 'a' + 1);
        }

        while (k-- > 0)
        {
            int digitSum = 0;
            foreach (char digit in numericString)
            {
                digitSum += digit - '0';
            }

            numericString = digitSum.ToString();
        }

        return int.Parse(numericString);
    }
}