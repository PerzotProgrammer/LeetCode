namespace DiameterOfBinaryTree;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,2,3,4,5]
        // Output: 3
        // Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].

        // Example 2:
        //
        // Input: root = [1,2]
        // Output: 1

        Solution solution = new();

        TreeNode a5 = new(5, null, null);
        TreeNode a4 = new(4, null, null);
        TreeNode a3 = new(3, null, null);
        TreeNode a2 = new(2, a4, a5);
        TreeNode a1 = new(5, a2, a3);

        TreeNode b2 = new(2, null, null);
        TreeNode b1 = new(1, b2, null);

        Console.WriteLine(solution.DiameterOfBinaryTree(a1));
        Console.WriteLine(solution.DiameterOfBinaryTree(b1));
    }

    private int result;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        result = 0;
        FindDiameter(root);
        return result;
    }

    private int FindDiameter(TreeNode node)
    {
        if (node == null) return 0;
        int left = FindDiameter(node.left);
        int right = FindDiameter(node.right);
        result = Math.Max(result, right + left);
        return Math.Max(right, left) + 1;
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