namespace UniqueOccurrences;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [1,2,2,1,1,3]
        // Output: true
        // Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
        
        // Example 2:
        //
        // Input: arr = [1,2]
        // Output: false
        
        // Example 3:
        //
        // Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
        // Output: true

        Solution solution = new();

        Console.WriteLine(solution.UniqueOccurrences([1,2,2,1,1,3]));
        Console.WriteLine(solution.UniqueOccurrences([1,2]));
        Console.WriteLine(solution.UniqueOccurrences([-3,0,1,-3,1,1,1,-3,10,0]));
    }

    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> numbs = new();
        foreach (int num in arr)
        {
            if (!numbs.TryAdd(num, 1))
            {
                numbs[num] += 1;
            }
        }

        List<int> occurrs = new();

        foreach (KeyValuePair<int, int> pair in numbs)
        {
            if (occurrs.Contains(pair.Value))
            {
                return false;
            }

            occurrs.Add(pair.Value);
        }

        return true;
    }
}