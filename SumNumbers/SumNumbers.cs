namespace SumNumbers;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,2,3]
        // Output: 25
        // Explanation:
        // The root-to-leaf path 1->2 represents the number 12.
        // The root-to-leaf path 1->3 represents the number 13.
        // Therefore, sum = 12 + 13 = 25.

        // Example 2:
        //
        // Input: root = [4,9,0,5,1]
        // Output: 1026
        // Explanation:
        // The root-to-leaf path 4->9->5 represents the number 495.
        // The root-to-leaf path 4->9->1 represents the number 491.
        // The root-to-leaf path 4->0 represents the number 40.
        // Therefore, sum = 495 + 491 + 40 = 1026.

        Solution solution = new();

        TreeNode a3 = new(3, null, null);
        TreeNode a2 = new(2, null, null);
        TreeNode a1 = new(1, a2, a3);

        TreeNode b5 = new(5, null, null);
        TreeNode b1 = new(1, null, null);
        TreeNode b9 = new(9, b5, b1);
        TreeNode b0 = new(0, null, null);
        TreeNode b4 = new(4, b9, b0);

        Console.WriteLine(solution.SumNumbers(a1));
        Console.WriteLine(solution.SumNumbers(b4));
    }

    public int SumNumbers(TreeNode root)
    {
        if (root == null) return 0;

        int output = 0;
        Queue<TreeNode> nodes = new();
        Queue<int> sums = new();

        nodes.Enqueue(root);
        sums.Enqueue(root.val);

        while (nodes.Count > 0)
        {
            TreeNode node = nodes.Dequeue();
            int currentSum = sums.Dequeue();

            if (node.left == null && node.right == null) output += currentSum;
            if (node.left != null)
            {
                nodes.Enqueue(node.left);
                sums.Enqueue(currentSum * 10 + node.left.val);
            }

            if (node.right != null)
            {
                nodes.Enqueue(node.right);
                sums.Enqueue(currentSum * 10 + node.right.val);
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