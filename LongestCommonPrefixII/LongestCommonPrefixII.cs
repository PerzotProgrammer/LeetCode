namespace LongestCommonPrefixII;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: arr1 = [1,10,100], arr2 = [1000]
        // Output: 3
        // Explanation: There are 3 pairs (arr1[i], arr2[j]):
        // - The longest common prefix of (1, 1000) is 1.
        // - The longest common prefix of (10, 1000) is 10.
        // - The longest common prefix of (100, 1000) is 100.
        // The longest common prefix is 100 with a length of 3.

        // Example 2:
        //
        // Input: arr1 = [1,2,3], arr2 = [4,4,4]
        // Output: 0
        // Explanation: There exists no common prefix for any pair (arr1[i], arr2[j]), hence we return 0.
        // Note that common prefixes between elements of the same array do not count.


        Solution solution = new();

        Console.WriteLine(solution.LongestCommonPrefix([1, 10, 100], [1000]));
        Console.WriteLine(solution.LongestCommonPrefix([1, 2, 3], [4, 4, 4]));
    }

    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        HashSet<int> arr1Prefixes = new();

        for (int i = 0; i < arr1.Length; i++)
        {
            while (!arr1Prefixes.Contains(arr1[i]) && arr1[i] > 0)
            {
                arr1Prefixes.Add(arr1[i]);
                arr1[i] /= 10;
            }
        }

        int longestPrefix = 0;

        for (int i = 0; i < arr2.Length; i++)
        {
            while (!arr1Prefixes.Contains(arr2[i]) && arr2[i] > 0) arr2[i] /= 10;

            if (arr2[i] > 0)
            {
                longestPrefix = Math.Max(longestPrefix, (int)Math.Log10(arr2[i]) + 1);
            }
        }

        return longestPrefix;
    }
}