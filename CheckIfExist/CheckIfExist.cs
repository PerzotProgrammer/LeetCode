namespace CheckIfExist;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr = [10,2,5,3]
        // Output: true
        // Explanation: For i = 0 and j = 2, arr[i] == 10 == 2 * 5 == 2 * arr[j]

        // Example 2:
        //
        // Input: arr = [3,1,7,11]
        // Output: false
        // Explanation: There is no i and j that satisfy the conditions.


        Solution solution = new();

        Console.WriteLine(solution.CheckIfExist([10, 2, 5, 3]));
        Console.WriteLine(solution.CheckIfExist([3, 1, 7, 11]));
    }

    public bool CheckIfExist(int[] arr)
    {
        Array.Sort(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            int target = arr[i] * 2;
            int index = BinarySearch(arr, target);
            if (index != -1 && index != i) return true;
        }

        return false;
    }


    private int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }

        return -1;
    }
}