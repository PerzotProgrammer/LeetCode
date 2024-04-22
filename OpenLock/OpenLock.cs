namespace OpenLock;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
        // Output: 6
        // Explanation: 
        // A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" -> "1201" -> "1202" -> "0202".
        // Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202" would be invalid,
        // because the wheels of the lock become stuck after the display becomes the dead end "0102".

        // Example 2:
        //
        // Input: deadends = ["8888"], target = "0009"
        // Output: 1
        // Explanation: We can turn the last wheel in reverse to move from "0000" -> "0009".

        // Example 3:
        //
        // Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"], target = "8888"
        // Output: -1
        // Explanation: We cannot reach the target without getting stuck.

        Solution solution = new();

        Console.WriteLine(solution.OpenLock(["0201", "0101", "0102", "1212", "2002"], "0202"));
        Console.WriteLine(solution.OpenLock(["8888"], "0009"));
        Console.WriteLine(solution.OpenLock(["8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888"], "8888"));
    }

    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> deadSet = new(deadends);
        HashSet<string> visited = new();
        Queue<string> queue = new();
        queue.Enqueue("0000");
        visited.Add("0000");
        int level = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                string current = queue.Dequeue();
                if (deadSet.Contains(current)) continue;
                if (current == target) return level;

                for (int j = 0; j < 4; j++)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        char[] currentArray = current.ToCharArray();
                        int digit = (currentArray[j] - '0' + k + 10) % 10;
                        currentArray[j] = (char)(digit + '0');
                        string next = new string(currentArray);
                        if (!visited.Contains(next) && !deadSet.Contains(next))
                        {
                            queue.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }
            }

            level++;
        }

        return -1;
    }
}