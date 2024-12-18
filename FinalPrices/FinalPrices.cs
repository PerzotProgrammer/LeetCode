namespace FinalPrices;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: prices = [8,4,6,2,3]
        // Output: [4,2,4,2,3]
        // Explanation: 
        // For item 0 with price[0]=8 you will receive a discount equivalent to prices[1]=4, therefore, the final price you will pay is 8 - 4 = 4.
        // For item 1 with price[1]=4 you will receive a discount equivalent to prices[3]=2, therefore, the final price you will pay is 4 - 2 = 2.
        // For item 2 with price[2]=6 you will receive a discount equivalent to prices[3]=2, therefore, the final price you will pay is 6 - 2 = 4.
        // For items 3 and 4 you will not receive any discount at all.

        // Example 2:
        //
        // Input: prices = [1,2,3,4,5]
        // Output: [1,2,3,4,5]
        // Explanation: In this case, for all items, you will not receive any discount at all.

        // Example 3:
        //
        // Input: prices = [10,1,1,6]
        // Output: [9,0,1,6]


        Solution solution = new();

        PrintArray(solution.FinalPrices([8, 4, 6, 2, 3]));
        PrintArray(solution.FinalPrices([1, 2, 3, 4, 5]));
        PrintArray(solution.FinalPrices([10, 1, 1, 6]));
    }

    public int[] FinalPrices(int[] prices)
    {
        int[] result = (int[])prices.Clone();

        Stack<int> stack = new();

        for (int i = 0; i < prices.Length; i++)
        {
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i]) result[stack.Pop()] -= prices[i];
            stack.Push(i);
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}