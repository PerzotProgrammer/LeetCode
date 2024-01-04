namespace MinOperationsII;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [2,3,3,2,2,4,2,3,4]
        // Output: 4
        // Explanation: We can apply the following operations to make the array empty:
        // - Apply the first operation on the elements at indices 0 and 3. The resulting array is nums = [3,3,2,4,2,3,4].
        // - Apply the first operation on the elements at indices 2 and 4. The resulting array is nums = [3,3,4,3,4].
        // - Apply the second operation on the elements at indices 0, 1, and 3. The resulting array is nums = [4,4].
        // - Apply the first operation on the elements at indices 0 and 1. The resulting array is nums = [].
        // It can be shown that we cannot make the array empty in less than 4 operations.
        
        
        // Example 2:
        //
        // Input: nums = [2,1,2,2,3,3]
        // Output: -1
        // Explanation: It is impossible to empty the array.

        Solution solution = new();

        Console.WriteLine(solution.MinOperations([2,3,3,2,2,4,2,3,4]));
        Console.WriteLine(solution.MinOperations([2,1,2,2,3,3]));
    }

    public int MinOperations(int[] nums)
    {
        Dictionary<int, int> dictionary = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dictionary.ContainsKey(nums[i])) dictionary.Add(nums[i], 0);
            dictionary[nums[i]]++;
        }

        int output = 0;

        foreach (KeyValuePair<int,int> pair in dictionary)
        {
            if (pair.Value == 1) return -1;
            if (pair.Value % 3 == 0) output += pair.Value / 3;
            else output += pair.Value / 3 + 1;
        }

        return output;
    }
}