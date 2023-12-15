namespace DestCity;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: paths = [["London","New York"],["New York","Lima"],["Lima","Sao Paulo"]]
        // Output: "Sao Paulo" 
        // Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city. Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".

        // Example 2:
        //
        // Input: paths = [["B","C"],["D","B"],["C","A"]]
        // Output: "A"
        // Explanation: All possible trips are: 
        // "D" -> "B" -> "C" -> "A". 
        // "B" -> "C" -> "A". 
        // "C" -> "A". 
        // "A". 
        // Clearly the destination city is "A".

        // Example 3:
        //
        // Input: paths = [["A","Z"]]
        // Output: "Z"   

        List<List<string>> p1 = new()
        {
            new() { "London", "New York" },
            new() { "New York", "Lima" },
            new() { "Lima", "Sao Paulo" }
        };

        List<List<string>> p2 = new()
        {
            new() { "B", "C" },
            new() { "D", "B" },
            new() { "C", "A" }
        };

        List<List<string>> p3 = new()
        {
            new() { "A", "Z" }
        };

        Solution solution = new();

        Console.WriteLine(solution.DestCity(p1));
        Console.WriteLine(solution.DestCity(p2));
        Console.WriteLine(solution.DestCity(p3));
    }

    // Oryginalnie jest tu IList ale jestem leniem i nie umiem konwertować Listy na IListe
    public string DestCity(List<List<string>> paths)
    {
        for (int i = 0; i < paths.Count; i++)
        {
            string cityCheck = paths[i][1];
            bool flag = true;

            for (int j = 0; j < paths.Count; j++)
            {
                if (paths[j][0] == cityCheck)
                {
                    flag = false;
                    break;
                }
            }

            if (flag) return cityCheck;
        }

        return "";
    }
}