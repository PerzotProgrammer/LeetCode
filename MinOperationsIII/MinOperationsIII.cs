namespace MinOperationsIII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: logs = ["d1/","d2/","../","d21/","./"]
        // Output: 2
        // Explanation: Use this change folder operation "../" 2 times and go back to the main folder.

        // Example 2:
        //
        // Input: logs = ["d1/","d2/","./","d3/","../","d31/"]
        // Output: 3

        // Example 3:
        //
        // Input: logs = ["d1/","../","../","../"]
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.MinOperations(["d1/", "d2/", "../", "d21/", "./"]));
        Console.WriteLine(solution.MinOperations(["d1/", "d2/", "./", "d3/", "../", "d31/"]));
        Console.WriteLine(solution.MinOperations(["d1/", "../", "../", "../"]));
    }

    public int MinOperations(string[] logs)
    {
        Stack<string> stack = new();

        foreach (string log in logs)
        {
            if (log.Equals("../"))
            {
                if (stack.Count > 0) stack.Pop();
            }
            else if (!log.Equals("./")) stack.Push(log);
        }

        return stack.Count;
    }
}