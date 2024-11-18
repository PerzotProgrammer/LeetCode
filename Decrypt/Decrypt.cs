namespace Decrypt;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: code = [5,7,1,4], k = 3
        // Output: [12,10,16,13]
        // Explanation: Each number is replaced by the sum of the next 3 numbers. The decrypted code is [7+1+4, 1+4+5, 4+5+7, 5+7+1]. Notice that the numbers wrap around.

        // Example 2:
        //
        // Input: code = [1,2,3,4], k = 0
        // Output: [0,0,0,0]
        // Explanation: When k is zero, the numbers are replaced by 0. 

        // Example 3:
        //
        // Input: code = [2,4,9,3], k = -2
        // Output: [12,5,6,13]
        // Explanation: The decrypted code is [3+9, 2+3, 4+2, 9+4]. Notice that the numbers wrap around again. If k is negative, the sum is of the previous numbers.


        Solution solution = new();

        PrintList(solution.Decrypt([5, 7, 1, 4], 3));
        PrintList(solution.Decrypt([1, 2, 3, 4], 0));
        PrintList(solution.Decrypt([2, 4, 9, 3], -2));
    }

    public int[] Decrypt(int[] code, int k)
    {
        int[] result = new int[code.Length];
        if (k == 0) return result;

        for (int i = 0; i < result.Length; i++)
        {
            if (k > 0)
            {
                for (int j = i + 1; j < i + k + 1; j++) result[i] += code[j % code.Length];
            }
            else
            {
                for (int j = i - Math.Abs(k); j < i; j++) result[i] += code[(j + code.Length) % code.Length];
            }
        }

        return result;
    }

    static void PrintList(int[] list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}