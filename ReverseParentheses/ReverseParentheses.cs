namespace ReverseParentheses;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "(abcd)"
        // Output: "dcba"

        // Example 2:
        //
        // Input: s = "(u(love)i)"
        // Output: "iloveu"
        // Explanation: The substring "love" is reversed first, then the whole string is reversed.

        // Example 3:
        //
        // Input: s = "(ed(et(oc))el)"
        // Output: "leetcode"
        // Explanation: First, we reverse the substring "oc", then "etco", and finally, the whole string.


        Solution solution = new();

        Console.WriteLine(solution.ReverseParentheses("(abcd)"));
        Console.WriteLine(solution.ReverseParentheses("(u(love)i)"));
        Console.WriteLine(solution.ReverseParentheses("(ed(et(oc))el)"));
    }

    public string ReverseParentheses(string s)
    {
        char[] arr = s.ToCharArray();
        Stack<int> stack = new();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == '(') stack.Push(i);
            else if (arr[i] == ')')
            {
                int j = stack.Pop();
                Reverse(arr, j + 1, i - 1);
            }
        }

        string result = "";
        foreach (char ch in arr)
        {
            if (ch != '(' && ch != ')') result += ch;
        }

        return result;
    }

    private void Reverse(char[] arr, int left, int right)
    {
        while (left < right)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
}