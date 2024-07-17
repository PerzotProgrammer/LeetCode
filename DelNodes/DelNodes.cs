namespace DelNodes;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,2,3,4,5,6,7], to_delete = [3,5]
        // Output: [[1,2,null,4],[6],[7]]

        // Example 2:
        //
        // Input: root = [1,2,4,null,3], to_delete = [3]
        // Output: [[1,2,4]]

        TreeNode a7 = new(7, null, null);
        TreeNode a6 = new(6, null, null);
        TreeNode a3 = new(3, a6, a7);
        TreeNode a5 = new(5, null, null);
        TreeNode a4 = new(4, null, null);
        TreeNode a2 = new(2, a4, a5);
        TreeNode a1 = new(1, a2, a3);

        TreeNode b4 = new(4, null, null);
        TreeNode b3 = new(3, null, null);
        TreeNode b2 = new(2, null, b3);
        TreeNode b1 = new(1, b2, b4);


        Solution solution = new();

        PrintListedNodes(solution.DelNodes(a1, [3, 5]));
        PrintListedNodes(solution.DelNodes(b1, [3]));
    }

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
    {
        if (!to_delete.Any() || root == null) return new List<TreeNode>();


        List<TreeNode> result = new();

        HashSet<int> toDeleteSet = new(to_delete);

        if (!toDeleteSet.Contains(root.val))
        {
            result.Add(root);
            toDeleteSet.Remove(root.val);
        }

        Stack<(TreeNode, TreeNode)> stack = new();
        stack.Push((null, root)!);
        while (stack.Any() && toDeleteSet.Any())
        {
            var (parent, current) = stack.Pop();
            if (toDeleteSet.Contains(current.val))
            {
                toDeleteSet.Remove(current.val);
                if (parent != null)
                {
                    if (parent.left == current) parent.left = null;
                    else parent.right = null;
                }

                if (current.left != null && !toDeleteSet.Contains(current.left.val)) result.Add(current.left);
                if (current.right != null && !toDeleteSet.Contains(current.right.val)) result.Add(current.right);
            }

            if (current.left != null) stack.Push((current, current.left));
            if (current.right != null) stack.Push((current, current.right));
        }

        return result;
    }

    static void PrintListedNodes(IList<TreeNode> listOfNodes)
    {
        foreach (TreeNode node in listOfNodes) Console.Write($"{node.val}, ");
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