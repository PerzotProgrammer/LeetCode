namespace PostorderTraversal;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        // Input: root = [1,null,2,3]
        // Output: [3,2,1]

        // Example 2:
        //
        // Input: root = []
        // Output: []

        // Example 3:
        //
        // Input: root = [1]
        // Output: [1]


        Solution solution = new();

        TreeNode a3 = new(3, null, null);
        TreeNode a2 = new(2, a3, null);
        TreeNode a1 = new(1, null, a2);

        TreeNode b1 = new(1, null, null);

        PrintList(solution.PostorderTraversal(a1));
        PrintList(solution.PostorderTraversal(b1));
    }

    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> result = new();
        if (root == null) return result;

        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            result.Insert(0, node.val);

            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }

        return result;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int i in list) Console.Write($"{i}, ");
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