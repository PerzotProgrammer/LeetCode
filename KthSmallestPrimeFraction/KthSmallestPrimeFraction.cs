namespace KthSmallestPrimeFraction;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: arr = [1,2,3,5], k = 3
        // Output: [2,5]
        // Explanation: The fractions to be considered in sorted order are:
        // 1/5, 1/3, 2/5, 1/2, 3/5, and 2/3.
        // The third fraction is 2/5.

        // Example 2:
        //
        // Input: arr = [1,7], k = 1
        // Output: [1,7]

        Solution solution = new();

        PrintArray(solution.KthSmallestPrimeFraction([1, 2, 3, 5], 3));
        PrintArray(solution.KthSmallestPrimeFraction([1, 7], 1));
    }

    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        float left = 0;
        float right = 1;
        int[] output = new int[2];

        while (right > left)
        {
            float mid = (left + right) / 2;
            int count = 0;
            float maxFraction = 0;
            int numerator = 0;
            int denominator = 0;

            for (int i = 0, j = 1; i < arr.Length - 1; i++)
            {
                while (j < arr.Length && arr[i] > mid * arr[j]) j++;

                count += arr.Length - j;
                if (j < arr.Length && maxFraction < (float)arr[i] / arr[j])
                {
                    maxFraction = (float)arr[i] / arr[j];
                    numerator = arr[i];
                    denominator = arr[j];
                }
            }

            if (count == k)
            {
                output[0] = numerator;
                output[1] = denominator;
                break;
            }

            if (count < k) left = mid;
            else right = mid;
        }

        return output;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int i in arr) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}