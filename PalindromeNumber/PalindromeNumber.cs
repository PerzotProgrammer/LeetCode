namespace PalindromeNumber;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: x = 121
        // Output: true
        // Explanation: 121 reads as 121 from left to right and from right to left.
        // Example 2:

        // Input: x = -121
        // Output: false
        // Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
        // Example 3:

        // Input: x = 10
        // Output: false
        // Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
        int ex1 = 121;
        int ex2 = -121;
        int ex3 = 10;

        Solution solution = new();
        Console.WriteLine(solution.IsPalindrome(ex1));
        Console.WriteLine(solution.IsPalindrome(ex2));
        Console.WriteLine(solution.IsPalindrome(ex3));
    }
    
    public bool IsPalindrome(int x)
    {
        string xStr = x.ToString();
        char[] Arr = xStr.ToCharArray();
        string xStrRev = "";
        for (int i = Arr.Length - 1; i >= 0; i--) xStrRev += Arr[i];
        if (xStr == xStrRev) return true;
        return false;
    }
}