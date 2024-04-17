namespace SmallestFromLeaf;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [0,1,2,3,4,3,4]
        // Output: "dba"

        // Example 2:
        //
        // Input: root = [25,1,3,1,3,0,2]
        // Output: "adz"

        // Example 3:
        //
        // Input: root = [2,2,1,null,1,0,null,0]
        // Output: "abc"

        Solution solution = new();

        TreeNode a41 = new(4, null, null);
        TreeNode a42 = new(4, null, null);
        TreeNode a31 = new(3, null, null);
        TreeNode a32 = new(3, null, null);
        TreeNode a1 = new(1, a31, a41);
        TreeNode a2 = new(2, a32, a42);
        TreeNode a0 = new(0, a1, a2);

        TreeNode b2 = new(2, null, null);
        TreeNode b0 = new(0, null, null);
        TreeNode b31 = new(3, b0, b2);
        TreeNode b11 = new(1, null, null);
        TreeNode b32 = new(3, null, null);
        TreeNode b12 = new(1, b32, b11);
        TreeNode b25 = new(25, b12, b31);

        TreeNode c01 = new(0, null, null);
        TreeNode c02 = new(0, null, null);
        TreeNode c11 = new(1, c01, null);
        TreeNode c12 = new(1, c02, null);
        TreeNode c21 = new(2, null, c12);
        TreeNode c22 = new(2, c21, c11);

        Console.WriteLine(solution.SmallestFromLeaf(a0));
        Console.WriteLine(solution.SmallestFromLeaf(b25));
        Console.WriteLine(solution.SmallestFromLeaf(c22));
    }

    public string SmallestFromLeaf(TreeNode root)
    {
        Queue<TreeNode> queue = new();
        Dictionary<TreeNode, string> nodeToSuffix = new();
        queue.Enqueue(root);
        nodeToSuffix.Add(root, ((char)('a' + root.val)).ToString());

        string output = null!;

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            string suffix = nodeToSuffix[node];

            if (node.left == null && node.right == null)
            {
                if (output == null || suffix.CompareTo(output) < 0) output = suffix;
            }

            if (node.left != null)
            {
                queue.Enqueue(node.left);
                nodeToSuffix[node.left] = ((char)('a' + node.left.val)) + suffix;
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
                nodeToSuffix[node.right] = ((char)('a' + node.right.val)) + suffix;
            }
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