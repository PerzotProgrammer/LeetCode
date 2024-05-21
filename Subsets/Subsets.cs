namespace Subsets;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: nums = [1,2,3]
        // Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

        // Example 2:
        //
        // Input: nums = [0]
        // Output: [[],[0]]


        Solution solution = new();

        PrintSubsets(solution.Subsets([1, 2, 3]));
        PrintSubsets(solution.Subsets([0]));
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> output = new List<IList<int>>();
        output.Add(new List<int>());
        foreach (int num in nums)
        {
            List<IList<int>> newSubsets = new List<IList<int>>();
            foreach (List<int> curr in output)
            {
                IList<int> temp = new List<int>(curr);
                temp.Add(num);
                newSubsets.Add(temp);
            }

            foreach (IList<int> curr in newSubsets) output.Add(curr);
        }

        return output;
    }


    static void PrintSubsets(IList<IList<int>> subsets)
    {
        foreach (IList<int> subset in subsets)
        {
            Console.Write("[");
            foreach (int i in subset)
            {
                Console.Write($" {i} ");
            }

            Console.Write("],");
        }

        Console.WriteLine();
    }
}