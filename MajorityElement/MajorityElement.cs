namespace MajorityElement;

class Solution
{
    static void Main()
    {
        // Example 1:

        // Input: nums = [3,2,3]
        // Output: 3

        // Example 2:

        // Input: nums = [2,2,1,1,1,2,2]
        // Output: 2

        Solution solution = new();

        Console.WriteLine(solution.MajorityElement([3, 2, 3]));
        Console.WriteLine(solution.MajorityElement([2, 2, 1, 1, 1, 2, 2]));
    }

    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> freq = new();

        foreach (int num in nums)
        {
            if (!freq.TryAdd(num, 1))
            {
                freq[num]++;
            }
        }

        int maxElement = 0;
        int maxValue = 0;
        foreach (KeyValuePair<int, int> pair in freq)
        {
            if (pair.Value > maxValue)
            {
                maxElement = pair.Key;
                maxValue = pair.Value;
            }
        }

        return maxElement;
    }
}