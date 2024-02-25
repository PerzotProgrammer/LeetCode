namespace CanTraverseAllPairs;

class Solution
{
    static void Main()
    {
        // Pomoc editoriala
        // Example 1:
        //
        // Input: nums = [2,3,6]
        // Output: true
        // Explanation: In this example, there are 3 possible pairs of indices: (0, 1), (0, 2), and (1, 2).
        // To go from index 0 to index 1, we can use the sequence of traversals 0 -> 2 -> 1, where we move from index 0 to index 2 because gcd(nums[0], nums[2]) = gcd(2, 6) = 2 > 1, and then move from index 2 to index 1 because gcd(nums[2], nums[1]) = gcd(6, 3) = 3 > 1.
        // To go from index 0 to index 2, we can just go directly because gcd(nums[0], nums[2]) = gcd(2, 6) = 2 > 1. Likewise, to go from index 1 to index 2, we can just go directly because gcd(nums[1], nums[2]) = gcd(3, 6) = 3 > 1.

        // Example 2:
        //
        // Input: nums = [3,9,5]
        // Output: false
        // Explanation: No sequence of traversals can take us from index 0 to index 2 in this example. So, we return false.

        // Example 3:
        //
        // Input: nums = [4,3,12,8]
        // Output: true
        // Explanation: There are 6 possible pairs of indices to traverse between: (0, 1), (0, 2), (0, 3), (1, 2), (1, 3), and (2, 3). A valid sequence of traversals exists for each pair, so we return true.   

        Solution solution = new();

        Console.WriteLine(solution.CanTraverseAllPairs([2, 3, 6]));
        Console.WriteLine(solution.CanTraverseAllPairs([3, 9, 5]));
        Console.WriteLine(solution.CanTraverseAllPairs([4, 3, 12, 8]));
    }

    public bool CanTraverseAllPairs(int[] nums)
    {
        int MAX = 100000;
        int N = nums.Length;
        bool[] has = new bool[MAX + 1];
        for (int i = 0; i < N; i++) has[nums[i]] = true;

        if (N == 1) return true;
        if (has[1]) return false;

        int[] sieve = new int[MAX + 1];
        for (int d = 2; d <= MAX; d++)
        {
            if (sieve[d] == 0)
            {
                for (int v = d; v <= MAX; v += d) sieve[v] = d;
            }
        }

        DSU union = new(2 * MAX + 1);
        for (int i = 0; i < N; i++)
        {
            int val = nums[i];
            while (val > 1)
            {
                int prime = sieve[val];
                int root = prime + MAX;
                if (union.Find(root) != union.Find(nums[i])) union.Merge(root, nums[i]);

                while (val % prime == 0) val /= prime;
            }
        }

        int cnt = 0;
        for (int i = 2; i <= MAX; i++)
        {
            if (has[i] && union.Find(i) == i) cnt++;
        }

        return cnt == 1;
    }
}

public class DSU
{
    public int[] dsu;
    public int[] size;

    public DSU(int N)
    {
        dsu = new int[N + 1];
        size = new int[N + 1];
        for (int i = 0; i <= N; i++)
        {
            dsu[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x)
    {
        return dsu[x] == x ? x : (dsu[x] = Find(dsu[x]));
    }

    public void Merge(int x, int y)
    {
        int fx = Find(x);
        int fy = Find(y);
        if (fx == fy) return;

        if (size[fx] > size[fy]) (fx, fy) = (fy, fx);

        dsu[fx] = fy;
        size[fy] += size[fx];
    }
}