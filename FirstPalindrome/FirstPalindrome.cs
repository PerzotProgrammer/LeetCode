namespace FirstPalindrome;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: words = ["abc","car","ada","racecar","cool"]
        // Output: "ada"
        // Explanation: The first string that is palindromic is "ada".
        // Note that "racecar" is also palindromic, but it is not the first.

        // Example 2:
        //
        // Input: words = ["notapalindrome","racecar"]
        // Output: "racecar"
        // Explanation: The first and only string that is palindromic is "racecar".

        // Example 3:
        //
        // Input: words = ["def","ghi"]
        // Output: ""
        // Explanation: There are no palindromic strings, so the empty string is returned.

        Solution solution = new();

        Console.WriteLine(solution.FirstPalindrome(["abc", "car", "ada", "racecar", "cool"]));
        Console.WriteLine(solution.FirstPalindrome(["notapalindrome", "racecar"]));
        Console.WriteLine(solution.FirstPalindrome(["def", "ghi"]));
    }

    public string FirstPalindrome(string[] words)
    {
        foreach (string word in words)
        {
            string rev = "";
            foreach (char chr in word) rev = chr + rev;
            if (word == rev) return word;
        }

        return "";
    }
}