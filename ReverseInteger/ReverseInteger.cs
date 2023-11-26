namespace ReverseInteger;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: x = 123
        // Output: 321
        // Example 2:
        //
        // Input: x = -123
        // Output: -321
        // Example 3:
        //
        // Input: x = 120
        // Output: 21

        int i1 = 123;
        int i2 = -123;
        int i3 = 120;

        Solution solution = new();

        Console.WriteLine(solution.Reverse(i1));
        Console.WriteLine(solution.Reverse(i2));
        Console.WriteLine(solution.Reverse(i3));

    }
    
    public int Reverse(int x)
    {
        char[] xChrArr = x.ToString().ToCharArray();
        char sign = '+';
        if (xChrArr[0] == '-')
        {
            xChrArr = xChrArr.Skip(1).ToArray();
            sign = '-';
        }

        Array.Reverse(xChrArr);

        string outStr = sign + new string(xChrArr);
        if (!int.TryParse(outStr, out int outInt)) return 0;
        return outInt;
    }
}