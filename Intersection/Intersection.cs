namespace Intersection;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums1 = [1,2,2,1], nums2 = [2,2]
        // Output: [2]

        // Example 2:
        //
        // Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        // Output: [9,4]
        // Explanation: [4,9] is also accepted.

        Solution solution = new();

        PrintArray(solution.Intersection([1, 2, 2, 1], [2, 2]));
        PrintArray(solution.Intersection([4, 9, 5], [9, 4, 9, 8, 4]));
    }

    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> set1 = new(nums1);
        HashSet<int> set2 = new(nums2);

        set1.IntersectWith(set2);

        return set1.ToArray();
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}