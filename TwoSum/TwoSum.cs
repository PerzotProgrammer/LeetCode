namespace TwoSum;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [2,7,11,15], target = 9
        // Output: [0,1]
        // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        // Example 2:
        //
        // Input: nums = [3,2,4], target = 6
        // Output: [1,2]
        // Example 3:
        //
        // Input: nums = [3,3], target = 6
        // Output: [0,1]
        int[] T1 = { 2, 7, 11, 15 };
        int[] T2 = { 3, 2, 4 };
        int[] T3 = { 3, 3 };

        Solution solution = new();
        
        ReadSolution(solution, T1, 9);
        ReadSolution(solution, T2, 6);
        ReadSolution(solution, T3, 6);
    }

    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target && i != j)
                {
                    int[] answ = { i, j };
                    return answ;
                }
            }
        }
        return new []{0,0};
    }

    static void ReadSolution(Solution solution, int[] Tab, int target)
    {
        int[] answ = solution.TwoSum(Tab, target);
        foreach (int el in answ) Console.Write($"{el}, ");
        Console.WriteLine();
    }
}