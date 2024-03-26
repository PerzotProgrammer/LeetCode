namespace FirstMissingPositive;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,0]
        // Output: 3
        // Explanation: The numbers in the range [1,2] are all in the array.

        // Example 2:
        //
        // Input: nums = [3,4,-1,1]
        // Output: 2
        // Explanation: 1 is in the array but 2 is missing.

        // Example 3:
        //
        // Input: nums = [7,8,9,11,12]
        // Output: 1
        // Explanation: The smallest positive integer 1 is missing.

        Solution solution = new();

        Console.WriteLine(solution.FirstMissingPositive([1, 2, 0]));
        Console.WriteLine(solution.FirstMissingPositive([3, 4, -1, 1]));
        Console.WriteLine(solution.FirstMissingPositive([7, 8, 9, 11, 12]));
    }

    public int FirstMissingPositive(int[] nums)
    {
        bool[] seen = new bool[nums.Length + 1];

        foreach (int num in nums)
        {
            if (num > 0 && num <= nums.Length) seen[num] = true;
        }

        for (int i = 1; i <= nums.Length; i++)
        {
            if (!seen[i]) return i;
        }

        return nums.Length + 1;
    }
}