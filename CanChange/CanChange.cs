namespace CanChange;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: start = "_L__R__R_", target = "L______RR"
        // Output: true
        // Explanation: We can obtain the string target from start by doing the following moves:
        // - Move the first piece one step to the left, start becomes equal to "L___R__R_".
        // - Move the last piece one step to the right, start becomes equal to "L___R___R".
        // - Move the second piece three steps to the right, start becomes equal to "L______RR".
        // Since it is possible to get the string target from start, we return true.

        // Example 2:
        //
        // Input: start = "R_L_", target = "__LR"
        // Output: false
        // Explanation: The 'R' piece in the string start can move one step to the right to obtain "_RL_".
        //     After that, no pieces can move anymore, so it is impossible to obtain the string target from start.

        // Example 3:
        //
        // Input: start = "_R", target = "R_"
        // Output: false
        // Explanation: The piece in the string start can move only to the right, so it is impossible to obtain the string target from start.


        Solution solution = new();

        Console.WriteLine(solution.CanChange("_L__R__R_", "L______RR"));
        Console.WriteLine(solution.CanChange("R_L_", "__LR"));
        Console.WriteLine(solution.CanChange("_R", "R_"));
    }

    public bool CanChange(string start, string target)
    {
        int n = start.Length;

        string startPieces = start.Replace("_", "");
        string targetPieces = target.Replace("_", "");

        if (startPieces != targetPieces) return false;

        int j = 0;

        for (int i = 0; i < n; i++)
        {
            if (start[i] == '_') continue;

            while (target[j] == '_') j++;

            if (start[i] == 'L' && i < j) return false;
            if (start[i] == 'R' && i > j) return false;
            j++;
        }

        return true;
    }
}