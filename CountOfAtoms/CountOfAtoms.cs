namespace CountOfAtoms;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: formula = "H2O"
        // Output: "H2O"
        // Explanation: The count of elements are {'H': 2, 'O': 1}.
        // Example 2:
        //
        // Input: formula = "Mg(OH)2"
        // Output: "H2MgO2"
        // Explanation: The count of elements are {'H': 2, 'Mg': 1, 'O': 2}.
        // Example 3:
        //
        // Input: formula = "K4(ON(SO3)2)2"
        // Output: "K4N2O14S4"
        // Explanation: The count of elements are {'K': 4, 'N': 2, 'O': 14, 'S': 4}.


        Solution solution = new();

        Console.WriteLine(solution.CountOfAtoms("H2O"));
        Console.WriteLine(solution.CountOfAtoms("Mg(OH)2"));
        Console.WriteLine(solution.CountOfAtoms("K4(ON(SO3)2)2"));
    }

    public string CountOfAtoms(string formula)
    {
        Stack<Dictionary<string, int>> stack = new();
        Dictionary<string, int> map = new();
        int i = 0;

        while (i < formula.Length)
        {
            char ch = formula[i];

            if (ch == '(')
            {
                stack.Push(map);
                map = new Dictionary<string, int>();
                i++;
            }
            else if (ch == ')')
            {
                i++;
                int start = i;
                int multiplicity = 1;
                if (i < formula.Length && Char.IsDigit(formula[i]))
                {
                    while (i < formula.Length && Char.IsDigit(formula[i])) i++;
                    multiplicity = int.Parse(formula.Substring(start, i - start));
                }

                if (stack.Count > 0)
                {
                    Dictionary<string, int> tempMap = map;
                    map = stack.Pop();
                    foreach (string key in tempMap.Keys)
                    {
                        if (map.ContainsKey(key)) map[key] += tempMap[key] * multiplicity;
                        else map[key] = tempMap[key] * multiplicity;
                    }
                }
            }
            else
            {
                int start = i;
                i++;
                while (i < formula.Length && Char.IsLower(formula[i])) i++;
                string element = formula.Substring(start, i - start);
                start = i;
                while (i < formula.Length && Char.IsDigit(formula[i])) i++;
                int count = start < i ? int.Parse(formula.Substring(start, i - start)) : 1;
                if (!map.TryAdd(element, count)) map[element] += count;
            }
        }

        SortedDictionary<string, int> sortedMap = new(map);
        string result = "";
        foreach (var entry in sortedMap)
        {
            result += entry.Key;
            if (entry.Value > 1) result += entry.Value;
        }

        return result;
    }
}