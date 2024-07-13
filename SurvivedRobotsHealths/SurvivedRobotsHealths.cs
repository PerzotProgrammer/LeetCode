namespace SurvivedRobotsHealths;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: positions = [5,4,3,2,1], healths = [2,17,9,15,10], directions = "RRRRR"
        // Output: [2,17,9,15,10]
        // Explanation: No collision occurs in this example, since all robots are moving in the same direction. So, the health of the robots in order from the first robot is returned, [2, 17, 9, 15, 10].

        // Example 2:
        //
        // Input: positions = [3,5,2,6], healths = [10,10,15,12], directions = "RLRL"
        // Output: [14]
        // Explanation: There are 2 collisions in this example. Firstly, robot 1 and robot 2 will collide, and since both have the same health, they will be removed from the line. Next, robot 3 and robot 4 will collide and since robot 4's health is smaller, it gets removed, and robot 3's health becomes 15 - 1 = 14. Only robot 3 remains, so we return [14].

        // Example 3:
        //
        // Input: positions = [1,2,5,6], healths = [10,10,11,11], directions = "RLRL"
        // Output: []
        // Explanation: Robot 1 and robot 2 will collide and since both have the same health, they are both removed. Robot 3 and 4 will collide and since both have the same health, they are both removed. So, we return an empty array, [].


        Solution solution = new();

        PrintList(solution.SurvivedRobotsHealths([5, 4, 3, 2, 1], [2, 17, 9, 15, 10], "RRRRR"));
        PrintList(solution.SurvivedRobotsHealths([3, 5, 2, 6], [10, 10, 15, 12], "RLRL"));
        PrintList(solution.SurvivedRobotsHealths([1, 2, 5, 6], [10, 10, 11, 11], "RLRL"));
    }

    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        int n = positions.Length;
        int[] indices = new int[n];
        for (int i = 0; i < n; i++) indices[i] = i;

        Array.Sort(indices, (i, j) => positions[i].CompareTo(positions[j]));

        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < n; i++)
        {
            int currentIndex = indices[i];
            if (directions[currentIndex] == 'R') stack.Push(currentIndex);
            else
            {
                while (stack.Count > 0 && healths[currentIndex] > 0)
                {
                    int j = stack.Pop();
                    if (healths[j] > healths[currentIndex])
                    {
                        healths[j]--;
                        healths[currentIndex] = 0;
                        stack.Push(j);
                    }
                    else if (healths[j] < healths[currentIndex])
                    {
                        healths[currentIndex]--;
                        healths[j] = 0;
                    }
                    else
                    {
                        healths[currentIndex] = 0;
                        healths[j] = 0;
                        break;
                    }
                }
            }
        }

        List<int> result = new();
        for (int i = 0; i < n; i++)
        {
            if (healths[i] > 0) result.Add(healths[i]);
        }

        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
        Console.WriteLine();
    }
}