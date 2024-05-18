namespace DistributeCoins;

public class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [3,0,0]
        // Output: 2
        // Explanation: From the root of the tree, we move one coin to its left child, and one coin to its right child.

        // Example 2:
        //
        //Input: root = [0,3,0]
        //Output: 3
        //Explanation: From the left child of the root, we move two coins to the root [taking two moves]. Then, we move one coin from the root of the tree to the right child.

        Solution solution = new();

        TreeNode a01 = new(0, null, null);
        TreeNode a02 = new(0, null, null);
        TreeNode a3 = new(3, a01, a02);

        TreeNode b01 = new(0, null, null);
        TreeNode b3 = new(3, null, null);
        TreeNode b02 = new(0, b3, b01);

        Console.WriteLine(solution.DistributeCoins(a3));
        solution.Moves = 0;
        Console.WriteLine(solution.DistributeCoins(b02));
    }

    private int Moves = 0;

    public int Dfs(TreeNode node)
    {
        if (node == null) return 0;
        int left = Dfs(node.left);
        int right = Dfs(node.right);
        Moves += Math.Abs(left) + Math.Abs(right);

        return node.val + left + right - 1;
    }

    public int DistributeCoins(TreeNode root)
    {
        Dfs(root);
        return Moves;
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