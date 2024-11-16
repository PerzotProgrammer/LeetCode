namespace ResultsArray;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [1,2,3,4,3,2,5], k = 3
        // Output: [3,4,-1,-1,-1]
        // Explanation:
        // There are 5 subarrays of nums of size 3:
        // [1, 2, 3] with the maximum element 3.
        // [2, 3, 4] with the maximum element 4.
        // [3, 4, 3] whose elements are not consecutive.
        // [4, 3, 2] whose elements are not sorted.
        // [3, 2, 5] whose elements are not consecutive.

        // Example 2:
        //
        // Input: nums = [2,2,2,2,2], k = 4
        // Output: [-1,-1]

        // Example 3:
        //
        // Input: nums = [3,2,3,2,3,2], k = 2
        // Output: [-1,3,-1,3,-1]


        Solution solution = new();

        PrintArray(solution.ResultsArray([1, 2, 3, 4, 3, 2, 5], 3));
        PrintArray(solution.ResultsArray([2, 2, 2, 2, 2], 4));
        PrintArray(solution.ResultsArray([3, 2, 3, 2, 3, 2], 2));
    }

    public int[] ResultsArray(int[] nums, int k)
    {
        int[] result = new int[nums.Length - k + 1];

        for (int start = 0; start <= nums.Length - k; start++)
        {
            bool isConsecutiveAndSorted = true;

            for (int index = start; index < start + k - 1; index++)
            {
                if (nums[index + 1] != nums[index] + 1)
                {
                    isConsecutiveAndSorted = false;
                    break;
                }
            }

            if (isConsecutiveAndSorted) result[start] = nums[start + k - 1];
            else result[start] = -1;
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}