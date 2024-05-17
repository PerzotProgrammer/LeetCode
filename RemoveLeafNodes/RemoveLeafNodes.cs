namespace RemoveLeafNodes;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,2,3,2,null,2,4], target = 2
        // Output: [1,null,3,null,4]
        // Explanation: Leaf nodes in green with value (target = 2) are removed (Picture in left). 
        // After removing, new nodes become leaf nodes with value (target = 2) (Picture in center).

        // Example 2:
        //
        // Input: root = [1,3,3,3,2], target = 3
        // Output: [1,3,null,null,2]

        // Example 3:
        //
        // Input: root = [1,2,null,2,null,2], target = 2
        // Output: [1]
        // Explanation: Leaf nodes in green with value (target = 2) are removed at each step.


        Solution solution = new();

        TreeNode a4 = new(4, null, null);
        TreeNode a21 = new(2, null, null);
        TreeNode a3 = new(3, a21, a4);
        TreeNode a22 = new(2, null, null);
        TreeNode a23 = new(2, a22, null);
        TreeNode a1 = new(1, a23, a3);

        TreeNode b31 = new(3, null, null);
        TreeNode b2 = new(2, null, null);
        TreeNode b32 = new(3, null, null);
        TreeNode b33 = new(3, b32, b2);
        TreeNode b1 = new(1, b33, b31);

        TreeNode c21 = new(2, null, null);
        TreeNode c22 = new(2, c21, null);
        TreeNode c23 = new(2, c22, null);
        TreeNode c1 = new(1, c23, null);

        PrintTreeBfs(solution.RemoveLeafNodes(a1, 2));
        PrintTreeBfs(solution.RemoveLeafNodes(b1, 3));
        PrintTreeBfs(solution.RemoveLeafNodes(c1, 2));
    }

    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        if (root == null) return null!;

        root.left = RemoveLeafNodes(root.left, target);
        root.right = RemoveLeafNodes(root.right, target);

        if (root.left == null && root.right == null && root.val == target) return null!;

        return root;
    }

    static void PrintTreeBfs(TreeNode root)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            Console.Write($"{current.val}, ");
            if (current.left != null) queue.Enqueue(current.left);
            else Console.Write("Null, ");
            if (current.right != null) queue.Enqueue(current.right);
        }

        Console.WriteLine();
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