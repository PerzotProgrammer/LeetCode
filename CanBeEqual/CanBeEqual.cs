namespace CanBeEqual;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: target = [1,2,3,4], arr = [2,4,1,3]
        // Output: true
        // Explanation: You can follow the next steps to convert arr to target:
        // 1- Reverse subarray [2,4,1], arr becomes [1,4,2,3]
        // 2- Reverse subarray [4,2], arr becomes [1,2,4,3]
        // 3- Reverse subarray [4,3], arr becomes [1,2,3,4]
        // There are multiple ways to convert arr to target, this is not the only way to do so.

        // Example 2:
        //
        // Input: target = [7], arr = [7]
        // Output: true
        // Explanation: arr is equal to target without any reverses.

        // Example 3:
        //
        // Input: target = [3,7,9], arr = [3,7,11]
        // Output: false
        // Explanation: arr does not have value 9 and it can never be converted to target.


        Solution solution = new();

        Console.WriteLine(solution.CanBeEqual([1, 2, 3, 4], [2, 4, 1, 3]));
        Console.WriteLine(solution.CanBeEqual([7], [7]));
        Console.WriteLine(solution.CanBeEqual([3, 7, 9], [3, 7, 11]));
    }

    public bool CanBeEqual(int[] target, int[] arr)
    {
        Array.Sort(target);
        Array.Sort(arr);

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] != arr[i]) return false;
        }

        return true;
    }
}