namespace FindAllPeople;

class Solution
{
    static void Main()
    {
        // Pomoc internetu: https://leetcode.com/problems/find-all-people-with-secret/solutions/4776663/c-solution-for-find-all-people-with-secret-problem/?envType=daily-question&envId=2024-02-24

        // Example 1:

        // Input: n = 6, meetings = [[1,2,5],[2,3,8],[1,5,10]], firstPerson = 1
        // Output: [0,1,2,3,5]
        // Explanation:
        // At time 0, person 0 shares the secret with person 1.
        // At time 5, person 1 shares the secret with person 2.
        // At time 8, person 2 shares the secret with person 3.
        // At time 10, person 1 shares the secret with person 5.
        // Thus, people 0, 1, 2, 3, and 5 know the secret after all the meetings.

        // Example 2:

        // Input: n = 4, meetings = [[3,1,3],[1,2,2],[0,3,3]], firstPerson = 3
        // Output: [0,1,3]
        // Explanation:
        // At time 0, person 0 shares the secret with person 3.
        // At time 2, neither person 1 nor person 2 know the secret.
        // At time 3, person 3 shares the secret with person 0 and person 1.
        // Thus, people 0, 1, and 3 know the secret after all the meetings.

        // Example 3:

        // Input: n = 5, meetings = [[3,4,2],[1,2,1],[2,3,1]], firstPerson = 1
        // Output: [0,1,2,3,4]
        // Explanation:
        // At time 0, person 0 shares the secret with person 1.
        // At time 1, person 1 shares the secret with person 2, and person 2 shares the secret with person 3.
        // Note that person 2 can share the secret at the same time as receiving it.
        // At time 2, person 3 shares the secret with person 4.
        // Thus, people 0, 1, 2, 3, and 4 know the secret after all the meetings.

        Solution solution = new();

        PrintList(solution.FindAllPeople(6, [[1, 2, 5], [2, 3, 8], [1, 5, 10]], 1));
        PrintList(solution.FindAllPeople(4, [[3, 1, 3], [1, 2, 2], [0, 3, 3]], 3));
        PrintList(solution.FindAllPeople(5, [[3, 4, 2], [1, 2, 1], [2, 3, 1]], 1));
    }

    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        Dictionary<int, List<int[]>> meetingMap = new();

        foreach (int[] meeting in meetings)
        {
            if (!meetingMap.ContainsKey(meeting[0])) meetingMap[meeting[0]] = new();
            meetingMap[meeting[0]].Add([meeting[2], meeting[1]]);
            if (!meetingMap.ContainsKey(meeting[1])) meetingMap[meeting[1]] = new();
            meetingMap[meeting[1]].Add([meeting[2], meeting[0]]);
        }

        int[] earliest = new int[n];
        Array.Fill(earliest, int.MaxValue);
        earliest[0] = earliest[firstPerson] = 0;

        Stack<int[]> stack = new();
        stack.Push([0, 0]);
        stack.Push([firstPerson, 0]);

        while (stack.Count > 0)
        {
            int[] current = stack.Pop();
            int person = current[0];
            int time = current[1];

            foreach (int[] neighbor in meetingMap.GetValueOrDefault(person, new()))
            {
                int t = neighbor[0];
                int nextPerson = neighbor[1];

                if (t >= time && earliest[nextPerson] > t)
                {
                    earliest[nextPerson] = t;
                    stack.Push([nextPerson, t]);
                }
            }
        }

        List<int> result = new();
        for (int i = 0; i < n; i++)
        {
            if (earliest[i] != int.MaxValue) result.Add(i);
        }

        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i},");
        Console.WriteLine();
    }
}