namespace SumSubarrayMins;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [3,1,2,4]
        // Output: 17
        // Explanation: 
        // Subarrays are [3], [1], [2], [4], [3,1], [1,2], [2,4], [3,1,2], [1,2,4], [3,1,2,4]. 
        // Minimums are 3, 1, 2, 4, 1, 1, 2, 1, 1, 1.
        // Sum is 17.

        // Example 2:
        //
        // Input: arr = [11,81,94,43,3]
        // Output: 444

        Solution solution = new();

        Console.WriteLine(solution.SumSubarrayMins([3, 1, 2, 4]));
        Console.WriteLine(solution.SumSubarrayMins([11, 81, 94, 43, 3]));
    }

    public int SumSubarrayMins(int[] arr)
    {
        int mod = 1000000007;
        int n = arr.Length;
        long result = 0;

        Stack<int> stack = new();

        for (int i = 0; i <= n; i++)
        {
            while (stack.Count > 0 && (i == n || arr[i] < arr[stack.Peek()]))
            {
                int j = stack.Pop();
                int left = stack.Count > 0 ? stack.Peek() : -1;
                result = (result + (long)arr[j] * (i - j) * (j - left)) % mod;
            }

            if (i < n)
            {
                stack.Push(i);
            }
        }

        return (int)result;
    }
}