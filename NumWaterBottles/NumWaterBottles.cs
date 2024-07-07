namespace NumWaterBottles;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: numBottles = 9, numExchange = 3
        // Output: 13
        // Explanation: You can exchange 3 empty bottles to get 1 full water bottle.
        // Number of water bottles you can drink: 9 + 3 + 1 = 13.
        //
        // Example 2:
        //
        // Input: numBottles = 15, numExchange = 4
        // Output: 19
        // Explanation: You can exchange 4 empty bottles to get 1 full water bottle. 
        // Number of water bottles you can drink: 15 + 3 + 1 = 19.


        Solution solution = new();

        Console.WriteLine(solution.NumWaterBottles(9, 3));
        Console.WriteLine(solution.NumWaterBottles(15, 4));
    }

    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int totalDrinks = 0;
        int emptyBottles = 0;

        while (numBottles > 0)
        {
            totalDrinks += numBottles;
            emptyBottles += numBottles;
            numBottles = emptyBottles / numExchange;
            emptyBottles %= numExchange;
        }

        return totalDrinks;
    }
}