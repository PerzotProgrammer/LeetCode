namespace ThreeConsecutiveOdds;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [2,6,4,1]
        // Output: false
        // Explanation: There are no three consecutive odds.

        // Example 2:
        //
        // Input: arr = [1,2,34,3,4,5,7,23,12]
        // Output: true
        // Explanation: [5,7,23] are three consecutive odds.


        Solution solution = new();

        Console.WriteLine(solution.ThreeConsecutiveOdds([2, 6, 4, 1]));
        Console.WriteLine(solution.ThreeConsecutiveOdds([1, 2, 34, 3, 4, 5, 7, 23, 12]));
    }

    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;

        foreach (int num in arr)
        {
            if (num % 2 != 0)
            {
                count++;
                if (count == 3) return true;
            }
            else count = 0;
        }

        return false;
    }
}