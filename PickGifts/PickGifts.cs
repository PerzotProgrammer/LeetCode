﻿namespace PickGifts;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: gifts = [25,64,9,4,100], k = 4
        // Output: 29
        // Explanation: 
        // The gifts are taken in the following way:
        // - In the first second, the last pile is chosen and 10 gifts are left behind.
        // - Then the second pile is chosen and 8 gifts are left behind.
        // - After that the first pile is chosen and 5 gifts are left behind.
        // - Finally, the last pile is chosen again and 3 gifts are left behind.
        // The final remaining gifts are [5,8,9,4,3], so the total number of gifts remaining is 29.

        // Example 2:
        //
        // Input: gifts = [1,1,1,1], k = 4
        // Output: 4
        // Explanation: 
        // In this case, regardless which pile you choose, you have to leave behind 1 gift in each pile. 
        // That is, you can't take any pile with you. 
        // So, the total gifts remaining are 4.


        Solution solution = new();

        Console.WriteLine(solution.PickGifts([25, 64, 9, 4, 100], 4));
        Console.WriteLine(solution.PickGifts([1, 1, 1, 1], 4));
    }

    public long PickGifts(int[] gifts, int k)
    {
        List<int> piles = new(gifts);

        for (int i = 0; i < k; i++)
        {
            piles.Sort((a, b) => b.CompareTo(a));
            int maxGifts = piles[0];

            piles[0] = (int)Math.Floor(Math.Sqrt(maxGifts));
        }

        long totalGifts = 0;
        foreach (int pile in piles) totalGifts += pile;

        return totalGifts;
    }
}