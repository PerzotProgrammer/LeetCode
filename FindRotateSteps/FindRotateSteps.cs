namespace FindRotateSteps;

class Solution
{
    static void Main()
    {
        // Wielka pomoc LeetCode: https://leetcode.com/problems/freedom-trail/solutions/5077481/c-solution-for-freedom-trail-problem/?envType=daily-question&envId=2024-04-27
        // Example 1:
        //
        // Input: ring = "godding", key = "gd"
        // Output: 4
        // Explanation:
        // For the first key character 'g', since it is already in place, we just need 1 step to spell this character. 
        // For the second key character 'd', we need to rotate the ring "godding" anticlockwise by two steps to make it become "ddinggo".
        // Also, we need 1 more step for spelling.
        // So the final output is 4.
       
        // Example 2:
        //
        // Input: ring = "godding", key = "godding"
        // Output: 13

        Solution solution = new();

        Console.WriteLine(solution.FindRotateSteps("godding", "gd"));
        Console.WriteLine(solution.FindRotateSteps("godding", "godding"));
    }

    public int FindRotateSteps(string ring, string key)
    {
        Dictionary<string, int> memo = new();
        return DFS(ring, key, 0, memo);
    }

    private int DFS(string ring, string key, int index, Dictionary<string, int> memo)
    {
        if (index == key.Length) return 0;
        string keyRing = ring + index;
        if (memo.TryGetValue(keyRing, out int value)) return value;

        char target = key[index];
        int minSteps = int.MaxValue;

        for (int i = 0; i < ring.Length; i++)
        {
            if (ring[i] == target)
            {
                int stepsToRotate = Math.Min(i, ring.Length - i);
                string rotatedRing = RotateRing(ring, i);
                int steps = stepsToRotate + 1 + DFS(rotatedRing, key, index + 1, memo);
                minSteps = Math.Min(minSteps, steps);
            }
        }

        memo[keyRing] = minSteps;
        return minSteps;
    }

    private string RotateRing(string ring, int steps)
    {
        return ring.Substring(steps) + ring.Substring(0, steps);
    }
}