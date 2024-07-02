namespace Intersect;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums1 = [1,2,2,1], nums2 = [2,2]
        // Output: [2,2]

        // Example 2:
        //
        // Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        // Output: [4,9]
        // Explanation: [9,4] is also accepted.


        Solution solution = new();

        PrintArray(solution.Intersect([1, 2, 2, 1], [2, 2]));
        PrintArray(solution.Intersect([4, 9, 5], [9, 4, 9, 8, 4]));
    }

    public int[] Intersect(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int i = 0;
        int j = 0;
        List<int> intersection = new();

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j]) i++;
            else if (nums1[i] > nums2[j]) j++;
            else
            {
                intersection.Add(nums1[i]);
                i++;
                j++;
            }
        }

        return intersection.ToArray();
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}