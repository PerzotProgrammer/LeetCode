namespace TotalMoney;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: n = 4
        // Output: 10
        // Explanation: After the 4th day, the total is 1 + 2 + 3 + 4 = 10.
        //     Example 2:
        //
        // Input: n = 10
        // Output: 37
        // Explanation: After the 10th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4) = 37. Notice that on the 2nd Monday, Hercy only puts in $2.
        //     Example 3:
        //
        // Input: n = 20
        // Output: 96
        // Explanation: After the 20th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4 + 5 + 6 + 7 + 8) + (3 + 4 + 5 + 6 + 7 + 8) = 96.

        int n1 = 4;
        int n2 = 10;
        int n3 = 20;

        Solution solution = new();

        Console.WriteLine(solution.TotalMoney(n1));
        Console.WriteLine(solution.TotalMoney(n2));
        Console.WriteLine(solution.TotalMoney(n3));
    }

    public int TotalMoney(int n)
    {
        int money = 0;
        int day = 1;

        while (n > 0)
        {
            for (int i = 0; i < Math.Min(n, 7); i++)
            {
                money += day + i;
            }

            n -= 7;
            day++;
        }

        return money;
    }
}