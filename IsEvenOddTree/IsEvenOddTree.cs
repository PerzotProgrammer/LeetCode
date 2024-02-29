namespace IsEvenOddTree;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,10,4,3,null,7,9,12,8,6,null,null,2]
        // Output: true
        // Explanation: The node values on each level are:
        // Level 0: [1]
        // Level 1: [10,4]
        // Level 2: [3,7,9]
        // Level 3: [12,8,6,2]
        // Since levels 0 and 2 are all odd and increasing and levels 1 and 3 are all even and decreasing, the tree is Even-Odd.

        // Example 2:
        //
        // Input: root = [5,4,2,3,3,7]
        // Output: false
        // Explanation: The node values on each level are:
        // Level 0: [5]
        // Level 1: [4,2]
        // Level 2: [3,3,7]
        // Node values in level 2 must be in strictly increasing order, so the tree is not Even-Odd.

        // Example 3:
        //
        // Input: root = [5,9,1,3,5,7]
        // Output: false
        // Explanation: Node values in the level 1 should be even integers.

        Solution solution = new();
        
        TreeNode a12 = new(12, null, null);
        TreeNode a8 = new(8, null, null);
        TreeNode a6 = new(6, null, null);
        TreeNode a2 = new(2, null, null);
        TreeNode a3 = new(3, a12, a8);
        TreeNode a7 = new(7, a6, null);
        TreeNode a9 = new(9, null, a2);
        TreeNode a10 = new(10, a3, null);
        TreeNode a4 = new(4, a7, a9);
        TreeNode a1 = new(1, a10, a4);

        TreeNode b31 = new(3, null, null);
        TreeNode b32 = new(3, null, null);
        TreeNode b7 = new(7, null, null);
        TreeNode b4 = new(4, b31, b32);
        TreeNode b2 = new(2, b7, null);
        TreeNode b5 = new(5, b4, b2);

        TreeNode c3 = new(3, null, null);
        TreeNode c51 = new(5, null, null);
        TreeNode c7 = new(7, null, null);
        TreeNode c9 = new(9, c3, c51);
        TreeNode c1 = new(1, c7, null);
        TreeNode c52 = new(5, c9, c1);
        
        Console.WriteLine(solution.IsEvenOddTree(a1));
        Console.WriteLine(solution.IsEvenOddTree(b5));
        Console.WriteLine(solution.IsEvenOddTree(c52));





    }

    public bool IsEvenOddTree(TreeNode root)
    {
        if (root == null) return true;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int level = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            int? prevVal = null;

            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();

                if (level % 2 == 0)
                {
                    if (node.val % 2 == 0 || (prevVal.HasValue && node.val <= prevVal.Value)) return false;
                }
                else
                {
                    if (node.val % 2 != 0 || (prevVal.HasValue && node.val >= prevVal.Value)) return false;
                }

                prevVal = node.val;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            level++;
        }

        return true;
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