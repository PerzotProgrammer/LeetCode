namespace CompareVersion;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: version1 = "1.01", version2 = "1.001"
        // Output: 0
        // Explanation: Ignoring leading zeroes, both "01" and "001" represent the same integer "1".

        // Example 2:
        //
        // Input: version1 = "1.0", version2 = "1.0.0"
        // Output: 0
        // Explanation: version1 does not specify revision 2, which means it is treated as "0".

        // Example 3:
        //
        // Input: version1 = "0.1", version2 = "1.1"
        // Output: -1
        // Explanation: version1's revision 0 is "0", while version2's revision 0 is "1". 0 < 1, so version1 < version2.

        Solution solution = new();

        Console.WriteLine(solution.CompareVersion("1.01", "1.001"));
        Console.WriteLine(solution.CompareVersion("1.0", "1.0.0"));
        Console.WriteLine(solution.CompareVersion("0.1", "1.1"));
    }

    public int CompareVersion(string version1, string version2)
    {
        int i = 0;
        int j = 0;

        while (i < version1.Length || j < version2.Length)
        {
            int num1 = 0;
            int num2 = 0;

            while (i < version1.Length && version1[i] != '.')
            {
                num1 = num1 * 10 + int.Parse(version1[i].ToString());
                i++;
            }

            while (j < version2.Length && version2[j] != '.')
            {
                num2 = num2 * 10 + int.Parse(version2[j].ToString());
                j++;
            }

            if (num1 < num2) return -1;
            if (num1 > num2) return 1;

            i++;
            j++;
        }

        return 0;
    }
}