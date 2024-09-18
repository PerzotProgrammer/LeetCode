namespace LargestNumber;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: nums = [10,2]
        // Output: "210"
        // Example 2:
        //
        // Input: nums = [3,30,34,5,9]
        // Output: "9534330"


        Solution solution = new();

        Console.WriteLine(solution.LargestNumber([10, 2]));
        Console.WriteLine(solution.LargestNumber([3, 30, 34, 5, 9]));
    }

    public string LargestNumber(int[] nums)
    {
        string[] numStrs = new string[nums.Length];

        for (int i = 0; i < nums.Length; i++) numStrs[i] = nums[i].ToString();
        Array.Sort(numStrs, (a, b) => string.Compare(b + a, a + b, StringComparison.Ordinal));

        if (numStrs[0] == "0") return "0";

        string output = "";
        foreach (string numStr in numStrs) output += numStr;

        return output;
    }
}