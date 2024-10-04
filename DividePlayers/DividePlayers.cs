namespace DividePlayers;

public class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: skill = [3,2,5,1,3,4]
        // Output: 22
        // Explanation: 
        // Divide the players into the following teams: (1, 5), (2, 4), (3, 3), where each team has a total skill of 6.
        // The sum of the chemistry of all the teams is: 1 * 5 + 2 * 4 + 3 * 3 = 5 + 8 + 9 = 22.

        // Example 2:
        //
        // Input: skill = [3,4]
        // Output: 12
        // Explanation: 
        // The two players form a team with a total skill of 7.
        // The chemistry of the team is 3 * 4 = 12.

        // Example 3:
        //
        // Input: skill = [1,1,2,3]
        // Output: -1
        // Explanation: 
        // There is no way to divide the players into teams such that the total skill of each team is equal.

        Solution solution = new();

        Console.WriteLine(solution.DividePlayers([3, 2, 5, 1, 3, 4]));
        Console.WriteLine(solution.DividePlayers([3, 4]));
        Console.WriteLine(solution.DividePlayers([1, 1, 2, 3]));
    }

    public long DividePlayers(int[] skill)
    {
        Array.Sort(skill);
        int n = skill.Length;
        int targetSum = skill[0] + skill[n - 1];
        long sumProduct = 0;

        for (int i = 0; i < n / 2; i++)
        {
            if (skill[i] + skill[n - 1 - i] != targetSum)
            {
                return -1;
            }

            sumProduct += (long)skill[i] * skill[n - 1 - i];
        }

        return sumProduct;
    }
}