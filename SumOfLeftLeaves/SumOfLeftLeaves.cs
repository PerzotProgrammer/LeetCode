namespace SumOfLeftLeaves;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: root = [3,9,20,null,null,15,7]
        // Output: 24
        // Explanation: There are two left leaves in the binary tree, with values 9 and 15 respectively.

        // Example 2:
        //
        // Input: root = [1]
        // Output: 0

        Solution solution = new();

        TreeNode a7 = new(7, null, null);
        TreeNode a15 = new(15, null, null);
        TreeNode a20 = new(20, a15, a7);
        TreeNode a9 = new(9, null, null);
        TreeNode a3 = new(3, a9, a20);

        TreeNode b1 = new(1, null, null);

        Console.WriteLine(solution.SumOfLeftLeaves(a3));
        Console.WriteLine(solution.SumOfLeftLeaves(b1));
    }

    public int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null) return 0;

        int output = 0;
        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();

            if (current.left != null)
            {
                if (current.left.left == null && current.left.right == null) output += current.left.val;
                stack.Push(current.left);
            }

            if (current.right != null) stack.Push(current.right);
        }

        return output;
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