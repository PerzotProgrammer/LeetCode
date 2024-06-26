namespace BalanceBST;

class Solution
{
    static void Main()
    {
        // POMOC LEETCODE: https://leetcode.com/problems/balance-a-binary-search-tree/solutions/5370237/c-solution-for-balance-a-binary-search-tree-problem/?envType=daily-question&envId=2024-06-26

        // Example 1:
        //
        //
        // Input: root = [1,null,2,null,3,null,4,null,null]
        // Output: [2,1,3,null,null,null,4]
        // Explanation: This is not the only correct answer, [3,1,4,null,2] is also correct.
        // Example 2:
        //
        //
        // Input: root = [2,1,3]
        // Output: [2,1,3]

        Solution solution = new();

        TreeNode a4 = new(4, null, null);
        TreeNode a3 = new(3, null, a4);
        TreeNode a2 = new(2, null, a3);
        TreeNode a1 = new(1, null, a2);

        TreeNode b3 = new(3, null, null);
        TreeNode b1 = new(1, null, null);
        TreeNode b2 = new(1, b1, b3);
        
        PrintTreeBfs(solution.BalanceBST(a1));
        PrintTreeBfs(solution.BalanceBST(b2));
    }

    public TreeNode BalanceBST(TreeNode root)
    {
        List<TreeNode> nodeList = new();
        CollectNodes(root, nodeList);
        return BuildBalancedTree(nodeList, 0, nodeList.Count - 1);
    }

    private void CollectNodes(TreeNode node, List<TreeNode> nodeList)
    {
        if (node == null) return;
        CollectNodes(node.left, nodeList);
        nodeList.Add(node);
        CollectNodes(node.right, nodeList);
    }

    private TreeNode BuildBalancedTree(List<TreeNode> nodeList, int start, int end)
    {
        if (start > end) return null!;
        int mid = start + (end - start) / 2;
        TreeNode root = nodeList[mid];
        root.left = BuildBalancedTree(nodeList, start, mid - 1);
        root.right = BuildBalancedTree(nodeList, mid + 1, end);
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