namespace LexicalOrder;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: n = 13
        // Output: [1,10,11,12,13,2,3,4,5,6,7,8,9]
        // Example 2:
        //
        // Input: n = 2
        // Output: [1,2]


        Solution solution = new();

        PrintList(solution.LexicalOrder(13));
        PrintList(solution.LexicalOrder(2));
    }

    public List<int> LexicalOrder(int n)
    {
        List<int> lexicographicalNumbers = new();
        int currentNumber = 1;

        for (int i = 0; i < n; ++i)
        {
            lexicographicalNumbers.Add(currentNumber);

            if (currentNumber * 10 <= n) currentNumber *= 10;
            else
            {
                while (currentNumber % 10 == 9 || currentNumber >= n) currentNumber /= 10;
                currentNumber += 1;
            }
        }

        return lexicographicalNumbers;
    }

    static void PrintList(List<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}