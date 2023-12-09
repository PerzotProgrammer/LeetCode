namespace InorderTraversal;

class Solution
{
    static void Main()
    {
        // Example 1:
        //
        //
        // Input: root = [1,null,2,3]
        // Output: [1,3,2]
        // Example 2:
        //
        // Input: root = []
        // Output: []
        // Example 3:
        //
        // Input: root = [1]
        // Output: [1]

        TreeNode n3a = new(3);
        TreeNode n2a = new(2, n3a);
        TreeNode n1a = new(1, null!, n2a);
        TreeNode n1b = new(1);

        Solution solution = new();

        IList<int> output1 = solution.InorderTraversal(n1a);
        IList<int> output2 = solution.InorderTraversal(n1b);
        
        PrintList(output1);
        PrintList(output2);
    }

    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> res = new();
        Stack<TreeNode> stack = new();

        TreeNode curr = root;

        while (curr != null || stack.Count != 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }

            curr = stack.Pop();
            res.Add(curr.val);
            curr = curr.right;
        }

        return res;
    }

    static void PrintList(IList<int> list)
    {
        foreach (int element in list)
        {
            Console.Write($"{element}, ");
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

    public TreeNode(int val = 0, TreeNode left = null!, TreeNode right = null!)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}