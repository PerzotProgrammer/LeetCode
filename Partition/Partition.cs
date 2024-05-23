namespace Partition;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: s = "aab"
        // Output: [["a","a","b"],["aa","b"]]
        
        // Example 2:
        //
        // Input: s = "a"
        // Output: [["a"]]


        Solution solution = new();
        
        PrintSubsets(solution.Partition("aab"));
        PrintSubsets(solution.Partition("a"));
    }

    public IList<IList<string>> Partition(string s)
    {
        int n = s.Length;
        List<IList<string>> result = new();

        Recursion(0, new());

        return result;

        void Recursion(int j, List<string> partition)
        {
            if (j >= n)
            {
                result.Add(new List<string>(partition));
                return;
            }

            for (int i = j; i < n; i++)
            {
                bool flag = true;
                int left = j;
                int right = i;

                while (left < right)
                {
                    if (s[left] != s[right])
                    {
                        flag = false;
                        break;
                    }

                    left++;
                    right--;
                }

                if (flag)
                {
                    partition.Add(s[j..(i + 1)]);
                    Recursion(i + 1, partition);
                    partition.RemoveAt(partition.Count - 1);
                }
            }
        }
    }

    static void PrintSubsets(IList<IList<string>> subsets)
    {
        foreach (IList<string> subset in subsets)
        {
            Console.Write("[");
            foreach (string i in subset)
            {
                Console.Write($" {i} ");
            }

            Console.Write("],");
        }

        Console.WriteLine();
    }
}