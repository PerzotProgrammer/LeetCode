namespace SequentialDigits;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: low = 100, high = 300
        // Output: [123,234]

        // Example 2:
        //
        // Input: low = 1000, high = 13000
        // Output: [1234,2345,3456,4567,5678,6789,12345]

        Solution solution = new();

        IList<int> a1 = solution.SequentialDigits(100, 300);
        IList<int> a2 = solution.SequentialDigits(1000, 13000);
        
        PrintList(a1);
        Console.WriteLine();
        PrintList(a2);
    }

    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> result = new List<int>();
        string digits = "123456789";
        int maxDigits = high.ToString().Length;

        for (int length = 2; length <= maxDigits; length++)
        {
            for (int i = 0; i <= digits.Length - length; i++)
            {
                string substring = digits.Substring(i, length);
                int num = int.Parse(substring);
                if (num >= low && num <= high) result.Add(num);
            }
        }

        result.Sort();
        return result;
    }

    static void PrintList(IList<int> arr)
    {
        foreach (int i in arr) Console.Write($"{i},");
        Console.WriteLine();
    }
}