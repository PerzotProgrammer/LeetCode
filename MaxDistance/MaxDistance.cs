namespace MaxDistance;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: position = [1,2,3,4,7], m = 3
        // Output: 3
        // Explanation: Distributing the 3 balls into baskets 1, 4 and 7 will make the magnetic force between ball pairs [3, 3, 6]. The minimum magnetic force is 3. We cannot achieve a larger minimum magnetic force than 3.

        // Example 2:
        //
        // Input: position = [5,4,3,2,1,1000000000], m = 2
        // Output: 999999999
        // Explanation: We can use baskets 1 and 1000000000.


        Solution solution = new();

        Console.WriteLine(solution.MaxDistance([1, 2, 3, 4, 7], 3));
        Console.WriteLine(solution.MaxDistance([5, 4, 3, 2, 1, 1000000000], 2));
    }

    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);

        int low = 1, high = position[^1] - position[0];
        int result = 0;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CanPlaceBalls(position, m, mid))
            {
                result = mid;
                low = mid + 1;
            }
            else high = mid - 1;
        }

        return result;
    }

    private bool CanPlaceBalls(int[] position, int m, int minDist)
    {
        int count = 1;
        int lastPos = position[0];

        for (int i = 1; i < position.Length; i++)
        {
            if (position[i] - lastPos >= minDist)
            {
                count++;
                lastPos = position[i];
                if (count == m) return true;
            }
        }

        return false;
    }
}