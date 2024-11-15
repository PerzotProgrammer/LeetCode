namespace FindLengthOfShortestSubarray;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [1,2,3,10,4,2,3,5]
        // Output: 3
        // Explanation: The shortest subarray we can remove is [10,4,2] of length 3. The remaining elements after that will be [1,2,3,3,5] which are sorted.
        // Another correct solution is to remove the subarray [3,10,4].

        // Example 2:
        //
        // Input: arr = [5,4,3,2,1]
        // Output: 4
        // Explanation: Since the array is strictly decreasing, we can only keep a single element. Therefore we need to remove a subarray of length 4, either [5,4,3,2] or [4,3,2,1].

        // Example 3:
        //
        // Input: arr = [1,2,3]
        // Output: 0
        // Explanation: The array is already non-decreasing. We do not need to remove any elements.


        Solution solution = new();

        Console.WriteLine(solution.FindLengthOfShortestSubarray([1, 2, 3, 10, 4, 2, 3, 5]));
        Console.WriteLine(solution.FindLengthOfShortestSubarray([5, 4, 3, 2, 1]));
        Console.WriteLine(solution.FindLengthOfShortestSubarray([1, 2, 3]));
    }

    public int FindLengthOfShortestSubarray(int[] arr)
    {
        int right = arr.Length - 1;
        while (right > 0 && arr[right] >= arr[right - 1]) right--;

        int ans = right;
        int left = 0;
        while (left < right && (left == 0 || arr[left - 1] <= arr[left]))
        {
            while (right < arr.Length && arr[left] > arr[right]) right++;
            ans = Math.Min(ans, right - left - 1);
            left++;
        }

        return ans;
    }
}