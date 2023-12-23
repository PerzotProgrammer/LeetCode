namespace IsPathCrossing;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: path = "NES"
        // Output: false 
        // Explanation: Notice that the path doesn't cross any point more than once.
        
        // Example 2:
        //
        //
        // Input: path = "NESWW"
        // Output: true
        // Explanation: Notice that the path visits the origin twice.
        
        string p1 = "NES";
        string p2 = "NESWW";

        Solution solution = new();

        Console.WriteLine(solution.IsPathCrossing(p1));
        Console.WriteLine(solution.IsPathCrossing(p2));
    }

    public bool IsPathCrossing(string path)
    {
        int x = 0;
        int y = 0;

        HashSet<string> visited = new() { "0,0" };

        foreach (char c in path)
        {
            if (c == 'E') x++;
            else if (c == 'W') x--;
            else if (c == 'N') y++;
            else if (c == 'S') y--;

            string pos = $"{x},{y}";
            if (!visited.Add(pos)) return true;
        }

        return false;
    }
}