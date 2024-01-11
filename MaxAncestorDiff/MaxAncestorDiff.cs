namespace MaxAncestorDiff;

class Solution
{
    static void Main()
    {
        //Pomoc z wątku: https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/solutions/4543827/c-solution-for-maximum-difference-between-node-and-ancestor-problem/?envType=daily-question&envId=2024-01-11
        
        
        // Example 1:
        //
        // Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
        // Output: 7
        // Explanation: We have various ancestor-node differences, some of which are given below :
        //     |8 - 3| = 5
        //     |3 - 7| = 4
        //     |8 - 1| = 7
        //     |10 - 13| = 3
        // Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.

        //     Example 2:
        //
        // Input: root = [1,null,2,null,0,3]
        // Output: 3

        TreeNode a1 = new(1, null, null);
        TreeNode a4 = new(4, null, null);
        TreeNode a7 = new(7, null, null);
        TreeNode a13 = new(13, null, null);
        TreeNode a6 = new(6, a4, a7);
        TreeNode a3 = new(3, a1, a6);
        TreeNode a14 = new(14, a13, null);
        TreeNode a10 = new(10, null, a14);
        TreeNode a8 = new(8, a3, a10);
        
        TreeNode b3 = new(3, null, null);
        TreeNode b0 = new(0, b3, null);
        TreeNode b2 = new(2, null, b0);
        TreeNode b1 = new(1, null, b2);

        Solution solution = new();

        Console.WriteLine(solution.MaxAncestorDiff(a8));
        Console.WriteLine(solution.MaxAncestorDiff(b1));
        
    }

    public int MaxAncestorDiff(TreeNode root)
    {
        return FindMaxAncestorDiff(root, root.val, root.val);
    }

    private int FindMaxAncestorDiff(TreeNode node, int minAncestor, int maxAncestor)
    {
        if (node == null) return 0;

        int currentDiff = Math.Max(Math.Abs(node.val - minAncestor), Math.Abs(node.val - maxAncestor));

        minAncestor = Math.Min(minAncestor, node.val);
        maxAncestor = Math.Max(maxAncestor, node.val);

        int leftDiff = FindMaxAncestorDiff(node.left, minAncestor, maxAncestor);
        int rightDiff = FindMaxAncestorDiff(node.right, minAncestor, maxAncestor);

        return Math.Max(currentDiff, Math.Max(leftDiff, rightDiff));
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