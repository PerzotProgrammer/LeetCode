namespace FlipEquiv;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Flipped Trees Diagram
        // Input: root1 = [1,2,3,4,5,6,null,null,null,7,8], root2 = [1,3,2,null,6,4,5,null,null,null,null,8,7]
        // Output: true
        // Explanation: We flipped at nodes with values 1, 3, and 5.

        // Example 2:
        //
        // Input: root1 = [], root2 = []
        // Output: true

        // Example 3:
        //
        // Input: root1 = [], root2 = [1]
        // Output: false

        Solution solution = new();

        TreeNode a8 = new(8, null, null);
        TreeNode a7 = new(7, null, null);
        TreeNode a6 = new(6, null, null);
        TreeNode a5 = new(5, a7, a8);
        TreeNode a4 = new(4, null, null);
        TreeNode a3 = new(3, a6, null);
        TreeNode a2 = new(2, a4, a5);
        TreeNode a1 = new(1, a2, a3);

        TreeNode b7 = new(7, null, null);
        TreeNode b8 = new(8, null, null);
        TreeNode b6 = new(6, null, null);
        TreeNode b5 = new(5, b8, b7);
        TreeNode b4 = new(4, null, null);
        TreeNode b3 = new(3, null, b6);
        TreeNode b2 = new(2, b4, b5);
        TreeNode b1 = new(1, b3, b2);

        TreeNode c1 = new(1, null, null);

        Console.WriteLine(solution.FlipEquiv(a1, b1));
        Console.WriteLine(solution.FlipEquiv(null, null));
        Console.WriteLine(solution.FlipEquiv(null, c1));
    }

    public bool FlipEquiv(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) return true;
        if (root1 == null || root2 == null) return false;
        if (root1.val != root2.val) return false;

        bool noSwap =
            FlipEquiv(root1.left, root2.left) &&
            FlipEquiv(root1.right, root2.right);
        bool swap =
            FlipEquiv(root1.left, root2.right) &&
            FlipEquiv(root1.right, root2.left);

        return noSwap || swap;
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