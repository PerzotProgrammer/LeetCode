namespace FindBottomLeftValue;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [2,1,3]
        // Output: 1

        // Example 2:
        //
        // Input: root = [1,2,3,4,null,5,6,null,null,7]
        // Output: 7

        Solution solution = new();

        TreeNode a3 = new(3, null, null);
        TreeNode a1 = new(1, null, null);
        TreeNode a2 = new(2, a1, a3);

        TreeNode b7 = new(7, null, null);
        TreeNode b6 = new(6, null, null);
        TreeNode b5 = new(5, b7, null);
        TreeNode b4 = new(4, null, null);
        TreeNode b3 = new(3, b5, b6);
        TreeNode b2 = new(2, b4, null);
        TreeNode b1 = new(1, b2, b3);

        Console.WriteLine(solution.FindBottomLeftValue(a2));
        Console.WriteLine(solution.FindBottomLeftValue(b1));
    }

    private int leftmostValue = -1;
    private int maxDepth = -1;

    public int FindBottomLeftValue(TreeNode root)
    {
        DFS(root, 0);
        return leftmostValue;
    }

    private void DFS(TreeNode node, int depth)
    {
        if (node == null) return;
        if (depth > maxDepth)
        {
            leftmostValue = node.val;
            maxDepth = depth;
        }

        DFS(node.left, depth + 1);
        DFS(node.right, depth + 1);
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