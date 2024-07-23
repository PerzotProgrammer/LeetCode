namespace FrequencySortII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,1,2,2,2,3]
        // Output: [3,1,1,2,2,2]
        // Explanation: '3' has a frequency of 1, '1' has a frequency of 2, and '2' has a frequency of 3.

        // Example 2:
        //
        // Input: nums = [2,3,1,3,2]
        // Output: [1,3,3,2,2]
        // Explanation: '2' and '3' both have a frequency of 2, so they are sorted in decreasing order.

        // Example 3:
        //
        // Input: nums = [-1,1,-6,4,5,-6,1,4,1]
        // Output: [5,-1,4,4,-6,-6,1,1,1]


        Solution solution = new();

        PrintArray(solution.FrequencySort([1, 1, 2, 2, 2, 3]));
        PrintArray(solution.FrequencySort([2, 3, 1, 3, 2]));
        PrintArray(solution.FrequencySort([-1, 1, -6, 4, 5, -6, 1, 4, 1]));
    }

    public int[] FrequencySort(int[] nums)
    {
        Dictionary<int, int> freqMap = new();
        foreach (int num in nums)
        {
            if (!freqMap.TryAdd(num, 1)) freqMap[num]++;
        }

        Dictionary<int, List<int>> groupedByFreq = new();
        foreach (var kvp in freqMap)
        {
            int num = kvp.Key;
            int freq = kvp.Value;
            if (!groupedByFreq.ContainsKey(freq)) groupedByFreq[freq] = new List<int>();
            groupedByFreq[freq].Add(num);
        }

        List<int> sortedNums = new();
        foreach (int freq in groupedByFreq.Keys.OrderBy(f => f))
        {
            List<int> numsWithSameFreq = groupedByFreq[freq];
            numsWithSameFreq.Sort((a, b) => b.CompareTo(a));
            foreach (int num in numsWithSameFreq)
            {
                for (int i = 0; i < freq; i++) sortedNums.Add(num);
            }
        }

        return sortedNums.ToArray();
    }

    static void PrintArray(int[] array)
    {
        foreach (int i in array) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}