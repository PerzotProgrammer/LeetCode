namespace IsSameTree;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: p = [1,2,3], q = [1,2,3]
        // Output: true

        // Example 2:
        //
        // Input: p = [1,2], q = [1,null,2]
        // Output: false

        // Example 3:
        //
        // Input: p = [1,2,1], q = [1,1,2]
        // Output: false

        Solution solution = new();

        TreeNode a3 = new(3, null, null);
        TreeNode a2 = new(2, null, null);
        TreeNode a1 = new(1, a2, a3);
        TreeNode b3 = new(3, null, null);
        TreeNode b2 = new(2, null, null);
        TreeNode b1 = new(1, b2, b3);

        TreeNode c2 = new(2, null, null);
        TreeNode c1 = new(1, c2, null);
        TreeNode d2 = new(2, null, null);
        TreeNode d1 = new(1, null, d2);

        TreeNode e11 = new(1, null, null);
        TreeNode e2 = new(2, null, null);
        TreeNode e1 = new(1, e2, e11);
        TreeNode f2 = new(2, null, null);
        TreeNode f11 = new(1, null, null);
        TreeNode f1 = new(1, f11, f2);

        Console.WriteLine(solution.IsSameTree(a1, b1));
        Console.WriteLine(solution.IsSameTree(c1, d1));
        Console.WriteLine(solution.IsSameTree(e1, f1));
    }

    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(p);
        queue.Enqueue(q);

        while (queue.Count > 0)
        {
            TreeNode a = queue.Dequeue();
            TreeNode b = queue.Dequeue();

            if (a == null && b == null) continue;
            if (a == null || b == null || a.val != b.val) return false;

            queue.Enqueue(a.left);
            queue.Enqueue(b.left);
            queue.Enqueue(a.right);
            queue.Enqueue(b.right);
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