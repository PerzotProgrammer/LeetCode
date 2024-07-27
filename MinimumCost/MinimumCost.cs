namespace MinimumCost;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: source = "abcd", target = "acbe", original = ["a","b","c","c","e","d"], changed = ["b","c","b","e","b","e"], cost = [2,5,5,1,2,20]
        // Output: 28
        // Explanation: To convert the string "abcd" to string "acbe":
        // - Change value at index 1 from 'b' to 'c' at a cost of 5.
        // - Change value at index 2 from 'c' to 'e' at a cost of 1.
        // - Change value at index 2 from 'e' to 'b' at a cost of 2.
        // - Change value at index 3 from 'd' to 'e' at a cost of 20.
        // The total cost incurred is 5 + 1 + 2 + 20 = 28.
        // It can be shown that this is the minimum possible cost.

        // Example 2:
        //
        // Input: source = "aaaa", target = "bbbb", original = ["a","c"], changed = ["c","b"], cost = [1,2]
        // Output: 12
        // Explanation: To change the character 'a' to 'b' change the character 'a' to 'c' at a cost of 1, followed by changing the character 'c' to 'b' at a cost of 2, for a total cost of 1 + 2 = 3. To change all occurrences of 'a' to 'b', a total cost of 3 * 4 = 12 is incurred.

        // Example 3:
        //
        // Input: source = "abcd", target = "abce", original = ["a"], changed = ["e"], cost = [10000]
        // Output: -1
        // Explanation: It is impossible to convert source to target because the value at index 3 cannot be changed from 'd' to 'e'.


        Solution solution = new();

        Console.WriteLine(solution.MinimumCost("abcd", "acbe", ['a', 'b', 'c', 'c', 'e', 'd'],
            ['b', 'c', 'b', 'e', 'b', 'e'], [2, 5, 5, 1, 2, 20]));
        Console.WriteLine(solution.MinimumCost("aaaa", "bbbb", ['a', 'c'], ['c', 'b'], [1, 2]));
        Console.WriteLine(solution.MinimumCost("abcd", "abce", ['a'], ['e'], [10000]));
    }

    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        int n = 'z' - 'a' + 1;
        long[][] map = new long[n][];
        for (int i = 0; i < n; ++i)
        {
            map[i] = new long[n];
            Array.Fill(map[i], long.MaxValue);
        }

        for (int i = 0; i < original.Length; ++i)
        {
            int from = original[i] - 'a';
            int to = changed[i] - 'a';
            int price = cost[i];
            map[from][from] = map[to][to] = 0;
            map[from][to] = Math.Min(price, map[from][to]);
        }

        for (int k = 0; k < n; ++k)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (map[i][k] != long.MaxValue && map[k][j] != long.MaxValue)
                    {
                        if (map[i][k] + map[k][j] < map[i][j])
                        {
                            map[i][j] = map[i][k] + map[k][j];
                        }
                    }
                }
            }
        }

        long result = 0;
        for (int i = 0; i < source.Length; ++i)
        {
            int from = source[i] - 'a';
            int to = target[i] - 'a';
            if (map[from][to] == long.MaxValue) return -1;
            result += map[from][to];
        }

        return result;
    }
}