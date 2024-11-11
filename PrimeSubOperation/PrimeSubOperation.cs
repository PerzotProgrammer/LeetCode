namespace PrimeSubOperation;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [4,9,6,10]
        // Output: true
        // Explanation: In the first operation: Pick i = 0 and p = 3, and then subtract 3 from nums[0], so that nums becomes [1,9,6,10].
        // In the second operation: i = 1, p = 7, subtract 7 from nums[1], so nums becomes equal to [1,2,6,10].
        // After the second operation, nums is sorted in strictly increasing order, so the answer is true.

        // Example 2:
        //
        // Input: nums = [6,8,11,12]
        // Output: true
        // Explanation: Initially nums is sorted in strictly increasing order, so we don't need to make any operations.

        // Example 3:
        //
        // Input: nums = [5,8,3]
        // Output: false
        // Explanation: It can be proven that there is no way to perform operations to make nums sorted in strictly increasing order, so the answer is false.


        Solution solution = new();

        Console.WriteLine(solution.PrimeSubOperation([4, 9, 6, 10]));
        Console.WriteLine(solution.PrimeSubOperation([6, 8, 11, 12]));
        Console.WriteLine(solution.PrimeSubOperation([5, 8, 3]));
    }

    public bool PrimeSubOperation(int[] nums)
    {
        int maxElement = int.MinValue;
        foreach (int num in nums) maxElement = Math.Max(maxElement, num);

        int[] previousPrime = new int[maxElement + 1];

        for (int i = 2; i <= maxElement; i++)
        {
            if (IsPrime(i)) previousPrime[i] = i;
            else previousPrime[i] = previousPrime[i - 1];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int bound;
            if (i == 0) bound = nums[0];
            else bound = nums[i] - nums[i - 1];

            if (bound <= 0) return false;

            int largestPrime = previousPrime[bound - 1];
            nums[i] -= largestPrime;
        }

        return true;
    }

    public bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0) return false;
        }

        return true;
    }
}