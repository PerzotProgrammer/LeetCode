namespace AddOneRow;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: root = [4,2,6,3,1,5], val = 1, depth = 2
        // Output: [4,1,1,2,null,null,6,3,1,5]

        // Example 2:
        //
        // Input: root = [4,2,null,3,1], val = 1, depth = 3
        // Output: [4,2,null,1,1,3,null,null,1]

        Solution solution = new();

        TreeNode a3 = new(3, null, null);
        TreeNode a1 = new(1, null, null);
        TreeNode a2 = new(2, a3, a1);
        TreeNode a5 = new(5, null, null);
        TreeNode a6 = new(6, a5, null);
        TreeNode a4 = new(4, a2, a6);

        TreeNode b3 = new(3, null, null);
        TreeNode b1 = new(1, null, null);
        TreeNode b2 = new(2, b3, b1);
        TreeNode b4 = new(4, b2, null);
        
        BfsPrint(solution.AddOneRow(a4, 1, 2));
        BfsPrint(solution.AddOneRow(b4, 1, 3));
    }

    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (depth == 1)
        {
            TreeNode newRoot = new(val);
            newRoot.left = root;
            return newRoot;
        }

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int currentDepth = 1;

        while (queue.Count > 0 && currentDepth < depth - 1)
        {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            currentDepth++;
        }

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            TreeNode leftChild = new(val);
            leftChild.left = node.left;
            node.left = leftChild;

            TreeNode rightChild = new(val);
            rightChild.right = node.right;
            node.right = rightChild;
        }

        return root;
    }

    static void BfsPrint(TreeNode root)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            Console.Write($"{current.val} -> ");
            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);
        }

        Console.WriteLine("END");
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