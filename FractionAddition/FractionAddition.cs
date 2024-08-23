using System.Text.RegularExpressions;

namespace FractionAddition;

class Solution
{
    static void Main(string[] args)
    {
        // POMOC LEETCODE: https://leetcode.com/problems/fraction-addition-and-subtraction/solutions/5677041/94-21-easy-solution-with-explanation/?envType=daily-question&envId=2024-08-23
        // Example 1:
        //
        // Input: expression = "-1/2+1/2"
        // Output: "0/1"

        // Example 2:
        //
        // Input: expression = "-1/2+1/2+1/3"
        // Output: "1/3"

        // Example 3:
        //
        // Input: expression = "1/3-1/2"
        // Output: "-1/6"


        Solution solution = new();

        Console.WriteLine(solution.FractionAddition("-1/2+1/2"));
        Console.WriteLine(solution.FractionAddition("-1/2+1/2+1/3"));
        Console.WriteLine(solution.FractionAddition("1/3-1/2"));
    }

    public string FractionAddition(string expression)
    {
        int numerator = 0;
        int denominator = 1;

        Regex regex = new(@"([+-]?\d+)\/(\d+)");
        MatchCollection matches = regex.Matches(expression);

        foreach (Match match in matches)
        {
            int num = int.Parse(match.Groups[1].Value);
            int den = int.Parse(match.Groups[2].Value);

            numerator = numerator * den + num * denominator;
            denominator *= den;

            int gcdVal = GCD(Math.Abs(numerator), denominator);
            numerator /= gcdVal;
            denominator /= gcdVal;
        }

        return $"{numerator}/{denominator}";
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}