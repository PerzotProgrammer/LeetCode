namespace NumRescueBoats;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: people = [1,2], limit = 3
        // Output: 1
        // Explanation: 1 boat (1, 2)
        // Example 2:
        //
        // Input: people = [3,2,2,1], limit = 3
        // Output: 3
        // Explanation: 3 boats (1, 2), (2) and (3)
        // Example 3:
        //
        // Input: people = [3,5,3,4], limit = 5
        // Output: 4
        // Explanation: 4 boats (3), (3), (4), (5)

        Solution solution = new();

        Console.WriteLine(solution.NumRescueBoats([1, 2], 3));
        Console.WriteLine(solution.NumRescueBoats([3, 2, 2, 1], 3));
        Console.WriteLine(solution.NumRescueBoats([3, 5, 3, 4], 5));
    }

    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int boats = 0;
        int low = 0;
        int high = people.Length - 1;

        while (low <= high)
        {
            if (people[low] + people[high] <= limit) low++;
            high--;
            boats++;
        }

        return boats;
    }
}