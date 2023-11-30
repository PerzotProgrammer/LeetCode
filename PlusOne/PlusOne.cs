namespace PlusOne;

class Solution
{
    static void Main()
    {
        int[] D1 = { 1, 2, 3 };
        int[] D2 = { 1, 6, 9 };
        int[] D3 = { 1, 9, 9 };
        int[] D4 = { 1, 1, 6, 7 };
        int[] D5 = { 9, 9, 9, 9 };

        Solution solution = new();

        solution.PlusOne(D1);
        solution.PlusOne(D2);
        solution.PlusOne(D3);
        solution.PlusOne(D4);
        solution.PlusOne(D5);
    }

    public int[] PlusOne(int[] digits)
    {
        int[] digitsCopy = digits;
        digitsCopy[^1] += 1;
        try
        {
            for (int i = digitsCopy.Length - 1; i >= 0; i--)
            {
                if (digitsCopy[i] > 9)
                {
                    digitsCopy[i] = 0;
                    digitsCopy[i - 1] += 1;
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            int[] digReturn = new int[digitsCopy.Length + 1];
            for (int i = digitsCopy.Length - 1; i >= 0; i--)
            {
                digReturn[i] = digitsCopy[i];
            }

            digReturn[0] = 1;

            WriteTab(digReturn);
            return digReturn;
        }

        WriteTab(digitsCopy);
        return digitsCopy;
    }

    static void WriteTab(int[] Tab)
    {
        foreach (int i in Tab)
        {
            Console.Write($"{i},");
        }

        Console.WriteLine();
    }
}