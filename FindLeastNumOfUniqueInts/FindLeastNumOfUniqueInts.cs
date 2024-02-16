namespace FindLeastNumOfUniqueInts;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [5,5,4], k = 1
        // Output: 1
        // Explanation: Remove the single 4, only 5 is left.

        // Example 2:
        // Input: arr = [4,3,1,1,3,3,2], k = 3
        // Output: 2
        // Explanation: Remove 4, 2 and either one of the two 1s or three 3s. 1 and 3 will be left.

        Solution solution = new();

        Console.WriteLine(solution.FindLeastNumOfUniqueInts([5, 5, 4], 1));
        Console.WriteLine(solution.FindLeastNumOfUniqueInts([4, 3, 1, 1, 3, 3, 2], 3));
    }

    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        Dictionary<int, int> frequencyMap = new();
        
        foreach (int num in arr) frequencyMap[num] = frequencyMap.GetValueOrDefault(num, 0) + 1;
        
        List<int> frequencies = frequencyMap.Values.ToList();
        frequencies.Sort();
        int uniqueCount = frequencies.Count;
        
        foreach (int frequency in frequencies)
        {
            if (k >= frequency)
            {
                k -= frequency;
                uniqueCount--;
            }
            else break;
        }

        return uniqueCount;
    }
}