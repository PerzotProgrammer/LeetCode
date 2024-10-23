namespace ReplaceValueInTree;

class Solution
{
    static void Main(string[] args)
    {
        // Example 1:
        //
        // Input: root = [5,4,9,1,10,null,7]
        // Output: [0,0,0,7,7,null,11]
        // Explanation: The diagram above shows the initial binary tree and the binary tree after changing the value of each node.
        // - Node with value 5 does not have any cousins so its sum is 0.
        // - Node with value 4 does not have any cousins so its sum is 0.
        // - Node with value 9 does not have any cousins so its sum is 0.
        // - Node with value 1 has a cousin with value 7 so its sum is 7.
        // - Node with value 10 has a cousin with value 7 so its sum is 7.
        // - Node with value 7 has cousins with values 1 and 10 so its sum is 11.

        // Example 2:
        //
        // Input: root = [3,1,2]
        // Output: [0,0,0]
        // Explanation: The diagram above shows the initial binary tree and the binary tree after changing the value of each node.
        // - Node with value 3 does not have any cousins so its sum is 0.
        // - Node with value 1 does not have any cousins so its sum is 0.
        // - Node with value 2 does not have any cousins so its sum is 0.

        Solution solution = new();

        TreeNode a7 = new(7, null, null);
        TreeNode a10 = new(10, null, null);
        TreeNode a1 = new(1, null, null);
        TreeNode a9 = new(9, null, a7);
        TreeNode a4 = new(4, a1, a10);
        TreeNode a5 = new(5, a4, a9);

        TreeNode b1 = new(1, null, null);
        TreeNode b2 = new(2, null, null);
        TreeNode b3 = new(3, b1, b2);

        a5 = solution.ReplaceValueInTree(a5);
        b3 = solution.ReplaceValueInTree(b3);
        PrintTree(a5);
        Console.WriteLine();
        PrintTree(b3);
        Console.WriteLine();
    }

    private int[] LevelSums = new int[100000];

    public TreeNode ReplaceValueInTree(TreeNode root)
    {
        CalculateLevelSum(root, 0);
        ReplaceValueInTreeInternal(root, 0, 0);
        return root;
    }

    private void CalculateLevelSum(TreeNode node, int level)
    {
        if (node == null) return;

        LevelSums[level] += node.val;
        CalculateLevelSum(node.left, level + 1);
        CalculateLevelSum(node.right, level + 1);
    }

    private void ReplaceValueInTreeInternal(TreeNode node, int siblingSum, int level)
    {
        if (node == null) return;

        int leftChildVal = node.left?.val ?? 0;
        int rightChildVal = node.right?.val ?? 0;

        if (level == 0 || level == 1)
        {
            node.val = 0;
        }
        else
        {
            node.val = LevelSums[level] - node.val - siblingSum;
        }

        ReplaceValueInTreeInternal(node.left!, rightChildVal, level + 1);
        ReplaceValueInTreeInternal(node.right!, leftChildVal, level + 1);
    }

    static void PrintTree(TreeNode node)
    {
        if (node == null) return;

        Console.Write($"{node.val}, ");
        PrintTree(node.left);
        PrintTree(node.right);
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