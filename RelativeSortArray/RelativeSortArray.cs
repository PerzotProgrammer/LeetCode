﻿namespace RelativeSortArray;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
        // Output: [2,2,2,1,4,3,3,9,6,7,19]

        // Example 2:
        //
        // Input: arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]
        // Output: [22,28,8,6,17,44]


        Solution solution = new();

        PrintArray(solution.RelativeSortArray([2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19], [2, 1, 4, 3, 9, 6]));
        PrintArray(solution.RelativeSortArray([28, 6, 22, 8, 44, 17], [22, 28, 8, 6]));
    }

    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        Dictionary<int, int> freq = new();
        foreach (int i in arr2)
        {
            freq.Add(i, 0);
        }

        Array.Sort(arr1);
        foreach (int i in arr1)
        {
            if (!freq.TryAdd(i, 1)) freq[i]++;
        }

        List<int> output = new();

        foreach (KeyValuePair<int, int> pair in freq)
        {
            for (int i = 0; i < pair.Value; i++) output.Add(pair.Key);
        }

        return output.ToArray();
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}