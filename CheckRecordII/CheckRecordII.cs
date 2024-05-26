namespace CheckRecordII;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/student-attendance-record-ii/solutions/3792839/simple-o-n-intuitive-solution/?envType=daily-question&envId=2024-05-26
        // Example 1:
        //
        // Input: n = 2
        // Output: 8
        // Explanation: There are 8 records with length 2 that are eligible for an award:
        // "PP", "AP", "PA", "LP", "PL", "AL", "LA", "LL"
        // Only "AA" is not eligible because there are 2 absences (there need to be fewer than 2).
        //     Example 2:
        //
        // Input: n = 1
        // Output: 3
        // Example 3:
        //
        // Input: n = 10101
        // Output: 183236316

        Solution solution = new();

        Console.WriteLine(solution.CheckRecord(2));
        Console.WriteLine(solution.CheckRecord(1));
        Console.WriteLine(solution.CheckRecord(10101));
    }

    public int CheckRecord(int n)
    {
        long dp0 = 1;
        long dp1 = 1;
        long dp2 = 0;
        long dp3 = 1;
        long dp4 = 0;
        long dp5 = 0;

        for (int i = 1; i < n; i++)
        {
            long nextdp0 = dp0 + dp1 + dp2;
            long nextdp1 = dp0;
            long nextdp2 = dp1;
            long nextdp3 = dp0 + dp1 + dp2 + dp3 + dp4 + dp5;
            long nextdp4 = dp3;
            long nextdp5 = dp4;
            dp0 = nextdp0 % 1000000007;
            dp1 = nextdp1 % 1000000007;
            dp2 = nextdp2 % 1000000007;
            dp3 = nextdp3 % 1000000007;
            dp4 = nextdp4 % 1000000007;
            dp5 = nextdp5 % 1000000007;
        }

        return (int)((dp0 + dp1 + dp2 + dp3 + dp4 + dp5) % 1000000007);
    }
}