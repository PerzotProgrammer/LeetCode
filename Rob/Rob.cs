namespace Rob;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,1]
        // Output: 4
        // Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        // Total amount you can rob = 1 + 3 = 4.
        
        // Example 2:
        //
        // Input: nums = [2,7,9,3,1]
        // Output: 12
        // Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
        // Total amount you can rob = 2 + 9 + 1 = 12.

        Solution solution = new();

        Console.WriteLine(solution.Rob([1,2,3,1]));
        Console.WriteLine(solution.Rob([2,7,9,3,1]));
    }
    
    public int Rob(int[] nums)
    {
        int currentMax = 0;
        int previousMax = 0;

        foreach (int num in nums)
        {
            int temp = currentMax;
            currentMax = Math.Max(previousMax + num, currentMax);
            previousMax = temp;
        }

        return currentMax;
    }
}