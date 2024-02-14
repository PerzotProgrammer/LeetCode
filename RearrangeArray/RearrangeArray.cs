namespace RearrangeArray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [3,1,-2,-5,2,-4]
        // Output: [3,-2,1,-5,2,-4]
        // Explanation:
        // The positive integers in nums are [3,1,2]. The negative integers are [-2,-5,-4].
        // The only possible way to rearrange them such that they satisfy all conditions is [3,-2,1,-5,2,-4].
        // Other ways such as [1,-2,2,-5,3,-4], [3,1,2,-2,-5,-4], [-2,3,-5,1,-4,2] are incorrect because they do not satisfy one or more conditions.  

        // Example 2:
        //
        // Input: nums = [-1,1]
        // Output: [1,-1]
        // Explanation:
        // 1 is the only positive integer and -1 the only negative integer in nums.
        // So nums is rearranged to [1,-1].

        Solution solution = new();
        PrintArray(solution.RearrangeArray([3, 1, -2, -5, 2, -4]));
        PrintArray(solution.RearrangeArray([-1, 1]));
    }

    public int[] RearrangeArray(int[] nums)
    {
        List<int> neg = new();
        List<int> pos = new();
        foreach (int num in nums)
        {
            if (num < 0) neg.Add(num);
            else pos.Add(num);
        }

        int[] output = new int[nums.Length];
        bool isPos = true;
        for (int i = 0; i < output.Length; i++)
        {
            if (isPos)
            {
                output[i] = pos[i / 2];
                isPos = false;
            }
            else
            {
                output[i] = neg[i / 2];
                isPos = true;
            }
        }

        return output;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}