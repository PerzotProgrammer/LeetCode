namespace EvaluateTree;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [2,1,3,null,null,0,1]
        // Output: true
        // Explanation: The above diagram illustrates the evaluation process.
        // The AND node evaluates to False AND True = False.
        // The OR node evaluates to True OR False = True.
        // The root node evaluates to True, so we return true.

        // Example 2:
        //
        // Input: root = [0]
        // Output: false
        // Explanation: The root node is a leaf node and it evaluates to false, so we return false.


        Solution solution = new();

        TreeNode a11 = new(1, null, null);
        TreeNode a0 = new(0, null, null);
        TreeNode a3 = new(3, a0, a11);
        TreeNode a12 = new(1, null, null);
        TreeNode a2 = new(2, a12, a3);

        TreeNode b0 = new(0, null, null);

        Console.WriteLine(solution.EvaluateTree(a2));
        Console.WriteLine(solution.EvaluateTree(b0));
    }

    public bool EvaluateTree(TreeNode root)
    {
        if (root == null) return false;
        if (root.left == null && root.right == null) return root.val == 1;

        if (root.val == 2) return EvaluateTree(root.left!) || EvaluateTree(root.right);
        return EvaluateTree(root.left!) && EvaluateTree(root.right);
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