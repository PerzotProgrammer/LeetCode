namespace SortJumbled;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: mapping = [8,9,4,0,2,1,3,5,7,6], nums = [991,338,38]
        // Output: [338,38,991]
        // Explanation: 
        // Map the number 991 as follows:
        // 1. mapping[9] = 6, so all occurrences of the digit 9 will become 6.
        // 2. mapping[1] = 9, so all occurrences of the digit 1 will become 9.
        // Therefore, the mapped value of 991 is 669.
        // 338 maps to 007, or 7 after removing the leading zeros.
        // 38 maps to 07, which is also 7 after removing leading zeros.
        // Since 338 and 38 share the same mapped value, they should remain in the same relative order, so 338 comes before 38.
        // Thus, the sorted array is [338,38,991].

        // Example 2:
        //
        // Input: mapping = [0,1,2,3,4,5,6,7,8,9], nums = [789,456,123]
        // Output: [123,456,789]
        // Explanation: 789 maps to 789, 456 maps to 456, and 123 maps to 123. Thus, the sorted array is [123,456,789].


        Solution solution = new();

        PrintArray(solution.SortJumbled([8, 9, 4, 0, 2, 1, 3, 5, 7, 6], [991, 338, 38]));
        PrintArray(solution.SortJumbled([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], [789, 456, 123]));
    }

    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        SortedDictionary<int, List<int>> map = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int key = 0;
            foreach (char ch in nums[i].ToString())
                key = (key * 10) + mapping[ch - '0'];

            if (!map.ContainsKey(key)) map.Add(key, [nums[i]]);
            else map[key].Add(nums[i]);
        }

        int index = 0;
        foreach (int list in map.SelectMany(pair => pair.Value)) nums[index++] = list;

        return nums;
    }

    static void PrintArray(int[] array)
    {
        foreach (int i in array) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}