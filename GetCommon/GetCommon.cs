namespace GetCommon;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums1 = [1,2,3], nums2 = [2,4]
        // Output: 2
        // Explanation: The smallest element common to both arrays is 2, so we return 2.

        // Example 2:
        //
        // Input: nums1 = [1,2,3,6], nums2 = [2,3,4,5]
        // Output: 2
        // Explanation: There are two common elements in the array 2 and 3 out of which 2 is the smallest, so 2 is returned.

        Solution solution = new();

        Console.WriteLine(solution.GetCommon([1, 2, 3], [2, 4]));
        Console.WriteLine(solution.GetCommon([1, 2, 3, 6], [2, 3, 4, 5]));
    }

    public int GetCommon(int[] nums1, int[] nums2)
    {
        HashSet<int> numsSet = new(nums2);
        foreach (int num in nums1)
        {
            if (numsSet.Contains(num)) return num;
        }

        return -1;
    }
}