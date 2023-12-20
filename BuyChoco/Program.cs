namespace BuyChoco;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: prices = [1,2,2], money = 3
        // Output: 0
        // Explanation: Purchase the chocolates priced at 1 and 2 units respectively. You will have 3 - 3 = 0 units of money afterwards. Thus, we return 0.
        
        // Example 2:
        //
        // Input: prices = [3,2,3], money = 3
        // Output: 3
        // Explanation: You cannot buy 2 chocolates without going in debt, so we return 3.

        int[] m1 = { 1, 2, 2 };
        int[] m2 = { 3, 2, 3 };

        Solution solution = new();

        Console.WriteLine(solution.BuyChoco(m1, 3));
        Console.WriteLine(solution.BuyChoco(m2, 3));
    }

    public int BuyChoco(int[] prices, int money)
    {
        int sum = int.MaxValue;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = 0; j < prices.Length; j++)
            {
                int checkSum = prices[i] + prices[j];
                if (i != j && checkSum < sum && checkSum >= 0) sum = checkSum;
            }
        }

        if (money - sum < 0)
        { 
            return money;
        }

        return money - sum;
    }
}