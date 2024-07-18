namespace CountPairs;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/number-of-good-leaf-nodes-pairs/solutions/5494822/c-solution-for-number-of-good-leaf-nodes-pairs-problem/?envType=daily-question&envId=2024-07-18
        // Example 1:
        //
        // Input: root = [1,2,3,null,4], distance = 3
        // Output: 1
        // Explanation: The leaf nodes of the tree are 3 and 4 and the length of the shortest path between them is 3. This is the only good pair.

        // Example 2:
        //
        // Input: root = [1,2,3,4,5,6,7], distance = 3
        // Output: 2
        // Explanation: The good pairs are [4,5] and [6,7] with shortest path = 2. The pair [4,6] is not good because the length of ther shortest path between them is 4.

        // Example 3:
        //
        // Input: root = [7,1,4,6,null,5,3,null,null,null,null,null,2], distance = 3
        // Output: 1
        // Explanation: The only good pair is [2,5].

        TreeNode a3 = new(3, null, null);
        TreeNode a4 = new(4, null, null);
        TreeNode a2 = new(2, null, a4);
        TreeNode a1 = new(1, a2, a3);

        TreeNode b7 = new(7, null, null);
        TreeNode b6 = new(6, null, null);
        TreeNode b5 = new(5, null, null);
        TreeNode b4 = new(4, null, null);
        TreeNode b3 = new(3, b6, b7);
        TreeNode b2 = new(2, b4, b5);
        TreeNode b1 = new(1, b2, b3);

        Solution solution = new();

        Console.WriteLine(solution.CountPairs(a1, 3));
        Console.WriteLine(solution.CountPairs(b1, 3));
    }

    public int CountPairs(TreeNode root, int distance)
    {
        int count = 0;
        CountPairsHelper(root, distance, ref count);
        return count;
    }

    private int[] CountPairsHelper(TreeNode node, int distance, ref int count)
    {
        if (node == null) return new int[distance + 1];

        if (node.left == null && node.right == null)
        {
            int[] leafDistances = new int[distance + 1];
            leafDistances[1] = 1;
            return leafDistances;
        }

        int[] leftDistances = CountPairsHelper(node.left, distance, ref count);
        int[] rightDistances = CountPairsHelper(node.right, distance, ref count);

        for (int i = 1; i <= distance; i++)
        {
            for (int j = 1; j <= distance; j++)
            {
                if (i + j <= distance) count += leftDistances[i] * rightDistances[j];
            }
        }

        int[] currentDistances = new int[distance + 1];
        for (int i = 1; i < distance; i++)
        {
            currentDistances[i + 1] = leftDistances[i] + rightDistances[i];
        }

        return currentDistances;
    }
}

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}