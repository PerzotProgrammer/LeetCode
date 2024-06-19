namespace MinDays;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: bloomDay = [1,10,3,10,2], m = 3, k = 1
        // Output: 3
        // Explanation: Let us see what happened in the first three days. x means flower bloomed and _ means flower did not bloom in the garden.
        // We need 3 bouquets each should contain 1 flower.
        // After day 1: [x, _, _, _, _]   // we can only make one bouquet.
        // After day 2: [x, _, _, _, x]   // we can only make two bouquets.
        // After day 3: [x, _, x, _, x]   // we can make 3 bouquets. The answer is 3.

        // Example 2:
        //
        // Input: bloomDay = [1,10,3,10,2], m = 3, k = 2
        // Output: -1
        // Explanation: We need 3 bouquets each has 2 flowers, that means we need 6 flowers. We only have 5 flowers so it is impossible to get the needed bouquets and we return -1.

        // Example 3:
        //
        // Input: bloomDay = [7,7,7,7,12,7,7], m = 2, k = 3
        // Output: 12
        // Explanation: We need 2 bouquets each should have 3 flowers.
        //     Here is the garden after the 7 and 12 days:
        // After day 7: [x, x, x, x, _, x, x]
        // We can make one bouquet of the first three flowers that bloomed. We cannot make another bouquet from the last three flowers that bloomed because they are not adjacent.
        // After day 12: [x, x, x, x, x, x, x]
        // It is obvious that we can make two bouquets in different ways.


        Solution solution = new();

        Console.WriteLine(solution.MinDays([1, 10, 3, 10, 2], 3, 1));
        Console.WriteLine(solution.MinDays([1, 10, 3, 10, 2], 3, 2));
        Console.WriteLine(solution.MinDays([7, 7, 7, 7, 12, 7, 7], 2, 3));
    }

    public int MinDays(int[] bloomDay, int m, int k)
    {
        int n = bloomDay.Length;

        if (m * k > n) return -1;

        int start = 0;
        int end = 0;
        foreach (int day in bloomDay) end = Math.Max(end, day);

        int ans = -1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            if (GetNumOfBouquets(bloomDay, mid, k) >= m)
            {
                ans = mid;
                end = mid - 1;
            }
            else start = mid + 1;
        }

        return ans;
    }

    private int GetNumOfBouquets(int[] bloomDay, int day, int k)
    {
        int numOfBouquets = 0;
        int flowers = 0;

        foreach (int bloom in bloomDay)
        {
            if (bloom <= day)
            {
                flowers++;
                if (flowers == k)
                {
                    numOfBouquets++;
                    flowers = 0;
                }
            }
            else flowers = 0;
        }

        return numOfBouquets;
    }
}