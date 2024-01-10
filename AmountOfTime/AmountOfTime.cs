namespace AmountOfTime;

class Solution
{
    static void Main()
    {
        // Zrobiono z pomocą editorala
        
        // Example 1:
        // Input: root = [1,5,3,null,4,10,6,9,2], start = 3
        // Output: 4
        // Explanation: The following nodes are infected during:
        // - Minute 0: Node 3
        //     - Minute 1: Nodes 1, 10 and 6
        //     - Minute 2: Node 5
        //     - Minute 3: Node 4
        //     - Minute 4: Nodes 9 and 2
        // It takes 4 minutes for the whole tree to be infected so we return 4.
       
        
        // Example 2:
        // Input: root = [1], start = 1
        // Output: 0
        // Explanation: At minute 0, the only node in the tree is infected so we return 0.

        TreeNode a9 = new TreeNode(9, null, null);
        TreeNode a2 = new TreeNode(2, null, null);
        TreeNode a4 = new TreeNode(4, a9, a2);
        TreeNode a5 = new TreeNode(5, null, a4);
        TreeNode a10 = new TreeNode(10, null, null);
        TreeNode a6 = new TreeNode(6, null, null);
        TreeNode a3 = new TreeNode(3, a10, a6);
        TreeNode a1 = new TreeNode(1, a5, a3);

        TreeNode b1 = new TreeNode(1, null, null);
        
        Solution solution = new();

        Console.WriteLine(solution.AmountOfTime(a1, 3));
        Console.WriteLine(solution.AmountOfTime(b1, 1));
    }

    private int maxDistance = 0;

    public int AmountOfTime(TreeNode root, int start)
    {
        Traverse(root, start);
        return maxDistance;
    }

    public int Traverse(TreeNode root, int start)
    {
        int depth = 0;
        if (root == null)
        {
            return depth;
        }

        int leftDepth = Traverse(root.left, start);
        int rightDepth = Traverse(root.right, start);

        if (root.val == start)
        {
            maxDistance = Math.Max(leftDepth, rightDepth);
            depth = -1;
        }
        else if (leftDepth >= 0 && rightDepth >= 0)
        {
            depth = Math.Max(leftDepth, rightDepth) + 1;
        }
        else
        {
            int distance = Math.Abs(leftDepth) + Math.Abs(rightDepth);
            maxDistance = Math.Max(maxDistance, distance);
            depth = Math.Min(leftDepth, rightDepth) - 1;
        }

        return depth;
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