namespace RangeSumBST;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
        // Output: 32
        // Explanation: Nodes 7, 10, and 15 are in the range [7, 15]. 7 + 10 + 15 = 32.
        //     Example 2:
        //
        //
        // Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
        // Output: 23
        // Explanation: Nodes 6, 7, and 10 are in the range [6, 10]. 6 + 7 + 10 = 23.

        TreeNode a18 = new(18, null, null);
        TreeNode a15 = new(15, null, a18);
        TreeNode a7 = new(7, null, null);
        TreeNode a3 = new(3, null, null);
        TreeNode a5 = new(5, a3, a7);
        TreeNode a10 = new(10, a5, a15);

        TreeNode b18 = new(18, null, null);
        TreeNode b13 = new(13, null, null);
        TreeNode b15 = new(15, b13, b18);
        TreeNode b6 = new(6, null, null);
        TreeNode b7 = new(7, b6, null);
        TreeNode b1 = new(1, null, null);
        TreeNode b3 = new(3, b1, null);
        TreeNode b5 = new(5, b3, b7);
        TreeNode b10 = new(10, b5, b15);

        Solution solution = new();

        Console.WriteLine(solution.RangeSumBST(a10, 7, 15));
        Console.WriteLine(solution.RangeSumBST(b10, 6, 10));
    }

    public int RangeSumBST(TreeNode root, int low, int high)
    {
        int count = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            if (current == null) continue;
            if (current.val < low)
            {
                queue.Enqueue(current.right);
            }
            else if (current.val > high)
            {
                queue.Enqueue(current.left);
            }
            else
            {
                count += current.val;
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
        }

        return count;
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