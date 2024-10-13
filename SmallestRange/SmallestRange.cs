namespace SmallestRange;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
        // Output: [20,24]
        // Explanation: 
        // List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
        // List 2: [0, 9, 12, 20], 20 is in range [20,24].
        // List 3: [5, 18, 22, 30], 22 is in range [20,24].

        // Example 2:
        //
        // Input: nums = [[1,2,3],[1,2,3],[1,2,3]]
        // Output: [1,1]


        Solution solution = new();

        PrintArray(solution.SmallestRange([[4, 10, 15, 24, 26], [0, 9, 12, 20], [5, 18, 22, 30]]));
        PrintArray(solution.SmallestRange([[1, 2, 3], [1, 2, 3], [1, 2, 3]]));
    }

    public int[] SmallestRange(IList<IList<int>> nums)
    {
        List<int[]> allNumbers = new();
        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = 0; j < nums[i].Count; j++) allNumbers.Add([nums[i][j], i]);
        }

        allNumbers.Sort((a, b) => a[0] - b[0]);

        int[] result = [allNumbers[0][0], allNumbers[^1][0]];
        int[] count = new int[nums.Count];
        int uniqueListsCovered = 0;
        int left = 0;
        for (int right = 0; right < allNumbers.Count; right++)
        {
            int listIndex = allNumbers[right][1];

            if (count[listIndex] == 0) uniqueListsCovered++;

            count[listIndex]++;

            while (uniqueListsCovered == nums.Count)
            {
                int currentRange = allNumbers[right][0] - allNumbers[left][0];
                int bestRange = result[1] - result[0];
                if (currentRange < bestRange)
                {
                    result[0] = allNumbers[left][0];
                    result[1] = allNumbers[right][0];
                }

                int leftListIndex = allNumbers[left][1];
                count[leftListIndex]--;
                if (count[leftListIndex] == 0) uniqueListsCovered--;

                left++;
            }
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i},");
        Console.WriteLine();
    }
}