namespace SortPeople;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: names = ["Mary","John","Emma"], heights = [180,165,170]
        // Output: ["Mary","Emma","John"]
        // Explanation: Mary is the tallest, followed by Emma and John.

        // Example 2:
        //
        // Input: names = ["Alice","Bob","Bob"], heights = [155,185,150]
        // Output: ["Bob","Alice","Bob"]
        // Explanation: The first Bob is the tallest, followed by Alice and the second Bob.


        Solution solution = new();

        PrintArray(solution.SortPeople(["Mary", "John", "Emma"], [180, 165, 170]));
        PrintArray(solution.SortPeople(["Alice", "Bob", "Bob"], [155, 185, 150]));
    }

    public string[] SortPeople(string[] names, int[] heights)
    {
        int n = names.Length;

        (string Name, int Height)[] personArray = new (string, int)[n];
        for (int i = 0; i < n; i++) personArray[i] = (names[i], heights[i]);

        Array.Sort(personArray, (a, b) => b.Height.CompareTo(a.Height));

        string[] result = new string[n];
        for (int i = 0; i < n; i++) result[i] = personArray[i].Name;

        return result;
    }

    static void PrintArray(string[] array)
    {
        foreach (string s in array) Console.Write($"{s}, ");
        Console.WriteLine();
    }
}