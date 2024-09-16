namespace FindMinDifference;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: timePoints = ["23:59","00:00"]
        // Output: 1

        // Example 2:
        //
        // Input: timePoints = ["00:00","23:59","00:00"]
        // Output: 0


        Solution solution = new();

        Console.WriteLine(solution.FindMinDifference(["23:59", "00:00"]));
        Console.WriteLine(solution.FindMinDifference(["00:00", "23:59", "00:00"]));
    }

    public int FindMinDifference(IList<string> timePoints)
    {
        int[] minutes = new int[timePoints.Count];
        for (int i = 0; i < timePoints.Count; i++)
        {
            String time = timePoints[i];
            int h = int.Parse(time.Substring(0, 2));
            int m = int.Parse(time.Substring(3));
            minutes[i] = h * 60 + m;
        }

        Array.Sort(minutes);

        int ans = int.MaxValue;
        for (int i = 0; i < minutes.Length - 1; i++)
        {
            ans = Math.Min(ans, minutes[i + 1] - minutes[i]);
        }

        return Math.Min(ans, 24 * 60 - minutes[^1] + minutes[0]);
    }
}