namespace ReverseString;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = ["h","e","l","l","o"]
        // Output: ["o","l","l","e","h"]

        // Example 2:
        //
        // Input: s = ["H","a","n","n","a","h"]
        // Output: ["h","a","n","n","a","H"]


        char[] s1 = ['h', 'e', 'l', 'l', 'o'];
        char[] s2 = ['H', 'a', 'n', 'n', 'a', 'h'];

        Solution solution = new();

        solution.ReverseString(s1);
        solution.ReverseString(s2);

        PrintArray(s1);
        PrintArray(s2);
    }

    public void ReverseString(char[] s)
    {
        int low = 0;
        int high = s.Length - 1;

        while (low < high)
        {
            (s[low], s[high]) = (s[high], s[low]);
            low++;
            high--;
        }
    }

    static void PrintArray(char[] arr)
    {
        foreach (char c in arr) Console.Write($"{c},");
        Console.WriteLine();
    }
}